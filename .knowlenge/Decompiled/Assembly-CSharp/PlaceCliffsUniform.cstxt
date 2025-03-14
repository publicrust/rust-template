using UnityEngine;

public class PlaceCliffsUniform : ProceduralComponent
{
	public SpawnFilter Filter;

	public string ResourceFolder = string.Empty;

	public float ObjectDistance = 10f;

	public float ObjectDithering = 5f;

	public TerrainAnchorMode AnchorMode;

	[InspectorFlags]
	public SpawnFilterMode FilterMode = (SpawnFilterMode)(-1);

	private static int min_rotation_z = 0;

	private static int max_rotation_z = 12;

	private static int rotation_delta_z = 4;

	private static int min_rotation_x = 0;

	private static int max_rotation_x = 12;

	private static int rotation_delta_x = 2;

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
		for (int num3 = 128; num3 > 0; num3 /= 2)
		{
			float num4 = ObjectDistance * (float)num3;
			for (float num5 = z; num5 < num2; num5 += num4)
			{
				for (float num6 = x; num6 < num; num6 += num4)
				{
					float x2 = num6 + SeedRandom.Range(ref seed, 0f - ObjectDithering, ObjectDithering);
					float z2 = num5 + SeedRandom.Range(ref seed, 0f - ObjectDithering, ObjectDithering);
					float normX = TerrainMeta.NormalizeX(x2);
					float normZ = TerrainMeta.NormalizeZ(z2);
					float num7 = SeedRandom.Value(ref seed);
					ArrayEx.BubbleSort(array);
					if ((FilterMode & SpawnFilterMode.PivotPoint) != 0)
					{
						float factor = Filter.GetFactor(normX, normZ);
						if (factor * factor < num7)
						{
							continue;
						}
					}
					float height = heightMap.GetHeight(normX, normZ);
					Prefab[] array2 = array;
					foreach (Prefab prefab in array2)
					{
						Vector3 pos = new Vector3(x2, height, z2);
						Quaternion rot = prefab.Object.transform.localRotation;
						Vector3 scale = prefab.Object.transform.localScale;
						bool flag = false;
						Vector3 position2 = Vector3.zero;
						Quaternion rotation = Quaternion.identity;
						Vector3 scale2 = Vector3.zero;
						prefab.ApplyDecorComponents(ref pos, ref rot, ref scale);
						for (int j = min_rotation_z; j <= max_rotation_z; j += rotation_delta_z)
						{
							for (int k = min_rotation_x; k <= max_rotation_x; k += rotation_delta_x)
							{
								for (int l = -1; l <= 1; l += 2)
								{
									for (int m = -1; m <= 1; m += 2)
									{
										Vector3 pos2 = pos;
										Quaternion quaternion = rot * Quaternion.Euler(m * k, 0f, l * j);
										Vector3 vector = scale;
										if (prefab.ApplyTerrainFilters(pos2, quaternion, vector) && prefab.ApplyTerrainAnchors(ref pos2, quaternion, vector, AnchorMode, ((FilterMode & SpawnFilterMode.TerrainAnchorPoints) != 0) ? Filter : null) && prefab.ApplyTerrainChecks(pos2, quaternion, vector, ((FilterMode & SpawnFilterMode.TerrainCheckPoints) != 0) ? Filter : null) && prefab.ApplyWaterChecks(pos2, quaternion, vector) && prefab.ApplyEnvironmentVolumeChecks(pos2, quaternion, vector) && (!flag || position2.y < pos2.y))
										{
											flag = true;
											position2 = pos2;
											rotation = quaternion;
											scale2 = vector;
										}
									}
								}
							}
						}
						if (flag)
						{
							prefab.SpawnedCount++;
							World.AddPrefab("Decor", prefab, position2, rotation, scale2);
							break;
						}
					}
				}
			}
		}
	}
}
