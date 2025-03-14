using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Material Config")]
public class MaterialConfig : ScriptableObject
{
	public class ShaderParameters<T>
	{
		public string Name;

		public T Arid;

		public T Temperate;

		public T Tundra;

		public T Arctic;

		private T[] climates;

		public float FindBlendParameters(Vector3 pos, out T src, out T dst)
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
			int biomeMaxType = TerrainMeta.BiomeMap.GetBiomeMaxType(pos);
			int biomeMaxType2 = TerrainMeta.BiomeMap.GetBiomeMaxType(pos, ~biomeMaxType);
			src = climates[TerrainBiome.TypeToIndex(biomeMaxType)];
			dst = climates[TerrainBiome.TypeToIndex(biomeMaxType2)];
			return TerrainMeta.BiomeMap.GetBiome(pos, biomeMaxType2);
		}

		public T FindBlendParameters(Vector3 pos)
		{
			if (TerrainMeta.BiomeMap == null)
			{
				return Temperate;
			}
			if (climates == null || climates.Length == 0)
			{
				climates = new T[4] { Arid, Temperate, Tundra, Arctic };
			}
			int biomeMaxType = TerrainMeta.BiomeMap.GetBiomeMaxType(pos);
			return climates[TerrainBiome.TypeToIndex(biomeMaxType)];
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

	[Horizontal(4, 0)]
	public ShaderParametersFloat[] Floats;

	[Horizontal(4, 0)]
	public ShaderParametersColor[] Colors;

	[Horizontal(4, 0)]
	public ShaderParametersTexture[] Textures;

	public string[] ScaleUV;

	private MaterialPropertyBlock properties;

	public MaterialPropertyBlock GetMaterialPropertyBlock(Material mat, Vector3 pos, Vector3 scale)
	{
		if (properties == null)
		{
			properties = new MaterialPropertyBlock();
		}
		properties.Clear();
		for (int i = 0; i < Floats.Length; i++)
		{
			ShaderParametersFloat shaderParametersFloat = Floats[i];
			float src;
			float dst;
			float t = shaderParametersFloat.FindBlendParameters(pos, out src, out dst);
			properties.SetFloat(shaderParametersFloat.Name, Mathf.Lerp(src, dst, t));
		}
		for (int j = 0; j < Colors.Length; j++)
		{
			ShaderParametersColor shaderParametersColor = Colors[j];
			Color src2;
			Color dst2;
			float t2 = shaderParametersColor.FindBlendParameters(pos, out src2, out dst2);
			properties.SetColor(shaderParametersColor.Name, Color.Lerp(src2, dst2, t2));
		}
		for (int k = 0; k < Textures.Length; k++)
		{
			ShaderParametersTexture shaderParametersTexture = Textures[k];
			Texture texture = shaderParametersTexture.FindBlendParameters(pos);
			if ((bool)texture)
			{
				properties.SetTexture(shaderParametersTexture.Name, texture);
			}
		}
		for (int l = 0; l < ScaleUV.Length; l++)
		{
			Vector4 vector = mat.GetVector(ScaleUV[l]);
			vector = new Vector4(vector.x * scale.y, vector.y * scale.y, vector.z, vector.w);
			properties.SetVector(ScaleUV[l], vector);
		}
		return properties;
	}
}
