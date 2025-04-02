using System;
using ConVar;
using Facepunch.Nexus.Logging;
using UnityEngine;

public class NexusServerLogger : INexusLogger
{
	public static NexusServerLogger Instance { get; } = new NexusServerLogger();

	private NexusServerLogger()
	{
	}

	public void Log(NexusLogLevel level, string message, Exception exception = null)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		if (!Nexus.logging)
		{
			return;
		}
		if ((int)level != 1)
		{
			if ((int)level == 2)
			{
				Debug.LogError((object)message);
			}
			else
			{
				Debug.Log((object)message);
			}
		}
		else
		{
			Debug.LogWarning((object)message);
		}
		if (exception != null)
		{
			Debug.LogException(exception);
		}
	}
}
