using System;
using UnityEngine;

public static class FloodedSpawnHandler
{
	private static readonly int[] SpreadSteps = new int[7] { 0, 1, -1, 2, -2, 3, -3 };

	public static bool GetSpawnPoint(BasePlayer.SpawnPoint spawnPoint, float searchHeight)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		SpawnHandler instance = SingletonComponent<SpawnHandler>.Instance;
		if ((Object)(object)TerrainMeta.HeightMap == (Object)null || (Object)(object)instance == (Object)null)
		{
			return false;
		}
		LayerMask placementMask = instance.PlacementMask;
		LayerMask placementCheckMask = instance.PlacementCheckMask;
		float placementCheckHeight = instance.PlacementCheckHeight;
		LayerMask radiusCheckMask = instance.RadiusCheckMask;
		float radiusCheckDistance = instance.RadiusCheckDistance;
		RaycastHit val2 = default(RaycastHit);
		for (int i = 0; i < 10; i++)
		{
			Vector3 val = FindSpawnPoint(searchHeight);
			if (LayerMask.op_Implicit(placementCheckMask) != 0 && Physics.Raycast(val + Vector3.up * placementCheckHeight, Vector3.down, ref val2, placementCheckHeight, LayerMask.op_Implicit(placementCheckMask)))
			{
				if (((1 << ((Component)((RaycastHit)(ref val2)).transform).gameObject.layer) & LayerMask.op_Implicit(placementMask)) == 0)
				{
					continue;
				}
				val.y = ((RaycastHit)(ref val2)).point.y;
			}
			if (LayerMask.op_Implicit(radiusCheckMask) == 0 || !Physics.CheckSphere(val, radiusCheckDistance, LayerMask.op_Implicit(radiusCheckMask)))
			{
				spawnPoint.pos = val;
				spawnPoint.rot = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
				return true;
			}
		}
		return false;
	}

	private static Vector3 FindSpawnPoint(float searchHeight)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = Vector3Ex.WithY(TerrainMeta.Size / 2f, 0f);
		float magnitude = ((Vector3)(ref val)).magnitude;
		float distance = magnitude / 50f;
		float num = RandomAngle();
		float num2 = num + MathF.PI;
		Vector3 val2 = TerrainMeta.Position + val + Step(num, magnitude);
		for (int i = 0; i < 50; i++)
		{
			float num3 = float.MinValue;
			Vector3 val3 = Vector3.zero;
			float num4 = 0f;
			int[] spreadSteps = SpreadSteps;
			foreach (int num5 in spreadSteps)
			{
				float num6 = num2 + (float)num5 * 0.17453292f;
				Vector3 val4 = val2 + Step(num6, distance);
				float height = TerrainMeta.HeightMap.GetHeight(val4);
				if (height > num3)
				{
					num3 = height;
					val3 = val4;
					num4 = num6;
				}
			}
			val2 = Vector3Ex.WithY(val3, num3);
			num2 = (num2 + num4) / 2f;
			if (num3 >= searchHeight)
			{
				break;
			}
		}
		return val2;
	}

	private static Vector3 Step(float angle, float distance)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		return new Vector3(distance * Mathf.Cos(angle), 0f, distance * (0f - Mathf.Sin(angle)));
	}

	private static float RandomAngle()
	{
		return Random.value * (MathF.PI * 2f);
	}
}
