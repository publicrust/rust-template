using UnityEngine;

public static class AssetStorage
{
	public static void Save<T>(ref T asset, string path) where T : Object
	{
		Object.op_Implicit((Object)(object)asset);
	}

	public static void Save(ref Texture2D asset)
	{
	}

	public static void Save(ref Texture2D asset, string path, bool linear, bool compress)
	{
		Object.op_Implicit((Object)(object)asset);
	}

	public static void Load<T>(ref T asset, string path) where T : Object
	{
	}

	public static void Delete<T>(ref T asset) where T : Object
	{
		if (Object.op_Implicit((Object)(object)asset))
		{
			Object.Destroy((Object)(object)asset);
			asset = default(T);
		}
	}
}
