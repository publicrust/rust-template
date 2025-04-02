using UnityEngine;

public static class PoolableEx
{
	public static bool SupportsPoolingInParent(this GameObject gameObject)
	{
		Poolable componentInParent = gameObject.GetComponentInParent<Poolable>();
		if (componentInParent != null)
		{
			return componentInParent.prefabID != 0;
		}
		return false;
	}

	public static bool SupportsPooling(this GameObject gameObject)
	{
		Poolable component = gameObject.GetComponent<Poolable>();
		if (component != null)
		{
			return component.prefabID != 0;
		}
		return false;
	}

	public static void AwakeFromInstantiate(this GameObject gameObject)
	{
		if (gameObject.activeSelf)
		{
			gameObject.GetComponent<Poolable>().SetBehaviourEnabled(state: true);
		}
		else
		{
			gameObject.SetActive(value: true);
		}
	}
}
