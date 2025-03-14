using System;
using UnityEngine;

[Serializable]
public class ResourceRef<T> where T : UnityEngine.Object
{
	public string guid;

	private T _cachedObject;

	public bool isValid => !string.IsNullOrEmpty(guid);

	public string resourcePath => GameManifest.GUIDToPath(guid);

	public uint resourceID => StringPool.Get(resourcePath);

	public T Get()
	{
		if (_cachedObject == null)
		{
			_cachedObject = GameManifest.GUIDToObject(guid) as T;
		}
		return _cachedObject;
	}
}
