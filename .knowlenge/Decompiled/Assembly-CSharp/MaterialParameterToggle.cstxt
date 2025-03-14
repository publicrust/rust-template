using System;
using UnityEngine;

public class MaterialParameterToggle : MonoBehaviour
{
	[Flags]
	public enum ToggleMode
	{
		Detail = 0,
		Emission = 1
	}

	[InspectorFlags]
	public ToggleMode Toggle;

	public Renderer[] TargetRenderers = new Renderer[0];

	[ColorUsage(true, true)]
	public Color EmissionColor;
}
