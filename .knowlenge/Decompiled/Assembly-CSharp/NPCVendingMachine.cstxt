using Facepunch.Rust;
using Oxide.Core;
using UnityEngine;

public class NPCVendingMachine : VendingMachine
{
	public NPCVendingOrder vendingOrders;

	private float[] refillTimes;

	public byte GetBPState(bool sellItemAsBP, bool currencyItemAsBP)
	{
		byte result = 0;
		if (sellItemAsBP)
		{
			result = 1;
		}
		if (currencyItemAsBP)
		{
			result = 2;
		}
		if (sellItemAsBP && currencyItemAsBP)
		{
			result = 3;
		}
		return result;
	}

	public override void TakeCurrencyItem(Item takenCurrencyItem)
	{
		if (Interface.CallHook("OnTakeCurrencyItem", this, takenCurrencyItem) == null)
		{
			takenCurrencyItem.MoveToContainer(base.inventory);
			takenCurrencyItem.RemoveFromContainer();
			takenCurrencyItem.Remove();
		}
	}

	public override void GiveSoldItem(Item soldItem, BasePlayer buyer)
	{
		if (Interface.CallHook("OnNpcGiveSoldItem", this, soldItem, buyer) == null)
		{
			base.GiveSoldItem(soldItem, buyer);
		}
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		Invoke(InstallFromVendingOrders, 1f);
	}

	public override void ServerInit()
	{
		base.ServerInit();
		skinID = 861142659uL;
		SendNetworkUpdate();
		Invoke(InstallFromVendingOrders, 1f);
		InvokeRandomized(Refill, 1f, 1f, 0.1f);
	}

	public virtual void InstallFromVendingOrders()
	{
		if (vendingOrders == null)
		{
			Debug.LogError("No vending orders!");
			return;
		}
		ClearSellOrders();
		base.inventory.Clear();
		ItemManager.DoRemoves();
		NPCVendingOrder.Entry[] orders = vendingOrders.orders;
		foreach (NPCVendingOrder.Entry entry in orders)
		{
			AddItemForSale(entry.sellItem.itemid, entry.sellItemAmount, entry.currencyItem.itemid, entry.currencyAmount, GetBPState(entry.sellItemAsBP, entry.currencyAsBP));
		}
	}

	public override void InstallDefaultSellOrders()
	{
		base.InstallDefaultSellOrders();
	}

	public void Refill()
	{
		if (vendingOrders == null || vendingOrders.orders == null || base.inventory == null)
		{
			return;
		}
		if (refillTimes == null)
		{
			refillTimes = new float[vendingOrders.orders.Length];
		}
		for (int i = 0; i < vendingOrders.orders.Length; i++)
		{
			NPCVendingOrder.Entry entry = vendingOrders.orders[i];
			if (!(Time.realtimeSinceStartup > refillTimes[i]))
			{
				continue;
			}
			int num = Mathf.FloorToInt(base.inventory.GetAmount(entry.sellItem.itemid, onlyUsableAmounts: false) / entry.sellItemAmount);
			int num2 = Mathf.Min(10 - num, entry.refillAmount) * entry.sellItemAmount;
			if (num2 > 0)
			{
				transactionActive = true;
				Item item = null;
				if (entry.sellItemAsBP)
				{
					item = ItemManager.Create(blueprintBaseDef, num2, 0uL);
					item.blueprintTarget = entry.sellItem.itemid;
				}
				else
				{
					item = ItemManager.Create(entry.sellItem, num2, 0uL);
				}
				item.MoveToContainer(base.inventory);
				transactionActive = false;
			}
			refillTimes[i] = Time.realtimeSinceStartup + entry.refillDelay;
		}
	}

	public void ClearSellOrders()
	{
		sellOrders.sellOrders.Clear();
	}

	public void AddItemForSale(int itemID, int amountToSell, int currencyID, int currencyPerTransaction, byte bpState)
	{
		AddSellOrder(itemID, amountToSell, currencyID, currencyPerTransaction, bpState);
		transactionActive = true;
		int num = 10;
		if (bpState == 1 || bpState == 3)
		{
			for (int i = 0; i < num; i++)
			{
				Item item = ItemManager.CreateByItemID(blueprintBaseDef.itemid, 1, 0uL);
				item.blueprintTarget = itemID;
				base.inventory.Insert(item);
			}
		}
		else
		{
			base.inventory.AddItem(ItemManager.FindItemDefinition(itemID), amountToSell * num, 0uL);
		}
		transactionActive = false;
		RefreshSellOrderStockLevel();
	}

	public void RefreshStock()
	{
	}

	protected override void RecordSaleAnalytics(Item itemSold)
	{
		Facepunch.Rust.Analytics.Server.VendingMachineTransaction(vendingOrders, itemSold.info, itemSold.amount);
	}

	protected override bool CanRotate()
	{
		return false;
	}

	public override bool CanPlayerAdmin(BasePlayer player)
	{
		object obj = Interface.CallHook("CanAdministerVending", player, this);
		if (obj is bool)
		{
			return (bool)obj;
		}
		return false;
	}
}
