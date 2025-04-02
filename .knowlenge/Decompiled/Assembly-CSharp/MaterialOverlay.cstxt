using UnityEngine;

[ExecuteInEditMode]
public class MaterialOverlay : MonoBehaviour
{
	public Material material;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!Object.op_Implicit((Object)(object)material))
		{
			Graphics.Blit((Texture)(object)source, destination);
			return;
		}
		for (int i = 0; i < material.passCount; i++)
		{
			Graphics.Blit((Texture)(object)source, destination, material, i);
		}
	}
}
