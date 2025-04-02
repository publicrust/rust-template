using System;
using System.Collections.Generic;
using UnityEngine;

public class FoodViewModel : BaseViewModel
{
	[Serializable]
	public class FoodVisualConfig
	{
		public List<FoodVisualObject> VisualItems = new List<FoodVisualObject>();

		public string TintMaterialProperty;

		private MaterialPropertyBlock materialPB;

		private int detailAlbedo;

		public void InitForItem(Item item)
		{
			if (item != null && !(item.info == null))
			{
				InitForItemDef(item.info);
			}
		}

		public void InitForItemDef(ItemDefinition itemDef)
		{
			if (itemDef == null)
			{
				return;
			}
			if (materialPB == null)
			{
				materialPB = new MaterialPropertyBlock();
				detailAlbedo = Shader.PropertyToID(TintMaterialProperty);
			}
			FoodVisualObject foodVisualObject = null;
			foreach (FoodVisualObject visualItem in VisualItems)
			{
				if (visualItem != null)
				{
					visualItem.SetVisible(flag: false);
					if (visualItem.ItemDef == itemDef)
					{
						foodVisualObject = visualItem;
					}
				}
			}
			if (foodVisualObject != null)
			{
				foodVisualObject.SetVisible(flag: true);
				foodVisualObject.ApplyTint(materialPB, detailAlbedo);
			}
		}

		public void HideAll()
		{
			foreach (FoodVisualObject visualItem in VisualItems)
			{
				visualItem?.SetVisible(flag: false);
			}
		}
	}

	[Serializable]
	public class FoodVisualObject
	{
		public ItemDefinition ItemDef;

		public List<GameObject> GameObjects;

		public SkinnedMeshRenderer TintSkinnedRenderer;

		public List<MeshRenderer> TintRenderers;

		public Color ColorTint;

		public void SetVisible(bool flag)
		{
			if (GameObjects == null)
			{
				return;
			}
			foreach (GameObject gameObject in GameObjects)
			{
				gameObject.SetActive(flag);
			}
		}

		public void ApplyTint(MaterialPropertyBlock mpb, int matPropertyName)
		{
			if (mpb == null || (TintSkinnedRenderer == null && TintRenderers == null) || matPropertyName == 0)
			{
				return;
			}
			mpb.SetColor(matPropertyName, ColorTint);
			if (TintSkinnedRenderer != null)
			{
				TintSkinnedRenderer.SetPropertyBlock(mpb, 0);
			}
			if (TintRenderers == null)
			{
				return;
			}
			foreach (MeshRenderer tintRenderer in TintRenderers)
			{
				if (!(tintRenderer == null))
				{
					tintRenderer.SetPropertyBlock(mpb, 0);
				}
			}
		}
	}

	public List<GameObject> VisualRoots;

	public FoodVisualConfig VisualConfig;
}
