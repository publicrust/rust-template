using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Blended Engine Loop Definition")]
public class BlendedEngineLoopDefinition : ScriptableObject
{
	[Serializable]
	public class EngineLoopDefinition
	{
		public SoundDefinition soundDefinition;

		public float RPM;

		public float startRPM;

		public float startFullRPM;

		public float stopFullRPM;

		public float stopRPM;

		public float GetPitchForRPM(float targetRPM)
		{
			return targetRPM / RPM;
		}
	}

	public EngineLoopDefinition[] engineLoops;

	public float minRPM;

	public float maxRPM;

	public float RPMChangeRateUp = 0.5f;

	public float RPMChangeRateDown = 0.2f;
}
