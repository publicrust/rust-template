using System;
using UnityEngine;

public class LifeScale : BaseMonoBehaviour
{
	[NonSerialized]
	private bool initialized;

	[NonSerialized]
	private Vector3 initialScale;

	public Vector3 finalScale = Vector3.one;

	private Vector3 targetLerpScale = Vector3.zero;

	private Action updateScaleAction;

	protected void Awake()
	{
		updateScaleAction = UpdateScale;
	}

	public void OnEnable()
	{
		Init();
		base.transform.localScale = initialScale;
	}

	public void SetProgress(float progress)
	{
		Init();
		targetLerpScale = Vector3.Lerp(initialScale, finalScale, progress);
		InvokeRepeating(updateScaleAction, 0f, 0.015f);
	}

	public void Init()
	{
		if (!initialized)
		{
			initialScale = base.transform.localScale;
			initialized = true;
		}
	}

	public void UpdateScale()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, targetLerpScale, Time.deltaTime);
		if (base.transform.localScale == targetLerpScale)
		{
			targetLerpScale = Vector3.zero;
			CancelInvoke(updateScaleAction);
		}
	}
}
