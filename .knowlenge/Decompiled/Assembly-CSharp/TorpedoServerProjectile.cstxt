using UnityEngine;

public class TorpedoServerProjectile : ServerProjectile
{
	[SerializeField]
	[Tooltip("Make sure to leave some allowance for waves, which affect the true depth.")]
	private float minWaterDepth = 0.5f;

	[SerializeField]
	private float shallowWaterInaccuracy;

	[SerializeField]
	private float deepWaterInaccuracy;

	[SerializeField]
	private float shallowWaterCutoff = 2f;

	public override bool HasRangeLimit => false;

	protected override int mask => 1237003009;

	public override bool DoMovement()
	{
		if (!base.DoMovement())
		{
			return false;
		}
		float num = WaterLevel.GetWaterInfo(base.transform.position, waves: true, volumes: false).surfaceLevel - base.transform.position.y;
		if (num < -1f)
		{
			gravityModifier = 1f;
		}
		else if (num <= minWaterDepth)
		{
			Vector3 currentVelocity = base.CurrentVelocity;
			currentVelocity.y = 0f;
			base.CurrentVelocity = currentVelocity;
			gravityModifier = 0.1f;
		}
		else if (num > minWaterDepth + 0.3f && num <= minWaterDepth + 0.7f)
		{
			gravityModifier = -0.1f;
		}
		else
		{
			gravityModifier = Mathf.Clamp(base.CurrentVelocity.y, -0.1f, 0.1f);
		}
		return true;
	}

	public override void InitializeVelocity(Vector3 overrideVel)
	{
		base.InitializeVelocity(overrideVel);
		float value = WaterLevel.GetWaterInfo(base.transform.position, waves: true, volumes: false).surfaceLevel - base.transform.position.y;
		float t = Mathf.InverseLerp(shallowWaterCutoff, shallowWaterCutoff + 2f, value);
		float maxAngle = Mathf.Lerp(shallowWaterInaccuracy, deepWaterInaccuracy, t);
		initialVelocity = initialVelocity.GetWithInaccuracy(maxAngle);
		base.CurrentVelocity = initialVelocity;
	}
}
