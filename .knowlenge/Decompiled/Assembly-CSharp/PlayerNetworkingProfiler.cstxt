using System;
using ConVar;
using Facepunch.Network.Raknet;
using Facepunch.Rust;
using Network;

public static class PlayerNetworkingProfiler
{
	public static int level = 0;

	public static TimeSpan MinFlushInterval = TimeSpan.FromSeconds(1.0);

	public static int ConnectionsPerFrame = 30;

	private static int currentIndex;

	private static DateTime flushCooldown;

	public static void Serialize(AzureAnalyticsUploader uploader, int frameIndex, DateTime timestamp)
	{
		if (level == 0)
		{
			return;
		}
		if (currentIndex >= Network.Net.sv.connections.Count)
		{
			if (flushCooldown > DateTime.UtcNow)
			{
				return;
			}
			flushCooldown = DateTime.UtcNow + MinFlushInterval;
			currentIndex = 0;
		}
		if (Network.Net.sv is Facepunch.Network.Raknet.Server server)
		{
			SerializeRaknet(uploader, frameIndex, timestamp, server);
		}
	}

	private unsafe static void SerializeRaknet(AzureAnalyticsUploader uploader, int frameIndex, DateTime timestamp, Facepunch.Network.Raknet.Server server)
	{
		int num = Math.Min(server.connections.Count, currentIndex + ConnectionsPerFrame);
		while (currentIndex < num)
		{
			Connection connection = server.connections[currentIndex];
			if (server.TryGetConnectionStats(connection, out var stats))
			{
				string ipaddress = connection.ipaddress;
				string value = ipaddress.Split(':')[0];
				string value2 = ipaddress.Split(':')[1];
				int latestPing = server.GetLatestPing(connection);
				EventRecord eventRecord = EventRecord.CSV().AddField("", timestamp).AddField("", frameIndex)
					.AddField("", ConVar.Server.server_id)
					.AddField("", connection.guid)
					.AddField("", connection.userid)
					.AddField("", value)
					.AddField("", value2)
					.AddField("", latestPing)
					.AddField("", stats.connectionStartTime)
					.AddField("", stats.isLimitedByCongestionControl)
					.AddField("", stats.isLimitedByOutgoingBandwidthLimit)
					.AddField("", stats.BPSLimitByCongestionControl)
					.AddField("", stats.BPSLimitByOutgoingBandwidthLimit)
					.AddField("", stats.messagesInResendBuffer)
					.AddField("", stats.bytesInResendBuffer)
					.AddField("", stats.packetlossLastSecond)
					.AddField("", stats.packetlossTotal);
				for (int i = 0; i < 4; i++)
				{
					eventRecord.AddField("", (ulong)stats.bytesInSendBuffer[i]);
				}
				for (int j = 0; j < 4; j++)
				{
					eventRecord.AddField("", (ulong)stats.messageInSendBuffer[j]);
				}
				eventRecord.AddField("", stats.runningTotal[0]);
				eventRecord.AddField("", stats.runningTotal[1]);
				eventRecord.AddField("", stats.runningTotal[2]);
				eventRecord.AddField("", stats.runningTotal[3]);
				eventRecord.AddField("", stats.runningTotal[4]);
				eventRecord.AddField("", stats.runningTotal[5]);
				eventRecord.AddField("", stats.runningTotal[6]);
				uploader.Append(eventRecord);
			}
			currentIndex++;
		}
	}
}
