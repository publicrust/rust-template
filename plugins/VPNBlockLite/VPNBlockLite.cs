using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Oxide.Core.Libraries;
using Oxide.Core.Libraries.Covalence;

namespace Oxide.Plugins
{
    [Info("VpnBlockLite", "fakerplayers", "1.0.0")]
    [Description(
        "Blocks players using VPN/Proxy services. Detects country, city and ISP information. Lite version."
    )]
    public class VpnBlockLite : RustPlugin
    {
        #region Configuration and Settings
        private ConfigData configData = null!;

        private sealed class ConfigData
        {
            [JsonProperty("Сохранять информацию в логи")]
            public bool SaveToLogs = true;

            [JsonProperty("Показывать IP адрес")]
            public bool ShowIP = true;

            [JsonProperty("Показывать страну")]
            public bool ShowCountry = true;

            [JsonProperty("Показывать город")]
            public bool ShowCity = true;

            [JsonProperty("Показывать провайдера")]
            public bool ShowISP = true;

            [JsonProperty("Кикать игроков с VPN/Proxy")]
            public bool KickVPNUsers = true;

            [JsonProperty("Сообщение при кике за VPN/Proxy")]
            public string VPNKickMessage = "VPN/Proxy соединения запрещены.";
        }

        protected override void LoadDefaultConfig()
        {
            configData = new ConfigData();
            SaveConfig();
        }

        protected override void LoadConfig()
        {
            base.LoadConfig();
            try
            {
                configData = Config.ReadObject<ConfigData>();
                if (configData == null)
                {
                    LoadDefaultConfig();
                }
            }
            catch
            {
                PrintError("[Configuration] Error reading config file!");
                LogToFile("errors", "Ошибка чтения конфигурации! Создаю новую...", this);
                LoadDefaultConfig();
            }
            SaveConfig();
        }

        protected override void SaveConfig()
        {
            Config.WriteObject(configData);
        }
        #endregion Configuration and Settings

        private readonly HashSet<string> knownVPNProviders = new(StringComparer.OrdinalIgnoreCase)
        {
            "EDIS GmbH",
            "M247",
            "OVH",
            "Digital Ocean",
            "Amazon",
            "Linode",
            "Vultr",
            "Hetzner",
            "Google Cloud",
            "Microsoft Azure",
            "NordVPN",
            "ExpressVPN",
            "CloudFlare",
        };

        private bool IsVPNOrProxy(string isp)
        {
            if (
                knownVPNProviders.Any(provider =>
                    isp.Contains(provider, StringComparison.OrdinalIgnoreCase)
                )
            )
            {
                return true;
            }

            string ispLower = isp.ToLower(CultureInfo.InvariantCulture);
            string[] keywords = new[]
            {
                "hosting",
                "datacenter",
                "data center",
                "cloud",
                "server",
                "vps",
                "vpn",
                "proxy",
            };

            return keywords.Any(ispLower.Contains);
        }

        private void OnUserConnected(IPlayer player)
        {
            if (player == null)
            {
                return;
            }

            webrequest.Enqueue(
                $"http://ip-api.com/json/{player.Address}",
                null,
                (code, response) =>
                {
                    if (code != 200 || string.IsNullOrEmpty(response))
                    {
                        PrintError(
                            $"Ошибка получения информации об IP для {player.Name}: HTTP {code}"
                        );
                        return;
                    }

                    try
                    {
                        Dictionary<string, string> ipInfo = JsonConvert.DeserializeObject<
                            Dictionary<string, string>
                        >(response)!;
                        bool isProxy = IsVPNOrProxy(ipInfo["isp"]);

                        string message =
                            $"Игрок: {player.Name}\n"
                            + (configData.ShowIP ? $"IP: {ipInfo["query"]}\n" : "")
                            + (configData.ShowCountry ? $"Страна: {ipInfo["country"]}\n" : "")
                            + (configData.ShowCity ? $"Город: {ipInfo["city"]}\n" : "")
                            + (configData.ShowISP ? $"Провайдер: {ipInfo["isp"]}\n" : "")
                            + $"VPN/Proxy: {(isProxy ? "Да" : "Нет")}";

                        if (configData.SaveToLogs)
                        {
                            LogToFile("ip_info", $"{DateTime.Now} - {message}", this);
                        }

                        if (isProxy && configData.KickVPNUsers)
                        {
                            _ = timer.Once(0.5f, () => player.Kick(configData.VPNKickMessage));
                        }

                        LogToFile("info", "Логи недоступны в лайт версии", this);
                    }
                    catch (Exception ex)
                    {
                        PrintError(
                            $"Ошибка обработки информации об IP для {player.Name}: {ex.Message}"
                        );
                    }
                },
                this,
                RequestMethod.GET
            );
        }
    }
}
