#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using Oxide.Core;
using UnityEngine;
using UnityEngine.Assertions;

public class DoorCloser : BaseEntity
{
	[ItemSelector(ItemCategory.All)]
	public ItemDefinition itemType;

	public float delay = 3f;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("DoorCloser.OnRpcMessage"))
		{
			if (rpc == 342802563 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - RPC_Take ");
				}
				using (TimeWarning.New("RPC_Take"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.MaxDistance.Test(342802563u, "RPC_Take", this, player, 3f))
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
							RPCMessage rpc2 = rPCMessage;
							RPC_Take(rpc2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in RPC_Take");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override float BoundsPadding()
	{
		return 1f;
	}

	public void Think()
	{
		Invoke(SendClose, delay);
	}

	public void SendClose()
	{
		BaseEntity baseEntity = GetParentEntity();
		if (children != null)
		{
			foreach (BaseEntity child in children)
			{
				if (child != null)
				{
					Invoke(SendClose, delay);
					return;
				}
			}
		}
		if ((bool)baseEntity)
		{
			baseEntity.SendMessage("CloseRequest");
		}
	}

	[RPC_Server]
	[RPC_Server.MaxDistance(3f)]
	public void RPC_Take(RPCMessage rpc)
	{
		if (Interface.CallHook("ICanPickupEntity", rpc.player, this) != null || !rpc.player.CanInteract() || !rpc.player.CanBuild())
		{
			return;
		}
		Door door = GetDoor();
		if (!(door == null) && door.GetPlayerLockPermission(rpc.player))
		{
			Item item = ItemManager.Create(itemType, 1, skinID);
			if (item != null)
			{
				rpc.player.GiveItem(item);
			}
			Kill();
		}
	}

	public Door GetDoor()
	{
		return GetParentEntity() as Door;
	}
}
