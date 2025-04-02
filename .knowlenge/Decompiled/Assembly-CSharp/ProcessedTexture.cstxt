using UnityEngine;

public class ProcessedTexture
{
	protected RenderTexture result;

	protected Material material;

	public void Dispose()
	{
		DestroyRenderTexture(ref result);
		DestroyMaterial(ref material);
	}

	protected RenderTexture CreateRenderTexture(string name, int width, int height, bool linear)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		RenderTexture val = new RenderTexture(width, height, 0, (RenderTextureFormat)0, (RenderTextureReadWrite)(linear ? 1 : 2))
		{
			hideFlags = (HideFlags)52,
			name = name,
			filterMode = (FilterMode)1,
			anisoLevel = 0
		};
		val.Create();
		return val;
	}

	protected void DestroyRenderTexture(ref RenderTexture rt)
	{
		if (!((Object)(object)rt == (Object)null))
		{
			Object.Destroy((Object)(object)rt);
			rt = null;
		}
	}

	protected RenderTexture CreateTemporary()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		return RenderTexture.GetTemporary(((Texture)result).width, ((Texture)result).height, result.depth, result.format, (RenderTextureReadWrite)((!result.sRGB) ? 1 : 2));
	}

	protected void ReleaseTemporary(RenderTexture rt)
	{
		RenderTexture.ReleaseTemporary(rt);
	}

	protected Material CreateMaterial(string shader)
	{
		return CreateMaterial(Shader.Find(shader));
	}

	protected Material CreateMaterial(Shader shader)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		return new Material(shader)
		{
			hideFlags = (HideFlags)52
		};
	}

	protected void DestroyMaterial(ref Material mat)
	{
		if (!((Object)(object)mat == (Object)null))
		{
			Object.Destroy((Object)(object)mat);
			mat = null;
		}
	}

	public static implicit operator Texture(ProcessedTexture t)
	{
		return (Texture)(object)t.result;
	}
}
