using System;
using UnityEngine;

[Serializable]
public class TOD_FogParameters
{
	[Tooltip("Fog color mode.")]
	public TOD_FogType Mode = TOD_FogType.Atmosphere;

	[Tooltip("Fog color sampling height.\n = 0 fog is atmosphere color at horizon.\n = 1 fog is atmosphere color at zenith.")]
	[TOD_Range(0f, 1f)]
	public float HeightBias;
}
