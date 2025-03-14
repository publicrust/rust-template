using System;
using UnityEngine;

public class SnowmobileChassisVisuals : VehicleChassisVisuals<Snowmobile>, IClientComponent
{
	[Serializable]
	private class TreadRenderer
	{
		public Renderer renderer;

		public int materialIndex;
	}

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private SnowmobileAudio audioScript;

	[SerializeField]
	private TreadRenderer[] treadRenderers;

	[SerializeField]
	private float treadSpeedMultiplier = 0.01f;

	[SerializeField]
	private bool flipRightSkiExtension;

	[SerializeField]
	private Transform leftSki;

	[SerializeField]
	private Transform leftSkiPistonIn;

	[SerializeField]
	private Transform leftSkiPistonOut;

	[SerializeField]
	private Transform rightSki;

	[SerializeField]
	private Transform rightSkiPistonIn;

	[SerializeField]
	private Transform rightSkiPistonOut;

	[SerializeField]
	private float skiVisualAdjust;

	[SerializeField]
	private float treadVisualAdjust;

	[SerializeField]
	private float skiVisualMaxExtension;

	[SerializeField]
	private float treadVisualMaxExtension;

	[SerializeField]
	private float wheelSizeVisualMultiplier = 1f;
}
