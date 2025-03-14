using System;
using UnityEngine;

[Serializable]
public struct SubsurfaceProfileData
{
	[Range(0.1f, 50f)]
	public float ScatterRadius;

	[ColorUsage(false, true, 1f, 1f, 1f, 1f)]
	public Color SubsurfaceColor;

	[ColorUsage(false, true, 1f, 1f, 1f, 1f)]
	public Color FalloffColor;

	public static SubsurfaceProfileData Default
	{
		get
		{
			SubsurfaceProfileData result = default(SubsurfaceProfileData);
			result.ScatterRadius = 1.2f;
			result.SubsurfaceColor = new Color(0.48f, 0.41f, 0.28f);
			result.FalloffColor = new Color(1f, 0.37f, 0.3f);
			return result;
		}
	}

	public static SubsurfaceProfileData Invalid
	{
		get
		{
			SubsurfaceProfileData result = default(SubsurfaceProfileData);
			result.ScatterRadius = 0f;
			result.SubsurfaceColor = Color.clear;
			result.FalloffColor = Color.clear;
			return result;
		}
	}
}
