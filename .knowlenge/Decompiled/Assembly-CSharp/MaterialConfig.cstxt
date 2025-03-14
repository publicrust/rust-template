using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Material Config")]
public class MaterialConfig : ScriptableObject
{
	[Serializable]
	public class EnvironmentVolumeOverride
	{
		public EnvironmentType Environment;

		public TerrainBiome.Enum Biome;
	}

	public class ShaderParameters<T>
	{
		public string Name;

		public T Arid;

		public T Temperate;

		public T Tundra;

		public T Arctic;

		private T[] climates;

		public float FindBlendParameters(Vector3 pos, int biomeOverride, out T src, out T dst)
		{
			if (TerrainMeta.BiomeMap == null)
			{
				src = Temperate;
				dst = Tundra;
				return 0f;
			}
			if (climates == null || climates.Length == 0)
			{
				climates = new T[4] { Arid, Temperate, Tundra, Arctic };
			}
			int num = ((biomeOverride != 0) ? biomeOverride : TerrainMeta.BiomeMap.GetBiomeMaxType(pos));
			int num2 = ((biomeOverride != 0) ? biomeOverride : TerrainMeta.BiomeMap.GetBiomeMaxType(pos, ~num));
			src = climates[TerrainBiome.TypeToIndex(num)];
			dst = climates[TerrainBiome.TypeToIndex(num2)];
			return TerrainMeta.BiomeMap.GetBiome(pos, num2);
		}

		public T FindBlendParameters(Vector3 pos, int biomeOverride)
		{
			if (TerrainMeta.BiomeMap == null)
			{
				return Temperate;
			}
			if (climates == null || climates.Length == 0)
			{
				climates = new T[4] { Arid, Temperate, Tundra, Arctic };
			}
			int id = ((biomeOverride != 0) ? biomeOverride : TerrainMeta.BiomeMap.GetBiomeMaxType(pos));
			return climates[TerrainBiome.TypeToIndex(id)];
		}
	}

	[Serializable]
	public class ShaderParametersFloat : ShaderParameters<float>
	{
	}

	[Serializable]
	public class ShaderParametersColor : ShaderParameters<Color>
	{
	}

	[Serializable]
	public class ShaderParametersTexture : ShaderParameters<Texture>
	{
	}

	[Serializable]
	public class ShaderParametersToggle : ShaderParameters<bool>
	{
	}

	[Horizontal(4, 0)]
	public ShaderParametersFloat[] Floats;

	[Horizontal(4, 0)]
	public ShaderParametersColor[] Colors;

	[Horizontal(4, 0)]
	public ShaderParametersTexture[] Textures;

	[Horizontal(4, 0)]
	public ShaderParametersToggle[] Toggles;

	public string[] ScaleUV;

	[Horizontal(2, -1)]
	public EnvironmentVolumeOverride[] EnvironmentVolumeOverrides;

	private MaterialPropertyBlock properties;

	public MaterialPropertyBlock GetMaterialPropertyBlock(Material mat, Vector3 pos, Vector3 scale)
	{
		if (properties == null)
		{
			properties = new MaterialPropertyBlock();
		}
		properties.Clear();
		int biomeOverride = 0;
		if (EnvironmentVolumeOverrides.Length != 0)
		{
			EnvironmentType environmentType = EnvironmentManager.Get(pos);
			if (TerrainMeta.IsPointWithinTutorialBounds(pos))
			{
				biomeOverride = 2;
			}
			else
			{
				EnvironmentVolumeOverride[] environmentVolumeOverrides = EnvironmentVolumeOverrides;
				foreach (EnvironmentVolumeOverride environmentVolumeOverride in environmentVolumeOverrides)
				{
					if ((environmentType & environmentVolumeOverride.Environment) != 0)
					{
						biomeOverride = (int)environmentVolumeOverride.Biome;
						break;
					}
				}
			}
		}
		for (int j = 0; j < Floats.Length; j++)
		{
			ShaderParametersFloat shaderParametersFloat = Floats[j];
			float src;
			float dst;
			float t = shaderParametersFloat.FindBlendParameters(pos, biomeOverride, out src, out dst);
			properties.SetFloat(shaderParametersFloat.Name, Mathf.Lerp(src, dst, t));
		}
		for (int k = 0; k < Colors.Length; k++)
		{
			ShaderParametersColor shaderParametersColor = Colors[k];
			Color src2;
			Color dst2;
			float t2 = shaderParametersColor.FindBlendParameters(pos, biomeOverride, out src2, out dst2);
			properties.SetColor(shaderParametersColor.Name, Color.Lerp(src2, dst2, t2));
		}
		for (int l = 0; l < Textures.Length; l++)
		{
			ShaderParametersTexture shaderParametersTexture = Textures[l];
			Texture texture = shaderParametersTexture.FindBlendParameters(pos, biomeOverride);
			if ((bool)texture)
			{
				properties.SetTexture(shaderParametersTexture.Name, texture);
			}
		}
		for (int m = 0; m < Toggles.Length; m++)
		{
			ShaderParametersToggle shaderParametersToggle = Toggles[m];
			bool flag = shaderParametersToggle.FindBlendParameters(pos, biomeOverride);
			properties.SetFloat(shaderParametersToggle.Name, flag ? 1f : 0f);
		}
		for (int n = 0; n < ScaleUV.Length; n++)
		{
			Vector4 vector = mat.GetVector(ScaleUV[n]);
			vector = new Vector4(vector.x * scale.y, vector.y * scale.y, vector.z, vector.w);
			properties.SetVector(ScaleUV[n], vector);
		}
		return properties;
	}
}
