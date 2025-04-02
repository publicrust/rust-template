using Network;

public class SlotMachineStorage : StorageContainer
{
	public int Amount;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("SlotMachineStorage.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public bool IsPlayerValid(BasePlayer player)
	{
		if (!player.isMounted || player.GetMounted() != GetParentEntity())
		{
			return false;
		}
		return true;
	}

	public override bool PlayerOpenLoot(BasePlayer player, string panelToOpen = "", bool doPositionChecks = true)
	{
		if (!IsPlayerValid(player))
		{
			return false;
		}
		return base.PlayerOpenLoot(player, panelToOpen);
	}

	protected override void OnInventoryDirty()
	{
		base.OnInventoryDirty();
		UpdateAmount(base.inventory.GetSlot(0)?.amount ?? 0);
	}

	public void UpdateAmount(int amount)
	{
		if (Amount != amount)
		{
			Amount = amount;
			(GetParentEntity() as SlotMachine).OnBettingScrapUpdated(amount);
			ClientRPC(RpcTarget.NetworkGroup("RPC_UpdateAmount"), Amount);
		}
	}

	public override bool CanBeLooted(BasePlayer player)
	{
		if (!IsPlayerValid(player))
		{
			return false;
		}
		return base.CanBeLooted(player);
	}
}
