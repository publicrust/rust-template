using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Environment Volume Properties Collection")]
public class EnvironmentVolumePropertiesCollection : ScriptableObject
{
	[Serializable]
	public class EnvironmentMultiplier
	{
		public EnvironmentType Type;

		public float Multiplier;
	}

	[Serializable]
	public class OceanParameters
	{
		[Header("Lighting")]
		public AnimationCurve TransitionCurveLighting = AnimationCurve.Linear(0f, 0f, 40f, 1f);

		[Range(0f, 1f)]
		public float DirectionalLightMultiplier = 0.25f;

		[Range(0f, 1f)]
		public float AmbientLightMultiplier;

		[Range(0f, 1f)]
		public float ReflectionMultiplier = 1f;

		[Header("Sun/Moon")]
		public AnimationCurve TransitionCurveSunMoon = AnimationCurve.Linear(0f, 0f, 40f, 1f);

		[Range(0f, 1f)]
		public float SunMeshBrightnessMultiplier = 1f;

		[Range(0f, 1f)]
		public float MoonMeshBrightnessMultiplier = 1f;

		[Header("Atmosphere")]
		public AnimationCurve TransitionCurveAtmosphere = AnimationCurve.Linear(0f, 0f, 40f, 1f);

		[Range(0f, 1f)]
		public float AtmosphereBrightnessMultiplier = 1f;

		[Header("Colors")]
		public AnimationCurve TransitionCurve = AnimationCurve.Linear(0f, 0f, 40f, 1f);

		[Range(0f, 1f)]
		public float LightColorMultiplier = 1f;

		public Color LightColor = Color.black;

		[Range(0f, 1f)]
		public float SunRayColorMultiplier = 1f;

		public Color SunRayColor = Color.black;

		[Range(0f, 1f)]
		public float MoonRayColorMultiplier = 1f;

		public Color MoonRayColor = Color.black;
	}

	public float TransitionSpeed = 1f;

	public LayerMask ReflectionMask = 1084293120;

	[Horizontal(1, 0)]
	public EnvironmentMultiplier[] ReflectionMultipliers;

	public float DefaultReflectionMultiplier = 1f;

	[Horizontal(1, 0)]
	public EnvironmentMultiplier[] AmbientMultipliers;

	public float DefaultAmbientMultiplier = 1f;

	public OceanParameters OceanOverrides;
}
