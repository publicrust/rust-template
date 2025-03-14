using UnityEngine;

[RequireComponent(typeof(Wearable))]
public class WearableHairCap : MonoBehaviour
{
	public HairType Type;

	[ColorUsage(false, true)]
	public Color BaseColor = Color.black;

	public Texture Mask;

	private static MaterialPropertyBlock block;

	private static int _HairBaseColorUV1 = Shader.PropertyToID("_HairBaseColorUV1");

	private static int _HairBaseColorUV2 = Shader.PropertyToID("_HairBaseColorUV2");

	private static int _HairPackedMapUV1 = Shader.PropertyToID("_HairPackedMapUV1");

	private static int _HairPackedMapUV2 = Shader.PropertyToID("_HairPackedMapUV2");

	public void ApplyHairCap(MaterialPropertyBlock block)
	{
		if (Type == HairType.Head || Type == HairType.Armpit || Type == HairType.Pubic)
		{
			Texture texture = block.GetTexture(_HairPackedMapUV1);
			block.SetColor(_HairBaseColorUV1, BaseColor.gamma);
			block.SetTexture(_HairPackedMapUV1, (Mask != null) ? Mask : texture);
		}
		else if (Type == HairType.Facial)
		{
			Texture texture2 = block.GetTexture(_HairPackedMapUV2);
			block.SetColor(_HairBaseColorUV2, BaseColor.gamma);
			block.SetTexture(_HairPackedMapUV2, (Mask != null) ? Mask : texture2);
		}
	}
}
