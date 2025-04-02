using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemPreviewIcon : BaseMonoBehaviour, IInventoryChanged, IItemAmountChanged, IItemIconChanged
{
	public ItemContainerSource containerSource;

	[Range(0f, 64f)]
	public int slot;

	public bool setSlotFromSiblingIndex = true;

	public CanvasGroup iconContents;

	public Image iconImage;

	public Text amountText;

	[NonSerialized]
	public Item item;
}
