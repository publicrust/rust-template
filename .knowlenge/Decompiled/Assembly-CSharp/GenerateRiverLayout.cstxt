using System;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRiverLayout : ProceduralComponent
{
	public const float Width = 10f;

	public const float InnerPadding = 1f;

	public const float OuterPadding = 1f;

	public const float InnerFade = 8f;

	public const float OuterFade = 64f;

	public const float RandomScale = 0.75f;

	public const float MeshOffset = -0.5f;

	public const float TerrainOffset = -1.5f;

	private static Quaternion rot90 = Quaternion.Euler(0f, 90f, 0f);

	public override void Process(uint seed)
	{
		if (World.Networked)
		{
			TerrainMeta.Path.Rivers.Clear();
			TerrainMeta.Path.Rivers.AddRange(World.GetPaths("River"));
		}
		else
		{
			if (!World.Config.Rivers)
			{
				return;
			}
			List<PathList> list = new List<PathList>();
			TerrainHeightMap heightMap = TerrainMeta.HeightMap;
			TerrainTopologyMap topologyMap = TerrainMeta.TopologyMap;
			List<Vector3> list2 = new List<Vector3>();
			int num = 3;
			if (World.Size <= 4000)
			{
				num = 2;
			}
			for (float num2 = TerrainMeta.Position.z; num2 < TerrainMeta.Position.z + TerrainMeta.Size.z; num2 += 20f)
			{
				for (float num3 = TerrainMeta.Position.x; num3 < TerrainMeta.Position.x + TerrainMeta.Size.x; num3 += 20f)
				{
					Vector3 vector = new Vector3(num3, 0f, num2);
					float num4 = (vector.y = heightMap.GetHeight(vector));
					if (vector.y <= 15f)
					{
						continue;
					}
					Vector3 normal = heightMap.GetNormal(vector);
					if (normal.y <= 0.01f || normal.y >= 0.99f)
					{
						continue;
					}
					Vector2 normalized = normal.XZ2D().normalized;
					float value = Vector3.Angle(Vector3.up, normal);
					list2.Add(vector);
					float baseRadius = 5f;
					int num5 = 0;
					int num6 = 5;
					for (int i = 0; i < 5000; i++)
					{
						int num7 = i * 4;
						Vector2 vector2 = normalized.Rotate(Mathf.Sin((float)num7 * (MathF.PI / 180f) * 0.5f) * Mathf.InverseLerp(30f, 10f, value) * 60f);
						vector.x += vector2.x * 4f;
						vector.z += vector2.y * 4f;
						bool flag = false;
						for (int j = 0; j < list2.Count - 10; j++)
						{
							Vector3 vector3 = new Line(list2[j], list2[j + 1]).ClosestPoint(vector);
							if ((vector - vector3).sqrMagnitude < 16900f)
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
						float height = heightMap.GetHeight(vector);
						if (height > num4 + 32f)
						{
							break;
						}
						float num8 = Mathf.Min(height, num4);
						float t = Mathf.Lerp(0.15f, 0.95f, Mathf.InverseLerp(10f, 0f, num8));
						vector.y = Mathf.Lerp(vector.y, num8, t);
						float radius = PathList.GetRadius(num7, 0f, baseRadius, 0.75f, scaleWidthWithLength: true);
						float radius2 = PathList.GetRadius(num7, num7, baseRadius, 0.75f, scaleWidthWithLength: true);
						Vector3 vector4 = new Vector3(vector2.x, 0f, vector2.y);
						Vector3 vector5 = vector4 * (radius * 1.5f);
						Vector3 vector6 = vector4 * (radius2 + 1f + 64f);
						Vector3 vector7 = rot90 * vector4;
						Vector3 vector8 = vector7 * (radius * 1.5f);
						Vector3 vector9 = vector7 * (radius2 + 1f + 64f);
						int topology = topologyMap.GetTopology(vector, radius + 1f + 64f);
						int num9 = topologyMap.GetTopology(vector) & topologyMap.GetTopology(vector - vector5) & topologyMap.GetTopology(vector + vector5) & topologyMap.GetTopology(vector + vector6) & topologyMap.GetTopology(vector - vector8) & topologyMap.GetTopology(vector - vector9) & topologyMap.GetTopology(vector + vector8) & topologyMap.GetTopology(vector + vector9);
						int topology2 = topologyMap.GetTopology(vector);
						int num10 = 3742724;
						int num11 = 128;
						int num12 = 128;
						if ((topology & num10) != 0)
						{
							break;
						}
						if ((num9 & num11) != 0)
						{
							list2.Add(vector);
							if (list2.Count >= 62)
							{
								PathList pathList = new PathList("River " + (TerrainMeta.Path.Rivers.Count + list.Count), list2.ToArray());
								pathList.Spline = true;
								pathList.Width = 10f;
								pathList.InnerPadding = 1f;
								pathList.OuterPadding = 1f;
								pathList.InnerFade = 8f;
								pathList.OuterFade = 64f;
								pathList.RandomScale = 0.75f;
								pathList.MeshOffset = -0.5f;
								pathList.TerrainOffset = -1.5f;
								pathList.Topology = 16384;
								pathList.Splat = 128;
								pathList.Start = true;
								pathList.End = true;
								list.Add(pathList);
							}
							break;
						}
						if ((topology2 & num12) != 0 || vector.y < 0f)
						{
							if (num5++ >= num6)
							{
								break;
							}
						}
						else if (num5 > 0)
						{
							break;
						}
						if (i % 4 == 0)
						{
							list2.Add(vector);
						}
						normal = heightMap.GetNormal(vector);
						value = Vector3.Angle(Vector3.up, normal);
						normalized = Vector2.Lerp(normalized, normal.XZ2D().normalized, 0.025f).normalized;
						num4 = num8;
					}
					list2.Clear();
				}
			}
			list.Sort((PathList a, PathList b) => b.Path.Points.Length.CompareTo(a.Path.Points.Length));
			int num13 = (int)(World.Size / 16);
			bool[,] array = new bool[num13, num13];
			for (int k = 0; k < list.Count; k++)
			{
				if (k >= num)
				{
					list.RemoveAt(k--);
					continue;
				}
				PathList pathList2 = list[k];
				bool flag2 = false;
				for (int l = 0; l < k; l++)
				{
					PathList pathList3 = list[l];
					Vector3[] points = pathList2.Path.Points;
					foreach (Vector3 vector10 in points)
					{
						Vector3[] points2 = pathList3.Path.Points;
						foreach (Vector3 vector11 in points2)
						{
							if ((vector10 - vector11).sqrMagnitude < 270400f)
							{
								list.RemoveAt(k--);
								flag2 = true;
							}
							if (flag2)
							{
								break;
							}
						}
						if (flag2)
						{
							break;
						}
					}
					if (flag2)
					{
						break;
					}
				}
				if (flag2)
				{
					continue;
				}
				for (int num14 = 0; num14 < pathList2.Path.Points.Length; num14++)
				{
					Vector3 vector12 = pathList2.Path.Points[num14];
					int num15 = Mathf.Clamp((int)(TerrainMeta.NormalizeX(vector12.x) * (float)num13), 0, num13 - 1);
					int num16 = Mathf.Clamp((int)(TerrainMeta.NormalizeZ(vector12.z) * (float)num13), 0, num13 - 1);
					if (array[num16, num15])
					{
						list.RemoveAt(k--);
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					continue;
				}
				int num17 = -1;
				int num18 = -1;
				for (int num19 = 0; num19 < pathList2.Path.Points.Length; num19++)
				{
					Vector3 vector13 = pathList2.Path.Points[num19];
					int num20 = Mathf.Clamp((int)(TerrainMeta.NormalizeX(vector13.x) * (float)num13), 0, num13 - 1);
					int num21 = Mathf.Clamp((int)(TerrainMeta.NormalizeZ(vector13.z) * (float)num13), 0, num13 - 1);
					if (num17 != -1)
					{
						array[num21, num17] = true;
					}
					if (num18 != -1)
					{
						array[num18, num20] = true;
					}
					array[num21, num20] = true;
					num17 = num20;
					num18 = num21;
				}
			}
			for (int num22 = 0; num22 < list.Count; num22++)
			{
				list[num22].Name = "River " + (TerrainMeta.Path.Rivers.Count + num22);
			}
			foreach (PathList item in list)
			{
				item.Path.Smoothen(4, new Vector3(1f, 0f, 1f));
				item.Path.Smoothen(8, new Vector3(0f, 1f, 0f));
				item.Path.Resample(7.5f);
				item.Path.RecalculateTangents();
			}
			TerrainMeta.Path.Rivers.AddRange(list);
		}
	}
}
