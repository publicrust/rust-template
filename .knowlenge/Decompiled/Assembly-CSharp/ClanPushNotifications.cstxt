using System.Collections.Generic;
using CompanionServer;
using ConVar;
using Facepunch;

public static class ClanPushNotifications
{
	public static async void SendClanAnnouncement(IClan clan, long previousTimestamp, ulong ignorePlayer)
	{
		if (ClanUtility.Timestamp() - previousTimestamp < 300000)
		{
			return;
		}
		List<ulong> steamIds = Facepunch.Pool.Get<List<ulong>>();
		foreach (ClanMember member in clan.Members)
		{
			if (member.SteamId != ignorePlayer)
			{
				steamIds.Add(member.SteamId);
			}
		}
		Dictionary<string, string> serverPairingData = Util.GetServerPairingData();
		serverPairingData.Add("type", "clan");
		serverPairingData.Add("fromId", ignorePlayer.ToString("G"));
		await NotificationList.SendNotificationTo(steamIds, NotificationChannel.ClanAnnouncement, "[" + clan.Name + "] Announcement was updated", ConVar.Server.hostname, serverPairingData);
		Facepunch.Pool.FreeUnmanaged(ref steamIds);
	}
}
