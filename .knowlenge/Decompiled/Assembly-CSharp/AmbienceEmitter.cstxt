using System;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceEmitter : MonoBehaviour, IClientComponent, IComparable<AmbienceEmitter>
{
	public AmbienceDefinitionList baseAmbience;

	public AmbienceDefinitionList stings;

	public bool isStatic = true;

	public bool followCamera;

	public bool isBaseEmitter;

	public bool active;

	public float cameraDistanceSq = float.PositiveInfinity;

	public BoundingSphere boundingSphere;

	public float crossfadeTime = 2f;

	public Dictionary<AmbienceDefinition, float> nextStingTime = new Dictionary<AmbienceDefinition, float>();

	public float deactivateTime = float.PositiveInfinity;

	public bool playUnderwater = true;

	public bool playAbovewater = true;

	public TerrainTopology.Enum currentTopology { get; private set; }

	public TerrainBiome.Enum currentBiome { get; private set; }

	public int CompareTo(AmbienceEmitter other)
	{
		return cameraDistanceSq.CompareTo(other.cameraDistanceSq);
	}
}
