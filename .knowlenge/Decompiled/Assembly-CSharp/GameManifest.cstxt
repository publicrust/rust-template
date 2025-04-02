using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GameManifest : ScriptableObject
{
	[Serializable]
	public struct PooledString
	{
		[HideInInspector]
		public string str;

		public uint hash;
	}

	[Serializable]
	public class PrefabProperties
	{
		[HideInInspector]
		public string name;

		public string guid;

		public uint hash;

		public bool pool;
	}

	[Serializable]
	public class EffectCategory
	{
		[HideInInspector]
		public string folder;

		public List<string> prefabs;
	}

	[Serializable]
	public class GuidPath
	{
		[HideInInspector]
		public string name;

		public string guid;
	}

	internal static GameManifest loadedManifest;

	public static Dictionary<string, string> guidToPath = new Dictionary<string, string>();

	public static Dictionary<string, string> pathToGuid = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

	public static Dictionary<string, UnityEngine.Object> guidToObject = new Dictionary<string, UnityEngine.Object>();

	public PooledString[] pooledStrings;

	public PrefabProperties[] prefabProperties;

	public EffectCategory[] effectCategories;

	public GuidPath[] guidPaths;

	public string[] entities;

	public static GameManifest Current
	{
		get
		{
			if (loadedManifest != null)
			{
				return loadedManifest;
			}
			Load();
			return loadedManifest;
		}
	}

	public static void Load()
	{
		if (loadedManifest != null)
		{
			return;
		}
		loadedManifest = FileSystem.Load<GameManifest>("Assets/manifest.asset");
		PrefabProperties[] array = loadedManifest.prefabProperties;
		foreach (PrefabProperties prefabProperties in array)
		{
			guidToPath.Add(prefabProperties.guid, prefabProperties.name);
			pathToGuid.Add(prefabProperties.name, prefabProperties.guid);
		}
		GuidPath[] array2 = loadedManifest.guidPaths;
		foreach (GuidPath guidPath in array2)
		{
			if (!guidToPath.ContainsKey(guidPath.guid))
			{
				guidToPath.Add(guidPath.guid, guidPath.name);
				pathToGuid.Add(guidPath.name, guidPath.guid);
			}
		}
		DebugEx.Log(GetMetadataStatus());
	}

	public static void LoadAssets()
	{
		if (Skinnable.All == null)
		{
			Skinnable.All = FileSystem.LoadAllFromBundle<Skinnable>("skinnables.preload.bundle", "t:Skinnable");
			if (Skinnable.All == null || Skinnable.All.Length == 0)
			{
				throw new Exception("Error loading skinnables");
			}
			DebugEx.Log(GetAssetStatus());
		}
	}

	internal static Dictionary<string, string[]> LoadEffectDictionary()
	{
		EffectCategory[] array = loadedManifest.effectCategories;
		Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
		EffectCategory[] array2 = array;
		foreach (EffectCategory effectCategory in array2)
		{
			dictionary.Add(effectCategory.folder, effectCategory.prefabs.ToArray());
		}
		return dictionary;
	}

	internal static string GUIDToPath(string guid)
	{
		if (string.IsNullOrEmpty(guid))
		{
			Debug.LogError("GUIDToPath: guid is empty");
			return string.Empty;
		}
		Load();
		if (guidToPath.TryGetValue(guid, out var value))
		{
			return value;
		}
		Debug.LogWarning("GUIDToPath: no path found for guid " + guid);
		return string.Empty;
	}

	internal static UnityEngine.Object GUIDToObject(string guid)
	{
		UnityEngine.Object value = null;
		if (guidToObject.TryGetValue(guid, out value))
		{
			return value;
		}
		string text = GUIDToPath(guid);
		if (string.IsNullOrEmpty(text))
		{
			Debug.LogWarning("Missing file for guid " + guid);
			guidToObject.Add(guid, null);
			return null;
		}
		UnityEngine.Object @object = FileSystem.Load<UnityEngine.Object>(text);
		guidToObject.Add(guid, @object);
		return @object;
	}

	public static void Invalidate(string path)
	{
		if (pathToGuid.TryGetValue(path, out var value) && guidToObject.TryGetValue(value, out var value2))
		{
			if (value2 != null)
			{
				UnityEngine.Object.DestroyImmediate(value2, allowDestroyingAssets: true);
			}
			guidToObject.Remove(value);
		}
	}

	private static string GetMetadataStatus()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (loadedManifest != null)
		{
			stringBuilder.Append("Manifest Metadata Loaded");
			stringBuilder.AppendLine();
			stringBuilder.Append("\t");
			stringBuilder.Append(loadedManifest.pooledStrings.Length.ToString());
			stringBuilder.Append(" pooled strings");
			stringBuilder.AppendLine();
			stringBuilder.Append("\t");
			stringBuilder.Append(loadedManifest.prefabProperties.Length.ToString());
			stringBuilder.Append(" prefab properties");
			stringBuilder.AppendLine();
			stringBuilder.Append("\t");
			stringBuilder.Append(loadedManifest.effectCategories.Length.ToString());
			stringBuilder.Append(" effect categories");
			stringBuilder.AppendLine();
			stringBuilder.Append("\t");
			stringBuilder.Append(loadedManifest.entities.Length.ToString());
			stringBuilder.Append(" entity names");
			stringBuilder.AppendLine();
		}
		else
		{
			stringBuilder.Append("Manifest Metadata Missing");
		}
		return stringBuilder.ToString();
	}

	private static string GetAssetStatus()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (loadedManifest != null)
		{
			stringBuilder.Append("Manifest Assets Loaded");
			stringBuilder.AppendLine();
			stringBuilder.Append("\t");
			stringBuilder.Append((Skinnable.All != null) ? Skinnable.All.Length.ToString() : "0");
			stringBuilder.Append(" skinnable objects");
		}
		else
		{
			stringBuilder.Append("Manifest Assets Missing");
		}
		return stringBuilder.ToString();
	}
}
