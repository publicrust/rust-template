using UnityEngine;

public class PlaceDecorUniform : ProceduralComponent
{
	public SpawnFilter Filter;

	public string ResourceFolder = string.Empty;

	public float ObjectDistance = 10f;

	public float ObjectDithering = 5f;

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
		float x = position.x;
		float z = position.z;
		float num = position.x + size.x;
		float num2 = position.z + size.z;
		for (float num3 = z; num3 < num2; num3 += ObjectDistance)
		{
			for (float num4 = x; num4 < num; num4 += ObjectDistance)
			{
				float x2 = num4 + SeedRandom.Range(ref seed, 0f - ObjectDithering, ObjectDithering);
				float z2 = num3 + SeedRandom.Range(ref seed, 0f - ObjectDithering, ObjectDithering);
				float normX = TerrainMeta.NormalizeX(x2);
				float normZ = TerrainMeta.NormalizeZ(z2);
				float num5 = SeedRandom.Value(ref seed);
				Prefab random = ArrayEx.GetRandom(array, ref seed);
				if ((FilterMode & SpawnFilterMode.PivotPoint) != 0)
				{
					float factor = Filter.GetFactor(normX, normZ);
					if (factor * factor < num5)
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
}
