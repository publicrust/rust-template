using System;
using System.Collections.Generic;
using Facepunch;
using JSON;
using UnityEngine;

public class EngineAudioClip : MonoBehaviour, IClientComponent
{
	[Serializable]
	public class EngineCycle
	{
		public int RPM;

		public int startSample;

		public int endSample;

		public float period;

		public int id;

		public EngineCycle(int RPM, int startSample, int endSample, float period, int id)
		{
			this.RPM = RPM;
			this.startSample = startSample;
			this.endSample = endSample;
			this.period = period;
			this.id = id;
		}
	}

	public class EngineCycleBucket
	{
		public int RPM;

		public List<EngineCycle> cycles = new List<EngineCycle>();

		public List<int> remainingCycles = new List<int>();

		public EngineCycleBucket(int RPM)
		{
			this.RPM = RPM;
		}

		public EngineCycle GetCycle(System.Random random, int lastCycleId)
		{
			if (remainingCycles.Count == 0)
			{
				ResetRemainingCycles(random);
			}
			int index = remainingCycles.Pop();
			if (cycles[index].id == lastCycleId)
			{
				if (remainingCycles.Count == 0)
				{
					ResetRemainingCycles(random);
				}
				index = remainingCycles.Pop();
			}
			return cycles[index];
		}

		private void ResetRemainingCycles(System.Random random)
		{
			for (int i = 0; i < cycles.Count; i++)
			{
				remainingCycles.Add(i);
			}
			remainingCycles.Shuffle((uint)random.Next());
		}

		public void Add(EngineCycle cycle)
		{
			if (!cycles.Contains(cycle))
			{
				cycles.Add(cycle);
			}
		}
	}

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

		public void Init(float[] source, EngineCycle cycle, int cyclePadding)
		{
			sourceData = source;
			startSample = cycle.startSample - cyclePadding;
			currentSample = startSample;
			attackTimeSamples = cyclePadding;
			sustainTimeSamples = cycle.endSample - cycle.startSample;
			releaseTimeSamples = cyclePadding;
			gainPerSampleAttack = 1f / (float)attackTimeSamples;
			gainPerSampleRelease = -1f / (float)releaseTimeSamples;
			attackEndSample = startSample + attackTimeSamples;
			releaseStartSample = attackEndSample + sustainTimeSamples;
			endSample = releaseStartSample + releaseTimeSamples;
			gain = 0f;
		}

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
				if (gain > 0.8f)
				{
					gain = 0.8f;
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
	}

	public AudioClip granularClip;

	public AudioClip accelerationClip;

	public TextAsset accelerationCyclesJson;

	public List<EngineCycle> accelerationCycles = new List<EngineCycle>();

	public List<EngineCycleBucket> cycleBuckets = new List<EngineCycleBucket>();

	public Dictionary<int, EngineCycleBucket> accelerationCyclesByRPM = new Dictionary<int, EngineCycleBucket>();

	public Dictionary<int, int> rpmBucketLookup = new Dictionary<int, int>();

	public int sampleRate = 44100;

	public int samplesUntilNextGrain;

	public int lastCycleId;

	public List<Grain> grains = new List<Grain>();

	public int currentRPM;

	public int targetRPM = 1500;

	public int minRPM;

	public int maxRPM;

	public int cyclePadding;

	[Range(0f, 1f)]
	public float RPMControl;

	public AudioSource source;

	public float rpmLerpSpeed = 0.025f;

	public float rpmLerpSpeedDown = 0.01f;

	private int GetBucketRPM(int RPM)
	{
		return Mathf.RoundToInt(RPM / 25) * 25;
	}
}
