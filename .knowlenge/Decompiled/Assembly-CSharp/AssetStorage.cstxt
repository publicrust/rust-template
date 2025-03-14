using UnityEngine;

public static class AssetStorage
{
	public static void Save<T>(ref T asset, string path) where T : Object
	{
		_ = (bool)asset;
	}

	public static void Save(ref Texture2D asset)
	{
	}

	public static void Save(ref Texture2D asset, string path, bool linear, bool compress)
	{
		_ = (bool)asset;
	}

	public static void Load<T>(ref T asset, string path) where T : Object
	{
	}

	public static void Delete<T>(ref T asset) where T : Object
	{
		if ((bool)asset)
		{
			Object.Destroy(asset);
			asset = null;
		}
	}
}
