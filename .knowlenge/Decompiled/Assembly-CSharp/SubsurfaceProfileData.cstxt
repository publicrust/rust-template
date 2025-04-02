using System;
using UnityEngine;

[Serializable]
public struct SubsurfaceProfileData
{
	[Range(0.1f, 100f)]
	public float ScatterRadius;

	[ColorUsage(false, false)]
	public Color SubsurfaceColor;

	[ColorUsage(false, false)]
	public Color FalloffColor;

	[ColorUsage(false, true)]
	public Color TransmissionTint;

	public static SubsurfaceProfileData Default
	{
		get
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			SubsurfaceProfileData result = default(SubsurfaceProfileData);
			result.ScatterRadius = 1.2f;
			result.SubsurfaceColor = new Color(0.48f, 0.41f, 0.28f);
			result.FalloffColor = new Color(1f, 0.37f, 0.3f);
			result.TransmissionTint = new Color(0.48f, 0.41f, 0.28f);
			return result;
		}
	}

	public static SubsurfaceProfileData Invalid
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			SubsurfaceProfileData result = default(SubsurfaceProfileData);
			result.ScatterRadius = 0f;
			result.SubsurfaceColor = Color.clear;
			result.FalloffColor = Color.clear;
			result.TransmissionTint = Color.clear;
			return result;
		}
	}
}
