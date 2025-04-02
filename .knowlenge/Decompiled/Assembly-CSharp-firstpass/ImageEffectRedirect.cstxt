using System;
using UnityEngine;

public class ImageEffectRedirect : MonoBehaviour
{
	[NonSerialized]
	public IImageEffect target;

	private void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		if ((target as Behaviour).enabled)
		{
			target.OnRenderImage(src, dst);
		}
		else
		{
			Graphics.Blit(src, dst);
		}
	}
}
