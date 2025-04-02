using System.Collections.Generic;
using UnityEngine;

public class LootGrid : MonoBehaviour
{
	public int Container;

	public int Offset;

	public int Count = 1;

	public GameObject ItemIconPrefab;

	public Sprite BackgroundImage;

	public ItemContainerSource Inventory;

	private List<ItemIcon> _icons = new List<ItemIcon>();

	public void CreateInventory(ItemContainerSource inventory, int? slots = null, int? offset = null)
	{
		foreach (ItemIcon icon in _icons)
		{
			Object.Destroy((Object)(object)((Component)icon).gameObject);
		}
		_icons.Clear();
		Inventory = inventory;
		Count = slots ?? Count;
		Offset = offset ?? Offset;
		for (int i = 0; i < Count; i++)
		{
			ItemIcon component = Object.Instantiate<GameObject>(ItemIconPrefab, ((Component)this).transform).GetComponent<ItemIcon>();
			component.slot = Offset + i;
			component.emptySlotBackgroundSprite = BackgroundImage ?? component.emptySlotBackgroundSprite;
			component.containerSource = inventory;
			_icons.Add(component);
		}
	}
}
