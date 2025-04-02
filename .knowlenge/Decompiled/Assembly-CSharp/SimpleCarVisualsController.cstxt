using System;
using UnityEngine;

[Serializable]
public class SimpleCarVisualsController
{
	public enum RotationAxis
	{
		X,
		Z,
		Y
	}

	[Header("Simple Visuals Settings")]
	public float wheelLerpSpeed = 5f;

	public float wheelAngleMaximum = 40f;

	public float timeSinceLastUpdateMinimum = 0.5f;

	[Tooltip("Should the wheels be rotated on the Y axis?")]
	public RotationAxis rotateAxis = RotationAxis.Z;

	public RotationAxis steerAxis;

	public TimeSince timeSinceUpdated;

	public void Updated()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		timeSinceUpdated = TimeSince.op_Implicit(0f);
	}
}
