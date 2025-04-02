using System.Collections.Generic;
using System.Threading.Tasks;
using Steamworks.Data;

public static class ServerInfoExtensions
{
	public static async Task<Dictionary<string, string>> QueryRulesAsync(this ServerInfo server)
	{
		return await new Steamworks.Data.ServerInfo(server.AddressRaw, (ushort)server.ConnectionPort, (ushort)server.QueryPort, 0u).QueryRulesAsync();
	}
}
