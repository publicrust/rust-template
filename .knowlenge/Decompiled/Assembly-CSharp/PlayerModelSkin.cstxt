using UnityEngine;

public class PlayerModelSkin : MonoBehaviour, IPrefabPreProcess
{
	public enum SkinMaterialType
	{
		HEAD,
		EYE,
		BODY
	}

	public SkinMaterialType MaterialType;

	public Renderer SkinRenderer;

	public void Setup(SkinSetCollection skin, float hairNum, float meshNum)
	{
		if ((bool)SkinRenderer && (bool)skin)
		{
			switch (MaterialType)
			{
			case SkinMaterialType.HEAD:
				SkinRenderer.sharedMaterial = skin.Get(meshNum).HeadMaterial;
				break;
			case SkinMaterialType.BODY:
				SkinRenderer.sharedMaterial = skin.Get(meshNum).BodyMaterial;
				break;
			case SkinMaterialType.EYE:
				SkinRenderer.sharedMaterial = skin.Get(meshNum).EyeMaterial;
				break;
			default:
				SkinRenderer.sharedMaterial = skin.Get(meshNum).BodyMaterial;
				break;
			}
		}
	}

	public void PreProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		if (clientside)
		{
			SkinRenderer = GetComponent<Renderer>();
		}
	}
}
