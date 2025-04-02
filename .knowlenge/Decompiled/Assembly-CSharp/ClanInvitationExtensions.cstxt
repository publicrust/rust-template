using System.Collections.Generic;
using Facepunch;
using ProtoBuf;

public static class ClanInvitationExtensions
{
	public static ClanInvitations ToProto(this List<ClanInvitation> invitations)
	{
		List<ClanInvitations.Invitation> list = Pool.Get<List<ClanInvitations.Invitation>>();
		foreach (ClanInvitation invitation in invitations)
		{
			list.Add(ToProto(invitation));
		}
		ClanInvitations clanInvitations = Pool.Get<ClanInvitations>();
		clanInvitations.invitations = list;
		return clanInvitations;
	}

	public static ClanInvitations.Invitation ToProto(this ClanInvitation invitation)
	{
		ClanInvitations.Invitation invitation2 = Pool.Get<ClanInvitations.Invitation>();
		invitation2.clanId = invitation.ClanId;
		invitation2.recruiter = invitation.Recruiter;
		invitation2.timestamp = invitation.Timestamp;
		return invitation2;
	}
}
