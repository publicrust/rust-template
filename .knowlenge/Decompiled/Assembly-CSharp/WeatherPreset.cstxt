using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/WeatherPreset")]
public class WeatherPreset : ScriptableObject
{
	public WeatherPresetType Type;

	public float Wind;

	public float Rain;

	public float Thunder;

	public float Rainbow;

	public TOD_AtmosphereParameters Atmosphere;

	public TOD_CloudParameters Clouds;

	[Range(0f, 1f)]
	public float AmbientLightMultiplier = 1f;

	[Range(0f, 1f)]
	public float DirectionalLightMultiplier = 1f;

	[Range(0f, 1f)]
	public float ReflectionMultiplier = 1f;

	[Range(0f, 1f)]
	public float SunMeshBrightnessMultiplier = 1f;

	[Range(0f, 1f)]
	public float MoonMeshBrightnessMultiplier = 1f;

	[Range(0f, 10f)]
	public float OceanScale;

	public void Apply(TOD_Sky sky)
	{
		sky.Atmosphere.RayleighMultiplier = Atmosphere.RayleighMultiplier;
		sky.Atmosphere.MieMultiplier = Atmosphere.MieMultiplier;
		sky.Atmosphere.Brightness = Atmosphere.Brightness;
		sky.Atmosphere.Contrast = Atmosphere.Contrast;
		sky.Atmosphere.Directionality = Atmosphere.Directionality;
		sky.Atmosphere.Fogginess = Atmosphere.Fogginess;
		sky.Clouds.Size = Clouds.Size;
		sky.Clouds.Opacity = Clouds.Opacity;
		sky.Clouds.Coverage = Clouds.Coverage;
		sky.Clouds.Sharpness = Clouds.Sharpness;
		sky.Clouds.Coloring = Clouds.Coloring;
		sky.Clouds.Attenuation = Clouds.Attenuation;
		sky.Clouds.Saturation = Clouds.Saturation;
		sky.Clouds.Scattering = Clouds.Scattering;
		sky.Clouds.Brightness = Clouds.Brightness;
	}

	public void Copy(TOD_Sky sky)
	{
		Atmosphere.RayleighMultiplier = sky.Atmosphere.RayleighMultiplier;
		Atmosphere.MieMultiplier = sky.Atmosphere.MieMultiplier;
		Atmosphere.Brightness = sky.Atmosphere.Brightness;
		Atmosphere.Contrast = sky.Atmosphere.Contrast;
		Atmosphere.Directionality = sky.Atmosphere.Directionality;
		Atmosphere.Fogginess = sky.Atmosphere.Fogginess;
		Clouds.Size = sky.Clouds.Size;
		Clouds.Opacity = sky.Clouds.Opacity;
		Clouds.Coverage = sky.Clouds.Coverage;
		Clouds.Sharpness = sky.Clouds.Sharpness;
		Clouds.Coloring = sky.Clouds.Coloring;
		Clouds.Attenuation = sky.Clouds.Attenuation;
		Clouds.Saturation = sky.Clouds.Saturation;
		Clouds.Scattering = sky.Clouds.Scattering;
		Clouds.Brightness = sky.Clouds.Brightness;
	}

	public void Reset()
	{
		Wind = -1f;
		Rain = -1f;
		Thunder = -1f;
		Rainbow = -1f;
		Atmosphere = new TOD_AtmosphereParameters();
		Atmosphere.RayleighMultiplier = -1f;
		Atmosphere.MieMultiplier = -1f;
		Atmosphere.Brightness = -1f;
		Atmosphere.Contrast = -1f;
		Atmosphere.Directionality = -1f;
		Atmosphere.Fogginess = -1f;
		Clouds = new TOD_CloudParameters();
		Clouds.Size = -1f;
		Clouds.Opacity = -1f;
		Clouds.Coverage = -1f;
		Clouds.Sharpness = -1f;
		Clouds.Coloring = -1f;
		Clouds.Attenuation = -1f;
		Clouds.Saturation = -1f;
		Clouds.Scattering = -1f;
		Clouds.Brightness = -1f;
		AmbientLightMultiplier = -1f;
		DirectionalLightMultiplier = -1f;
		ReflectionMultiplier = -1f;
		SunMeshBrightnessMultiplier = -1f;
		MoonMeshBrightnessMultiplier = -1f;
		OceanScale = -1f;
	}

	public void Set(WeatherPreset other)
	{
		Wind = other.Wind;
		Rain = other.Rain;
		Thunder = other.Thunder;
		Rainbow = other.Rainbow;
		Atmosphere.RayleighMultiplier = other.Atmosphere.RayleighMultiplier;
		Atmosphere.MieMultiplier = other.Atmosphere.MieMultiplier;
		Atmosphere.Brightness = other.Atmosphere.Brightness;
		Atmosphere.Contrast = other.Atmosphere.Contrast;
		Atmosphere.Directionality = other.Atmosphere.Directionality;
		Atmosphere.Fogginess = other.Atmosphere.Fogginess;
		Clouds.Size = other.Clouds.Size;
		Clouds.Opacity = other.Clouds.Opacity;
		Clouds.Coverage = other.Clouds.Coverage;
		Clouds.Sharpness = other.Clouds.Sharpness;
		Clouds.Coloring = other.Clouds.Coloring;
		Clouds.Attenuation = other.Clouds.Attenuation;
		Clouds.Saturation = other.Clouds.Saturation;
		Clouds.Scattering = other.Clouds.Scattering;
		Clouds.Brightness = other.Clouds.Brightness;
		AmbientLightMultiplier = other.AmbientLightMultiplier;
		DirectionalLightMultiplier = other.DirectionalLightMultiplier;
		ReflectionMultiplier = other.ReflectionMultiplier;
		SunMeshBrightnessMultiplier = other.SunMeshBrightnessMultiplier;
		MoonMeshBrightnessMultiplier = other.MoonMeshBrightnessMultiplier;
		OceanScale = other.OceanScale;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"Wind {Wind}");
		stringBuilder.AppendLine($"Rain {Rain}");
		stringBuilder.AppendLine($"Thunder {Thunder}");
		stringBuilder.AppendLine($"Rainbow {Rainbow}");
		stringBuilder.AppendLine($"RayleighMultiplier {Atmosphere.RayleighMultiplier}");
		stringBuilder.AppendLine($"MieMultiplier {Atmosphere.MieMultiplier}");
		stringBuilder.AppendLine($"Brightness {Atmosphere.Brightness}");
		stringBuilder.AppendLine($"Contrast {Atmosphere.Contrast}");
		stringBuilder.AppendLine($"Directionality {Atmosphere.Directionality}");
		stringBuilder.AppendLine($"Fogginess {Atmosphere.Fogginess}");
		stringBuilder.AppendLine($"Size {Clouds.Size}");
		stringBuilder.AppendLine($"Opacity {Clouds.Opacity}");
		stringBuilder.AppendLine($"Coverage {Clouds.Coverage}");
		stringBuilder.AppendLine($"Sharpness {Clouds.Sharpness}");
		stringBuilder.AppendLine($"Coloring {Clouds.Coloring}");
		stringBuilder.AppendLine($"Attenuation {Clouds.Attenuation}");
		stringBuilder.AppendLine($"Saturation {Clouds.Saturation}");
		stringBuilder.AppendLine($"Scattering {Clouds.Scattering}");
		stringBuilder.AppendLine($"Brightness {Clouds.Brightness}");
		stringBuilder.AppendLine($"AmbientLightMultiplier {AmbientLightMultiplier}");
		stringBuilder.AppendLine($"DirectionalLightMultiplier {DirectionalLightMultiplier}");
		stringBuilder.AppendLine($"ReflectionMultiplier {ReflectionMultiplier}");
		stringBuilder.AppendLine($"SunMeshBrightnessMultiplier {SunMeshBrightnessMultiplier}");
		stringBuilder.AppendLine($"MoonMeshBrightnessMultiplier {MoonMeshBrightnessMultiplier}");
		stringBuilder.AppendLine($"Ocean {OceanScale}");
		return stringBuilder.ToString();
	}

	public void Fade(WeatherPreset a, WeatherPreset b, float t)
	{
		Fade(ref Wind, a.Wind, b.Wind, t);
		Fade(ref Rain, a.Rain, b.Rain, t);
		Fade(ref Thunder, a.Thunder, b.Thunder, t);
		Fade(ref Rainbow, a.Rainbow, b.Rainbow, t);
		Fade(ref Atmosphere.RayleighMultiplier, a.Atmosphere.RayleighMultiplier, b.Atmosphere.RayleighMultiplier, t);
		Fade(ref Atmosphere.MieMultiplier, a.Atmosphere.MieMultiplier, b.Atmosphere.MieMultiplier, t);
		Fade(ref Atmosphere.Brightness, a.Atmosphere.Brightness, b.Atmosphere.Brightness, t);
		Fade(ref Atmosphere.Contrast, a.Atmosphere.Contrast, b.Atmosphere.Contrast, t);
		Fade(ref Atmosphere.Directionality, a.Atmosphere.Directionality, b.Atmosphere.Directionality, t);
		Fade(ref Atmosphere.Fogginess, a.Atmosphere.Fogginess, b.Atmosphere.Fogginess, t);
		Fade(ref Clouds.Size, a.Clouds.Size, b.Clouds.Size, t);
		Fade(ref Clouds.Opacity, a.Clouds.Opacity, b.Clouds.Opacity, t);
		Fade(ref Clouds.Coverage, a.Clouds.Coverage, b.Clouds.Coverage, t);
		Fade(ref Clouds.Sharpness, a.Clouds.Sharpness, b.Clouds.Sharpness, t);
		Fade(ref Clouds.Coloring, a.Clouds.Coloring, b.Clouds.Coloring, t);
		Fade(ref Clouds.Attenuation, a.Clouds.Attenuation, b.Clouds.Attenuation, t);
		Fade(ref Clouds.Saturation, a.Clouds.Saturation, b.Clouds.Saturation, t);
		Fade(ref Clouds.Scattering, a.Clouds.Scattering, b.Clouds.Scattering, t);
		Fade(ref Clouds.Brightness, a.Clouds.Brightness, b.Clouds.Brightness, t);
		Fade(ref AmbientLightMultiplier, a.AmbientLightMultiplier, b.AmbientLightMultiplier, t);
		Fade(ref DirectionalLightMultiplier, a.DirectionalLightMultiplier, b.DirectionalLightMultiplier, t);
		Fade(ref ReflectionMultiplier, a.ReflectionMultiplier, b.ReflectionMultiplier, t);
		Fade(ref SunMeshBrightnessMultiplier, a.SunMeshBrightnessMultiplier, b.SunMeshBrightnessMultiplier, t);
		Fade(ref MoonMeshBrightnessMultiplier, a.MoonMeshBrightnessMultiplier, b.MoonMeshBrightnessMultiplier, t);
		Fade(ref OceanScale, a.OceanScale, b.OceanScale, t);
	}

	public void Override(WeatherPreset other)
	{
		Override(ref Wind, other.Wind);
		Override(ref Rain, other.Rain);
		Override(ref Thunder, other.Thunder);
		Override(ref Rainbow, other.Rainbow);
		Override(ref Atmosphere.RayleighMultiplier, other.Atmosphere.RayleighMultiplier);
		Override(ref Atmosphere.MieMultiplier, other.Atmosphere.MieMultiplier);
		Override(ref Atmosphere.Brightness, other.Atmosphere.Brightness);
		Override(ref Atmosphere.Contrast, other.Atmosphere.Contrast);
		Override(ref Atmosphere.Directionality, other.Atmosphere.Directionality);
		Override(ref Atmosphere.Fogginess, other.Atmosphere.Fogginess);
		Override(ref Clouds.Size, other.Clouds.Size);
		Override(ref Clouds.Opacity, other.Clouds.Opacity);
		Override(ref Clouds.Coverage, other.Clouds.Coverage);
		Override(ref Clouds.Sharpness, other.Clouds.Sharpness);
		Override(ref Clouds.Coloring, other.Clouds.Coloring);
		Override(ref Clouds.Attenuation, other.Clouds.Attenuation);
		Override(ref Clouds.Saturation, other.Clouds.Saturation);
		Override(ref Clouds.Scattering, other.Clouds.Scattering);
		Override(ref Clouds.Brightness, other.Clouds.Brightness);
		Override(ref AmbientLightMultiplier, other.AmbientLightMultiplier);
		Override(ref DirectionalLightMultiplier, other.DirectionalLightMultiplier);
		Override(ref ReflectionMultiplier, other.ReflectionMultiplier);
		Override(ref SunMeshBrightnessMultiplier, other.SunMeshBrightnessMultiplier);
		Override(ref MoonMeshBrightnessMultiplier, other.MoonMeshBrightnessMultiplier);
		Override(ref OceanScale, other.OceanScale);
	}

	public void Max(WeatherPreset other)
	{
		Max(ref Wind, other.Wind);
		Max(ref Rain, other.Rain);
		Max(ref Thunder, other.Thunder);
		Max(ref Rainbow, other.Rainbow);
		Max(ref Atmosphere.RayleighMultiplier, other.Atmosphere.RayleighMultiplier);
		Max(ref Atmosphere.MieMultiplier, other.Atmosphere.MieMultiplier);
		Max(ref Atmosphere.Brightness, other.Atmosphere.Brightness);
		Max(ref Atmosphere.Contrast, other.Atmosphere.Contrast);
		Max(ref Atmosphere.Directionality, other.Atmosphere.Directionality);
		Max(ref Atmosphere.Fogginess, other.Atmosphere.Fogginess);
		Max(ref Clouds.Size, other.Clouds.Size);
		Max(ref Clouds.Opacity, other.Clouds.Opacity);
		Max(ref Clouds.Coverage, other.Clouds.Coverage);
		Max(ref Clouds.Sharpness, other.Clouds.Sharpness);
		Max(ref Clouds.Coloring, other.Clouds.Coloring);
		Max(ref Clouds.Attenuation, other.Clouds.Attenuation);
		Max(ref Clouds.Saturation, other.Clouds.Saturation);
		Max(ref Clouds.Scattering, other.Clouds.Scattering);
		Max(ref Clouds.Brightness, other.Clouds.Brightness);
		Min(ref AmbientLightMultiplier, other.AmbientLightMultiplier);
		Min(ref DirectionalLightMultiplier, other.DirectionalLightMultiplier);
		Min(ref ReflectionMultiplier, other.ReflectionMultiplier);
		Min(ref SunMeshBrightnessMultiplier, other.SunMeshBrightnessMultiplier);
		Min(ref MoonMeshBrightnessMultiplier, other.MoonMeshBrightnessMultiplier);
		Max(ref OceanScale, other.OceanScale);
	}

	public void Min(WeatherPreset other)
	{
		Min(ref Wind, other.Wind);
		Min(ref Rain, other.Rain);
		Min(ref Thunder, other.Thunder);
		Min(ref Rainbow, other.Rainbow);
		Min(ref Atmosphere.RayleighMultiplier, other.Atmosphere.RayleighMultiplier);
		Min(ref Atmosphere.MieMultiplier, other.Atmosphere.MieMultiplier);
		Min(ref Atmosphere.Brightness, other.Atmosphere.Brightness);
		Min(ref Atmosphere.Contrast, other.Atmosphere.Contrast);
		Min(ref Atmosphere.Directionality, other.Atmosphere.Directionality);
		Min(ref Atmosphere.Fogginess, other.Atmosphere.Fogginess);
		Min(ref Clouds.Size, other.Clouds.Size);
		Min(ref Clouds.Opacity, other.Clouds.Opacity);
		Min(ref Clouds.Coverage, other.Clouds.Coverage);
		Min(ref Clouds.Sharpness, other.Clouds.Sharpness);
		Min(ref Clouds.Coloring, other.Clouds.Coloring);
		Min(ref Clouds.Attenuation, other.Clouds.Attenuation);
		Min(ref Clouds.Saturation, other.Clouds.Saturation);
		Min(ref Clouds.Scattering, other.Clouds.Scattering);
		Min(ref Clouds.Brightness, other.Clouds.Brightness);
		Min(ref AmbientLightMultiplier, other.AmbientLightMultiplier);
		Min(ref DirectionalLightMultiplier, other.DirectionalLightMultiplier);
		Min(ref ReflectionMultiplier, other.ReflectionMultiplier);
		Min(ref SunMeshBrightnessMultiplier, other.SunMeshBrightnessMultiplier);
		Min(ref MoonMeshBrightnessMultiplier, other.MoonMeshBrightnessMultiplier);
		Min(ref OceanScale, other.OceanScale);
	}

	private void Fade(ref float x, float a, float b, float t)
	{
		x = Mathf.SmoothStep(a, b, t);
	}

	private void Override(ref float x, float other)
	{
		if (other >= 0f)
		{
			x = other;
		}
	}

	private void Max(ref float x, float other)
	{
		x = Mathf.Max(x, other);
	}

	private void Min(ref float x, float other)
	{
		if (other >= 0f)
		{
			x = Mathf.Min(x, other);
		}
	}
}
