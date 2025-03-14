using System;
using UnityEngine;

[Serializable]
public class LODGroupRenderers
{
	public LODGroup lodGroup;

	public Renderer[] renderers;

	public void SetRenderersEnabled(bool enabled)
	{
		Renderer[] array = renderers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = enabled;
		}
	}
}
