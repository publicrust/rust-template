using System;
using UnityEngine;

[Serializable]
public class HairDye
{
	public enum CopyProperty
	{
		DyeColor,
		RootColor,
		TipColor,
		Brightness,
		DyeRoughness,
		DyeScatter,
		Specular,
		Roughness,
		Count
	}

	[Flags]
	public enum CopyPropertyMask
	{
		DyeColor = 1,
		RootColor = 2,
		TipColor = 4,
		Brightness = 8,
		DyeRoughness = 0x10,
		DyeScatter = 0x20,
		Specular = 0x40,
		Roughness = 0x80
	}

	[ColorUsage(false, true)]
	public Color capBaseColor;

	public Material sourceMaterial;

	[InspectorFlags]
	public CopyPropertyMask copyProperties;

	private static MaterialPropertyDesc[] transferableProps = new MaterialPropertyDesc[8]
	{
		new MaterialPropertyDesc("_DyeColor", typeof(Color)),
		new MaterialPropertyDesc("_RootColor", typeof(Color)),
		new MaterialPropertyDesc("_TipColor", typeof(Color)),
		new MaterialPropertyDesc("_Brightness", typeof(float)),
		new MaterialPropertyDesc("_DyeRoughness", typeof(float)),
		new MaterialPropertyDesc("_DyeScatter", typeof(float)),
		new MaterialPropertyDesc("_HairSpecular", typeof(float)),
		new MaterialPropertyDesc("_HairRoughness", typeof(float))
	};

	public static int _HairBaseColorUV1 = Shader.PropertyToID("_HairBaseColorUV1");

	public static int _HairBaseColorUV2 = Shader.PropertyToID("_HairBaseColorUV2");

	public static int _HairPackedMapUV1 = Shader.PropertyToID("_HairPackedMapUV1");

	public static int _HairPackedMapUV2 = Shader.PropertyToID("_HairPackedMapUV2");

	public void Apply(HairDyeCollection collection, MaterialPropertyBlock block)
	{
		if (!(sourceMaterial != null))
		{
			return;
		}
		for (int i = 0; i < 8; i++)
		{
			if (((uint)copyProperties & (uint)(1 << i)) == 0)
			{
				continue;
			}
			MaterialPropertyDesc materialPropertyDesc = transferableProps[i];
			if (sourceMaterial.HasProperty(materialPropertyDesc.nameID))
			{
				if (materialPropertyDesc.type == typeof(Color))
				{
					block.SetColor(materialPropertyDesc.nameID, sourceMaterial.GetColor(materialPropertyDesc.nameID));
				}
				else if (materialPropertyDesc.type == typeof(float))
				{
					block.SetFloat(materialPropertyDesc.nameID, sourceMaterial.GetFloat(materialPropertyDesc.nameID));
				}
			}
		}
	}

	public void ApplyCap(HairDyeCollection collection, HairType type, MaterialPropertyBlock block)
	{
		if (collection.applyCap)
		{
			switch (type)
			{
			case HairType.Head:
			case HairType.Armpit:
			case HairType.Pubic:
				block.SetColor(_HairBaseColorUV1, capBaseColor.gamma);
				block.SetTexture(_HairPackedMapUV1, (collection.capMask != null) ? collection.capMask : Texture2D.blackTexture);
				break;
			case HairType.Facial:
				block.SetColor(_HairBaseColorUV2, capBaseColor.gamma);
				block.SetTexture(_HairPackedMapUV2, (collection.capMask != null) ? collection.capMask : Texture2D.blackTexture);
				break;
			}
		}
	}
}
