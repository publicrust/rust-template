using System;

[Serializable]
public class TOD_Parameters
{
	public TOD_CycleParameters Cycle;

	public TOD_WorldParameters World;

	public TOD_AtmosphereParameters Atmosphere;

	public TOD_DayParameters Day;

	public TOD_NightParameters Night;

	public TOD_SunParameters Sun;

	public TOD_MoonParameters Moon;

	public TOD_LightParameters Light;

	public TOD_StarParameters Stars;

	public TOD_CloudParameters Clouds;

	public TOD_FogParameters Fog;

	public TOD_AmbientParameters Ambient;

	public TOD_ReflectionParameters Reflection;

	public TOD_Parameters()
	{
	}

	public TOD_Parameters(TOD_Sky sky)
	{
		Cycle = sky.Cycle;
		World = sky.World;
		Atmosphere = sky.Atmosphere;
		Day = sky.Day;
		Night = sky.Night;
		Sun = sky.Sun;
		Moon = sky.Moon;
		Light = sky.Light;
		Stars = sky.Stars;
		Clouds = sky.Clouds;
		Fog = sky.Fog;
		Ambient = sky.Ambient;
		Reflection = sky.Reflection;
	}

	public void ToSky(TOD_Sky sky)
	{
		sky.Cycle = Cycle;
		sky.World = World;
		sky.Atmosphere = Atmosphere;
		sky.Day = Day;
		sky.Night = Night;
		sky.Sun = Sun;
		sky.Moon = Moon;
		sky.Light = Light;
		sky.Stars = Stars;
		sky.Clouds = Clouds;
		sky.Fog = Fog;
		sky.Ambient = Ambient;
		sky.Reflection = Reflection;
	}
}
