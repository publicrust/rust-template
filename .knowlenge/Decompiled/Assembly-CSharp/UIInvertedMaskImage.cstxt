using UnityEngine;
using UnityEngine.UI;

public class UIInvertedMaskImage : Image
{
	private Material cachedMaterial;

	public override Material materialForRendering
	{
		get
		{
			if (cachedMaterial == null)
			{
				cachedMaterial = Object.Instantiate(base.materialForRendering);
				cachedMaterial.SetInt("_StencilComp", 6);
			}
			return cachedMaterial;
		}
	}
}
