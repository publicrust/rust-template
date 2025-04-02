using System;
using UnityEngine;

public class AudioVisualisationEntityLight : AudioVisualisationEntity
{
	[Serializable]
	public struct LightColourSet
	{
		[ColorUsage(true, true)]
		public Color LightColor;

		[ColorUsage(true, true)]
		public Color SecondaryLightColour;

		[ColorUsage(true, true)]
		public Color EmissionColour;
	}

	public Light TargetLight;

	public Light SecondaryLight;

	public MeshRenderer[] TargetRenderer;

	public LightColourSet RedColour;

	public LightColourSet GreenColour;

	public LightColourSet BlueColour;

	public LightColourSet YellowColour;

	public LightColourSet PinkColour;

	public float lightMinIntensity = 0.05f;

	public float lightMaxIntensity = 1f;
}
