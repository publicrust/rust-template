using System;
using System.Collections.Generic;
using UnityEngine;

public class RainSurfaceAmbience : SingletonComponent<RainSurfaceAmbience>, IClientComponent
{
	[Serializable]
	public class SurfaceSound
	{
		public AmbienceDefinitionList baseAmbience;

		public List<PhysicMaterial> materials = new List<PhysicMaterial>();
	}

	public List<SurfaceSound> surfaces = new List<SurfaceSound>();

	public GameObjectRef emitterPrefab;

	public Dictionary<ParticlePatch, AmbienceEmitter> spawnedEmitters = new Dictionary<ParticlePatch, AmbienceEmitter>();
}
