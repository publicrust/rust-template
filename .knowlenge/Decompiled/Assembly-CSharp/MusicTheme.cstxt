using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/MusicTheme")]
public class MusicTheme : ScriptableObject
{
	[Serializable]
	public class Layer
	{
		public string name = "layer";
	}

	[Serializable]
	public class PositionedClip
	{
		public MusicTheme theme;

		public MusicClip musicClip;

		public int startingBar;

		public int layerId;

		public float minIntensity;

		public float maxIntensity = 1f;

		public bool allowFadeIn = true;

		public bool allowFadeOut = true;

		public float fadeInTime = 1f;

		public float fadeOutTime = 0.5f;

		public float intensityReduction;

		public int jumpBarCount;

		public float jumpMinimumIntensity = 0.5f;

		public float jumpMaximumIntensity = 0.5f;

		public int endingBar
		{
			get
			{
				if (!(musicClip == null))
				{
					return startingBar + musicClip.lengthInBarsWithTail;
				}
				return startingBar;
			}
		}

		public bool isControlClip => musicClip == null;

		public bool CanPlay(float intensity)
		{
			if (intensity > minIntensity || (minIntensity == 0f && intensity == 0f))
			{
				return intensity <= maxIntensity;
			}
			return false;
		}

		public void CopySettingsFrom(PositionedClip otherClip)
		{
			if (isControlClip == otherClip.isControlClip && otherClip != this)
			{
				allowFadeIn = otherClip.allowFadeIn;
				fadeInTime = otherClip.fadeInTime;
				allowFadeOut = otherClip.allowFadeOut;
				fadeOutTime = otherClip.fadeOutTime;
				maxIntensity = otherClip.maxIntensity;
				minIntensity = otherClip.minIntensity;
				intensityReduction = otherClip.intensityReduction;
			}
		}
	}

	[Serializable]
	public class ValueRange
	{
		public float min;

		public float max;

		public ValueRange(float min, float max)
		{
			this.min = min;
			this.max = max;
		}
	}

	[Header("Basic info")]
	public float tempo = 80f;

	public int intensityHoldBars = 4;

	public int lengthInBars;

	[Header("Playback restrictions")]
	public bool canPlayInMenus = true;

	[Horizontal(2, -1)]
	public ValueRange rain = new ValueRange(0f, 1f);

	[Horizontal(2, -1)]
	public ValueRange wind = new ValueRange(0f, 1f);

	[Horizontal(2, -1)]
	public ValueRange snow = new ValueRange(0f, 1f);

	[InspectorFlags]
	public TerrainBiome.Enum biomes = (TerrainBiome.Enum)(-1);

	[InspectorFlags]
	public TerrainTopology.Enum topologies = (TerrainTopology.Enum)(-1);

	public AnimationCurve time = AnimationCurve.Linear(0f, 0f, 24f, 0f);

	[Header("Clip data")]
	public List<PositionedClip> clips = new List<PositionedClip>();

	public List<Layer> layers = new List<Layer>();

	private Dictionary<int, List<PositionedClip>> activeClips = new Dictionary<int, List<PositionedClip>>();

	private List<AudioClip> firstAudioClips = new List<AudioClip>();

	private Dictionary<AudioClip, bool> audioClipDict = new Dictionary<AudioClip, bool>();

	public int layerCount => layers.Count;

	public int samplesPerBar => MusicUtil.BarsToSamples(tempo, 1f, 44100);

	private void OnValidate()
	{
		audioClipDict.Clear();
		activeClips.Clear();
		UpdateLengthInBars();
		for (int i = 0; i < clips.Count; i++)
		{
			PositionedClip positionedClip = clips[i];
			int num = ActiveClipCollectionID(positionedClip.startingBar - 8);
			int num2 = ActiveClipCollectionID(positionedClip.endingBar);
			for (int j = num; j <= num2; j++)
			{
				if (!activeClips.ContainsKey(j))
				{
					activeClips.Add(j, new List<PositionedClip>());
				}
				if (!activeClips[j].Contains(positionedClip))
				{
					activeClips[j].Add(positionedClip);
				}
			}
			if (positionedClip.musicClip != null)
			{
				AudioClip audioClip = positionedClip.musicClip.audioClip;
				if (!audioClipDict.ContainsKey(audioClip))
				{
					audioClipDict.Add(audioClip, value: true);
				}
				if (positionedClip.startingBar < 8 && !firstAudioClips.Contains(audioClip))
				{
					firstAudioClips.Add(audioClip);
				}
				positionedClip.musicClip.lengthInBarsWithTail = Mathf.CeilToInt(MusicUtil.SecondsToBars(tempo, positionedClip.musicClip.audioClip.length));
			}
		}
	}

	public List<PositionedClip> GetActiveClipsForBar(int bar)
	{
		int key = ActiveClipCollectionID(bar);
		if (!activeClips.ContainsKey(key))
		{
			return null;
		}
		return activeClips[key];
	}

	private int ActiveClipCollectionID(int bar)
	{
		return Mathf.FloorToInt(Mathf.Max(bar / 4, 0f));
	}

	public Layer LayerById(int id)
	{
		if (layers.Count <= id)
		{
			return null;
		}
		return layers[id];
	}

	public void AddLayer()
	{
		Layer layer = new Layer();
		layer.name = "layer " + layers.Count;
		layers.Add(layer);
	}

	private void UpdateLengthInBars()
	{
		int num = 0;
		for (int i = 0; i < clips.Count; i++)
		{
			PositionedClip positionedClip = clips[i];
			if (!(positionedClip.musicClip == null))
			{
				int num2 = positionedClip.startingBar + positionedClip.musicClip.lengthInBars;
				if (num2 > num)
				{
					num = num2;
				}
			}
		}
		lengthInBars = num;
	}

	public bool CanPlayInEnvironment(int currentBiome, int currentTopology, float currentRain, float currentSnow, float currentWind)
	{
		if ((bool)TOD_Sky.Instance && time.Evaluate(TOD_Sky.Instance.Cycle.Hour) < 0f)
		{
			return false;
		}
		if (biomes != (TerrainBiome.Enum)(-1) && ((uint)biomes & (uint)currentBiome) == 0)
		{
			return false;
		}
		if (topologies != (TerrainTopology.Enum)(-1) && ((uint)topologies & (uint)currentTopology) != 0)
		{
			return false;
		}
		if (((rain.min > 0f || rain.max < 1f) && currentRain < rain.min) || currentRain > rain.max)
		{
			return false;
		}
		if (((snow.min > 0f || snow.max < 1f) && currentSnow < snow.min) || currentSnow > snow.max)
		{
			return false;
		}
		if (((wind.min > 0f || wind.max < 1f) && currentWind < wind.min) || currentWind > wind.max)
		{
			return false;
		}
		return true;
	}

	public bool FirstClipsLoaded()
	{
		for (int i = 0; i < firstAudioClips.Count; i++)
		{
			if (firstAudioClips[i].loadState != AudioDataLoadState.Loaded)
			{
				return false;
			}
		}
		return true;
	}

	public bool ContainsAudioClip(AudioClip clip)
	{
		return audioClipDict.ContainsKey(clip);
	}
}
