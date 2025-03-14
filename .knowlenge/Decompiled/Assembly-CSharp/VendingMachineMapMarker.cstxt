using System;
using System.Collections.Generic;
using Facepunch;
using ProtoBuf;

public class VendingMachineMapMarker : MapMarker
{
	public string markerShopName;

	public VendingMachine server_vendingMachine;

	public ProtoBuf.VendingMachine client_vendingMachine;

	[NonSerialized]
	public NetworkableId client_vendingMachineNetworkID;

	public GameObjectRef clusterMarkerObj;

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.vendingMachine = new ProtoBuf.VendingMachine();
		info.msg.vendingMachine.shopName = markerShopName;
		if (!(server_vendingMachine != null))
		{
			return;
		}
		info.msg.vendingMachine.networkID = server_vendingMachine.net.ID;
		info.msg.vendingMachine.sellOrderContainer = new ProtoBuf.VendingMachine.SellOrderContainer();
		info.msg.vendingMachine.sellOrderContainer.ShouldPool = false;
		info.msg.vendingMachine.sellOrderContainer.sellOrders = new List<ProtoBuf.VendingMachine.SellOrder>();
		foreach (ProtoBuf.VendingMachine.SellOrder sellOrder2 in server_vendingMachine.sellOrders.sellOrders)
		{
			ProtoBuf.VendingMachine.SellOrder sellOrder = new ProtoBuf.VendingMachine.SellOrder
			{
				ShouldPool = false
			};
			sellOrder2.CopyTo(sellOrder);
			info.msg.vendingMachine.sellOrderContainer.sellOrders.Add(sellOrder);
		}
	}

	public override AppMarker GetAppMarkerData()
	{
		AppMarker appMarkerData = base.GetAppMarkerData();
		appMarkerData.name = markerShopName ?? "";
		appMarkerData.outOfStock = !HasFlag(Flags.Busy);
		if (server_vendingMachine != null)
		{
			appMarkerData.sellOrders = Pool.GetList<AppMarker.SellOrder>();
			foreach (ProtoBuf.VendingMachine.SellOrder sellOrder2 in server_vendingMachine.sellOrders.sellOrders)
			{
				AppMarker.SellOrder sellOrder = Pool.Get<AppMarker.SellOrder>();
				sellOrder.itemId = sellOrder2.itemToSellID;
				sellOrder.quantity = sellOrder2.itemToSellAmount;
				sellOrder.currencyId = sellOrder2.currencyID;
				sellOrder.costPerItem = sellOrder2.currencyAmountPerItem;
				sellOrder.amountInStock = sellOrder2.inStock;
				sellOrder.itemIsBlueprint = sellOrder2.itemToSellIsBP;
				sellOrder.currencyIsBlueprint = sellOrder2.currencyIsBP;
				sellOrder.itemCondition = sellOrder2.itemCondition;
				sellOrder.itemConditionMax = sellOrder2.itemConditionMax;
				appMarkerData.sellOrders.Add(sellOrder);
			}
		}
		return appMarkerData;
	}
}
