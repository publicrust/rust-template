using System.Collections.Generic;
using Rust;

public interface IAmmoContainer
{
	Item FindAmmo(AmmoTypes ammoType);

	void FindAmmo(List<Item> list, AmmoTypes ammoType);

	Item FindItemByItemID(int id);

	List<Item> FindItemsByItemID(int id);

	Item FindItemByItemName(string name);

	bool HasAmmo(AmmoTypes ammoType);

	Item FindItemByUID(ItemId iUID);

	bool GiveItem(Item item, ItemContainer container = null);
}
