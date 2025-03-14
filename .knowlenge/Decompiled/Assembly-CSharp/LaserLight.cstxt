using System;
using UnityEngine;

public class LaserLight : AudioVisualisationEntity
{
	[Serializable]
	public struct ColourSetting
	{
		public Color PointLightColour;

		public Material LaserMaterial;

		public Color DotColour;

		public Color FlareColour;
	}

	public Animator LaserAnimator;

	public LineRenderer[] LineRenderers;

	public MeshRenderer[] DotRenderers;

	public MeshRenderer FlareRenderer;

	public Light[] LightSources;

	public ColourSetting RedSettings;

	public ColourSetting GreenSettings;

	public ColourSetting BlueSettings;

	public ColourSetting YellowSettings;

	public ColourSetting PinkSettings;

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
	}
}
