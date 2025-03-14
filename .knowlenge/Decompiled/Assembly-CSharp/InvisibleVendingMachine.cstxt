using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class InvisibleVendingMachine : NPCVendingMachine
{
	public GameObjectRef buyEffect;

	public NPCVendingOrderManifest vmoManifest;

	public NPCShopKeeper GetNPCShopKeeper()
	{
		List<NPCShopKeeper> obj = Pool.GetList<NPCShopKeeper>();
		Vis.Entities(base.transform.position, 2f, obj, 131072);
		NPCShopKeeper result = null;
		if (obj.Count > 0)
		{
			result = obj[0];
		}
		Pool.FreeList(ref obj);
		return result;
	}

	public void KeeperLookAt(Vector3 pos)
	{
		NPCShopKeeper nPCShopKeeper = GetNPCShopKeeper();
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
		NPCShopKeeper nPCShopKeeper = GetNPCShopKeeper();
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
	}

	public override void ServerInit()
	{
		base.ServerInit();
		if (vmoManifest.GetIndex(vendingOrders) == -1)
		{
			Debug.LogError("VENDING ORDERS NOT FOUND! Did you forget to add these orders to the VMOManifest?");
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (!info.fromDisk || !(vmoManifest != null) || info.msg.vendingMachine == null)
		{
			return;
		}
		if (info.msg.vendingMachine.vmoIndex == -1 && TerrainMeta.Path.Monuments != null)
		{
			foreach (MonumentInfo monument in TerrainMeta.Path.Monuments)
			{
				if (monument.displayPhrase.token.Contains("fish") && Vector3.Distance(monument.transform.position, base.transform.position) < 100f)
				{
					info.msg.vendingMachine.vmoIndex = 17;
				}
			}
		}
		NPCVendingOrder fromIndex = vmoManifest.GetFromIndex(info.msg.vendingMachine.vmoIndex);
		vendingOrders = fromIndex;
	}
}
