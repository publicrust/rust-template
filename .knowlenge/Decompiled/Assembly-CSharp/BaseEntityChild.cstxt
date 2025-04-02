using System;
using Rust;
using Rust.Registry;
using UnityEngine;

public class BaseEntityChild : MonoBehaviour
{
	public static void Setup(GameObject obj, BaseEntity parent)
	{
		TimeWarning val = TimeWarning.New("Registry.Entity.Register", 0);
		try
		{
			Entity.Register(obj, (IEntity)(object)parent);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public void OnDestroy()
	{
		if (Application.isQuitting)
		{
			return;
		}
		TimeWarning val = TimeWarning.New("Registry.Entity.Unregister", 0);
		try
		{
			Entity.Unregister(((Component)this).gameObject);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}
}
