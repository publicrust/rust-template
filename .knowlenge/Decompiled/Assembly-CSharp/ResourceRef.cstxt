using System;
using UnityEngine;

[Serializable]
public class ResourceRef<T> where T : UnityEngine.Object
{
	public string guid;

	protected T _cachedObject;

	public bool isValid => !string.IsNullOrEmpty(guid);

	public string resourcePath => GameManifest.GUIDToPath(guid);

	public uint resourceID => StringPool.Get(resourcePath);

	public virtual T Get()
	{
		if (_cachedObject == null)
		{
			_cachedObject = GameManifest.GUIDToObject(guid) as T;
		}
		return _cachedObject;
	}
}
