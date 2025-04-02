using System;
using UnityEngine;

[Serializable]
public class BaseEntityRef : ResourceRef<BaseEntity>
{
	public override BaseEntity Get()
	{
		if ((Object)(object)_cachedObject != (Object)null)
		{
			return _cachedObject;
		}
		Object obj = GameManifest.GUIDToObject(guid);
		GameObject val = (GameObject)(object)((obj is GameObject) ? obj : null);
		BaseEntity baseEntity = null;
		if ((Object)(object)val != (Object)null && val.TryGetComponent<BaseEntity>(ref baseEntity))
		{
			_cachedObject = baseEntity;
		}
		return baseEntity;
	}
}
