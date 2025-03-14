using System;
using Facepunch;
using UnityEngine;

[Serializable]
public class GameObjectRef : ResourceRef<GameObject>
{
	public GameObject Instantiate(Transform parent = null)
	{
		return Facepunch.Instantiate.GameObject(Get(), parent);
	}

	public BaseEntity GetEntity()
	{
		GameObject gameObject = Get();
		if (!(gameObject == null))
		{
			return gameObject.GetComponent<BaseEntity>();
		}
		return null;
	}
}
