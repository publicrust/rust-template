using UnityEngine;

[CreateAssetMenu(fileName = "Engine Audio Preset", menuName = "Scriptable Object/Vehicles/Engine Audio Preset")]
public class EngineAudioSet : ScriptableObject
{
	public BlendedEngineLoopDefinition[] engineAudioLoops;

	public int priority;

	public float idleRpm = 600f;

	public float gearUpRpm = 5000f;

	public float gearDownRpm = 2500f;

	public int numGears = 5;

	public float minRpm = 10f;

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
