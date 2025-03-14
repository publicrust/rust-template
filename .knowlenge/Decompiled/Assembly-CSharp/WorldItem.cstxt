#define UNITY_ASSERTIONS
using System;
using ConVar;
using Facepunch;
using Facepunch.Rust;
using Network;
using Oxide.Core;
using ProtoBuf;
using UnityEngine;
using UnityEngine.Assertions;

public class WorldItem : BaseEntity
{
	private bool _isInvokingSendItemUpdate;

	[Header("WorldItem")]
	public bool allowPickup = true;

	[NonSerialized]
	public Item item;

	protected float eatSeconds = 10f;

	protected float caloriesPerSecond = 1f;

	public override TraitFlag Traits
	{
		get
		{
			if (item != null)
			{
				return item.Traits;
			}
			return base.Traits;
		}
	}

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("WorldItem.OnRpcMessage"))
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
						if (!RPC_Server.IsVisible.Test(2778075470u, "Pickup", this, player, 3f))
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

	public override void ServerInit()
	{
		base.ServerInit();
		if (item != null)
		{
			BroadcastMessage("OnItemChanged", item, SendMessageOptions.DontRequireReceiver);
		}
	}

	private void DoItemNetworking()
	{
		if (!_isInvokingSendItemUpdate)
		{
			_isInvokingSendItemUpdate = true;
			Invoke(SendItemUpdate, 0.1f);
		}
	}

	private void SendItemUpdate()
	{
		_isInvokingSendItemUpdate = false;
		if (item == null)
		{
			return;
		}
		using UpdateItem updateItem = Facepunch.Pool.Get<UpdateItem>();
		updateItem.item = item.Save(bIncludeContainer: false, bIncludeOwners: false);
		ClientRPC(null, "UpdateItem", updateItem);
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void Pickup(RPCMessage msg)
	{
		if (msg.player.CanInteract() && this.item != null && allowPickup && Interface.CallHook("OnItemPickup", this.item, msg.player) == null)
		{
			ClientRPC(null, "PickupSound");
			Item item = this.item;
			Facepunch.Rust.Analytics.Azure.OnItemPickup(msg.player, this);
			RemoveItem();
			msg.player.GiveItem(item, GiveItemReason.PickedUp);
			msg.player.SignalBroadcast(Signal.Gesture, "pickup_item");
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (item != null)
		{
			bool forDisk = info.forDisk;
			info.msg.worldItem = Facepunch.Pool.Get<ProtoBuf.WorldItem>();
			info.msg.worldItem.item = item.Save(forDisk, bIncludeOwners: false);
		}
	}

	internal override void DoServerDestroy()
	{
		base.DoServerDestroy();
		DestroyItem();
	}

	public override void SwitchParent(BaseEntity ent)
	{
		SetParent(ent, parentBone);
	}

	public override Item GetItem()
	{
		return item;
	}

	public void InitializeItem(Item in_item)
	{
		if (item != null)
		{
			RemoveItem();
		}
		item = in_item;
		if (item != null)
		{
			item.OnDirty += OnItemDirty;
			base.name = item.info.shortname + " (world)";
			item.SetWorldEntity(this);
			OnItemDirty(item);
		}
	}

	public void RemoveItem()
	{
		if (item != null)
		{
			item.OnDirty -= OnItemDirty;
			item = null;
		}
	}

	public void DestroyItem()
	{
		if (item != null)
		{
			item.OnDirty -= OnItemDirty;
			item.Remove();
			item = null;
		}
	}

	protected virtual void OnItemDirty(Item in_item)
	{
		Assert.IsTrue(item == in_item, "WorldItem:OnItemDirty - dirty item isn't ours!");
		if (item != null)
		{
			BroadcastMessage("OnItemChanged", item, SendMessageOptions.DontRequireReceiver);
		}
		DoItemNetworking();
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.worldItem != null && info.msg.worldItem.item != null)
		{
			Item item = ItemManager.Load(info.msg.worldItem.item, this.item, base.isServer);
			if (item != null)
			{
				InitializeItem(item);
			}
		}
	}

	public override void Eat(BaseNpc baseNpc, float timeSpent)
	{
		if (!(eatSeconds <= 0f))
		{
			eatSeconds -= timeSpent;
			baseNpc.AddCalories(caloriesPerSecond * timeSpent);
			if (eatSeconds < 0f)
			{
				DestroyItem();
				Kill();
			}
		}
	}

	public override string ToString()
	{
		if (_name == null)
		{
			if (base.isServer)
			{
				_name = string.Format("{1}[{0}] {2}", net?.ID ?? default(NetworkableId), base.ShortPrefabName, ObjectEx.IsUnityNull(this) ? "NULL" : base.name);
			}
			else
			{
				_name = base.ShortPrefabName;
			}
		}
		return _name;
	}
}
