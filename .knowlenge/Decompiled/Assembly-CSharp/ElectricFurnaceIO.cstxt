public class ElectricFurnaceIO : IOEntity, IIndustrialStorage
{
	public int PowerConsumption = 3;

	public ItemContainer Container => GetParentOven().inventory;

	public BaseEntity IndustrialEntity => this;

	public override int ConsumptionAmount()
	{
		return PowerConsumption;
	}

	public override int DesiredPower(int inputIndex = 0)
	{
		if (GetParentEntity() == null)
		{
			return 0;
		}
		if (!GetParentEntity().IsOn())
		{
			return 0;
		}
		return PowerConsumption;
	}

	public override void UpdateHasPower(int inputAmount, int inputSlot)
	{
		base.UpdateHasPower(inputAmount, inputSlot);
		ElectricOven parentOven = GetParentOven();
		if (!(parentOven == null))
		{
			if (inputAmount > 0)
			{
				parentOven.StartCooking();
			}
			else
			{
				parentOven.StopCooking();
			}
		}
	}

	private ElectricOven GetParentOven()
	{
		return GetParentEntity() as ElectricOven;
	}

	public Vector2i InputSlotRange(int slotIndex)
	{
		return new Vector2i(1, 2);
	}

	public Vector2i OutputSlotRange(int slotIndex)
	{
		return new Vector2i(3, 5);
	}

	public void OnStorageItemTransferBegin()
	{
	}

	public void OnStorageItemTransferEnd()
	{
	}
}
