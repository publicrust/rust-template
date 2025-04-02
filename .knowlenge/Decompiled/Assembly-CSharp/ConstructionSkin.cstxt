using System.Collections.Generic;
using UnityEngine;

public class ConstructionSkin : BasePrefab
{
	public List<GameObject> conditionals;

	public int DetermineConditionalModelState(BuildingBlock parent)
	{
		ConditionalModel[] array = PrefabAttribute.server.FindAll<ConditionalModel>(prefabID);
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].RunTests(parent))
			{
				num |= 1 << i;
			}
		}
		return num;
	}

	private void CreateConditionalModels(BuildingBlock parent)
	{
		ConditionalModel[] array = PrefabAttribute.server.FindAll<ConditionalModel>(prefabID);
		for (int i = 0; i < array.Length; i++)
		{
			if (!parent.GetConditionalModel(i))
			{
				continue;
			}
			GameObject gameObject = array[i].InstantiateSkin(parent);
			if (!(gameObject == null))
			{
				if (conditionals == null)
				{
					conditionals = new List<GameObject>();
				}
				conditionals.Add(gameObject);
			}
		}
	}

	private void DestroyConditionalModels(BuildingBlock parent)
	{
		if (conditionals != null)
		{
			for (int i = 0; i < conditionals.Count; i++)
			{
				parent.gameManager.Retire(conditionals[i]);
			}
			conditionals.Clear();
		}
	}

	public virtual void Refresh(BuildingBlock parent)
	{
		DestroyConditionalModels(parent);
		CreateConditionalModels(parent);
		if (!parent.HasWallpaper())
		{
			return;
		}
		foreach (GameObject conditional in conditionals)
		{
			if (conditional.CompareTag("Wallpaper"))
			{
				SkinHelpers.SetSkin(conditional, WallpaperPlanner.WallpaperItemDef, (conditional.transform.localRotation.y == 0f) ? parent.wallpaperID : parent.wallpaperID2);
			}
		}
	}

	public void Destroy(BuildingBlock parent)
	{
		DestroyConditionalModels(parent);
		parent.gameManager.Retire(base.gameObject);
	}

	public virtual uint GetStartingDetailColour(uint playerColourIndex)
	{
		return 0u;
	}
}
