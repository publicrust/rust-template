using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Skeleton Properties")]
public class SkeletonProperties : ScriptableObject
{
	[Serializable]
	public class BoneProperty
	{
		public GameObject bone;

		public Translate.Phrase name;

		public HitArea area;
	}

	public GameObject boneReference;

	[BoneProperty]
	public BoneProperty[] bones;

	[NonSerialized]
	private Dictionary<uint, BoneProperty> quickLookup;

	public void OnValidate()
	{
		if (boneReference == null)
		{
			Debug.LogWarning("boneReference is null on " + base.name, this);
			return;
		}
		List<BoneProperty> list = bones.ToList();
		foreach (Transform child in TransformEx.GetAllChildren(boneReference.transform))
		{
			if (list.All((BoneProperty x) => x.bone != child.gameObject))
			{
				list.Add(new BoneProperty
				{
					bone = child.gameObject,
					name = new Translate.Phrase
					{
						token = child.name.ToLower(),
						english = child.name.ToLower()
					}
				});
			}
		}
		bones = list.ToArray();
	}

	private void BuildDictionary()
	{
		quickLookup = new Dictionary<uint, BoneProperty>();
		if (boneReference == null)
		{
			Debug.LogWarning("boneReference is null on " + base.name, this);
			return;
		}
		BoneProperty[] array = bones;
		foreach (BoneProperty boneProperty in array)
		{
			if (boneProperty == null || boneProperty.bone == null || boneProperty.bone.name == null)
			{
				Debug.LogWarning("Bone error in SkeletonProperties.BuildDictionary for " + boneReference.name);
				continue;
			}
			uint key = StringPool.Get(boneProperty.bone.name);
			if (!quickLookup.ContainsKey(key))
			{
				quickLookup.Add(key, boneProperty);
				continue;
			}
			string text = boneProperty.bone.name;
			string text2 = quickLookup[key].bone.name;
			Debug.LogWarning("Duplicate bone id " + key + " for " + text + " and " + text2);
		}
	}

	public BoneProperty FindBone(uint id)
	{
		if (quickLookup == null)
		{
			BuildDictionary();
		}
		BoneProperty value = null;
		if (!quickLookup.TryGetValue(id, out value))
		{
			return null;
		}
		return value;
	}
}
