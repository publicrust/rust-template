using UnityEngine;

[ExecuteInEditMode]
public class LinearFog : MonoBehaviour
{
	public Material fogMaterial;

	public Color fogColor = Color.white;

	public float fogStart;

	public float fogRange = 1f;

	public float fogDensity = 1f;

	public bool fogSky;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)fogMaterial))
		{
			Graphics.Blit((Texture)(object)source, destination);
			return;
		}
		fogMaterial.SetColor("_FogColor", fogColor);
		fogMaterial.SetFloat("_Start", fogStart);
		fogMaterial.SetFloat("_Range", fogRange);
		fogMaterial.SetFloat("_Density", fogDensity);
		if (fogSky)
		{
			fogMaterial.SetFloat("_CutOff", 2f);
		}
		else
		{
			fogMaterial.SetFloat("_CutOff", 1f);
		}
		for (int i = 0; i < fogMaterial.passCount; i++)
		{
			Graphics.Blit((Texture)(object)source, destination, fogMaterial, i);
		}
	}
}
