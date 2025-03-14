using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlaceMonuments : ProceduralComponent
{
	public struct SpawnInfo
	{
		public Prefab prefab;

		public Vector3 position;

		public Quaternion rotation;

		public Vector3 scale;
	}

	public SpawnFilter Filter;

	public string ResourceFolder = string.Empty;

	public int TargetCount;

	[FormerlySerializedAs("Distance")]
	public int MinDistance = 500;

	[FormerlySerializedAs("MinSize")]
	public int MinWorldSize;

	private const int Candidates = 10;

	private const int Attempts = 10000;

	public override void Process(uint seed)
	{
		if (World.Networked)
		{
			World.Spawn("Monument", "assets/bundled/prefabs/autospawn/" + ResourceFolder + "/");
		}
		else
		{
			if (World.Size < MinWorldSize)
			{
				return;
			}
			TerrainHeightMap heightMap = TerrainMeta.HeightMap;
			Prefab<MonumentInfo>[] array = Prefab.Load<MonumentInfo>("assets/bundled/prefabs/autospawn/" + ResourceFolder);
			if (array == null || array.Length == 0)
			{
				return;
			}
			ArrayEx.Shuffle(array, seed);
			ArrayEx.BubbleSort(array);
			Vector3 position = TerrainMeta.Position;
			Vector3 size = TerrainMeta.Size;
			float x = position.x;
			float z = position.z;
			float max = position.x + size.x;
			float max2 = position.z + size.z;
			int num = 0;
			List<SpawnInfo> a = new List<SpawnInfo>();
			int num2 = 0;
			List<SpawnInfo> b = new List<SpawnInfo>();
			for (int i = 0; i < 10; i++)
			{
				num = 0;
				a.Clear();
				Prefab<MonumentInfo>[] array2 = array;
				foreach (Prefab<MonumentInfo> prefab in array2)
				{
					if ((bool)prefab.Component && World.Size < prefab.Component.MinWorldSize)
					{
						continue;
					}
					int num3 = (int)((!prefab.Parameters) ? PrefabPriority.Low : (prefab.Parameters.Priority + 1));
					int num4 = num3 * num3 * num3 * num3;
					for (int k = 0; k < 10000; k++)
					{
						float x2 = SeedRandom.Range(ref seed, x, max);
						float z2 = SeedRandom.Range(ref seed, z, max2);
						float normX = TerrainMeta.NormalizeX(x2);
						float normZ = TerrainMeta.NormalizeZ(z2);
						float num5 = SeedRandom.Value(ref seed);
						float factor = Filter.GetFactor(normX, normZ);
						if (factor * factor < num5)
						{
							continue;
						}
						float height = heightMap.GetHeight(normX, normZ);
						Vector3 pos = new Vector3(x2, height, z2);
						Quaternion rot = prefab.Object.transform.localRotation;
						Vector3 scale = prefab.Object.transform.localScale;
						int num6 = Mathf.Max(MinDistance, prefab.Component ? prefab.Component.MinDistance : 0);
						if (!CheckRadius(a, pos, num6))
						{
							prefab.ApplyDecorComponents(ref pos, ref rot, ref scale);
							if ((!prefab.Component || prefab.Component.CheckPlacement(pos, rot, scale)) && prefab.ApplyTerrainAnchors(ref pos, rot, scale, Filter) && prefab.ApplyTerrainChecks(pos, rot, scale, Filter) && prefab.ApplyTerrainFilters(pos, rot, scale) && prefab.ApplyWaterChecks(pos, rot, scale) && !prefab.CheckEnvironmentVolumes(pos, rot, scale, EnvironmentType.Underground))
							{
								SpawnInfo item = default(SpawnInfo);
								item.prefab = prefab;
								item.position = pos;
								item.rotation = rot;
								item.scale = scale;
								a.Add(item);
								num += num4;
								break;
							}
						}
					}
					if (TargetCount > 0 && a.Count >= TargetCount)
					{
						break;
					}
				}
				if (num > num2)
				{
					num2 = num;
					GenericsUtil.Swap(ref a, ref b);
				}
			}
			foreach (SpawnInfo item2 in b)
			{
				World.AddPrefab("Monument", item2.prefab, item2.position, item2.rotation, item2.scale);
			}
		}
	}

	public bool CheckRadius(List<SpawnInfo> spawns, Vector3 pos, float radius)
	{
		float num = radius * radius;
		foreach (SpawnInfo spawn in spawns)
		{
			if ((spawn.position - pos).sqrMagnitude < num)
			{
				return true;
			}
		}
		return false;
	}
}
