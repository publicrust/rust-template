using UnityEngine;

public class LegacyWeatherState
{
	private WeatherPreset preset;

	public float Wind
	{
		get
		{
			return preset.Wind;
		}
		set
		{
			preset.Wind = value;
		}
	}

	public float Rain
	{
		get
		{
			return preset.Rain;
		}
		set
		{
			preset.Rain = value;
		}
	}

	public float Clouds
	{
		get
		{
			return preset.Clouds.Coverage;
		}
		set
		{
			preset.Clouds.Opacity = Mathf.Sign(value);
			preset.Clouds.Coverage = value;
		}
	}

	public float Fog
	{
		get
		{
			return preset.Atmosphere.Fogginess;
		}
		set
		{
			preset.Atmosphere.Fogginess = value;
		}
	}

	public LegacyWeatherState(WeatherPreset preset)
	{
		this.preset = preset;
	}
}
