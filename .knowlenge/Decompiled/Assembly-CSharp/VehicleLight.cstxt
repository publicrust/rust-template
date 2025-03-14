using System;
using UnityEngine;

public class VehicleLight : MonoBehaviour, IClientComponent
{
	[Serializable]
	public class LightRenderer
	{
		public Renderer renderer;

		public int matIndex;
	}

	public bool IsBrake;

	public GameObject toggleObject;

	public LightRenderer[] renderers;

	[ColorUsage(true, true)]
	public Color lightOnColour;

	[ColorUsage(true, true)]
	public Color brakesOnColour;

	public bool applyToTransmittance;

	public bool useLightOnColourForBrake;
}
