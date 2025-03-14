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
		timeSinceUpdated = 0f;
	}
}
