using System;
using System.Collections.Generic;
using UnityEngine;

public class BoneDictionary
{
	public Transform transform;

	public Transform[] transforms;

	public string[] names;

	private Dictionary<string, Transform> nameDict = new Dictionary<string, Transform>(StringComparer.OrdinalIgnoreCase);

	private Dictionary<uint, Transform> hashDict = new Dictionary<uint, Transform>();

	private Dictionary<Transform, uint> transformDict = new Dictionary<Transform, uint>();

	public int Count => transforms.Length;

	public BoneDictionary(Transform rootBone)
	{
		this.transform = rootBone;
		transforms = rootBone.GetComponentsInChildren<Transform>(includeInactive: true);
		names = new string[transforms.Length];
		for (int i = 0; i < transforms.Length; i++)
		{
			Transform transform = transforms[i];
			if (transform != null)
			{
				names[i] = transform.name;
			}
		}
		BuildBoneDictionary();
	}

	public BoneDictionary(Transform rootBone, Transform[] boneTransforms, string[] boneNames)
	{
		transform = rootBone;
		transforms = boneTransforms;
		names = boneNames;
		BuildBoneDictionary();
	}

	private void BuildBoneDictionary()
	{
		for (int i = 0; i < transforms.Length; i++)
		{
			Transform transform = transforms[i];
			string text = names[i];
			uint num = StringPool.Get(text);
			if (!nameDict.ContainsKey(text))
			{
				nameDict.Add(text, transform);
			}
			if (!hashDict.ContainsKey(num))
			{
				hashDict.Add(num, transform);
			}
			if (transform != null && !transformDict.ContainsKey(transform))
			{
				transformDict.Add(transform, num);
			}
		}
	}

	public Transform FindBone(string name, bool defaultToRoot = true)
	{
		Transform value = null;
		if (nameDict.TryGetValue(name, out value))
		{
			return value;
		}
		if (!defaultToRoot)
		{
			return null;
		}
		return transform;
	}

	public Transform FindBone(uint hash, bool defaultToRoot = true)
	{
		Transform value = null;
		if (hashDict.TryGetValue(hash, out value))
		{
			return value;
		}
		if (!defaultToRoot)
		{
			return null;
		}
		return transform;
	}

	public uint FindBoneID(Transform transform)
	{
		if (!transformDict.TryGetValue(transform, out var value))
		{
			return StringPool.closest;
		}
		return value;
	}
}
