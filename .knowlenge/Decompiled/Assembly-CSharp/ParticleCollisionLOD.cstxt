using System;

public class ParticleCollisionLOD : LODComponentParticleSystem
{
	public enum QualityLevel
	{
		Disabled = -1,
		HighQuality,
		MediumQuality,
		LowQuality
	}

	[Serializable]
	public class State
	{
		public float distance;

		public QualityLevel quality = QualityLevel.Disabled;
	}

	[Horizontal(1, 0)]
	public State[] States;
}
