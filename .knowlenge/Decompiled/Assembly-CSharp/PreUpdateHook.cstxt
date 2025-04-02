using System;
using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class PreUpdateHook : MonoBehaviour
{
	public static Action OnUpdate;

	public static Action OnLateUpdate;

	public static Action OnFixedUpdate;

	public static Action PostPhysicsUpdate;

	public static Action StartOfFrame;

	private static int lastStartOfFrame;

	private void Start()
	{
		StartCoroutine(AfterPhysicsUpdate());
	}

	private void Update()
	{
		TryRunStartOfFrame();
		OnUpdate?.Invoke();
	}

	private void LateUpdate()
	{
		OnLateUpdate?.Invoke();
	}

	private void FixedUpdate()
	{
		TryRunStartOfFrame();
		OnFixedUpdate?.Invoke();
	}

	private void TryRunStartOfFrame()
	{
		int frameCount = Time.frameCount;
		if (lastStartOfFrame != frameCount)
		{
			lastStartOfFrame = frameCount;
			StartOfFrame?.Invoke();
		}
	}

	private IEnumerator AfterPhysicsUpdate()
	{
		while (Application.isPlaying)
		{
			yield return CoroutineEx.waitForFixedUpdate;
			PostPhysicsUpdate?.Invoke();
		}
	}
}
