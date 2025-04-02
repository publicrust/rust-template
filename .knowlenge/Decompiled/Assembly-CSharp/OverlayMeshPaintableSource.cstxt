using System;
using UnityEngine;

public class OverlayMeshPaintableSource : MeshPaintableSource
{
	private static readonly Memoized<string, string> STPrefixed = new Memoized<string, string>((Func<string, string>)((string s) => s + "_ST"));

	public string baseTextureName = "_Decal1Texture";

	[NonSerialized]
	public Texture2D baseTexture;

	public override void UpdateMaterials(MaterialPropertyBlock block, Texture2D textureOverride = null, bool forEditing = false, bool isSelected = false)
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		base.UpdateMaterials(block, textureOverride, forEditing, isSelected);
		if ((Object)(object)baseTexture != (Object)null)
		{
			float num = (float)((Texture)baseTexture).width / (float)((Texture)baseTexture).height;
			int num2 = texWidth / texHeight;
			float num3 = 1f;
			float num4 = 0f;
			float num5 = 1f;
			float num6 = 0f;
			if ((float)num2 <= num)
			{
				float num7 = (float)texHeight * num;
				num3 = (float)texWidth / num7;
				num4 = (1f - num3) / 2f;
			}
			else
			{
				float num8 = (float)texWidth / num;
				num5 = (float)texHeight / num8;
				num6 = (1f - num5) / 2f;
			}
			block.SetTexture(baseTextureName, (Texture)(object)baseTexture);
			block.SetVector(STPrefixed.Get(baseTextureName), new Vector4(num3, num5, num4, num6));
		}
		else
		{
			block.SetTexture(baseTextureName, (Texture)(object)Texture2D.blackTexture);
		}
	}
}
