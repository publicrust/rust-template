using System;
using System.Collections.Generic;
using UnityEngine;

public class RHIBAIController : FacepunchBehaviour
{
	public List<Vector3> nodes = new List<Vector3>();

	[ContextMenu("Calculate Path")]
	public void SetupPatrolPath()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		float x = TerrainMeta.Size.x;
		float num = x * 2f * MathF.PI;
		float num2 = 30f;
		int num3 = Mathf.CeilToInt(num / num2);
		nodes = new List<Vector3>();
		float num4 = x;
		float num5 = 0f;
		for (int i = 0; i < num3; i++)
		{
			float num6 = (float)i / (float)num3 * 360f;
			nodes.Add(new Vector3(Mathf.Sin(num6 * (MathF.PI / 180f)) * num4, num5, Mathf.Cos(num6 * (MathF.PI / 180f)) * num4));
		}
		float num7 = 2f;
		float num8 = 200f;
		float num9 = 150f;
		float num10 = 8f;
		bool flag = true;
		int num11 = 1;
		float num12 = 20f;
		Vector3[] array = (Vector3[])(object)new Vector3[5]
		{
			new Vector3(0f, 0f, 0f),
			new Vector3(num12, 0f, 0f),
			new Vector3(0f - num12, 0f, 0f),
			new Vector3(0f, 0f, num12),
			new Vector3(0f, 0f, 0f - num12)
		};
		RaycastHit val9 = default(RaycastHit);
		while (flag)
		{
			Debug.Log((object)("Loop # :" + num11));
			num11++;
			flag = false;
			for (int j = 0; j < num3; j++)
			{
				Vector3 val = nodes[j];
				int index = ((j == 0) ? (num3 - 1) : (j - 1));
				int index2 = ((j != num3 - 1) ? (j + 1) : 0);
				Vector3 val2 = nodes[index2];
				Vector3 val3 = nodes[index];
				Vector3 val4 = val;
				Vector3 val5 = Vector3.zero - val;
				Vector3 normalized = ((Vector3)(ref val5)).normalized;
				Vector3 val6 = val + normalized * num7;
				if (Vector3.Distance(val6, val2) > num8 || Vector3.Distance(val6, val3) > num8)
				{
					continue;
				}
				bool flag2 = true;
				for (int k = 0; k < array.Length; k++)
				{
					Vector3 val7 = val6 + array[k];
					if (GetWaterDepth(val7) < num10)
					{
						flag2 = false;
					}
					Vector3 val8 = normalized;
					if (val7 != Vector3.zero)
					{
						val5 = val7 - val4;
						val8 = ((Vector3)(ref val5)).normalized;
					}
					if (Physics.Raycast(val4, val8, ref val9, num9, 1218511105))
					{
						flag2 = false;
					}
				}
				if (flag2)
				{
					flag = true;
					nodes[j] = val6;
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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		RaycastHit val = default(RaycastHit);
		if (!Physics.Raycast(pos, Vector3.down, ref val, 100f, 8388608))
		{
			return 100f;
		}
		return ((RaycastHit)(ref val)).distance;
	}

	public void OnDrawGizmosSelected()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		if (TerrainMeta.Path.OceanPatrolClose != null)
		{
			for (int i = 0; i < TerrainMeta.Path.OceanPatrolClose.Count; i++)
			{
				Vector3 val = TerrainMeta.Path.OceanPatrolClose[i];
				Gizmos.color = Color.green;
				Gizmos.DrawSphere(val, 3f);
				Vector3 val2 = ((i + 1 == TerrainMeta.Path.OceanPatrolClose.Count) ? TerrainMeta.Path.OceanPatrolClose[0] : TerrainMeta.Path.OceanPatrolClose[i + 1]);
				Gizmos.DrawLine(val, val2);
			}
		}
	}
}
