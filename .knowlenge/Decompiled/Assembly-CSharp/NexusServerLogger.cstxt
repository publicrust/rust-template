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
		if (Nexus.logging)
		{
			switch (level)
			{
			case NexusLogLevel.Error:
				Debug.LogError(message);
				break;
			case NexusLogLevel.Warn:
				Debug.LogWarning(message);
				break;
			default:
				Debug.Log(message);
				break;
			}
			if (exception != null)
			{
				Debug.LogException(exception);
			}
		}
	}
}
