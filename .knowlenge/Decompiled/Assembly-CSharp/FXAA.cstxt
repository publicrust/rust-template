using UnityEngine;

[AddComponentMenu("Image Effects/FXAA")]
public class FXAA : FXAAPostEffectsBase, IImageEffect
{
	public Shader shader;

	private Material mat;

	private void CreateMaterials()
	{
		if (mat == null)
		{
			mat = CheckShaderAndCreateMaterial(shader, mat);
		}
	}

	private void Start()
	{
		CreateMaterials();
		CheckSupport(needDepth: false);
	}

	public bool IsActive()
	{
		return base.enabled;
	}

	public void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		CreateMaterials();
		float num = 1f / (float)Screen.width;
		float num2 = 1f / (float)Screen.height;
		mat.SetVector("_rcpFrame", new Vector4(num, num2, 0f, 0f));
		mat.SetVector("_rcpFrameOpt", new Vector4(num * 2f, num2 * 2f, num * 0.5f, num2 * 0.5f));
		Graphics.Blit(source, destination, mat);
	}
}
