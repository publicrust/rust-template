using System;
using UnityEngine;

[Serializable]
public class BaseEntityRef : ResourceRef<BaseEntity>
{
	public override BaseEntity Get()
	{
		if (_cachedObject != null)
		{
			return _cachedObject;
		}
		GameObject gameObject = GameManifest.GUIDToObject(guid) as GameObject;
		BaseEntity component = null;
		if (gameObject != null && gameObject.TryGetComponent<BaseEntity>(out component))
		{
			_cachedObject = component;
		}
		return component;
	}
}
