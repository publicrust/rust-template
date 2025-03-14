using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundDefinition : ScriptableObject
{
	[Serializable]
	public class DistanceAudioClipList
	{
		public int distance;

		[Horizontal(2, -1)]
		public List<WeightedAudioClip> audioClips;
	}

	public GameObjectRef template;

	[Horizontal(2, -1)]
	public List<WeightedAudioClip> weightedAudioClips = new List<WeightedAudioClip>
	{
		new WeightedAudioClip()
	};

	public List<DistanceAudioClipList> distanceAudioClips;

	public SoundClass soundClass;

	public bool defaultToFirstPerson;

	public bool loop;

	public bool randomizeStartPosition;

	public bool useHighQualityFades;

	[Range(0f, 1f)]
	public float volume = 1f;

	[Range(0f, 1f)]
	public float volumeVariation;

	[Range(-3f, 3f)]
	public float pitch = 1f;

	[Range(0f, 1f)]
	public float pitchVariation;

	[Header("Voice limiting")]
	public bool dontVoiceLimit;

	public int globalVoiceMaxCount = 100;

	public int localVoiceMaxCount = 100;

	public float localVoiceRange = 10f;

	public float voiceLimitFadeOutTime = 0.05f;

	public float localVoiceDebounceTime = 0.1f;

	[Header("Occlusion Settings")]
	public bool forceOccludedPlayback;

	[Header("Doppler")]
	public bool enableDoppler;

	public float dopplerAmount = 0.18f;

	public float dopplerScale = 1f;

	public float dopplerAdjustmentRate = 1f;

	[Header("Custom curves")]
	public AnimationCurve falloffCurve;

	public bool useCustomFalloffCurve;

	public AnimationCurve spatialBlendCurve;

	public bool useCustomSpatialBlendCurve;

	public AnimationCurve spreadCurve;

	public bool useCustomSpreadCurve;

	public float maxDistance
	{
		get
		{
			if (template == null)
			{
				return 0f;
			}
			AudioSource component = template.Get().GetComponent<AudioSource>();
			if (component == null)
			{
				return 0f;
			}
			return component.maxDistance;
		}
	}

	public float GetLength()
	{
		float num = 0f;
		for (int i = 0; i < weightedAudioClips.Count; i++)
		{
			AudioClip audioClip = weightedAudioClips[i].audioClip;
			if ((bool)audioClip)
			{
				num = Mathf.Max(audioClip.length, num);
			}
		}
		for (int j = 0; j < distanceAudioClips.Count; j++)
		{
			List<WeightedAudioClip> audioClips = distanceAudioClips[j].audioClips;
			for (int k = 0; k < audioClips.Count; k++)
			{
				AudioClip audioClip2 = audioClips[k].audioClip;
				if ((bool)audioClip2)
				{
					num = Mathf.Max(audioClip2.length, num);
				}
			}
		}
		float num2 = 1f / (pitch - pitchVariation);
		return num * num2;
	}

	public Sound Play()
	{
		return null;
	}

	public Sound Play(GameObject forGameObject)
	{
		return null;
	}
}
