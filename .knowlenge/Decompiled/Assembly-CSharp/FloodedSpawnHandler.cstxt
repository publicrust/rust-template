using System;
using UnityEngine;

public static class FloodedSpawnHandler
{
	private static readonly int[] SpreadSteps = new int[7] { 0, 1, -1, 2, -2, 3, -3 };

	public static bool GetSpawnPoint(BasePlayer.SpawnPoint spawnPoint, float searchHeight)
	{
		SpawnHandler instance = SingletonComponent<SpawnHandler>.Instance;
		if (TerrainMeta.HeightMap == null || instance == null)
		{
			return false;
		}
		LayerMask placementMask = instance.PlacementMask;
		LayerMask placementCheckMask = instance.PlacementCheckMask;
		float placementCheckHeight = instance.PlacementCheckHeight;
		LayerMask radiusCheckMask = instance.RadiusCheckMask;
		float radiusCheckDistance = instance.RadiusCheckDistance;
		for (int i = 0; i < 10; i++)
		{
			Vector3 vector = FindSpawnPoint(searchHeight);
			if ((int)placementCheckMask != 0 && Physics.Raycast(vector + Vector3.up * placementCheckHeight, Vector3.down, out var hitInfo, placementCheckHeight, placementCheckMask))
			{
				if (((1 << hitInfo.transform.gameObject.layer) & (int)placementMask) == 0)
				{
					continue;
				}
				vector.y = hitInfo.point.y;
			}
			if ((int)radiusCheckMask == 0 || !Physics.CheckSphere(vector, radiusCheckDistance, radiusCheckMask))
			{
				spawnPoint.pos = vector;
				spawnPoint.rot = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
				return true;
			}
		}
		return false;
	}

	private static Vector3 FindSpawnPoint(float searchHeight)
	{
		Vector3 vector = (TerrainMeta.Size / 2f).WithY(0f);
		float magnitude = vector.magnitude;
		float distance = magnitude / 50f;
		float num = RandomAngle();
		float num2 = num + MathF.PI;
		Vector3 vector2 = TerrainMeta.Position + vector + Step(num, magnitude);
		for (int i = 0; i < 50; i++)
		{
			float num3 = float.MinValue;
			Vector3 v = Vector3.zero;
			float num4 = 0f;
			int[] spreadSteps = SpreadSteps;
			foreach (int num5 in spreadSteps)
			{
				float num6 = num2 + (float)num5 * 0.17453292f;
				Vector3 vector3 = vector2 + Step(num6, distance);
				float height = TerrainMeta.HeightMap.GetHeight(vector3);
				if (height > num3)
				{
					num3 = height;
					v = vector3;
					num4 = num6;
				}
			}
			vector2 = v.WithY(num3);
			num2 = (num2 + num4) / 2f;
			if (num3 >= searchHeight)
			{
				break;
			}
		}
		return vector2;
	}

	private static Vector3 Step(float angle, float distance)
	{
		return new Vector3(distance * Mathf.Cos(angle), 0f, distance * (0f - Mathf.Sin(angle)));
	}

	private static float RandomAngle()
	{
		return UnityEngine.Random.value * (MathF.PI * 2f);
	}
}
