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
		RenderTexture renderTexture = new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32, linear ? RenderTextureReadWrite.Linear : RenderTextureReadWrite.sRGB);
		renderTexture.hideFlags = HideFlags.DontSave;
		renderTexture.name = name;
		renderTexture.filterMode = FilterMode.Bilinear;
		renderTexture.anisoLevel = 0;
		renderTexture.Create();
		return renderTexture;
	}

	protected void DestroyRenderTexture(ref RenderTexture rt)
	{
		if (!(rt == null))
		{
			Object.Destroy(rt);
			rt = null;
		}
	}

	protected RenderTexture CreateTemporary()
	{
		return RenderTexture.GetTemporary(result.width, result.height, result.depth, result.format, (!result.sRGB) ? RenderTextureReadWrite.Linear : RenderTextureReadWrite.sRGB);
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
		return new Material(shader)
		{
			hideFlags = HideFlags.DontSave
		};
	}

	protected void DestroyMaterial(ref Material mat)
	{
		if (!(mat == null))
		{
			Object.Destroy(mat);
			mat = null;
		}
	}

	public static implicit operator Texture(ProcessedTexture t)
	{
		return t.result;
	}
}
