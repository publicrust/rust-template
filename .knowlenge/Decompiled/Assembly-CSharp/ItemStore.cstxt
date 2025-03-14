using System.Collections.Generic;
using Facepunch;
using TMPro;
using UnityEngine;

public class ItemStore : SingletonComponent<ItemStore>, VirtualScroll.IDataSource
{
	public GameObject ItemPrefab;

	public RectTransform ItemParent;

	public List<IPlayerItemDefinition> Cart = new List<IPlayerItemDefinition>();

	public ItemStoreItemInfoModal ItemStoreInfoModal;

	public GameObject BuyingModal;

	public ItemStoreBuyFailedModal ItemStoreBuyFailedModal;

	public ItemStoreBuySuccessModal ItemStoreBuySuccessModal;

	public SoundDefinition AddToCartSound;

	public TextMeshProUGUI TotalValue;

	public int GetItemCount()
	{
		return Cart.Count;
	}

	public void SetItemData(int i, GameObject obj)
	{
		obj.GetComponent<ItemStoreCartItem>().Init(i, Cart[i]);
	}
}
