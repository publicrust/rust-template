using System;
using System.Collections.Generic;
using Facepunch.Nexus;
using Facepunch.Nexus.Models;
using UnityEngine;

public static class NexusClanUtil
{
	public const string MotdVariable = "motd";

	public const string MotdAuthorVariable = "motd_author";

	public const string LogoVariable = "logo";

	public const string ColorVariable = "color";

	public const string CanSetLogoVariable = "can_set_logo";

	public const string CanSetMotdVariable = "can_set_motd";

	public const string CanSetPlayerNotesVariable = "can_set_player_notes";

	public const string PlayerNoteVariable = "notes";

	public static readonly List<VariableUpdate> DefaultLeaderVariables = new List<VariableUpdate>
	{
		new VariableUpdate("can_set_logo", bool.TrueString, (bool?)null, (bool?)null),
		new VariableUpdate("can_set_motd", bool.TrueString, (bool?)null, (bool?)null),
		new VariableUpdate("can_set_player_notes", bool.TrueString, (bool?)null, (bool?)null)
	};

	private static readonly Memoized<string, ulong> SteamIdToPlayerId = new Memoized<string, ulong>((Func<ulong, string>)((ulong steamId) => steamId.ToString("G")));

	public static string GetPlayerId(ulong steamId)
	{
		return SteamIdToPlayerId.Get(steamId);
	}

	public static string GetPlayerId(ulong? steamId)
	{
		if (!steamId.HasValue)
		{
			return null;
		}
		return SteamIdToPlayerId.Get(steamId.Value);
	}

	public static ulong GetSteamId(string playerId)
	{
		return ulong.Parse(playerId);
	}

	public static ulong? TryGetSteamId(string playerId)
	{
		if (!ulong.TryParse(playerId, out var result))
		{
			return null;
		}
		return result;
	}

	public static void GetMotd(this NexusClan clan, out string motd, out long motdTimestamp, out ulong motdAuthor)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Invalid comparison between Unknown and I4
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		Variable val = default(Variable);
		Variable val2 = default(Variable);
		if (!clan.TryGetVariable("motd", ref val) || !clan.TryGetVariable("motd_author", ref val2) || (int)val.Type != 1 || (int)val2.Type != 1)
		{
			motd = null;
			motdTimestamp = 0L;
			motdAuthor = 0uL;
		}
		else
		{
			motd = val.GetAsString();
			motdTimestamp = val.LastUpdated * 1000;
			motdAuthor = GetSteamId(val2.GetAsString());
		}
	}

	public static void GetBanner(this NexusClan clan, out byte[] logo, out Color32 color)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Variable val = default(Variable);
		logo = ((clan.TryGetVariable("logo", ref val) && (int)val.Type == 0) ? val.GetAsBinary() : null);
		Variable val2 = default(Variable);
		color = ((clan.TryGetVariable("color", ref val2) && (int)val2.Type == 1) ? ColorEx.FromInt32(int.Parse(val2.GetAsString())) : Color32.op_Implicit(Color.white));
	}

	public static ClanRole ToClanRole(this NexusClanRole role)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		bool flag = role.Rank == 1;
		ClanRole result = default(ClanRole);
		result.RoleId = role.RoleId;
		result.Rank = role.Rank;
		result.Name = role.Name;
		result.CanInvite = flag || role.CanInvite;
		result.CanKick = flag || role.CanKick;
		result.CanPromote = flag || role.CanPromote;
		result.CanDemote = flag || role.CanDemote;
		Variable variable = default(Variable);
		result.CanSetLogo = flag || (role.TryGetVariable("can_set_logo", ref variable) && ParseFlag(variable));
		Variable variable2 = default(Variable);
		result.CanSetMotd = flag || (role.TryGetVariable("can_set_motd", ref variable2) && ParseFlag(variable2));
		Variable variable3 = default(Variable);
		result.CanSetPlayerNotes = flag || (role.TryGetVariable("can_set_player_notes", ref variable3) && ParseFlag(variable3));
		result.CanAccessLogs = flag || role.CanAccessLogs;
		result.CanAccessScoreEvents = flag || role.CanAccessScoreEvents;
		return result;
	}

	public static ClanMember ToClanMember(this NexusClanMember member)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		Variable val = default(Variable);
		member.TryGetVariable("notes", ref val);
		ClanMember result = default(ClanMember);
		result.SteamId = GetSteamId(member.PlayerId);
		result.RoleId = member.RoleId;
		result.Joined = member.Joined * 1000;
		result.LastSeen = member.LastSeen * 1000;
		result.Notes = ((val != null) ? val.GetAsString() : null);
		result.NotesTimestamp = ((val != null) ? val.LastUpdated : 0);
		return result;
	}

	public static ClanInvite ToClanInvite(this ClanInvite invite)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		ClanInvite result = default(ClanInvite);
		result.SteamId = GetSteamId(((ClanInvite)(ref invite)).PlayerId);
		result.Recruiter = GetSteamId(((ClanInvite)(ref invite)).RecruiterPlayerId);
		result.Timestamp = ((ClanInvite)(ref invite)).Created * 1000;
		return result;
	}

	public static ClanResult ToClanResult(this NexusClanResultCode result)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected I4, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		return (ClanResult)((int)result switch
		{
			0 => 0, 
			1 => 1, 
			2 => 3, 
			3 => 4, 
			4 => 5, 
			5 => 9, 
			6 => 10, 
			7 => 11, 
			8 => 12, 
			9 => 13, 
			10 => 14, 
			11 => 15, 
			_ => throw new NotSupportedException($"Cannot map NexusClanResultCode {result} to ClanResult"), 
		});
	}

	public static ClanRoleParameters ToRoleParameters(this ClanRole role)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		ClanRoleParameters result = default(ClanRoleParameters);
		((ClanRoleParameters)(ref result)).Name = role.Name;
		((ClanRoleParameters)(ref result)).CanInvite = role.CanInvite;
		((ClanRoleParameters)(ref result)).CanKick = role.CanKick;
		((ClanRoleParameters)(ref result)).CanPromote = role.CanPromote;
		((ClanRoleParameters)(ref result)).CanDemote = role.CanDemote;
		((ClanRoleParameters)(ref result)).CanAccessLogs = role.CanAccessLogs;
		((ClanRoleParameters)(ref result)).CanAccessScoreEvents = role.CanAccessScoreEvents;
		((ClanRoleParameters)(ref result)).Variables = new List<VariableUpdate>(3)
		{
			FlagVariable("can_set_logo", role.CanSetLogo),
			FlagVariable("can_set_motd", role.CanSetMotd),
			FlagVariable("can_set_player_notes", role.CanSetPlayerNotes)
		};
		return result;
	}

	public static VariableUpdate FlagVariable(string key, bool value)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		return new VariableUpdate(key, value ? bool.TrueString : bool.FalseString, (bool?)null, (bool?)null);
	}

	private static bool ParseFlag(Variable variable, bool defaultValue = false)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		if (variable == null || (int)variable.Type != 1 || !bool.TryParse(variable.GetAsString(), out var result))
		{
			return false;
		}
		return result;
	}
}
