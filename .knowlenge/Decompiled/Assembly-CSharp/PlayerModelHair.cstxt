using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class PlayerModelHair : MonoBehaviour
{
	public struct RendererMaterials
	{
		public string[] names;

		public Material[] original;

		public Material[] replacement;

		public RendererMaterials(Renderer r)
		{
			original = r.sharedMaterials;
			replacement = original.Clone() as Material[];
			names = new string[original.Length];
			for (int i = 0; i < original.Length; i++)
			{
				names[i] = original[i].name;
			}
		}
	}

	public HairType type;

	private Dictionary<Renderer, RendererMaterials> materials;

	public Dictionary<Renderer, RendererMaterials> Materials => materials;

	private void CacheOriginalMaterials()
	{
		if (materials != null)
		{
			return;
		}
		List<SkinnedMeshRenderer> obj = Pool.Get<List<SkinnedMeshRenderer>>();
		base.gameObject.GetComponentsInChildren(includeInactive: true, obj);
		materials = new Dictionary<Renderer, RendererMaterials>();
		materials.Clear();
		foreach (SkinnedMeshRenderer item in obj)
		{
			materials.Add(item, new RendererMaterials(item));
		}
		Pool.FreeUnmanaged(ref obj);
	}

	private void Setup(HairType type, HairSetCollection hair, int meshIndex, float typeNum, float dyeNum, MaterialPropertyBlock block)
	{
		CacheOriginalMaterials();
		HairSetCollection.HairSetEntry hairSetEntry = hair.Get(type, typeNum);
		if (hairSetEntry.HairSet == null)
		{
			Debug.LogWarning("Hair.Get returned a NULL hair");
			return;
		}
		int blendShapeIndex = -1;
		if (type == HairType.Facial || type == HairType.Eyebrow)
		{
			blendShapeIndex = meshIndex;
		}
		HairDye dye = null;
		HairDyeCollection hairDyeCollection = hairSetEntry.HairDyeCollection;
		if (hairDyeCollection != null)
		{
			dye = hairDyeCollection.Get(dyeNum);
		}
		hairSetEntry.HairSet.Process(this, hairDyeCollection, dye, block);
		hairSetEntry.HairSet.ProcessMorphs(base.gameObject, blendShapeIndex);
	}

	public void Setup(SkinSetCollection skin, float hairNum, float meshNum, MaterialPropertyBlock block)
	{
		int index = skin.GetIndex(meshNum);
		SkinSet skinSet = skin.Skins[index];
		if (skinSet == null)
		{
			Debug.LogError("Skin.Get returned a NULL skin");
			return;
		}
		int typeIndex = (int)type;
		GetRandomVariation(hairNum, typeIndex, index, out var typeNum, out var dyeNum);
		Setup(type, skinSet.HairCollection, index, typeNum, dyeNum, block);
	}

	public static void GetRandomVariation(float hairNum, int typeIndex, int meshIndex, out float typeNum, out float dyeNum)
	{
		int num = Mathf.FloorToInt(hairNum * 100000f);
		typeNum = GetRandomHairType(hairNum, typeIndex);
		Random.InitState(num + meshIndex);
		dyeNum = Random.Range(0f, 1f);
	}

	public static float GetRandomHairType(float hairNum, int typeIndex)
	{
		Random.InitState(Mathf.FloorToInt(hairNum * 100000f) + typeIndex);
		return Random.Range(0f, 1f);
	}
}
