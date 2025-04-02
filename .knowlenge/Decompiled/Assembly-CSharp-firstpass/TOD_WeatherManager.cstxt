using UnityEngine;

public class TOD_WeatherManager : MonoBehaviour
{
	public enum RainType
	{
		None,
		Light,
		Heavy
	}

	public enum CloudType
	{
		None,
		Few,
		Scattered,
		Broken,
		Overcast
	}

	public enum AtmosphereType
	{
		Clear,
		Storm,
		Dust,
		Fog
	}

	public ParticleSystem RainParticleSystem;

	public float FadeTime = 10f;

	public RainType Rain;

	public CloudType Clouds;

	public AtmosphereType Atmosphere;

	private float cloudOpacityMax;

	private float cloudBrightnessMax;

	private float atmosphereBrightnessMax;

	private float rainEmissionMax;

	private float cloudOpacity;

	private float cloudCoverage;

	private float cloudBrightness;

	private float atmosphereFog;

	private float atmosphereBrightness;

	private float rainEmission;

	private float GetRainEmission()
	{
		if ((bool)RainParticleSystem)
		{
			return RainParticleSystem.emission.rateOverTimeMultiplier;
		}
		return 0f;
	}

	private void SetRainEmission(float value)
	{
		if ((bool)RainParticleSystem)
		{
			ParticleSystem.EmissionModule emission = RainParticleSystem.emission;
			emission.rateOverTimeMultiplier = value;
		}
	}

	protected void Start()
	{
		TOD_Sky instance = TOD_Sky.Instance;
		cloudOpacity = instance.Clouds.Opacity;
		cloudCoverage = instance.Clouds.Coverage;
		cloudBrightness = instance.Clouds.Brightness;
		atmosphereFog = instance.Atmosphere.Fogginess;
		atmosphereBrightness = instance.Atmosphere.Brightness;
		rainEmission = GetRainEmission();
		cloudOpacityMax = cloudOpacity;
		cloudBrightnessMax = cloudBrightness;
		atmosphereBrightnessMax = atmosphereBrightness;
		rainEmissionMax = rainEmission;
	}

	protected void Update()
	{
		TOD_Sky instance = TOD_Sky.Instance;
		switch (Rain)
		{
		case RainType.None:
			rainEmission = 0f;
			break;
		case RainType.Light:
			rainEmission = rainEmissionMax * 0.5f;
			break;
		case RainType.Heavy:
			rainEmission = rainEmissionMax;
			break;
		}
		switch (Clouds)
		{
		case CloudType.None:
			cloudOpacity = 0f;
			cloudCoverage = 0f;
			break;
		case CloudType.Few:
			cloudOpacity = cloudOpacityMax;
			cloudCoverage = 0.1f;
			break;
		case CloudType.Scattered:
			cloudOpacity = cloudOpacityMax;
			cloudCoverage = 0.3f;
			break;
		case CloudType.Broken:
			cloudOpacity = cloudOpacityMax;
			cloudCoverage = 0.6f;
			break;
		case CloudType.Overcast:
			cloudOpacity = cloudOpacityMax;
			cloudCoverage = 1f;
			break;
		}
		switch (Atmosphere)
		{
		case AtmosphereType.Clear:
			cloudBrightness = cloudBrightnessMax;
			atmosphereBrightness = atmosphereBrightnessMax;
			atmosphereFog = 0f;
			break;
		case AtmosphereType.Storm:
			cloudBrightness = cloudBrightnessMax * 0.3f;
			atmosphereBrightness = atmosphereBrightnessMax * 0.5f;
			atmosphereFog = 1f;
			break;
		case AtmosphereType.Dust:
			cloudBrightness = cloudBrightnessMax;
			atmosphereBrightness = atmosphereBrightnessMax;
			atmosphereFog = 0.5f;
			break;
		case AtmosphereType.Fog:
			cloudBrightness = cloudBrightnessMax;
			atmosphereBrightness = atmosphereBrightnessMax;
			atmosphereFog = 1f;
			break;
		}
		float t = ((FadeTime > 0f) ? Mathf.Clamp01(Time.deltaTime / FadeTime) : 1f);
		instance.Clouds.Opacity = Mathf.Lerp(instance.Clouds.Opacity, cloudOpacity, t);
		instance.Clouds.Coverage = Mathf.Lerp(instance.Clouds.Coverage, cloudCoverage, t);
		instance.Clouds.Brightness = Mathf.Lerp(instance.Clouds.Brightness, cloudBrightness, t);
		instance.Atmosphere.Fogginess = Mathf.Lerp(instance.Atmosphere.Fogginess, atmosphereFog, t);
		instance.Atmosphere.Brightness = Mathf.Lerp(instance.Atmosphere.Brightness, atmosphereBrightness, t);
		SetRainEmission(Mathf.Lerp(GetRainEmission(), rainEmission, t));
	}
}
