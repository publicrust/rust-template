using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IClan
{
	long ClanId { get; }

	string Name { get; }

	long Created { get; }

	ulong Creator { get; }

	string Motd { get; }

	long MotdTimestamp { get; }

	ulong MotdAuthor { get; }

	byte[] Logo { get; }

	Color32 Color { get; }

	long Score { get; }

	IReadOnlyList<ClanRole> Roles { get; }

	IReadOnlyList<ClanMember> Members { get; }

	int MaxMemberCount { get; }

	IReadOnlyList<ClanInvite> Invites { get; }

	ValueTask RefreshIfStale();

	ValueTask<ClanValueResult<ClanLogs>> GetLogs(int limit, ulong bySteamId);

	ValueTask<ClanResult> UpdateLastSeen(ulong steamId);

	ValueTask<ClanResult> SetMotd(string newMotd, ulong bySteamId);

	ValueTask<ClanResult> SetLogo(byte[] newLogo, ulong bySteamId);

	ValueTask<ClanResult> SetColor(Color32 newColor, ulong bySteamId);

	ValueTask<ClanResult> Invite(ulong steamId, ulong bySteamId);

	ValueTask<ClanResult> CancelInvite(ulong steamId, ulong bySteamId);

	ValueTask<ClanResult> AcceptInvite(ulong steamId);

	ValueTask<ClanResult> Kick(ulong steamId, ulong bySteamId);

	ValueTask<ClanResult> SetPlayerRole(ulong steamId, int newRoleId, ulong bySteamId);

	ValueTask<ClanResult> SetPlayerNotes(ulong steamId, string notes, ulong bySteamId);

	ValueTask<ClanResult> CreateRole(ClanRole role, ulong bySteamId);

	ValueTask<ClanResult> UpdateRole(ClanRole role, ulong bySteamId);

	ValueTask<ClanResult> SwapRoleRanks(int roleIdA, int roleIdB, ulong bySteamId);

	ValueTask<ClanResult> DeleteRole(int roleId, ulong bySteamId);

	ValueTask<ClanResult> Disband(ulong bySteamId);

	ValueTask<ClanValueResult<ClanScoreEvents>> GetScoreEvents(int limit, ulong bySteamId);

	ValueTask<ClanResult> AddScoreEvent(ClanScoreEvent scoreEvent);

	ValueTask<ClanValueResult<ClanChatScrollback>> GetChatScrollback();

	ValueTask<ClanResult> SendChatMessage(string name, string message, ulong bySteamId);
}
