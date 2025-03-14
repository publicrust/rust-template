public interface IIndustrialStorage
{
	ItemContainer Container { get; }

	BaseEntity IndustrialEntity { get; }

	Vector2i InputSlotRange(int slotIndex);

	Vector2i OutputSlotRange(int slotIndex);

	void OnStorageItemTransferBegin();

	void OnStorageItemTransferEnd();
}
