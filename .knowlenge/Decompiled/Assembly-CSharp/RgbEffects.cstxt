using System.ComponentModel;
using UnityEngine;

public class RgbEffects : SingletonComponent<RgbEffects>
{
	[ClientVar(Help = "Enables RGB lighting effects (supports SteelSeries and Razer)", Saved = true)]
	public static bool Enabled = true;

	[ClientVar(Help = "Controls how RGB values are mapped to LED lights on SteelSeries devices", Saved = true)]
	public static Vector3 ColorCorrection_SteelSeries = new Vector3(1.5f, 1.5f, 1.5f);

	[ClientVar(Help = "Controls how RGB values are mapped to LED lights on Razer devices", Saved = true)]
	public static Vector3 ColorCorrection_Razer = new Vector3(3f, 3f, 3f);

	[ClientVar(Help = "Brightness of colors, from 0 to 1 (note: may affect color accuracy)", Saved = true)]
	public static float Brightness = 1f;

	public Color defaultColor;

	public Color buildingPrivilegeColor;

	public Color coldColor;

	public Color hotColor;

	public Color hurtColor;

	public Color healedColor;

	public Color irradiatedColor;

	public Color comfortedColor;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ClientVar(Name = "static")]
	public static void ConVar_Static(ConsoleSystem.Arg args)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ClientVar(Name = "pulse")]
	public static void ConVar_Pulse(ConsoleSystem.Arg args)
	{
	}
}
