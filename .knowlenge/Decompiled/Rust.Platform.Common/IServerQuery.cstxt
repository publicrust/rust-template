using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IServerQuery : IDisposable
{
	IReadOnlyList<ServerInfo> Servers { get; }

	event Action<ServerInfo> OnServerFound;

	void AddFilter(string key, string value);

	Task RunQueryAsync(double timeoutInSeconds);
}
