using UnityEngine;

public class ItemModActionContainerChange : ItemMod
{
	public ItemMod[] actions;

	public override void OnParentChanged(Item item)
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
			Debug.LogWarning((object)"ItemModMenuOption: actions is null!", (Object)(object)((Component)this).gameObject);
		}
	}
}
