#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using Oxide.Core;
using UnityEngine;
using UnityEngine.Assertions;

public class CollectibleEntity : BaseEntity, IPrefabPreProcess
{
	public Translate.Phrase itemName;

	public ItemAmount[] itemList;

	public GameObjectRef pickupEffect;

	public float xpScale = 1f;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("CollectibleEntity.OnRpcMessage"))
		{
			if (rpc == 2778075470u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - Pickup "));
				}
				using (TimeWarning.New("Pickup"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.MaxDistance.Test(2778075470u, "Pickup", this, player, 3f))
						{
							return true;
						}
					}
					try
					{
						using (TimeWarning.New("Call"))
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg2 = rPCMessage;
							Pickup(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in Pickup");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public bool IsFood()
	{
		for (int i = 0; i < itemList.Length; i++)
		{
			if (itemList[i].itemDef.category == ItemCategory.Food)
			{
				return true;
			}
		}
		return false;
	}

	public void DoPickup(BasePlayer reciever)
	{
		if (itemList == null)
		{
			return;
		}
		ItemAmount[] array = itemList;
		foreach (ItemAmount itemAmount in array)
		{
			Item item = ItemManager.Create(itemAmount.itemDef, (int)itemAmount.amount, 0uL);
			if (item == null)
			{
				continue;
			}
			if ((bool)reciever)
			{
				if (Interface.CallHook("OnCollectiblePickup", item, reciever, this) != null)
				{
					return;
				}
				reciever.GiveItem(item, GiveItemReason.ResourceHarvested);
			}
			else
			{
				item.Drop(base.transform.position + Vector3.up * 0.5f, Vector3.up);
			}
		}
		itemList = null;
		if (pickupEffect.isValid)
		{
			Effect.server.Run(pickupEffect.resourcePath, base.transform.position, base.transform.up);
		}
		Kill();
	}

	[RPC_Server]
	[RPC_Server.MaxDistance(3f)]
	public void Pickup(RPCMessage msg)
	{
		if (msg.player.CanInteract())
		{
			DoPickup(msg.player);
		}
	}

	public override void PreProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		base.PreProcess(preProcess, rootObj, name, serverside, clientside, bundling);
		if (serverside)
		{
			preProcess.RemoveComponent(GetComponent<Collider>());
		}
	}
}
