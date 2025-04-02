using System;
using System.Collections.Generic;

public class AmbienceManager : SingletonComponent<AmbienceManager>, IClientComponent
{
	[Serializable]
	public class EmitterTypeLimit
	{
		public List<AmbienceDefinitionList> ambience;

		public int limit = 1;

		public int active;
	}

	public List<EmitterTypeLimit> localEmitterLimits = new List<EmitterTypeLimit>();

	public EmitterTypeLimit catchallEmitterLimit = new EmitterTypeLimit();

	public int maxActiveLocalEmitters = 5;

	public int activeLocalEmitters;

	public List<AmbienceEmitter> cameraEmitters = new List<AmbienceEmitter>();

	public List<AmbienceEmitter> emittersInRange = new List<AmbienceEmitter>();

	public List<AmbienceEmitter> activeEmitters = new List<AmbienceEmitter>();

	public float localEmitterRange = 30f;

	public List<AmbienceZone> currentAmbienceZones = new List<AmbienceZone>();

	public bool isUnderwater;

	public float ambienceZoneGain { get; private set; } = 1f;
}
