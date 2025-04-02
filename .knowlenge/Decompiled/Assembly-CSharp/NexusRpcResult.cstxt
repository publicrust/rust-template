using System;
using System.Collections.Generic;
using Facepunch;
using ProtoBuf.Nexus;

public class NexusRpcResult : IDisposable, IPooled
{
	public readonly Dictionary<string, Response> Responses;

	public NexusRpcResult()
	{
		Responses = new Dictionary<string, Response>(StringComparer.InvariantCultureIgnoreCase);
	}

	public void Dispose()
	{
		NexusRpcResult nexusRpcResult = this;
		Pool.Free<NexusRpcResult>(ref nexusRpcResult);
	}

	public void EnterPool()
	{
		foreach (KeyValuePair<string, Response> response in Responses)
		{
			response.Value.Dispose();
		}
		Responses.Clear();
	}

	public void LeavePool()
	{
	}
}
