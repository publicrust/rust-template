using System.Collections.Generic;
using Facepunch;
using ProtoBuf;

public static class ClanLogExtensions
{
	public static ClanLog ToProto(this ClanLogs clanLogs)
	{
		List<ClanLog.Entry> list = Pool.Get<List<ClanLog.Entry>>();
		foreach (ClanLogEntry entry2 in clanLogs.Entries)
		{
			ClanLog.Entry entry = Pool.Get<ClanLog.Entry>();
			entry.timestamp = entry2.Timestamp;
			entry.eventKey = entry2.EventKey;
			entry.arg1 = entry2.Arg1;
			entry.arg2 = entry2.Arg2;
			entry.arg3 = entry2.Arg3;
			entry.arg4 = entry2.Arg4;
			list.Add(entry);
		}
		ClanLog clanLog = Pool.Get<ClanLog>();
		clanLog.clanId = clanLogs.ClanId;
		clanLog.logEntries = list;
		return clanLog;
	}

	public static ProtoBuf.ClanScoreEvents ToProto(this ClanScoreEvents clanScoreEvents)
	{
		List<ProtoBuf.ClanScoreEvents.Entry> list = Pool.Get<List<ProtoBuf.ClanScoreEvents.Entry>>();
		foreach (ClanScoreEvent scoreEvent in clanScoreEvents.ScoreEvents)
		{
			ProtoBuf.ClanScoreEvents.Entry entry = Pool.Get<ProtoBuf.ClanScoreEvents.Entry>();
			entry.timestamp = scoreEvent.Timestamp;
			entry.type = (int)scoreEvent.Type;
			entry.score = scoreEvent.Score;
			entry.multiplier = scoreEvent.Multiplier;
			entry.steamId = scoreEvent.SteamId.GetValueOrDefault();
			entry.otherSteamId = scoreEvent.OtherSteamId.GetValueOrDefault();
			entry.otherClanId = scoreEvent.OtherClanId.GetValueOrDefault();
			entry.arg1 = scoreEvent.Arg1;
			entry.arg2 = scoreEvent.Arg2;
			list.Add(entry);
		}
		ProtoBuf.ClanScoreEvents clanScoreEvents2 = Pool.Get<ProtoBuf.ClanScoreEvents>();
		clanScoreEvents2.clanId = clanScoreEvents.ClanId;
		clanScoreEvents2.scoreEvents = list;
		return clanScoreEvents2;
	}
}
