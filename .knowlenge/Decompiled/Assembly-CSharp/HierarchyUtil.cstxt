using System;
using System.Collections.Generic;
using UnityEngine;

public static class HierarchyUtil
{
	public static Dictionary<string, GameObject> rootDict = new Dictionary<string, GameObject>(StringComparer.OrdinalIgnoreCase);

	public static GameObject GetRoot(string strName, bool groupActive = true, bool persistant = false)
	{
		if (rootDict.TryGetValue(strName, out var value))
		{
			if (value != null)
			{
				return value;
			}
			rootDict.Remove(strName);
		}
		value = new GameObject(strName);
		value.SetActive(groupActive);
		rootDict.Add(strName, value);
		if (persistant)
		{
			UnityEngine.Object.DontDestroyOnLoad(value);
		}
		return value;
	}
}
