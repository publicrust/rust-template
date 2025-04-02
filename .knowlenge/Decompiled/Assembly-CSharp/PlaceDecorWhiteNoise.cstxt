using UnityEngine;

public class PlaceDecorWhiteNoise : ProceduralComponent
{
	public SpawnFilter Filter;

	public string ResourceFolder = string.Empty;

	public float ObjectDensity = 100f;

	public TerrainAnchorMode AnchorMode;

	[InspectorFlags]
	public SpawnFilterMode FilterMode = (SpawnFilterMode)(-1);

	public override void Process(uint seed)
	{
		if (World.Networked)
		{
			World.Spawn("Decor", "assets/bundled/prefabs/autospawn/" + ResourceFolder + "/");
			return;
		}
		TerrainHeightMap heightMap = TerrainMeta.HeightMap;
		Prefab[] array = Prefab.Load("assets/bundled/prefabs/autospawn/" + ResourceFolder);
		if (array == null || array.Length == 0)
		{
			return;
		}
		Vector3 position = TerrainMeta.Position;
		Vector3 size = TerrainMeta.Size;
		int num = Mathf.RoundToInt(ObjectDensity * size.x * size.z * 1E-06f);
		float x = position.x;
		float z = position.z;
		float max = position.x + size.x;
		float max2 = position.z + size.z;
		for (int i = 0; i < num; i++)
		{
			float x2 = SeedRandom.Range(ref seed, x, max);
			float z2 = SeedRandom.Range(ref seed, z, max2);
			float normX = TerrainMeta.NormalizeX(x2);
			float normZ = TerrainMeta.NormalizeZ(z2);
			float num2 = SeedRandom.Value(ref seed);
			Prefab random = ArrayEx.GetRandom(array, ref seed);
			if ((FilterMode & SpawnFilterMode.PivotPoint) != 0)
			{
				float factor = Filter.GetFactor(normX, normZ);
				if (factor * factor < num2)
				{
					continue;
				}
			}
			float height = heightMap.GetHeight(normX, normZ);
			Vector3 pos = new Vector3(x2, height, z2);
			Quaternion rot = random.Object.transform.localRotation;
			Vector3 scale = random.Object.transform.localScale;
			random.ApplyDecorComponents(ref pos, ref rot, ref scale);
			if (random.ApplyTerrainFilters(pos, rot, scale) && random.ApplyTerrainAnchors(ref pos, rot, scale, AnchorMode, ((FilterMode & SpawnFilterMode.TerrainAnchorPoints) != 0) ? Filter : null) && random.ApplyTerrainChecks(pos, rot, scale, ((FilterMode & SpawnFilterMode.TerrainCheckPoints) != 0) ? Filter : null) && random.ApplyWaterChecks(pos, rot, scale) && random.ApplyEnvironmentVolumeChecks(pos, rot, scale))
			{
				World.AddPrefab("Decor", random, pos, rot, scale);
			}
		}
	}
}
