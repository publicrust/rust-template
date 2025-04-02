public interface IClanChangeSink
{
	void ClanChanged(long clanId, ClanDataSource dataSources);

	void ClanDisbanded(long clanId);

	void InvitationCreated(ulong steamId, long clanId);

	void MembershipChanged(ulong steamId, long? clanId);

	void ClanChatMessage(long clanId, ClanChatEntry entry);
}
