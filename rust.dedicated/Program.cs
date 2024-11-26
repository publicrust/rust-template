using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Укажите путь к вашему серверу Rust и исполняемому файлу RustDedicated.exe
        string serverPath = @"C:\RustServer 2.0\rustserver";
        string rustExecutable = "RustDedicated.exe";

        // Аргументы для максимально быстрой загрузки
        string serverArgs = "-batchmode -nographics -nolog " +
                            "+server.port 28015 +server.queryport 28016 +rcon.port 28017 " +
                            "+rcon.ip 0.0.0.0 +server.level \"Empty\" +server.worldsize 1000 " +
                            "+server.seed 1 +server.hostname \"FastLoadServer\" " +
                            "+server.identity \"test_server\" +rcon.password \"password\"";

        // Настройка процесса
        var processStartInfo = new ProcessStartInfo
        {
            FileName = Path.Combine(serverPath, rustExecutable),
            Arguments = serverArgs,
            WorkingDirectory = serverPath,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            RedirectStandardInput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var serverProcess = new Process { StartInfo = processStartInfo };

        // Обработка логов сервера
        serverProcess.OutputDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine($"[SERVER LOG] {e.Data}");

                // Поиск строки с подтверждением RCON
                if (e.Data.Contains("RCON listening on"))
                {
                    Console.WriteLine("[INFO] RCON успешно активирован.");
                }
            }
        };

        serverProcess.ErrorDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine($"[SERVER ERROR] {e.Data}");
            }
        };

        try
        {
            // Запуск процесса
            Console.WriteLine("Starting Rust server...");
            serverProcess.Start();
            serverProcess.BeginOutputReadLine();
            serverProcess.BeginErrorReadLine();

            Console.WriteLine("Rust server is running. Type commands to interact or type 'exit' to stop the server.");

            // Чтение пользовательского ввода для отправки команд серверу
            while (true)
            {
                string? input = Console.ReadLine();
                if (input == null || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Stopping Rust server...");
                    break;
                }

                // Отправляем команду в процесс
                await serverProcess.StandardInput.WriteLineAsync(input);
                await serverProcess.StandardInput.FlushAsync();
            }
        }
        finally
        {
            // Завершаем процесс
            if (!serverProcess.HasExited)
            {
                serverProcess.Kill();
                serverProcess.WaitForExit();
            }

            Console.WriteLine("Rust server stopped.");
        }
    }
}
