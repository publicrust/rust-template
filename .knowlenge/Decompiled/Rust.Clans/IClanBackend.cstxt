using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IClanBackend : IDisposable
{
	ValueTask Initialize(IClanChangeSink changeSink);

	ValueTask<ClanValueResult<IClan>> Get(long clanId);

	bool TryGet(long clanId, out IClan clan);

	ValueTask<ClanValueResult<IClan>> GetByMember(ulong steamId);

	ValueTask<ClanValueResult<IClan>> Create(ulong leaderSteamId, string name);

	ValueTask<ClanValueResult<List<ClanInvitation>>> ListInvitations(ulong steamId);

	ValueTask<ClanValueResult<List<ClanLeaderboardEntry>>> GetLeaderboard(int limit = 100);
}
