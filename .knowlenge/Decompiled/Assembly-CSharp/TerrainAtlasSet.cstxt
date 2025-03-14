using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Terrain Atlas Set")]
public class TerrainAtlasSet : ScriptableObject
{
	public enum SourceType
	{
		ALBEDO,
		NORMAL,
		SPECULAR,
		HEIGHT,
		COUNT
	}

	[Serializable]
	public class SourceMapSet
	{
		public Texture2D[] maps;

		internal void CheckReset()
		{
			if (maps == null)
			{
				maps = new Texture2D[8];
			}
			else if (maps.Length != 8)
			{
				Array.Resize(ref maps, 8);
			}
		}
	}

	public const int SplatCount = 8;

	public const int SplatSize = 2048;

	public const int MaxSplatSize = 2047;

	public const int SplatPadding = 256;

	public const int AtlasSize = 8192;

	public const int RegionSize = 2560;

	public const int SplatsPerLine = 3;

	public const int SourceTypeCount = 4;

	public const int AtlasMipCount = 10;

	public static string[] sourceTypeNames = new string[4] { "Albedo", "Normal", "Specular", "Height" };

	public static string[] sourceTypeNamesExt = new string[4] { "Albedo (rgb)", "Normal (rgb)", "Specular (rgba)", "Height (gray)" };

	public static string[] sourceTypePostfix = new string[4] { "_albedo", "_normal", "_specular", "_height" };

	public string[] splatNames;

	public bool[] albedoHighpass;

	public string[] albedoPaths;

	public Color[] defaultValues;

	public SourceMapSet[] sourceMaps;

	public bool highQualityCompression = true;

	public bool generateTextureAtlases = true;

	public bool generateTextureArrays;

	public string splatSearchPrefix = "terrain_";

	public string splatSearchFolder = "Assets/Content/Nature/Terrain";

	public string albedoAtlasSavePath = "Assets/Content/Nature/Terrain/Atlas/terrain_albedo_atlas";

	public string normalAtlasSavePath = "Assets/Content/Nature/Terrain/Atlas/terrain_normal_atlas";

	public string albedoArraySavePath = "Assets/Content/Nature/Terrain/Atlas/terrain_albedo_array";

	public string normalArraySavePath = "Assets/Content/Nature/Terrain/Atlas/terrain_normal_array";

	public void CheckReset()
	{
		if (splatNames == null)
		{
			splatNames = new string[8] { "Dirt", "Snow", "Sand", "Rock", "Grass", "Forest", "Stones", "Gravel" };
		}
		else if (splatNames.Length != 8)
		{
			Array.Resize(ref splatNames, 8);
		}
		if (albedoHighpass == null)
		{
			albedoHighpass = new bool[8];
		}
		else if (albedoHighpass.Length != 8)
		{
			Array.Resize(ref albedoHighpass, 8);
		}
		if (albedoPaths == null)
		{
			albedoPaths = new string[8];
		}
		else if (albedoPaths.Length != 8)
		{
			Array.Resize(ref albedoPaths, 8);
		}
		if (defaultValues == null)
		{
			defaultValues = new Color[4]
			{
				new Color(1f, 1f, 1f, 0.5f),
				new Color(0.5f, 0.5f, 1f, 0f),
				new Color(0.5f, 0.5f, 0.5f, 0.5f),
				Color.black
			};
		}
		else if (defaultValues.Length != 4)
		{
			Array.Resize(ref defaultValues, 4);
		}
		if (sourceMaps == null)
		{
			sourceMaps = new SourceMapSet[4];
		}
		else if (sourceMaps.Length != 4)
		{
			Array.Resize(ref sourceMaps, 4);
		}
		for (int i = 0; i < 4; i++)
		{
			sourceMaps[i] = ((sourceMaps[i] != null) ? sourceMaps[i] : new SourceMapSet());
			sourceMaps[i].CheckReset();
		}
	}
}
