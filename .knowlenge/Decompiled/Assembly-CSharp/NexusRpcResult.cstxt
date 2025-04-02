using System;
using System.Collections.Generic;
using Facepunch;
using ProtoBuf.Nexus;

public class NexusRpcResult : IDisposable, Pool.IPooled
{
	public readonly Dictionary<string, Response> Responses;

	public NexusRpcResult()
	{
		Responses = new Dictionary<string, Response>(StringComparer.InvariantCultureIgnoreCase);
	}

	public void Dispose()
	{
		NexusRpcResult obj = this;
		Pool.Free(ref obj);
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
