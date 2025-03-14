using System.Collections.Generic;
using Facepunch;
using ProtoBuf;
using UnityEngine;

public static class ClanInfoExtensions
{
	public static ClanInfo ToProto(this IClan clan)
	{
		if (clan == null)
		{
			return null;
		}
		ClanInfo clanInfo = Pool.Get<ClanInfo>();
		clanInfo.clanId = clan.ClanId;
		clanInfo.name = clan.Name;
		clanInfo.created = clan.Created;
		clanInfo.creator = clan.Creator;
		clanInfo.motd = clan.Motd;
		clanInfo.motdTimestamp = clan.MotdTimestamp;
		clanInfo.motdAuthor = clan.MotdAuthor;
		clanInfo.logo = clan.Logo;
		clanInfo.color = clan.Color.ToInt32();
		clanInfo.maxMemberCount = clan.MaxMemberCount;
		clanInfo.score = clan.Score;
		clanInfo.roles = Pool.Get<List<ClanInfo.Role>>();
		foreach (ClanRole role in clan.Roles)
		{
			clanInfo.roles.Add(role.ToProto());
		}
		clanInfo.members = Pool.Get<List<ClanInfo.Member>>();
		foreach (ClanMember member in clan.Members)
		{
			clanInfo.members.Add(member.ToProto());
		}
		clanInfo.invites = Pool.Get<List<ClanInfo.Invite>>();
		foreach (ClanInvite invite in clan.Invites)
		{
			clanInfo.invites.Add(invite.ToProto());
		}
		return clanInfo;
	}

	private static ClanInfo.Role ToProto(this ClanRole role)
	{
		bool flag = role.Rank == 1;
		ClanInfo.Role role2 = Pool.Get<ClanInfo.Role>();
		role2.roleId = role.RoleId;
		role2.rank = role.Rank;
		role2.name = role.Name;
		role2.canSetMotd = flag || role.CanSetMotd;
		role2.canSetLogo = flag || role.CanSetLogo;
		role2.canInvite = flag || role.CanInvite;
		role2.canKick = flag || role.CanKick;
		role2.canPromote = flag || role.CanPromote;
		role2.canDemote = flag || role.CanDemote;
		role2.canSetPlayerNotes = flag || role.CanSetPlayerNotes;
		role2.canAccessLogs = flag || role.CanAccessLogs;
		role2.canAccessScoreEvents = flag || role.CanAccessScoreEvents;
		return role2;
	}

	public static ClanRole FromProto(this ClanInfo.Role proto)
	{
		ClanRole result = default(ClanRole);
		result.RoleId = proto.roleId;
		result.Rank = proto.rank;
		result.Name = proto.name;
		result.CanSetMotd = proto.canSetMotd;
		result.CanSetLogo = proto.canSetLogo;
		result.CanInvite = proto.canInvite;
		result.CanKick = proto.canKick;
		result.CanPromote = proto.canPromote;
		result.CanDemote = proto.canDemote;
		result.CanSetPlayerNotes = proto.canSetPlayerNotes;
		result.CanAccessLogs = proto.canAccessLogs;
		result.CanAccessScoreEvents = proto.canAccessScoreEvents;
		return result;
	}

	private static ClanInfo.Member ToProto(this ClanMember member)
	{
		ClanInfo.Member member2 = Pool.Get<ClanInfo.Member>();
		member2.steamId = member.SteamId;
		member2.roleId = member.RoleId;
		member2.joined = member.Joined;
		member2.lastSeen = member.LastSeen;
		member2.notes = member.Notes;
		member2.online = (NexusServer.Started ? NexusServer.IsOnline(member.SteamId) : ServerPlayers.IsOnline(member.SteamId));
		return member2;
	}

	private static ClanInfo.Invite ToProto(this ClanInvite invite)
	{
		ClanInfo.Invite invite2 = Pool.Get<ClanInfo.Invite>();
		invite2.steamId = invite.SteamId;
		invite2.recruiter = invite.Recruiter;
		invite2.timestamp = invite.Timestamp;
		return invite2;
	}
}
