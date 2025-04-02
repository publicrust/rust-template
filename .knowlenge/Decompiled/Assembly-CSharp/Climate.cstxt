using System;
using System.Collections.Generic;
using System.Linq;
using Rust;
using UnityEngine;

public class Climate : SingletonComponent<Climate>
{
	[Serializable]
	public class ClimateParameters
	{
		public AnimationCurve Temperature;

		[Horizontal(4, -1)]
		public Float4 AerialDensity;

		[Horizontal(4, -1)]
		public Float4 FogDensity;

		[Horizontal(4, -1)]
		public Texture2D4 LUT;
	}

	[Serializable]
	public class WeatherParameters
	{
		[Range(0f, 1f)]
		public float ClearChance = 1f;

		[Range(0f, 1f)]
		public float DustChance;

		[Range(0f, 1f)]
		public float FogChance;

		[Range(0f, 1f)]
		public float OvercastChance;

		[Range(0f, 1f)]
		public float StormChance;

		[Range(0f, 1f)]
		public float RainChance;
	}

	public class Value4<T>
	{
		public T Dawn;

		public T Noon;

		public T Dusk;

		public T Night;

		public float FindBlendParameters(TOD_Sky sky, out T src, out T dst)
		{
			float num = Mathf.Abs(sky.SunriseTime - sky.Cycle.Hour);
			float num2 = Mathf.Abs(sky.SunsetTime - sky.Cycle.Hour);
			float num3 = (180f - sky.SunZenith) / 180f;
			float num4 = 1f / 9f;
			if (num < num2)
			{
				if (num3 < 0.5f)
				{
					src = Night;
					dst = Dawn;
					return Mathf.InverseLerp(0.5f - num4, 0.5f, num3);
				}
				src = Dawn;
				dst = Noon;
				return Mathf.InverseLerp(0.5f, 0.5f + num4, num3);
			}
			if (num3 > 0.5f)
			{
				src = Noon;
				dst = Dusk;
				return Mathf.InverseLerp(0.5f + num4, 0.5f, num3);
			}
			src = Dusk;
			dst = Night;
			return Mathf.InverseLerp(0.5f, 0.5f - num4, num3);
		}
	}

	[Serializable]
	public class Float4 : Value4<float>
	{
	}

	[Serializable]
	public class Color4 : Value4<Color>
	{
	}

	[Serializable]
	public class Texture2D4 : Value4<Texture2D>
	{
	}

	private const float fadeAngle = 20f;

	private const float defaultTemp = 15f;

	private const int weatherDurationHours = 18;

	private const int weatherFadeHours = 6;

	[Range(0f, 1f)]
	public float BlendingSpeed = 1f;

	[Range(1f, 9f)]
	public float FogMultiplier = 5f;

	public float FogDarknessDistance = 200f;

	public bool DebugLUTBlending;

	public WeatherParameters Weather;

	public WeatherPreset[] WeatherPresets;

	public ClimateParameters Arid;

	public ClimateParameters Temperate;

	public ClimateParameters Tundra;

	public ClimateParameters Arctic;

	public Dictionary<WeatherPresetType, WeatherPreset[]> presetLookup;

	private ClimateParameters[] climateLookup;

	public float WeatherStateBlend { get; set; }

	public uint WeatherSeedPrevious { get; set; }

	public uint WeatherSeedTarget { get; set; }

	public uint WeatherSeedNext { get; set; }

	public WeatherPreset WeatherStatePrevious { get; set; }

	public WeatherPreset WeatherStateTarget { get; set; }

	public WeatherPreset WeatherStateNext { get; set; }

	public WeatherPreset WeatherState { get; set; }

	public WeatherPreset WeatherClampsMin { get; private set; }

	public WeatherPreset WeatherClampsMax { get; private set; }

	public WeatherPreset WeatherOverrides { get; set; }

	public LegacyWeatherState Overrides { get; set; }

	protected override void Awake()
	{
		base.Awake();
		WeatherState = ScriptableObject.CreateInstance(typeof(WeatherPreset)) as WeatherPreset;
		WeatherClampsMin = ScriptableObject.CreateInstance(typeof(WeatherPreset)) as WeatherPreset;
		WeatherClampsMax = ScriptableObject.CreateInstance(typeof(WeatherPreset)) as WeatherPreset;
		WeatherOverrides = ScriptableObject.CreateInstance(typeof(WeatherPreset)) as WeatherPreset;
		WeatherState.Reset();
		WeatherClampsMin.Reset();
		WeatherClampsMax.Reset();
		WeatherOverrides.Reset();
		Overrides = new LegacyWeatherState(WeatherOverrides);
	}

	protected override void OnDestroy()
	{
		if (!Rust.Application.isQuitting)
		{
			base.OnDestroy();
			if (WeatherState != null)
			{
				UnityEngine.Object.Destroy(WeatherState);
			}
			if (WeatherClampsMin != null)
			{
				UnityEngine.Object.Destroy(WeatherClampsMin);
			}
			if (WeatherClampsMax != null)
			{
				UnityEngine.Object.Destroy(WeatherClampsMax);
			}
			if (WeatherOverrides != null)
			{
				UnityEngine.Object.Destroy(WeatherOverrides);
			}
		}
	}

	public void Update()
	{
		if (!Rust.Application.isReceiving && !Rust.Application.isLoading && (bool)TOD_Sky.Instance)
		{
			TOD_Sky instance = TOD_Sky.Instance;
			long num = World.Seed + instance.Cycle.Ticks;
			long num2 = 648000000000L;
			long num3 = 216000000000L;
			long num4 = num / num2;
			WeatherStateBlend = Mathf.InverseLerp(0f, num3, num % num2);
			uint seed = (WeatherSeedPrevious = GetSeedFromLong(num4));
			WeatherStatePrevious = GetWeatherPreset(seed);
			seed = (WeatherSeedTarget = GetSeedFromLong(num4 + 1));
			WeatherStateTarget = GetWeatherPreset(seed);
			seed = (WeatherSeedNext = GetSeedFromLong(num4 + 2));
			WeatherStateNext = GetWeatherPreset(seed);
			WeatherState.Fade(WeatherStatePrevious, WeatherStateTarget, WeatherStateBlend);
			WeatherState.Override(WeatherOverrides);
		}
	}

	private static bool Initialized()
	{
		if (!SingletonComponent<Climate>.Instance)
		{
			return false;
		}
		if (!SingletonComponent<Climate>.Instance.WeatherStatePrevious)
		{
			return false;
		}
		if (!SingletonComponent<Climate>.Instance.WeatherStateTarget)
		{
			return false;
		}
		if (!SingletonComponent<Climate>.Instance.WeatherStateNext)
		{
			return false;
		}
		if (!SingletonComponent<Climate>.Instance.WeatherState)
		{
			return false;
		}
		if (!SingletonComponent<Climate>.Instance.WeatherClampsMin)
		{
			return false;
		}
		if (!SingletonComponent<Climate>.Instance.WeatherOverrides)
		{
			return false;
		}
		return true;
	}

	public static float GetClouds(Vector3 position)
	{
		if (!Initialized())
		{
			return 0f;
		}
		return SingletonComponent<Climate>.Instance.WeatherState.Clouds.Coverage;
	}

	public static float GetFog(Vector3 position)
	{
		if (!Initialized())
		{
			return 0f;
		}
		return SingletonComponent<Climate>.Instance.WeatherState.Atmosphere.Fogginess;
	}

	public static float GetWind(Vector3 position)
	{
		if (!Initialized())
		{
			return 0f;
		}
		return SingletonComponent<Climate>.Instance.WeatherState.Wind;
	}

	public static float GetThunder(Vector3 position)
	{
		if (!Initialized())
		{
			return 0f;
		}
		float thunder = SingletonComponent<Climate>.Instance.WeatherOverrides.Thunder;
		if (thunder >= 0f)
		{
			return thunder;
		}
		float thunder2 = SingletonComponent<Climate>.Instance.WeatherState.Thunder;
		float thunder3 = SingletonComponent<Climate>.Instance.WeatherStatePrevious.Thunder;
		float thunder4 = SingletonComponent<Climate>.Instance.WeatherStateTarget.Thunder;
		if (thunder3 > 0f && thunder2 > 0.5f * thunder3)
		{
			return thunder2;
		}
		if (thunder4 > 0f && thunder2 > 0.5f * thunder4)
		{
			return thunder2;
		}
		return 0f;
	}

	public static float GetRainbow(Vector3 position)
	{
		if (!Initialized())
		{
			return 0f;
		}
		TOD_Sky instance = TOD_Sky.Instance;
		if (!instance || !instance.IsDay || instance.LerpValue < 1f)
		{
			return 0f;
		}
		if (GetFog(position) > 0.25f)
		{
			return 0f;
		}
		float num = (TerrainMeta.BiomeMap ? TerrainMeta.BiomeMap.GetBiome(position, 3) : 0f);
		if (num <= 0f)
		{
			return 0f;
		}
		float rainbow = SingletonComponent<Climate>.Instance.WeatherOverrides.Rainbow;
		if (rainbow >= 0f)
		{
			return rainbow * num;
		}
		if (SingletonComponent<Climate>.Instance.WeatherState.Rainbow <= 0f)
		{
			return 0f;
		}
		if (SingletonComponent<Climate>.Instance.WeatherStateTarget.Rainbow > 0f)
		{
			return 0f;
		}
		float rainbow2 = SingletonComponent<Climate>.Instance.WeatherStatePrevious.Rainbow;
		float num2 = SeedRandom.Value(SingletonComponent<Climate>.Instance.WeatherSeedPrevious);
		if (rainbow2 < num2)
		{
			return 0f;
		}
		return num;
	}

	public static float GetAurora(Vector3 position)
	{
		if (!Initialized())
		{
			return 0f;
		}
		TOD_Sky instance = TOD_Sky.Instance;
		if (!instance || !instance.IsNight || instance.LerpValue > 0f)
		{
			return 0f;
		}
		if (GetClouds(position) > 0.1f)
		{
			return 0f;
		}
		if (GetFog(position) > 0.1f)
		{
			return 0f;
		}
		if (!TerrainMeta.BiomeMap)
		{
			return 0f;
		}
		return TerrainMeta.BiomeMap.GetBiome(position, 8);
	}

	public static float GetRain(Vector3 position)
	{
		if (!Initialized())
		{
			return 0f;
		}
		float t = (TerrainMeta.BiomeMap ? TerrainMeta.BiomeMap.GetBiome(position, 1) : 0f);
		float num = (TerrainMeta.BiomeMap ? TerrainMeta.BiomeMap.GetBiome(position, 8) : 0f);
		return SingletonComponent<Climate>.Instance.WeatherState.Rain * Mathf.Lerp(1f, 0.5f, t) * (1f - num);
	}

	public static float GetSnow(Vector3 position)
	{
		if (!Initialized())
		{
			return 0f;
		}
		float num = (TerrainMeta.BiomeMap ? TerrainMeta.BiomeMap.GetBiome(position, 8) : 0f);
		return SingletonComponent<Climate>.Instance.WeatherState.Rain * num;
	}

	public static float GetTemperature(Vector3 position)
	{
		if (!Initialized())
		{
			return 15f;
		}
		TOD_Sky instance = TOD_Sky.Instance;
		if (!instance)
		{
			return 15f;
		}
		ClimateParameters src;
		ClimateParameters dst;
		float t = SingletonComponent<Climate>.Instance.FindBlendParameters(position, out src, out dst);
		if (src == null || dst == null)
		{
			return 15f;
		}
		float hour = instance.Cycle.Hour;
		float a = src.Temperature.Evaluate(hour);
		float b = dst.Temperature.Evaluate(hour);
		return Mathf.Lerp(a, b, t);
	}

	private uint GetSeedFromLong(long val)
	{
		uint x = (uint)((val % uint.MaxValue + uint.MaxValue) % uint.MaxValue);
		SeedRandom.Wanghash(ref x);
		SeedRandom.Wanghash(ref x);
		SeedRandom.Wanghash(ref x);
		return x;
	}

	private WeatherPreset GetWeatherPreset(uint seed)
	{
		float max = Weather.ClearChance + Weather.DustChance + Weather.FogChance + Weather.OvercastChance + Weather.StormChance + Weather.RainChance;
		float num = SeedRandom.Range(ref seed, 0f, max);
		if (num < Weather.RainChance)
		{
			return GetWeatherPreset(seed, WeatherPresetType.Rain);
		}
		if (num < Weather.RainChance + Weather.StormChance)
		{
			return GetWeatherPreset(seed, WeatherPresetType.Storm);
		}
		if (num < Weather.RainChance + Weather.StormChance + Weather.OvercastChance)
		{
			return GetWeatherPreset(seed, WeatherPresetType.Overcast);
		}
		if (num < Weather.RainChance + Weather.StormChance + Weather.OvercastChance + Weather.FogChance)
		{
			return GetWeatherPreset(seed, WeatherPresetType.Fog);
		}
		if (num < Weather.RainChance + Weather.StormChance + Weather.OvercastChance + Weather.FogChance + Weather.DustChance)
		{
			return GetWeatherPreset(seed, WeatherPresetType.Dust);
		}
		return GetWeatherPreset(seed, WeatherPresetType.Clear);
	}

	private WeatherPreset GetWeatherPreset(uint seed, WeatherPresetType type)
	{
		if (presetLookup == null)
		{
			presetLookup = new Dictionary<WeatherPresetType, WeatherPreset[]>();
		}
		if (!presetLookup.TryGetValue(type, out var value))
		{
			presetLookup.Add(type, value = CacheWeatherPresets(type));
		}
		return ArrayEx.GetRandom(value, ref seed);
	}

	public WeatherPreset[] CacheWeatherPresets(WeatherPresetType type)
	{
		return WeatherPresets.Where((WeatherPreset x) => x.Type == type).ToArray();
	}

	private float FindBlendParameters(Vector3 pos, out ClimateParameters src, out ClimateParameters dst)
	{
		if (climateLookup == null)
		{
			climateLookup = new ClimateParameters[4] { Arid, Temperate, Tundra, Arctic };
		}
		if (TerrainMeta.BiomeMap == null)
		{
			src = Temperate;
			dst = Temperate;
			return 0.5f;
		}
		int biomeMaxType = TerrainMeta.BiomeMap.GetBiomeMaxType(pos);
		int biomeMaxType2 = TerrainMeta.BiomeMap.GetBiomeMaxType(pos, ~biomeMaxType);
		src = climateLookup[TerrainBiome.TypeToIndex(biomeMaxType)];
		dst = climateLookup[TerrainBiome.TypeToIndex(biomeMaxType2)];
		return TerrainMeta.BiomeMap.GetBiome(pos, biomeMaxType2);
	}
}
