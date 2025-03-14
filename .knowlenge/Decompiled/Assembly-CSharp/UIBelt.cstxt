using System.Collections.Generic;
using System.Linq;

public class UIBelt : SingletonComponent<UIBelt>
{
	public List<ItemIcon> ItemIcons;

	protected override void Awake()
	{
		ItemIcons = (from s in GetComponentsInChildren<ItemIcon>()
			orderby s.slot
			select s).ToList();
	}

	public ItemIcon GetItemIconAtSlot(int slot)
	{
		if (slot < 0 || slot >= ItemIcons.Count)
		{
			return null;
		}
		return ItemIcons[slot];
	}
}
