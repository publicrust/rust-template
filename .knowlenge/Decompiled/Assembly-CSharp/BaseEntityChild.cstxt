using Rust;
using Rust.Registry;
using UnityEngine;

public class BaseEntityChild : MonoBehaviour
{
	public static void Setup(GameObject obj, BaseEntity parent)
	{
		using (TimeWarning.New("Registry.Entity.Register"))
		{
			Entity.Register(obj, parent);
		}
	}

	public void OnDestroy()
	{
		if (Rust.Application.isQuitting)
		{
			return;
		}
		using (TimeWarning.New("Registry.Entity.Unregister"))
		{
			Entity.Unregister(base.gameObject);
		}
	}
}
