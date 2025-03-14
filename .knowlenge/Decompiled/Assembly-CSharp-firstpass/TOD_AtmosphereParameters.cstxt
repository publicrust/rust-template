using System;
using UnityEngine;

[Serializable]
public class TOD_AtmosphereParameters
{
	[Tooltip("Intensity of the atmospheric Rayleigh scattering.")]
	[TOD_Min(0f)]
	public float RayleighMultiplier = 1f;

	[Tooltip("Intensity of the atmospheric Mie scattering.")]
	[TOD_Min(0f)]
	public float MieMultiplier = 1f;

	[Tooltip("Overall brightness of the atmosphere.")]
	[TOD_Min(0f)]
	public float Brightness = 1.5f;

	[Tooltip("Overall contrast of the atmosphere.")]
	[TOD_Min(0f)]
	public float Contrast = 1.5f;

	[Tooltip("Directionality factor that determines the size of the glow around the sun.")]
	[TOD_Range(0f, 1f)]
	public float Directionality = 0.7f;

	[Tooltip("Density of the fog covering the sky.")]
	[TOD_Range(0f, 1f)]
	public float Fogginess;
}
