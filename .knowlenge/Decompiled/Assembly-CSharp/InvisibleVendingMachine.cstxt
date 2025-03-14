using ConVar;
using Facepunch;
using ProtoBuf;
using UnityEngine;

public class InvisibleVendingMachine : NPCVendingMachine
{
	public GameObjectRef buyEffect;

	public NPCVendingOrderManifest vmoManifest;

	public bool canRefreshOrders;

	public EntityRef<NPCShopKeeper> cachedShopKeeper;

	public const Flags HasAttachedShopkeeper = Flags.Reserved7;

	private static ListHashSet<InvisibleVendingMachine> allMachines = new ListHashSet<InvisibleVendingMachine>();

	public TimeUntil nextOrderRefresh;

	protected override bool BlockOrderRefreshOnLoad => canRefreshOrders;

	public static InvisibleVendingMachine GetMachineAtPosition(float tolerance, Vector3 position)
	{
		foreach (InvisibleVendingMachine allMachine in allMachines)
		{
			if (allMachine != null && allMachine.Distance(position) < tolerance)
			{
				return allMachine;
			}
		}
		return null;
	}

	public void KeeperLookAt(Vector3 pos)
	{
		NPCShopKeeper nPCShopKeeper = cachedShopKeeper.Get(base.isServer);
		if (!(nPCShopKeeper == null))
		{
			nPCShopKeeper.SetAimDirection(Vector3Ex.Direction2D(pos, nPCShopKeeper.transform.position));
		}
	}

	public override bool HasVendingSounds()
	{
		return false;
	}

	public override float GetBuyDuration()
	{
		return 0.5f;
	}

	public override void CompletePendingOrder()
	{
		Effect.server.Run(buyEffect.resourcePath, base.transform.position, Vector3.up);
		NPCShopKeeper nPCShopKeeper = cachedShopKeeper.Get(base.isServer);
		if ((bool)nPCShopKeeper)
		{
			nPCShopKeeper.SignalBroadcast(Signal.Gesture, "victory");
			if (vend_Player != null)
			{
				nPCShopKeeper.SetAimDirection(Vector3Ex.Direction2D(vend_Player.transform.position, nPCShopKeeper.transform.position));
			}
		}
		base.CompletePendingOrder();
	}

	public override bool PlayerOpenLoot(BasePlayer player, string panelToOpen = "", bool doPositionChecks = true)
	{
		KeeperLookAt(player.transform.position);
		return base.PlayerOpenLoot(player, panelToOpen);
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (vmoManifest != null && info.msg.vendingMachine != null)
		{
			info.msg.vendingMachine.vmoIndex = vmoManifest.GetIndex(vendingOrders);
		}
		info.msg.npcVendingMachine = Facepunch.Pool.Get<ProtoBuf.NPCVendingMachine>();
		info.msg.npcVendingMachine.attachedNpc = cachedShopKeeper.uid;
		info.msg.npcVendingMachine.nextRefresh = nextOrderRefresh;
	}

	public override void ServerInit()
	{
		base.ServerInit();
		if (vmoManifest.GetIndex(vendingOrders) == -1)
		{
			Debug.LogError("VENDING ORDERS NOT FOUND! Did you forget to add these orders to the VMOManifest?");
		}
		if (canRefreshOrders)
		{
			nextOrderRefresh = Server.waterWellNpcSalesRefreshFrequency * 60f * 60f;
			InvokeRepeating(CheckSellOrderRefresh, 30f, 30f);
		}
		allMachines.TryAdd(this);
	}

	internal override void DoServerDestroy()
	{
		base.DoServerDestroy();
		allMachines.Remove(this);
	}

	public void CheckSellOrderRefresh()
	{
		if ((float)nextOrderRefresh < 0f)
		{
			nextOrderRefresh = Server.waterWellNpcSalesRefreshFrequency * 60f * 60f;
			InstallFromVendingOrders();
		}
	}

	public void SetAttachedNPC(NPCShopKeeper shopkeeper)
	{
		cachedShopKeeper.Set(shopkeeper);
		SetFlag(Flags.Reserved7, shopkeeper != null);
		SendNetworkUpdate();
	}

	public override bool CanBeLooted(BasePlayer player)
	{
		if (cachedShopKeeper.Get(base.isServer) == null)
		{
			return false;
		}
		return base.CanBeLooted(player);
	}

	protected override bool CanShop(BasePlayer bp)
	{
		if (base.CanShop(bp))
		{
			return cachedShopKeeper.Get(base.isServer) != null;
		}
		return false;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.fromDisk && vmoManifest != null && info.msg.vendingMachine != null)
		{
			NPCVendingOrder fromIndex = vmoManifest.GetFromIndex(info.msg.vendingMachine.vmoIndex);
			vendingOrders = fromIndex;
		}
		if (info.msg.npcVendingMachine != null)
		{
			cachedShopKeeper.uid = info.msg.npcVendingMachine.attachedNpc;
			if (base.isServer)
			{
				nextOrderRefresh = info.msg.npcVendingMachine.nextRefresh;
			}
		}
	}
}
