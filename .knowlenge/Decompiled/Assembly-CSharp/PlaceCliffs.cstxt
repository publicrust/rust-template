using System.Linq;
using UnityEngine;

public class PlaceCliffs : ProceduralComponent
{
	private class CliffPlacement
	{
		public int count;

		public int score;

		public Prefab prefab;

		public Vector3 pos = Vector3.zero;

		public Quaternion rot = Quaternion.identity;

		public Vector3 scale = Vector3.one;

		public CliffPlacement next;
	}

	public SpawnFilter Filter;

	public string ResourceFolder = string.Empty;

	public int RetryMultiplier = 1;

	public int CutoffSlope = 10;

	public float MinScale = 1f;

	public float MaxScale = 2f;

	private static int target_count = 4;

	private static int target_length = 0;

	private static float min_scale_delta = 0.1f;

	private static int max_scale_attempts = 10;

	private static int min_rotation = rotation_delta;

	private static int max_rotation = 60;

	private static int rotation_delta = 10;

	private static float offset_c = 0f;

	private static float offset_l = -0.75f;

	private static float offset_r = 0.75f;

	private static Vector3[] offsets = new Vector3[5]
	{
		new Vector3(offset_c, offset_c, offset_c),
		new Vector3(offset_l, offset_c, offset_c),
		new Vector3(offset_r, offset_c, offset_c),
		new Vector3(offset_c, offset_c, offset_l),
		new Vector3(offset_c, offset_c, offset_r)
	};

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
		Prefab[] array2 = array.Where((Prefab prefab) => (bool)prefab.Attribute.Find<DecorSocketMale>(prefab.ID) && (bool)prefab.Attribute.Find<DecorSocketFemale>(prefab.ID)).ToArray();
		if (array2 == null || array2.Length == 0)
		{
			return;
		}
		Prefab[] array3 = array.Where((Prefab prefab) => prefab.Attribute.Find<DecorSocketMale>(prefab.ID)).ToArray();
		if (array3 == null || array3.Length == 0)
		{
			return;
		}
		Prefab[] array4 = array.Where((Prefab prefab) => prefab.Attribute.Find<DecorSocketFemale>(prefab.ID)).ToArray();
		if (array4 == null || array4.Length == 0)
		{
			return;
		}
		Vector3 position = TerrainMeta.Position;
		Vector3 size = TerrainMeta.Size;
		float x = position.x;
		float z = position.z;
		float max = position.x + size.x;
		float max2 = position.z + size.z;
		int num = Mathf.RoundToInt(size.x * size.z * 0.001f * (float)RetryMultiplier);
		for (int i = 0; i < num; i++)
		{
			float x2 = SeedRandom.Range(ref seed, x, max);
			float z2 = SeedRandom.Range(ref seed, z, max2);
			float normX = TerrainMeta.NormalizeX(x2);
			float normZ = TerrainMeta.NormalizeZ(z2);
			float num2 = SeedRandom.Value(ref seed);
			float factor = Filter.GetFactor(normX, normZ);
			Prefab random = ArrayEx.GetRandom(array2, ref seed);
			if (factor * factor < num2)
			{
				continue;
			}
			Vector3 normal = TerrainMeta.HeightMap.GetNormal(normX, normZ);
			if (Vector3.Angle(Vector3.up, normal) < (float)CutoffSlope)
			{
				continue;
			}
			float height = heightMap.GetHeight(normX, normZ);
			Vector3 vector = new Vector3(x2, height, z2);
			Quaternion quaternion = QuaternionEx.LookRotationForcedUp(normal, Vector3.up);
			float num3 = Mathf.Max((MaxScale - MinScale) / (float)max_scale_attempts, min_scale_delta);
			for (float num4 = MaxScale; num4 >= MinScale; num4 -= num3)
			{
				Vector3 pos = vector;
				Quaternion quaternion2 = quaternion * random.Object.transform.localRotation;
				Vector3 vector2 = num4 * random.Object.transform.localScale;
				if (random.ApplyTerrainAnchors(ref pos, quaternion2, vector2) && random.ApplyTerrainChecks(pos, quaternion2, vector2) && random.ApplyTerrainFilters(pos, quaternion2, vector2) && random.ApplyWaterChecks(pos, quaternion2, vector2))
				{
					CliffPlacement cliffPlacement = PlaceMale(array3, ref seed, random, pos, quaternion2, vector2);
					CliffPlacement cliffPlacement2 = PlaceFemale(array4, ref seed, random, pos, quaternion2, vector2);
					World.AddPrefab("Decor", random, pos, quaternion2, vector2);
					while (cliffPlacement != null && cliffPlacement.prefab != null)
					{
						World.AddPrefab("Decor", cliffPlacement.prefab, cliffPlacement.pos, cliffPlacement.rot, cliffPlacement.scale);
						cliffPlacement = cliffPlacement.next;
						i++;
					}
					while (cliffPlacement2 != null && cliffPlacement2.prefab != null)
					{
						World.AddPrefab("Decor", cliffPlacement2.prefab, cliffPlacement2.pos, cliffPlacement2.rot, cliffPlacement2.scale);
						cliffPlacement2 = cliffPlacement2.next;
						i++;
					}
					break;
				}
			}
		}
	}

	private CliffPlacement PlaceMale(Prefab[] prefabs, ref uint seed, Prefab parentPrefab, Vector3 parentPos, Quaternion parentRot, Vector3 parentScale)
	{
		return Place<DecorSocketFemale, DecorSocketMale>(prefabs, ref seed, parentPrefab, parentPos, parentRot, parentScale);
	}

	private CliffPlacement PlaceFemale(Prefab[] prefabs, ref uint seed, Prefab parentPrefab, Vector3 parentPos, Quaternion parentRot, Vector3 parentScale)
	{
		return Place<DecorSocketMale, DecorSocketFemale>(prefabs, ref seed, parentPrefab, parentPos, parentRot, parentScale);
	}

	private CliffPlacement Place<ParentSocketType, ChildSocketType>(Prefab[] prefabs, ref uint seed, Prefab parentPrefab, Vector3 parentPos, Quaternion parentRot, Vector3 parentScale, int parentAngle = 0, int parentCount = 0, int parentScore = 0) where ParentSocketType : PrefabAttribute where ChildSocketType : PrefabAttribute
	{
		CliffPlacement cliffPlacement = null;
		if (parentAngle > 160 || parentAngle < -160)
		{
			return cliffPlacement;
		}
		int num = SeedRandom.Range(ref seed, 0, prefabs.Length);
		ParentSocketType val = parentPrefab.Attribute.Find<ParentSocketType>(parentPrefab.ID);
		Vector3 vector = parentPos + parentRot * Vector3.Scale(val.worldPosition, parentScale);
		float num2 = Mathf.Max((MaxScale - MinScale) / (float)max_scale_attempts, min_scale_delta);
		for (int i = 0; i < prefabs.Length; i++)
		{
			Prefab prefab = prefabs[(num + i) % prefabs.Length];
			if (prefab == parentPrefab)
			{
				continue;
			}
			ParentSocketType val2 = prefab.Attribute.Find<ParentSocketType>(prefab.ID);
			ChildSocketType val3 = prefab.Attribute.Find<ChildSocketType>(prefab.ID);
			bool flag = val2 != null;
			if (cliffPlacement != null && cliffPlacement.count > target_count && cliffPlacement.score > target_length && flag)
			{
				continue;
			}
			float num3 = MaxScale;
			while (num3 >= MinScale)
			{
				int j;
				Vector3 vector3;
				Quaternion quaternion;
				Vector3 pos;
				for (j = min_rotation; j <= max_rotation; j += rotation_delta)
				{
					for (int k = -1; k <= 1; k += 2)
					{
						Vector3[] array = offsets;
						int num4 = 0;
						while (num4 < array.Length)
						{
							Vector3 vector2 = array[num4];
							vector3 = parentScale * num3;
							quaternion = Quaternion.Euler(0f, k * j, 0f) * parentRot;
							pos = vector - quaternion * (Vector3.Scale(val3.worldPosition, vector3) + vector2);
							if (Filter.GetFactor(pos) < 0.5f || !prefab.ApplyTerrainAnchors(ref pos, quaternion, vector3) || !prefab.ApplyTerrainChecks(pos, quaternion, vector3) || !prefab.ApplyTerrainFilters(pos, quaternion, vector3) || !prefab.ApplyWaterChecks(pos, quaternion, vector3))
							{
								num4++;
								continue;
							}
							goto IL_01dd;
						}
					}
				}
				num3 -= num2;
				continue;
				IL_01dd:
				int parentAngle2 = parentAngle + j;
				int num5 = parentCount + 1;
				int num6 = parentScore + Mathf.CeilToInt(Vector3Ex.Distance2D(parentPos, pos));
				CliffPlacement cliffPlacement2 = null;
				if (flag)
				{
					cliffPlacement2 = Place<ParentSocketType, ChildSocketType>(prefabs, ref seed, prefab, pos, quaternion, vector3, parentAngle2, num5, num6);
					if (cliffPlacement2 != null)
					{
						num5 = cliffPlacement2.count;
						num6 = cliffPlacement2.score;
					}
				}
				else
				{
					num6 *= 2;
				}
				if (cliffPlacement == null)
				{
					cliffPlacement = new CliffPlacement();
				}
				if (cliffPlacement.score < num6)
				{
					cliffPlacement.next = cliffPlacement2;
					cliffPlacement.count = num5;
					cliffPlacement.score = num6;
					cliffPlacement.prefab = prefab;
					cliffPlacement.pos = pos;
					cliffPlacement.rot = quaternion;
					cliffPlacement.scale = vector3;
				}
				break;
			}
		}
		return cliffPlacement;
	}
}
