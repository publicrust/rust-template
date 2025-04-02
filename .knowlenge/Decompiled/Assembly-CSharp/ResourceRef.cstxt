using System;
using UnityEngine;

[Serializable]
public class ResourceRef<T> where T : Object
{
	public string guid;

	protected T _cachedObject;

	public bool isValid => !string.IsNullOrEmpty(guid);

	public string resourcePath => GameManifest.GUIDToPath(guid);

	public uint resourceID => StringPool.Get(resourcePath);

	public virtual T Get()
	{
		if ((Object)(object)_cachedObject == (Object)null)
		{
			ref T cachedObject = ref _cachedObject;
			Object obj = GameManifest.GUIDToObject(guid);
			cachedObject = (T)(object)((obj is T) ? obj : null);
		}
		return _cachedObject;
	}
}
