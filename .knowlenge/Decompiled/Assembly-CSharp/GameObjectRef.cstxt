using System;
using Facepunch;
using UnityEngine;

[Serializable]
public class GameObjectRef : ResourceRef<GameObject>
{
	public GameObject Instantiate(Transform parent = null)
	{
		return Instantiate.GameObject(Get(), parent);
	}

	public BaseEntity GetEntity()
	{
		GameObject val = Get();
		if (!((Object)(object)val == (Object)null))
		{
			return val.GetComponent<BaseEntity>();
		}
		return null;
	}
}
