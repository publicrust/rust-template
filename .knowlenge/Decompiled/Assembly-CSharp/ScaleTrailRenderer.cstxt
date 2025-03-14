using System;
using UnityEngine;

public class ScaleTrailRenderer : ScaleRenderer
{
	private TrailRenderer trailRenderer;

	[NonSerialized]
	private float startWidth;

	[NonSerialized]
	private float endWidth;

	[NonSerialized]
	private float duration;

	[NonSerialized]
	private float startMultiplier;

	public override void GatherInitialValues()
	{
		base.GatherInitialValues();
		if ((bool)myRenderer)
		{
			trailRenderer = myRenderer.GetComponent<TrailRenderer>();
		}
		else
		{
			trailRenderer = GetComponentInChildren<TrailRenderer>();
		}
		startWidth = trailRenderer.startWidth;
		endWidth = trailRenderer.endWidth;
		duration = trailRenderer.time;
		startMultiplier = trailRenderer.widthMultiplier;
	}

	public override void SetScale_Internal(float scale)
	{
		if (scale == 0f)
		{
			trailRenderer.emitting = false;
			trailRenderer.enabled = false;
			trailRenderer.time = 0f;
			trailRenderer.Clear();
			return;
		}
		if (!trailRenderer.emitting)
		{
			trailRenderer.Clear();
		}
		trailRenderer.emitting = true;
		trailRenderer.enabled = true;
		base.SetScale_Internal(scale);
		trailRenderer.widthMultiplier = startMultiplier * scale;
		trailRenderer.time = duration * scale;
	}
}
