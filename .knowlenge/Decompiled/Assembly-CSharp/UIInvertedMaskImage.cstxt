using UnityEngine;
using UnityEngine.UI;

public class UIInvertedMaskImage : Image
{
	private Material cachedMaterial;

	public override Material materialForRendering
	{
		get
		{
			if ((Object)(object)cachedMaterial == (Object)null)
			{
				cachedMaterial = Object.Instantiate<Material>(((Graphic)this).materialForRendering);
				cachedMaterial.SetInt("_StencilComp", 6);
			}
			return cachedMaterial;
		}
	}
}
