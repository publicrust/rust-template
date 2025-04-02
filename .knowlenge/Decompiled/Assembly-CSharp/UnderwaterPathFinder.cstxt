using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class UnderwaterPathFinder : BasePathFinder
{
	private BaseEntity npc;

	public void Init(BaseEntity npc)
	{
		this.npc = npc;
	}

	public override Vector3 GetBestRoamPosition(BaseNavigator navigator, Vector3 anchorPos, Vector3 fallbackPos, float minRange, float maxRange)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		List<Vector3> list = Pool.Get<List<Vector3>>();
		(float, float) waterAndTerrainSurface = WaterLevel.GetWaterAndTerrainSurface(((Component)navigator).transform.position, waves: false, volumes: false);
		float item = waterAndTerrainSurface.Item1;
		float item2 = waterAndTerrainSurface.Item2;
		for (int i = 0; i < 8; i++)
		{
			Vector3 pointOnCircle = BasePathFinder.GetPointOnCircle(fallbackPos, Random.Range(1f, navigator.MaxRoamDistanceFromHome), Random.Range(0f, 359f));
			pointOnCircle.y += Random.Range(-2f, 2f);
			pointOnCircle.y = Mathf.Clamp(pointOnCircle.y, item2, item);
			list.Add(pointOnCircle);
		}
		float num = -1f;
		int num2 = -1;
		for (int j = 0; j < list.Count; j++)
		{
			Vector3 val = list[j];
			if (npc.IsVisible(val))
			{
				float num3 = 0f;
				Vector3 val2 = Vector3Ex.Direction2D(val, ((Component)navigator).transform.position);
				float num4 = Vector3.Dot(((Component)navigator).transform.forward, val2);
				num3 += Mathf.InverseLerp(0.25f, 0.8f, num4) * 5f;
				float num5 = Mathf.Abs(val.y - ((Component)navigator).transform.position.y);
				num3 += 1f - Mathf.InverseLerp(1f, 3f, num5) * 5f;
				if (num3 > num || num2 == -1)
				{
					num = num3;
					num2 = j;
				}
			}
		}
		Vector3 result = list[num2];
		Pool.FreeUnmanaged<Vector3>(ref list);
		return result;
	}

	public override bool GetBestFleePosition(BaseNavigator navigator, AIBrainSenses senses, BaseEntity fleeFrom, Vector3 fallbackPos, float minRange, float maxRange, out Vector3 result)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)fleeFrom == (Object)null)
		{
			result = ((Component)navigator).transform.position;
			return false;
		}
		Vector3 val = Vector3Ex.Direction2D(((Component)navigator).transform.position, ((Component)fleeFrom).transform.position);
		result = ((Component)navigator).transform.position + val * Random.Range(minRange, maxRange);
		return true;
	}
}
