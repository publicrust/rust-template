using UnityEngine;

public class ItemModActionChange : ItemMod
{
	public ItemMod[] actions;

	public override void OnChanged(Item item)
	{
		if (!item.isServer)
		{
			return;
		}
		BasePlayer ownerPlayer = item.GetOwnerPlayer();
		ItemMod[] array = actions;
		foreach (ItemMod itemMod in array)
		{
			if (itemMod.CanDoAction(item, ownerPlayer))
			{
				itemMod.DoAction(item, ownerPlayer);
			}
		}
	}

	private void OnValidate()
	{
		if (actions == null)
		{
			Debug.LogWarning("ItemModMenuOption: actions is null!", base.gameObject);
		}
	}
}
