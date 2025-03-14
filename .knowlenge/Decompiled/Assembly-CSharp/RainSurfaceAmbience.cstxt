using System;
using System.Collections.Generic;
using UnityEngine;

public class RainSurfaceAmbience : MonoBehaviour
{
	[Serializable]
	public class SurfaceSound
	{
		public SoundDefinition soundDef;

		public List<PhysicMaterial> materials = new List<PhysicMaterial>();

		[HideInInspector]
		public Sound sound;

		[HideInInspector]
		public float amount;

		[HideInInspector]
		public Vector3 position = Vector3.zero;

		[HideInInspector]
		public Bounds bounds;

		[HideInInspector]
		public List<Vector3> points = new List<Vector3>();

		[HideInInspector]
		public SoundModulation.Modulator gainMod;

		[HideInInspector]
		public SoundModulation.Modulator spreadMod;
	}

	public float tickRate = 1f;

	public float gridSize = 20f;

	public float gridSamples = 10f;

	public float startHeight = 100f;

	public float rayLength = 250f;

	public LayerMask layerMask;

	public float spreadScale = 8f;

	public float maxDistance = 10f;

	public float lerpSpeed = 5f;

	public List<SurfaceSound> surfaces = new List<SurfaceSound>();
}
