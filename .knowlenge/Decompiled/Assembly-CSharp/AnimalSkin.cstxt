using UnityEngine;

public class AnimalSkin : MonoBehaviour, IClientComponent
{
	public SkinnedMeshRenderer[] animalMesh;

	public AnimalMultiSkin[] animalSkins;

	private Model model;

	public bool dontRandomizeOnStart;

	private void Start()
	{
		model = base.gameObject.GetComponent<Model>();
		if (!dontRandomizeOnStart)
		{
			int iSkin = Mathf.FloorToInt(Random.Range(0, animalSkins.Length));
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
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
		{
			Material[] sharedMaterials = skinnedMeshRenderer.sharedMaterials;
			if (sharedMaterials != null)
			{
				for (int j = 0; j < sharedMaterials.Length; j++)
				{
					sharedMaterials[j] = animalSkins[iSkin].multiSkin[j];
				}
				skinnedMeshRenderer.sharedMaterials = sharedMaterials;
			}
		}
		if (model != null)
		{
			model.skin = iSkin;
		}
	}
}
