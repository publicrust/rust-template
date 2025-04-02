using System;
using UnityEngine;

public class ScaleParticleSystem : ScaleRenderer
{
	public ParticleSystem pSystem;

	public bool scaleGravity;

	[NonSerialized]
	private float startSize;

	[NonSerialized]
	private float startLifeTime;

	[NonSerialized]
	private float startSpeed;

	[NonSerialized]
	private float startGravity;

	public override void GatherInitialValues()
	{
		base.GatherInitialValues();
		startGravity = pSystem.gravityModifier;
		startSpeed = pSystem.startSpeed;
		startSize = pSystem.startSize;
		startLifeTime = pSystem.startLifetime;
	}

	public override void SetScale_Internal(float scale)
	{
		base.SetScale_Internal(scale);
		pSystem.startSize = startSize * scale;
		pSystem.startLifetime = startLifeTime * scale;
		pSystem.startSpeed = startSpeed * scale;
		pSystem.gravityModifier = startGravity * scale;
	}
}
