using UnityEngine;

public interface IAIGroupable
{
	bool AddMember(IAIGroupable member);

	void RemoveMember(IAIGroupable member);

	void JoinGroup(IAIGroupable leader, BaseEntity leaderEntity);

	void SetGroupRoamRootPosition(Vector3 rootPos);

	bool InGroup();

	void LeaveGroup();

	void SetUngrouped();
}
