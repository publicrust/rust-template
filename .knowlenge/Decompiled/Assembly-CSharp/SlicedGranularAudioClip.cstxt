using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class SlicedGranularAudioClip : MonoBehaviour, IClientComponent
{
	public class Grain : Pool.IPooled
	{
		private float[] sourceData;

		private int startSample;

		private int currentSample;

		private int attackTimeSamples;

		private int sustainTimeSamples;

		private int releaseTimeSamples;

		private float gain;

		private float gainPerSampleAttack;

		private float gainPerSampleRelease;

		private int attackEndSample;

		private int releaseStartSample;

		private int endSample;

		public bool finished => currentSample >= endSample;

		void Pool.IPooled.LeavePool()
		{
		}

		void Pool.IPooled.EnterPool()
		{
			sourceData = null;
			startSample = 0;
			currentSample = 0;
			attackTimeSamples = 0;
			sustainTimeSamples = 0;
			releaseTimeSamples = 0;
			gain = 0f;
			gainPerSampleAttack = 0f;
			gainPerSampleRelease = 0f;
			attackEndSample = 0;
			releaseStartSample = 0;
			endSample = 0;
		}

		public void Init(float[] source, int start, int attack, int sustain, int release)
		{
			sourceData = source;
			startSample = start;
			currentSample = start;
			attackTimeSamples = attack;
			sustainTimeSamples = sustain;
			releaseTimeSamples = release;
			gainPerSampleAttack = 0.5f / (float)attackTimeSamples;
			gainPerSampleRelease = -0.5f / (float)releaseTimeSamples;
			attackEndSample = startSample + attackTimeSamples;
			releaseStartSample = attackEndSample + sustainTimeSamples;
			endSample = releaseStartSample + releaseTimeSamples;
			gain = 0f;
		}

		public float GetSample()
		{
			if (currentSample >= sourceData.Length)
			{
				return 0f;
			}
			float num = sourceData[currentSample];
			if (currentSample <= attackEndSample)
			{
				gain += gainPerSampleAttack;
				if (gain > 0.5f)
				{
					gain = 0.5f;
				}
			}
			else if (currentSample >= releaseStartSample)
			{
				gain += gainPerSampleRelease;
				if (gain < 0f)
				{
					gain = 0f;
				}
			}
			currentSample++;
			return num * gain;
		}

		public void FadeOut()
		{
			releaseStartSample = currentSample;
			endSample = releaseStartSample + releaseTimeSamples;
		}
	}

	public AudioSource source;

	public AudioClip sourceClip;

	public AudioClip granularClip;

	public int sampleRate = 44100;

	public float grainAttack = 0.1f;

	public float grainSustain = 0.1f;

	public float grainRelease = 0.1f;

	public float grainFrequency = 0.1f;

	public int grainAttackSamples;

	public int grainSustainSamples;

	public int grainReleaseSamples;

	public int grainFrequencySamples;

	public int samplesUntilNextGrain;

	public List<Grain> grains = new List<Grain>();

	public List<int> startPositions = new List<int>();

	public int lastStartPositionIdx = int.MaxValue;

	public bool playOnAwake = true;
}
