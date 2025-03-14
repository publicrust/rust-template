using System;
using System.Collections.Generic;
using UnityEngine;

public class RHIBAIController : FacepunchBehaviour
{
	public List<Vector3> nodes = new List<Vector3>();

	[ContextMenu("Calculate Path")]
	public void SetupPatrolPath()
	{
		float x = TerrainMeta.Size.x;
		float num = x * 2f * MathF.PI;
		float num2 = 30f;
		int num3 = Mathf.CeilToInt(num / num2);
		nodes = new List<Vector3>();
		float num4 = x;
		float y = 0f;
		for (int i = 0; i < num3; i++)
		{
			float num5 = (float)i / (float)num3 * 360f;
			nodes.Add(new Vector3(Mathf.Sin(num5 * (MathF.PI / 180f)) * num4, y, Mathf.Cos(num5 * (MathF.PI / 180f)) * num4));
		}
		float num6 = 2f;
		float num7 = 200f;
		float maxDistance = 150f;
		float num8 = 8f;
		bool flag = true;
		int num9 = 1;
		float num10 = 20f;
		Vector3[] array = new Vector3[5]
		{
			new Vector3(0f, 0f, 0f),
			new Vector3(num10, 0f, 0f),
			new Vector3(0f - num10, 0f, 0f),
			new Vector3(0f, 0f, num10),
			new Vector3(0f, 0f, 0f - num10)
		};
		while (flag)
		{
			Debug.Log("Loop # :" + num9);
			num9++;
			flag = false;
			for (int j = 0; j < num3; j++)
			{
				Vector3 vector = nodes[j];
				int index = ((j == 0) ? (num3 - 1) : (j - 1));
				int index2 = ((j != num3 - 1) ? (j + 1) : 0);
				Vector3 b = nodes[index2];
				Vector3 b2 = nodes[index];
				Vector3 vector2 = vector;
				Vector3 normalized = (Vector3.zero - vector).normalized;
				Vector3 vector3 = vector + normalized * num6;
				if (Vector3.Distance(vector3, b) > num7 || Vector3.Distance(vector3, b2) > num7)
				{
					continue;
				}
				bool flag2 = true;
				for (int k = 0; k < array.Length; k++)
				{
					Vector3 vector4 = vector3 + array[k];
					if (GetWaterDepth(vector4) < num8)
					{
						flag2 = false;
					}
					Vector3 direction = normalized;
					if (vector4 != Vector3.zero)
					{
						direction = (vector4 - vector2).normalized;
					}
					if (Physics.Raycast(vector2, direction, out var _, maxDistance, 1218511105))
					{
						flag2 = false;
					}
				}
				if (flag2)
				{
					flag = true;
					nodes[j] = vector3;
				}
			}
		}
		List<int> list = new List<int>();
		LineUtility.Simplify(nodes, 15f, list);
		List<Vector3> list2 = nodes;
		nodes = new List<Vector3>();
		foreach (int item in list)
		{
			nodes.Add(list2[item]);
		}
	}

	public float GetWaterDepth(Vector3 pos)
	{
		if (!Physics.Raycast(pos, Vector3.down, out var hitInfo, 100f, 8388608))
		{
			return 100f;
		}
		return hitInfo.distance;
	}

	public void OnDrawGizmosSelected()
	{
		if (TerrainMeta.Path.OceanPatrolClose != null)
		{
			for (int i = 0; i < TerrainMeta.Path.OceanPatrolClose.Count; i++)
			{
				Vector3 vector = TerrainMeta.Path.OceanPatrolClose[i];
				Gizmos.color = Color.green;
				Gizmos.DrawSphere(vector, 3f);
				Vector3 to = ((i + 1 == TerrainMeta.Path.OceanPatrolClose.Count) ? TerrainMeta.Path.OceanPatrolClose[0] : TerrainMeta.Path.OceanPatrolClose[i + 1]);
				Gizmos.DrawLine(vector, to);
			}
		}
	}
}
