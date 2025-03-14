public class ElectricFurnaceIO : IOEntity, IIndustrialStorage
{
	public int PowerConsumption = 3;

	public ItemContainer Container => GetParentOven().inventory;

	public BaseEntity IndustrialEntity => this;

	public override int ConsumptionAmount()
	{
		return PowerConsumption;
	}

	public override int DesiredPower()
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

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
		if (base.isServer)
		{
			ElectricOven parentOven = GetParentOven();
			if (parentOven != null)
			{
				parentOven.OnIOEntityFlagsChanged(old, next);
			}
		}
	}

	public override void UpdateHasPower(int inputAmount, int inputSlot)
	{
		if (inputSlot == 0)
		{
			base.UpdateHasPower(inputAmount, inputSlot);
		}
		if (inputSlot == 1 && inputAmount > 0)
		{
			ElectricOven parentOven = GetParentOven();
			if (parentOven != null)
			{
				parentOven.StartCooking();
			}
		}
		if (inputSlot == 2 && inputAmount > 0)
		{
			ElectricOven parentOven2 = GetParentOven();
			if (parentOven2 != null)
			{
				parentOven2.StopCooking();
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
