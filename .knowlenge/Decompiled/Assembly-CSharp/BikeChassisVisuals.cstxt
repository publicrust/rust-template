using System;
using UnityEngine;

public class BikeChassisVisuals : VehicleChassisVisuals<Bike>, IClientComponent
{
	[Serializable]
	private class SuspensionSettings
	{
		public bool enabled;

		public Transform front;

		public float frontMinZ = 0.3f;

		public float frontMaxZ = 0.55f;

		public Transform rearTop;

		public Transform rearBottom;

		public Transform rearSwingArm;

		public float swingArmMinAngle = 5f;

		public float swingArmMaxAngle = 25f;
	}

	[Serializable]
	private class PedalBikeSettings
	{
		public bool enabled;

		public Transform axle;

		public float ratio = 0.5f;

		public Transform left;

		public Transform right;

		public Transform[] clockwiseCogs;

		public Transform[] anticlockwiseCogs;

		public float cogRatio = 1f;
	}

	[Serializable]
	private class KickstandSettiongs
	{
		public bool enabled;

		public Transform pivot;

		public Transform spring;

		public Transform springTarget;

		public float kickstandZ;

		public float upX = 180f;

		public float downX = 80f;
	}

	[Serializable]
	private class ChainRenderer
	{
		public Renderer renderer;

		public int materialIndex;
	}

	[SerializeField]
	private SuspensionSettings suspension;

	[SerializeField]
	private PedalBikeSettings pedals;

	[SerializeField]
	private KickstandSettiongs kickstand;

	[SerializeField]
	private BikeVehicleAudio audioScript;

	[SerializeField]
	private ChainRenderer[] chainRenderers;

	[SerializeField]
	private float chainSpeedMultiplier = 1f;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private float minGroundFXSpeed = 3f;
}
