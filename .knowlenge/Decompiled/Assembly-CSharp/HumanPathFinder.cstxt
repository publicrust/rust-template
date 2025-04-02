using UnityEngine;

public class HumanPathFinder : BasePathFinder
{
	private BaseEntity npc;

	public void Init(BaseEntity npc)
	{
		this.npc = npc;
	}

	public override AIMovePoint GetBestRoamPoint(Vector3 anchorPos, Vector3 currentPos, Vector3 currentDirection, float anchorClampDistance, float lookupMaxRange = 20f)
	{
		AIInformationZone aIInformationZone = null;
		if (npc is HumanNPC humanNPC)
		{
			aIInformationZone = ((!(humanNPC.VirtualInfoZone != null)) ? humanNPC.GetInformationZone(currentPos) : humanNPC.VirtualInfoZone);
		}
		if (aIInformationZone == null)
		{
			return null;
		}
		return GetBestRoamPoint(aIInformationZone, anchorPos, currentPos, currentDirection, anchorClampDistance, lookupMaxRange);
	}

	private AIMovePoint GetBestRoamPoint(AIInformationZone aiZone, Vector3 anchorPos, Vector3 currentPos, Vector3 currentDirection, float clampDistance, float lookupMaxRange)
	{
		if (aiZone == null)
		{
			return null;
		}
		bool flag = clampDistance > -1f;
		float num = float.NegativeInfinity;
		AIPoint aIPoint = null;
		int pointCount;
		AIPoint[] movePointsInRange = aiZone.GetMovePointsInRange(anchorPos, lookupMaxRange, out pointCount);
		if (movePointsInRange == null || pointCount <= 0)
		{
			return null;
		}
		for (int i = 0; i < pointCount; i++)
		{
			AIPoint aIPoint2 = movePointsInRange[i];
			if (!aIPoint2.transform.parent.gameObject.activeSelf)
			{
				continue;
			}
			float num2 = Mathf.Abs(currentPos.y - aIPoint2.transform.position.y);
			bool flag2 = currentPos.y < WaterSystem.OceanLevel;
			if (!flag2 && ((!flag2 && aIPoint2.transform.position.y < WaterSystem.OceanLevel) || (currentPos.y >= WaterSystem.OceanLevel && num2 > 5f)))
			{
				continue;
			}
			float num3 = 0f;
			float value = Vector3.Dot(currentDirection, Vector3Ex.Direction2D(aIPoint2.transform.position, currentPos));
			num3 += Mathf.InverseLerp(-1f, 1f, value) * 100f;
			if (!aIPoint2.InUse())
			{
				num3 += 1000f;
			}
			num3 += (1f - Mathf.InverseLerp(1f, 10f, num2)) * 100f;
			float num4 = Vector3.Distance(currentPos, aIPoint2.transform.position);
			if (num4 <= 1f)
			{
				num3 -= 3000f;
			}
			if (flag)
			{
				float num5 = Vector3.Distance(anchorPos, aIPoint2.transform.position);
				if (num5 <= clampDistance)
				{
					num3 += 1000f;
					num3 += (1f - Mathf.InverseLerp(0f, clampDistance, num5)) * 200f * Random.Range(0.8f, 1f);
				}
			}
			else if (num4 > 3f)
			{
				num3 += Mathf.InverseLerp(3f, lookupMaxRange, num4) * 50f;
			}
			if (num3 > num)
			{
				aIPoint = aIPoint2;
				num = num3;
			}
		}
		return aIPoint as AIMovePoint;
	}
}
