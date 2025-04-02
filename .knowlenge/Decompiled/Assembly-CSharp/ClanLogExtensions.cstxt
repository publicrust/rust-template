using System.Collections.Generic;
using Facepunch;
using ProtoBuf;

public static class ClanLogExtensions
{
	public static ClanLog ToProto(this ClanLogs clanLogs)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		List<Entry> list = Pool.Get<List<Entry>>();
		foreach (ClanLogEntry entry in clanLogs.Entries)
		{
			Entry val = Pool.Get<Entry>();
			val.timestamp = entry.Timestamp;
			val.eventKey = entry.EventKey;
			val.arg1 = entry.Arg1;
			val.arg2 = entry.Arg2;
			val.arg3 = entry.Arg3;
			val.arg4 = entry.Arg4;
			list.Add(val);
		}
		ClanLog obj = Pool.Get<ClanLog>();
		obj.clanId = clanLogs.ClanId;
		obj.logEntries = list;
		return obj;
	}

	public static ClanScoreEvents ToProto(this ClanScoreEvents clanScoreEvents)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected I4, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		List<Entry> list = Pool.Get<List<Entry>>();
		foreach (ClanScoreEvent scoreEvent in clanScoreEvents.ScoreEvents)
		{
			Entry val = Pool.Get<Entry>();
			val.timestamp = scoreEvent.Timestamp;
			val.type = (int)scoreEvent.Type;
			val.score = scoreEvent.Score;
			val.multiplier = scoreEvent.Multiplier;
			val.steamId = scoreEvent.SteamId.GetValueOrDefault();
			val.otherSteamId = scoreEvent.OtherSteamId.GetValueOrDefault();
			val.otherClanId = scoreEvent.OtherClanId.GetValueOrDefault();
			val.arg1 = scoreEvent.Arg1;
			val.arg2 = scoreEvent.Arg2;
			list.Add(val);
		}
		ClanScoreEvents obj = Pool.Get<ClanScoreEvents>();
		obj.clanId = clanScoreEvents.ClanId;
		obj.scoreEvents = list;
		return obj;
	}
}
