using UnityEngine;

[CreateAssetMenu(fileName = "Engine Audio Preset", menuName = "Rust/Vehicles/Engine Audio Preset")]
public class EngineAudioSet : ScriptableObject
{
	public BlendedEngineLoopDefinition[] engineAudioLoops;

	public int priority;

	public float idleVolume = 0.4f;

	public float maxVolume = 0.6f;

	public float volumeChangeRateUp = 48f;

	public float volumeChangeRateDown = 16f;

	public float idlePitch = 0.25f;

	public float maxPitch = 1.5f;

	public float idleRpm = 600f;

	public float gearUpRpm = 5000f;

	public float gearDownRpm = 2500f;

	public int numGears = 5;

	public float maxRpm = 6000f;

	public float gearUpRpmRate = 5f;

	public float gearDownRpmRate = 6f;

	public SoundDefinition badPerformanceLoop;

	public BlendedEngineLoopDefinition GetEngineLoopDef(int numEngines)
	{
		int num = (numEngines - 1) % engineAudioLoops.Length;
		return engineAudioLoops[num];
	}
}
