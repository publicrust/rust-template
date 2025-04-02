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
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		if (Type == HairType.Head || Type == HairType.Armpit || Type == HairType.Pubic)
		{
			Texture texture = block.GetTexture(_HairPackedMapUV1);
			block.SetColor(_HairBaseColorUV1, ((Color)(ref BaseColor)).gamma);
			block.SetTexture(_HairPackedMapUV1, ((Object)(object)Mask != (Object)null) ? Mask : texture);
		}
		else if (Type == HairType.Facial)
		{
			Texture texture2 = block.GetTexture(_HairPackedMapUV2);
			block.SetColor(_HairBaseColorUV2, ((Color)(ref BaseColor)).gamma);
			block.SetTexture(_HairPackedMapUV2, ((Object)(object)Mask != (Object)null) ? Mask : texture2);
		}
	}
}
