using System;
using UnityEngine;

[AddComponentMenu("")]
public class ImageEffects
{
	public static void RenderDistortion(Material material, RenderTexture source, RenderTexture destination, float angle, Vector2 center, Vector2 radius)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (((Texture)source).texelSize.y < 0f)
		{
			center.y = 1f - center.y;
			angle = 0f - angle;
		}
		Matrix4x4 val = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, angle), Vector3.one);
		material.SetMatrix("_RotationMatrix", val);
		material.SetVector("_CenterRadius", new Vector4(center.x, center.y, radius.x, radius.y));
		material.SetFloat("_Angle", angle * ((float)Math.PI / 180f));
		Graphics.Blit((Texture)(object)source, destination, material);
	}

	[Obsolete("Use Graphics.Blit(source,dest) instead")]
	public static void Blit(RenderTexture source, RenderTexture dest)
	{
		Graphics.Blit((Texture)(object)source, dest);
	}

	[Obsolete("Use Graphics.Blit(source, destination, material) instead")]
	public static void BlitWithMaterial(Material material, RenderTexture source, RenderTexture dest)
	{
		Graphics.Blit((Texture)(object)source, dest, material);
	}
}
