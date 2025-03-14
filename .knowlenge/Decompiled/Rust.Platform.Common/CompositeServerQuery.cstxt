using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public sealed class CompositeServerQuery : IServerQuery, IDisposable
{
	private readonly IServerQuery _queryA;

	private readonly IServerQuery _queryB;

	public IReadOnlyList<ServerInfo> Servers { get; }

	public event Action<ServerInfo> OnServerFound;

	public CompositeServerQuery(IServerQuery queryA, IServerQuery queryB)
	{
		CompositeServerQuery compositeServerQuery = this;
		_queryA = queryA ?? throw new ArgumentNullException("queryA");
		_queryB = queryB ?? throw new ArgumentNullException("queryB");
		List<ServerInfo> serverList = new List<ServerInfo>();
		Servers = serverList;
		HashSet<(uint, int)> foundServers = new HashSet<(uint, int)>();
		Action<ServerInfo> value = delegate(ServerInfo info)
		{
			if (foundServers.Add((info.AddressRaw, info.QueryPort)))
			{
				serverList.Add(info);
				compositeServerQuery.OnServerFound?.Invoke(info);
			}
		};
		_queryA.OnServerFound += value;
		_queryB.OnServerFound += value;
	}

	public void Dispose()
	{
		_queryA.Dispose();
		_queryB.Dispose();
	}

	public void AddFilter(string key, string value)
	{
		_queryA.AddFilter(key, value);
		_queryB.AddFilter(key, value);
	}

	public async Task RunQueryAsync(double timeoutInSeconds)
	{
		await Task.WhenAll(_queryA.RunQueryAsync(timeoutInSeconds), _queryB.RunQueryAsync(timeoutInSeconds));
	}
}
