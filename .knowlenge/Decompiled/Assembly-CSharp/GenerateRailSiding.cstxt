using System.Collections.Generic;
using UnityEngine;

public class GenerateRailSiding : ProceduralComponent
{
	public const float Width = 4f;

	public const float InnerPadding = 1f;

	public const float OuterPadding = 1f;

	public const float InnerFade = 1f;

	public const float OuterFade = 32f;

	public const float RandomScale = 1f;

	public const float MeshOffset = 0f;

	public const float TerrainOffset = -0.125f;

	private static Quaternion rotRight = Quaternion.Euler(0f, 90f, 0f);

	private static Quaternion rotLeft = Quaternion.Euler(0f, -90f, 0f);

	private const int MaxDepth = 250000;

	private PathList CreateSegment(int number, Vector3[] points)
	{
		return new PathList("Rail " + number, points)
		{
			Spline = true,
			Width = 4f,
			InnerPadding = 1f,
			OuterPadding = 1f,
			InnerFade = 1f,
			OuterFade = 32f,
			RandomScale = 1f,
			MeshOffset = 0f,
			TerrainOffset = -0.125f,
			Topology = 524288,
			Splat = 128,
			Hierarchy = 2
		};
	}

	public override void Process(uint seed)
	{
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		if (World.Networked)
		{
			return;
		}
		int num = Mathf.RoundToInt(40f);
		int num2 = Mathf.RoundToInt(53.333332f);
		int num3 = Mathf.RoundToInt(13.333333f);
		int num4 = Mathf.RoundToInt(20f);
		float num5 = 16f * 16f;
		List<PathList> list = new List<PathList>();
		int[,] array = TerrainPath.CreateRailCostmap(ref seed);
		new PathFinder(array);
		array.GetLength(0);
		List<Vector3> list2 = new List<Vector3>();
		List<Vector3> list3 = new List<Vector3>();
		HashSet<Vector3> hashSet = new HashSet<Vector3>();
		foreach (PathList rail in TerrainMeta.Path.Rails)
		{
			foreach (PathList rail2 in TerrainMeta.Path.Rails)
			{
				if (rail == rail2)
				{
					continue;
				}
				Vector3[] points = rail.Path.Points;
				foreach (Vector3 val in points)
				{
					Vector3[] points2 = rail2.Path.Points;
					foreach (Vector3 val2 in points2)
					{
						Vector3 val3 = val - val2;
						if (((Vector3)(ref val3)).sqrMagnitude < num5)
						{
							hashSet.Add(val);
							break;
						}
					}
				}
			}
		}
		foreach (PathList rail3 in TerrainMeta.Path.Rails)
		{
			PathInterpolator path = rail3.Path;
			Vector3[] points3 = path.Points;
			Vector3[] tangents = path.Tangents;
			int num6 = path.MinIndex + 1 + 16;
			int num7 = path.MaxIndex - 1 - 16;
			for (int k = num6; k <= num7; k++)
			{
				list2.Clear();
				list3.Clear();
				int num8 = SeedRandom.Range(ref seed, num3, num4);
				int num9 = SeedRandom.Range(ref seed, num, num2);
				int num10 = k;
				int num11 = k + num8;
				if (num11 >= num7)
				{
					continue;
				}
				Vector3 val4 = tangents[num10];
				Vector3 val5 = tangents[num11];
				if (Vector3.Angle(val4, val5) > 30f)
				{
					continue;
				}
				Vector3 val6 = tangents[num10];
				Vector3 val7 = tangents[num11];
				Vector3 val8 = Vector3.Normalize(points3[num10 + 8] - points3[num10]);
				Vector3 val9 = Vector3.Normalize(points3[num11] - points3[num11 - 8]);
				float num12 = Vector3.SignedAngle(val8, val6, Vector3.up);
				float num13 = 0f - Vector3.SignedAngle(val9, val7, Vector3.up);
				if (Mathf.Sign(num12) != Mathf.Sign(num13) || Mathf.Abs(num12) > 60f || Mathf.Abs(num13) > 60f)
				{
					continue;
				}
				float num14 = 5f;
				Quaternion val10 = ((num12 > 0f) ? rotRight : rotLeft);
				for (int l = num10 - 8; l <= num11 + 8; l++)
				{
					Vector3 val11 = points3[l];
					if (hashSet.Contains(val11))
					{
						list2.Clear();
						list3.Clear();
						break;
					}
					Vector3 val12 = tangents[l];
					Vector3 val13 = val10 * val12;
					if (l < num10 + 8)
					{
						float num15 = Mathf.InverseLerp((float)(num10 - 8), (float)num10, (float)l);
						float num16 = Mathf.SmoothStep(0f, 1f, num15) * num14;
						val11 += val13 * num16;
					}
					else if (l > num11 - 8)
					{
						float num17 = Mathf.InverseLerp((float)(num11 + 8), (float)num11, (float)l);
						float num18 = Mathf.SmoothStep(0f, 1f, num17) * num14;
						val11 += val13 * num18;
					}
					else
					{
						val11 += val13 * num14;
					}
					list2.Add(val11);
					list3.Add(val12);
				}
				if (list2.Count >= 2)
				{
					int number = TerrainMeta.Path.Rails.Count + list.Count;
					PathList pathList = CreateSegment(number, list2.ToArray());
					pathList.Start = false;
					pathList.End = false;
					list.Add(pathList);
					k += num8;
				}
				k += num9;
			}
		}
		foreach (PathList item in list)
		{
			item.Path.Resample(7.5f);
			item.Path.RecalculateTangents();
			item.AdjustPlacementMap(20f);
		}
		TerrainMeta.Path.Rails.AddRange(list);
	}
}
