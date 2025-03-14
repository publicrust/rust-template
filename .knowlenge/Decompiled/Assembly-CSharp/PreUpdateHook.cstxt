using System;
using UnityEngine;

public class PreUpdateHook : MonoBehaviour
{
	public static Action OnUpdate;

	public static Action OnLateUpdate;

	public static Action OnFixedUpdate;

	private void Update()
	{
		OnUpdate?.Invoke();
	}

	private void LateUpdate()
	{
		OnLateUpdate?.Invoke();
	}

	private void FixedUpdate()
	{
		OnFixedUpdate?.Invoke();
	}
}
