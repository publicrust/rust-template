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
			if (item != null && !((Object)(object)item.info == (Object)null))
			{
				InitForItemDef(item.info);
			}
		}

		public void InitForItemDef(ItemDefinition itemDef)
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Expected O, but got Unknown
			if ((Object)(object)itemDef == (Object)null)
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
					if ((Object)(object)visualItem.ItemDef == (Object)(object)itemDef)
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
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			if (mpb == null || ((Object)(object)TintSkinnedRenderer == (Object)null && TintRenderers == null) || matPropertyName == 0)
			{
				return;
			}
			mpb.SetColor(matPropertyName, ColorTint);
			if ((Object)(object)TintSkinnedRenderer != (Object)null)
			{
				((Renderer)TintSkinnedRenderer).SetPropertyBlock(mpb, 0);
			}
			if (TintRenderers == null)
			{
				return;
			}
			foreach (MeshRenderer tintRenderer in TintRenderers)
			{
				if (!((Object)(object)tintRenderer == (Object)null))
				{
					((Renderer)tintRenderer).SetPropertyBlock(mpb, 0);
				}
			}
		}
	}

	public List<GameObject> VisualRoots;

	public FoodVisualConfig VisualConfig;
}
