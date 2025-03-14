using UnityEngine;

public class AIMovePoint : MonoBehaviour
{
	public float radius = 1f;

	public float nextAvailableRoamTime;

	public float nextAvailableEngagementTime;

	public BaseEntity lastUser;

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		GizmosUtil.DrawWireCircleY(base.transform.position, radius);
	}

	public bool CanBeUsedBy(BaseEntity user)
	{
		if (user != null && lastUser == user)
		{
			return true;
		}
		return IsUsed();
	}

	public bool IsUsed()
	{
		if (!IsUsedForRoaming())
		{
			return IsUsedForEngagement();
		}
		return true;
	}

	public void MarkUsedForRoam(float dur = 10f, BaseEntity user = null)
	{
		nextAvailableRoamTime = Time.time + dur;
		lastUser = user;
	}

	public void MarkUsedForEngagement(float dur = 5f, BaseEntity user = null)
	{
		nextAvailableEngagementTime = Time.time + dur;
		lastUser = user;
	}

	public bool IsUsedForRoaming()
	{
		return Time.time < nextAvailableRoamTime;
	}

	public bool IsUsedForEngagement()
	{
		return Time.time < nextAvailableEngagementTime;
	}
}
