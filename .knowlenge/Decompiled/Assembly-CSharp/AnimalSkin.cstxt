using UnityEngine;

public class AnimalSkin : MonoBehaviour, IClientComponent
{
	public SkinnedMeshRenderer[] animalMesh;

	public AnimalMultiSkin[] animalSkins;

	private Model model;

	public bool dontRandomizeOnStart;

	private void Start()
	{
		model = ((Component)this).gameObject.GetComponent<Model>();
		if (!dontRandomizeOnStart)
		{
			int iSkin = Mathf.FloorToInt((float)Random.Range(0, animalSkins.Length));
			ChangeSkin(iSkin);
		}
	}

	public void ChangeSkin(int iSkin)
	{
		if (animalSkins.Length == 0)
		{
			return;
		}
		iSkin = Mathf.Clamp(iSkin, 0, animalSkins.Length - 1);
		SkinnedMeshRenderer[] array = animalMesh;
		foreach (SkinnedMeshRenderer val in array)
		{
			Material[] sharedMaterials = ((Renderer)val).sharedMaterials;
			if (sharedMaterials != null)
			{
				for (int j = 0; j < sharedMaterials.Length; j++)
				{
					sharedMaterials[j] = animalSkins[iSkin].multiSkin[j];
				}
				((Renderer)val).sharedMaterials = sharedMaterials;
			}
		}
		if ((Object)(object)model != (Object)null)
		{
			model.skin = iSkin;
		}
	}
}
