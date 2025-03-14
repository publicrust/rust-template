using UnityEngine;

[ExecuteInEditMode]
public class MaterialOverlay : MonoBehaviour
{
	public Material material;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!material)
		{
			Graphics.Blit(source, destination);
			return;
		}
		for (int i = 0; i < material.passCount; i++)
		{
			Graphics.Blit(source, destination, material, i);
		}
	}
}
