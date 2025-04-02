using System;
using System.Collections.Generic;
using System.Linq;
using Rust.UI;
using UnityEngine;

public class OvenItemIcon : MonoBehaviour
{
	[Serializable]
	public class OvenSlotConfig
	{
		public OvenSlotType Type;

		public Sprite BackgroundImage;

		public Phrase SlotPhrase;
	}

	public ItemIcon ItemIcon;

	public RustText ItemLabel;

	public RustText MaterialLabel;

	public OvenSlotType SlotType;

	public Phrase EmptyPhrase = new Phrase("empty", "empty");

	public List<OvenSlotConfig> SlotConfigs = new List<OvenSlotConfig>();

	public float DisabledAlphaScale;

	public CanvasGroup CanvasGroup;

	private Item _item;

	private void Start()
	{
		OvenSlotConfig ovenSlotConfig = SlotConfigs.FirstOrDefault((OvenSlotConfig x) => x.Type == SlotType);
		if (ovenSlotConfig == null)
		{
			Debug.LogError((object)$"Can't find slot config for '{SlotType}'");
			return;
		}
		ItemIcon.emptySlotBackgroundSprite = ovenSlotConfig.BackgroundImage;
		MaterialLabel.SetPhrase(ovenSlotConfig.SlotPhrase, Array.Empty<object>());
		UpdateLabels();
	}

	private void Update()
	{
		if (ItemIcon.item != _item)
		{
			_item = ItemIcon.item;
			UpdateLabels();
		}
	}

	private void UpdateLabels()
	{
		CanvasGroup.alpha = ((_item != null) ? 1f : DisabledAlphaScale);
		RustText itemLabel = ItemLabel;
		if (itemLabel != null)
		{
			itemLabel.SetPhrase((_item == null) ? EmptyPhrase : _item.info.displayName, Array.Empty<object>());
		}
	}
}
