using System.Collections.Generic;
using Rust;
using UnityEngine;

public abstract class BaseScreenShake : MonoBehaviour
{
	public static List<BaseScreenShake> list = new List<BaseScreenShake>();

	internal static float punchFadeScale = 0f;

	internal static float bobScale = 0f;

	internal static float animPunchMagnitude = 10f;

	internal static AnimationCurve InverseCurve = AnimationCurve.Linear(0f, 1f, 1f, 0.05f);

	public float length = 2f;

	internal float timeTaken;

	private int currentFrame = -1;

	public static void Apply(Camera cam, BaseViewModel vm)
	{
		CachedTransform<Camera> cam2 = new CachedTransform<Camera>(cam);
		CachedTransform<BaseViewModel> vm2 = new CachedTransform<BaseViewModel>(vm);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].Run(ref cam2, ref vm2);
		}
		cam2.Apply();
		vm2.Apply();
	}

	protected void OnEnable()
	{
		list.Add(this);
		timeTaken = 0f;
		Setup();
	}

	protected void OnDisable()
	{
		if (!Rust.Application.isQuitting)
		{
			list.Remove(this);
		}
	}

	public void Run(ref CachedTransform<Camera> cam, ref CachedTransform<BaseViewModel> vm)
	{
		if (!(timeTaken > length))
		{
			if (Time.frameCount != currentFrame)
			{
				timeTaken += Time.deltaTime;
				currentFrame = Time.frameCount;
			}
			float delta = Mathf.InverseLerp(0f, length, timeTaken);
			Run(delta, ref cam, ref vm);
		}
	}

	public abstract void Setup();

	public abstract void Run(float delta, ref CachedTransform<Camera> cam, ref CachedTransform<BaseViewModel> vm);
}
