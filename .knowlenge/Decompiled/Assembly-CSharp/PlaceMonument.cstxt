using UnityEngine;

public class PlaceMonument : ProceduralComponent
{
	public struct SpawnInfo
	{
		public Prefab prefab;

		public Vector3 position;

		public Quaternion rotation;

		public Vector3 scale;
	}

	public SpawnFilter Filter;

	public GameObjectRef Monument;

	private const int Attempts = 10000;

	public override void Process(uint seed)
	{
		if (!Monument.isValid)
		{
			return;
		}
		TerrainHeightMap heightMap = TerrainMeta.HeightMap;
		Vector3 position = TerrainMeta.Position;
		Vector3 size = TerrainMeta.Size;
		float x = position.x;
		float z = position.z;
		float max = position.x + size.x;
		float max2 = position.z + size.z;
		SpawnInfo spawnInfo = default(SpawnInfo);
		int num = int.MinValue;
		Prefab<MonumentInfo> prefab = Prefab.Load<MonumentInfo>(Monument.resourceID);
		for (int i = 0; i < 10000; i++)
		{
			float x2 = SeedRandom.Range(ref seed, x, max);
			float z2 = SeedRandom.Range(ref seed, z, max2);
			float normX = TerrainMeta.NormalizeX(x2);
			float normZ = TerrainMeta.NormalizeZ(z2);
			float num2 = SeedRandom.Value(ref seed);
			float factor = Filter.GetFactor(normX, normZ);
			if (factor * factor < num2)
			{
				continue;
			}
			float height = heightMap.GetHeight(normX, normZ);
			Vector3 pos = new Vector3(x2, height, z2);
			Quaternion rot = prefab.Object.transform.localRotation;
			Vector3 scale = prefab.Object.transform.localScale;
			prefab.ApplyDecorComponents(ref pos, ref rot, ref scale);
			if ((!prefab.Component || prefab.Component.CheckPlacement(pos, rot, scale)) && prefab.ApplyTerrainFilters(pos, rot, scale) && prefab.ApplyTerrainAnchors(ref pos, rot, scale, Filter) && prefab.ApplyTerrainChecks(pos, rot, scale, Filter) && prefab.ApplyWaterChecks(pos, rot, scale) && !prefab.CheckEnvironmentVolumes(pos, rot, scale, EnvironmentType.Underground | EnvironmentType.TrainTunnels))
			{
				SpawnInfo spawnInfo2 = default(SpawnInfo);
				spawnInfo2.prefab = prefab;
				spawnInfo2.position = pos;
				spawnInfo2.rotation = rot;
				spawnInfo2.scale = scale;
				int num3 = -Mathf.RoundToInt(pos.Magnitude2D());
				if (num3 > num)
				{
					num = num3;
					spawnInfo = spawnInfo2;
				}
			}
		}
		if (num != int.MinValue)
		{
			World.AddPrefab("Monument", spawnInfo.prefab, spawnInfo.position, spawnInfo.rotation, spawnInfo.scale);
		}
	}
}
