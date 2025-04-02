using System;
using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class GranularAudioClip : MonoBehaviour
{
	public class Grain : Pool.IPooled
	{
		private float[] sourceData;

		private int sourceDataLength;

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
			sourceDataLength = 0;
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
			sourceDataLength = sourceData.Length;
			startSample = start;
			currentSample = start;
			attackTimeSamples = attack;
			sustainTimeSamples = sustain;
			releaseTimeSamples = release;
			gainPerSampleAttack = 1f / (float)attackTimeSamples;
			gainPerSampleRelease = -1f / (float)releaseTimeSamples;
			attackEndSample = startSample + attackTimeSamples;
			releaseStartSample = attackEndSample + sustainTimeSamples;
			endSample = releaseStartSample + releaseTimeSamples;
			gain = 0f;
		}

		public float GetSample()
		{
			int num = currentSample % sourceDataLength;
			if (num < 0)
			{
				num += sourceDataLength;
			}
			float num2 = sourceData[num];
			if (currentSample <= attackEndSample)
			{
				gain += gainPerSampleAttack;
			}
			else if (currentSample >= releaseStartSample)
			{
				gain += gainPerSampleRelease;
			}
			currentSample++;
			return num2 * gain;
		}
	}

	public AudioClip sourceClip;

	private float[] sourceAudioData;

	private int sourceChannels = 1;

	public AudioClip granularClip;

	public int sampleRate = 44100;

	public float sourceTime = 0.5f;

	public float sourceTimeVariation = 0.1f;

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

	private System.Random random = new System.Random();

	private bool inited;

	private void Update()
	{
		if (!inited && sourceClip.loadState == AudioDataLoadState.Loaded)
		{
			sampleRate = sourceClip.frequency;
			sourceAudioData = new float[sourceClip.samples * sourceClip.channels];
			sourceClip.GetData(sourceAudioData, 0);
			InitAudioClip();
			AudioSource component = GetComponent<AudioSource>();
			component.clip = granularClip;
			component.loop = true;
			component.Play();
			inited = true;
		}
		RefreshCachedData();
	}

	private void RefreshCachedData()
	{
		grainAttackSamples = Mathf.FloorToInt(grainAttack * (float)sampleRate * (float)sourceChannels);
		grainSustainSamples = Mathf.FloorToInt(grainSustain * (float)sampleRate * (float)sourceChannels);
		grainReleaseSamples = Mathf.FloorToInt(grainRelease * (float)sampleRate * (float)sourceChannels);
		grainFrequencySamples = Mathf.FloorToInt(grainFrequency * (float)sampleRate * (float)sourceChannels);
	}

	private void InitAudioClip()
	{
		int bufferLength = 1;
		int numBuffers = 1;
		UnityEngine.AudioSettings.GetDSPBufferSize(out bufferLength, out numBuffers);
		granularClip = AudioClip.Create(sourceClip.name + " (granular)", bufferLength, sourceClip.channels, sampleRate, stream: true, OnAudioRead);
		sourceChannels = sourceClip.channels;
	}

	private void OnAudioRead(float[] data)
	{
		for (int i = 0; i < data.Length; i++)
		{
			if (samplesUntilNextGrain <= 0)
			{
				SpawnGrain();
			}
			float num = 0f;
			for (int j = 0; j < grains.Count; j++)
			{
				num += grains[j].GetSample();
			}
			data[i] = num;
			samplesUntilNextGrain--;
		}
		CleanupFinishedGrains();
	}

	private void SpawnGrain()
	{
		if (grainFrequencySamples != 0)
		{
			float num = (float)(random.NextDouble() * (double)sourceTimeVariation * 2.0) - sourceTimeVariation;
			int start = Mathf.FloorToInt((sourceTime + num) * (float)sampleRate / (float)sourceChannels);
			Grain grain = Pool.Get<Grain>();
			grain.Init(sourceAudioData, start, grainAttackSamples, grainSustainSamples, grainReleaseSamples);
			grains.Add(grain);
			samplesUntilNextGrain = grainFrequencySamples;
		}
	}

	private void CleanupFinishedGrains()
	{
		for (int num = grains.Count - 1; num >= 0; num--)
		{
			Grain obj = grains[num];
			if (obj.finished)
			{
				Pool.Free(ref obj);
				grains.RemoveAt(num);
			}
		}
	}
}
