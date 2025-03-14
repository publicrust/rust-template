using System;
using System.Collections.Generic;
using Facepunch;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Hair Set")]
public class HairSet : ScriptableObject
{
	[Serializable]
	public class MeshReplace
	{
		[HideInInspector]
		public string FindName;

		public Mesh Find;

		public Mesh[] ReplaceShapes;

		public bool Test(string materialName)
		{
			return FindName == materialName;
		}
	}

	public MeshReplace[] MeshReplacements;

	public void Process(PlayerModelHair playerModelHair, HairDyeCollection dyeCollection, HairDye dye, MaterialPropertyBlock block)
	{
		List<SkinnedMeshRenderer> obj = Pool.Get<List<SkinnedMeshRenderer>>();
		playerModelHair.gameObject.GetComponentsInChildren(includeInactive: true, obj);
		foreach (SkinnedMeshRenderer item in obj)
		{
			if (!(item.sharedMesh == null) && !(item.sharedMaterial == null))
			{
				string materialName = item.sharedMesh.name;
				_ = item.sharedMaterial.name;
				if (!item.gameObject.activeSelf)
				{
					item.gameObject.SetActive(value: true);
				}
				for (int i = 0; i < MeshReplacements.Length; i++)
				{
					MeshReplacements[i].Test(materialName);
				}
				if (dye != null && item.gameObject.activeSelf)
				{
					dye.Apply(dyeCollection, block);
				}
			}
		}
		Pool.FreeUnmanaged(ref obj);
	}

	public void ProcessMorphs(GameObject obj, int blendShapeIndex = -1)
	{
	}
}
