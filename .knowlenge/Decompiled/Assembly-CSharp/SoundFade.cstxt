using UnityEngine;

public class SoundFade : MonoBehaviour, IClientComponent
{
	public enum Direction
	{
		In,
		Out
	}

	public SoundFadeHQAudioFilter hqFadeFilter;

	public float currentGain = 1f;

	public float startingGain;

	public float finalGain = 1f;

	public int sampleRate = 44100;

	public bool highQualityFadeCompleted;

	public float length;

	public Direction currentDirection;
}
