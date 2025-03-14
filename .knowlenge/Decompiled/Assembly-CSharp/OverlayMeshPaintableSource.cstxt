using System;
using UnityEngine;

public class OverlayMeshPaintableSource : MeshPaintableSource
{
	private static readonly Memoized<string, string> STPrefixed = new Memoized<string, string>((string s) => s + "_ST");

	public string baseTextureName = "_Decal1Texture";

	[NonSerialized]
	public Texture2D baseTexture;

	public override void UpdateMaterials(MaterialPropertyBlock block, Texture2D textureOverride = null)
	{
		base.UpdateMaterials(block, textureOverride);
		if (baseTexture != null)
		{
			float num = (float)baseTexture.width / (float)baseTexture.height;
			int num2 = texWidth / texHeight;
			float num3 = 1f;
			float z = 0f;
			float num4 = 1f;
			float w = 0f;
			if ((float)num2 <= num)
			{
				float num5 = (float)texHeight * num;
				num3 = (float)texWidth / num5;
				z = (1f - num3) / 2f;
			}
			else
			{
				float num6 = (float)texWidth / num;
				num4 = (float)texHeight / num6;
				w = (1f - num4) / 2f;
			}
			block.SetTexture(baseTextureName, baseTexture);
			block.SetVector(STPrefixed.Get(baseTextureName), new Vector4(num3, num4, z, w));
		}
	}
}
