using UnityEngine;

public interface IItemContainerEntity : IIdealSlotEntity, ILootableEntity, IInventoryProvider
{
	ItemContainer inventory { get; }

	Transform Transform { get; }

	bool DropsLoot { get; }

	float DestroyLootPercent { get; }

	bool DropFloats { get; }

	void DropItems(BaseEntity initiator = null);

	bool PlayerOpenLoot(BasePlayer player, string panelToOpen = "", bool doPositionChecks = true);

	bool ShouldDropItemsIndividually();

	void DropBonusItems(BaseEntity initiator, ItemContainer container);

	Vector3 GetDropPosition();
}
