using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class PlaceMonumentsOffshore : ProceduralComponent
{
	private struct SpawnInfo
	{
		public Prefab prefab;

		public Vector3 position;

		public Quaternion rotation;

		public Vector3 scale;
	}

	public string ResourceFolder = string.Empty;

	public int TargetCount;

	public int MinDistanceFromTerrain = 100;

	public int MaxDistanceFromTerrain = 500;

	public int DistanceBetweenMonuments = 500;

	[FormerlySerializedAs("MinSize")]
	public int MinWorldSize;

	private const int Candidates = 10;

	private const int Attempts = 10000;

	public override void Process(uint seed)
	{
		string[] array = (from folder in ResourceFolder.Split(',')
			select "assets/bundled/prefabs/autospawn/" + folder + "/").ToArray();
		if (World.Networked)
		{
			World.Spawn("Monument", array);
		}
		else
		{
			if (World.Size < MinWorldSize)
			{
				return;
			}
			TerrainHeightMap heightMap = TerrainMeta.HeightMap;
			List<Prefab<MonumentInfo>> list = new List<Prefab<MonumentInfo>>();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Prefab<MonumentInfo>[] array3 = Prefab.Load<MonumentInfo>(array2[i]);
				ArrayEx.Shuffle(array3, ref seed);
				list.AddRange(array3);
			}
			Prefab<MonumentInfo>[] array4 = list.ToArray();
			if (array4 == null || array4.Length == 0)
			{
				return;
			}
			ArrayEx.BubbleSort(array4);
			Vector3 position = TerrainMeta.Position;
			Vector3 size = TerrainMeta.Size;
			float min = position.x - (float)MaxDistanceFromTerrain;
			float max = position.x - (float)MinDistanceFromTerrain;
			float min2 = position.x + size.x + (float)MinDistanceFromTerrain;
			float max2 = position.x + size.x + (float)MaxDistanceFromTerrain;
			float min3 = position.z - (float)MaxDistanceFromTerrain;
			float max3 = position.z - (float)MinDistanceFromTerrain;
			float min4 = position.z + size.z + (float)MinDistanceFromTerrain;
			float max4 = position.z + size.z + (float)MaxDistanceFromTerrain;
			int num = 0;
			List<SpawnInfo> a = new List<SpawnInfo>();
			int num2 = 0;
			List<SpawnInfo> b = new List<SpawnInfo>();
			for (int j = 0; j < 10; j++)
			{
				num = 0;
				a.Clear();
				Prefab<MonumentInfo>[] array5 = array4;
				foreach (Prefab<MonumentInfo> prefab in array5)
				{
					int num3 = (int)((!prefab.Parameters) ? PrefabPriority.Low : (prefab.Parameters.Priority + 1));
					int num4 = num3 * num3 * num3 * num3;
					for (int k = 0; k < 10000; k++)
					{
						float x = 0f;
						float z = 0f;
						switch (seed % 4)
						{
						case 0u:
							x = SeedRandom.Range(ref seed, min, max);
							z = SeedRandom.Range(ref seed, min3, max4);
							break;
						case 1u:
							x = SeedRandom.Range(ref seed, min2, max2);
							z = SeedRandom.Range(ref seed, min3, max4);
							break;
						case 2u:
							x = SeedRandom.Range(ref seed, min, max2);
							z = SeedRandom.Range(ref seed, min3, max3);
							break;
						case 3u:
							x = SeedRandom.Range(ref seed, min, max2);
							z = SeedRandom.Range(ref seed, min4, max4);
							break;
						}
						float normX = TerrainMeta.NormalizeX(x);
						float normZ = TerrainMeta.NormalizeZ(z);
						float height = heightMap.GetHeight(normX, normZ);
						Vector3 pos = new Vector3(x, height, z);
						Quaternion rot = prefab.Object.transform.localRotation;
						Vector3 scale = prefab.Object.transform.localScale;
						if (!CheckRadius(a, pos, DistanceBetweenMonuments))
						{
							prefab.ApplyDecorComponents(ref pos, ref rot, ref scale);
							if ((!prefab.Component || prefab.Component.CheckPlacement(pos, rot, scale)) && prefab.ApplyEnvironmentVolumeChecks(pos, rot, scale) && !prefab.CheckEnvironmentVolumes(pos, rot, scale, EnvironmentType.Underground | EnvironmentType.TrainTunnels))
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
