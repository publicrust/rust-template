using UnityEngine;
using UnityEngine.Rendering;

public static class CommandBufferEx
{
	public static void BlitArray(this CommandBuffer cb, Mesh blitMesh, RenderTargetIdentifier source, Material mat, int slice, int pass = 0)
	{
		cb.SetGlobalTexture("_Source", source);
		cb.SetGlobalFloat("_SourceMip", 0f);
		if (slice >= 0)
		{
			cb.SetGlobalFloat("_SourceSlice", slice);
			cb.SetGlobalInt("_TargetSlice", slice);
		}
		cb.DrawMesh(blitMesh, Matrix4x4.identity, mat, 0, pass);
	}

	public static void BlitArray(this CommandBuffer cb, Mesh blitMesh, RenderTargetIdentifier source, Texture target, Material mat, int slice, int pass = 0)
	{
		cb.SetRenderTarget(target, 0, CubemapFace.Unknown, -1);
		cb.SetGlobalTexture("_Source", source);
		cb.SetGlobalFloat("_SourceMip", 0f);
		if (slice >= 0)
		{
			cb.SetGlobalFloat("_SourceSlice", slice);
			cb.SetGlobalInt("_TargetSlice", slice);
		}
		cb.DrawMesh(blitMesh, Matrix4x4.identity, mat, 0, pass);
	}

	public static void BlitArrayMip(this CommandBuffer cb, Mesh blitMesh, Texture source, int sourceMip, int sourceSlice, Texture target, int targetMip, int targetSlice, Material mat, int pass = 0)
	{
		int num = source.width >> sourceMip;
		int num2 = source.height >> sourceMip;
		Vector4 value = new Vector4(1f / (float)num, 1f / (float)num2, num, num2);
		int num3 = target.width >> targetMip;
		int num4 = target.height >> targetMip;
		Vector4 value2 = new Vector4(1f / (float)num3, 1f / (float)num4, num3, num4);
		cb.SetGlobalTexture("_Source", source);
		cb.SetGlobalVector("_Source_TexelSize", value);
		cb.SetGlobalVector("_Target_TexelSize", value2);
		cb.SetGlobalFloat("_SourceMip", sourceMip);
		if (sourceSlice >= 0)
		{
			cb.SetGlobalFloat("_SourceSlice", sourceSlice);
			cb.SetGlobalInt("_TargetSlice", targetSlice);
		}
		cb.SetRenderTarget(target, targetMip, CubemapFace.Unknown, -1);
		cb.DrawMesh(blitMesh, Matrix4x4.identity, mat, 0, pass);
	}

	public static void BlitMip(this CommandBuffer cb, Mesh blitMesh, Texture source, Texture target, int mip, int slice, Material mat, int pass = 0)
	{
		BlitArrayMip(cb, blitMesh, source, mip, slice, target, mip, slice, mat, pass);
	}
}
