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
		List<Vector3> obj = Pool.Get<List<Vector3>>();
		(float, float) waterAndTerrainSurface = WaterLevel.GetWaterAndTerrainSurface(navigator.transform.position, waves: false, volumes: false);
		float item = waterAndTerrainSurface.Item1;
		float item2 = waterAndTerrainSurface.Item2;
		for (int i = 0; i < 8; i++)
		{
			Vector3 pointOnCircle = BasePathFinder.GetPointOnCircle(fallbackPos, Random.Range(1f, navigator.MaxRoamDistanceFromHome), Random.Range(0f, 359f));
			pointOnCircle.y += Random.Range(-2f, 2f);
			pointOnCircle.y = Mathf.Clamp(pointOnCircle.y, item2, item);
			obj.Add(pointOnCircle);
		}
		float num = -1f;
		int num2 = -1;
		for (int j = 0; j < obj.Count; j++)
		{
			Vector3 vector = obj[j];
			if (npc.IsVisible(vector))
			{
				float num3 = 0f;
				Vector3 rhs = Vector3Ex.Direction2D(vector, navigator.transform.position);
				float value = Vector3.Dot(navigator.transform.forward, rhs);
				num3 += Mathf.InverseLerp(0.25f, 0.8f, value) * 5f;
				float value2 = Mathf.Abs(vector.y - navigator.transform.position.y);
				num3 += 1f - Mathf.InverseLerp(1f, 3f, value2) * 5f;
				if (num3 > num || num2 == -1)
				{
					num = num3;
					num2 = j;
				}
			}
		}
		Vector3 result = obj[num2];
		Pool.FreeUnmanaged(ref obj);
		return result;
	}

	public override bool GetBestFleePosition(BaseNavigator navigator, AIBrainSenses senses, BaseEntity fleeFrom, Vector3 fallbackPos, float minRange, float maxRange, out Vector3 result)
	{
		if (fleeFrom == null)
		{
			result = navigator.transform.position;
			return false;
		}
		Vector3 vector = Vector3Ex.Direction2D(navigator.transform.position, fleeFrom.transform.position);
		result = navigator.transform.position + vector * Random.Range(minRange, maxRange);
		return true;
	}
}
