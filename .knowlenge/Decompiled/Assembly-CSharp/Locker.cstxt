#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class Locker : StorageContainer
{
	private enum RowType
	{
		Clothing,
		Belt
	}

	public static class LockerFlags
	{
		public const Flags IsEquipping = Flags.Reserved1;
	}

	public GameObjectRef equipSound;

	private const int maxGearSets = 3;

	private const int attireSize = 7;

	private const int beltSize = 6;

	private const int columnSize = 2;

	private Item[] clothingBuffer = new Item[7];

	private const int setSize = 13;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("Locker.OnRpcMessage"))
		{
			if (rpc == 1799659668 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - RPC_Equip "));
				}
				using (TimeWarning.New("RPC_Equip"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(1799659668u, "RPC_Equip", this, player, 3f))
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
							RPC_Equip(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in RPC_Equip");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public bool IsEquipping()
	{
		return HasFlag(Flags.Reserved1);
	}

	private RowType GetRowType(int slot)
	{
		if (slot == -1)
		{
			return RowType.Clothing;
		}
		if (slot % 13 >= 7)
		{
			return RowType.Belt;
		}
		return RowType.Clothing;
	}

	public override void ServerInit()
	{
		base.ServerInit();
		SetFlag(Flags.Reserved1, b: false);
	}

	public void ClearEquipping()
	{
		SetFlag(Flags.Reserved1, b: false);
	}

	public override bool ItemFilter(Item item, int targetSlot)
	{
		if (!base.ItemFilter(item, targetSlot))
		{
			return false;
		}
		if (item.info.category == ItemCategory.Attire)
		{
			return true;
		}
		return GetRowType(targetSlot) == RowType.Belt;
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void RPC_Equip(RPCMessage msg)
	{
		int num = msg.read.Int32();
		if (num < 0 || num >= 3 || IsEquipping())
		{
			return;
		}
		BasePlayer player = msg.player;
		int num2 = num * 13;
		bool flag = false;
		for (int i = 0; i < player.inventory.containerWear.capacity; i++)
		{
			Item slot = player.inventory.containerWear.GetSlot(i);
			if (slot != null)
			{
				slot.RemoveFromContainer();
				clothingBuffer[i] = slot;
			}
		}
		for (int j = 0; j < 7; j++)
		{
			int num3 = num2 + j;
			Item slot2 = base.inventory.GetSlot(num3);
			Item item = clothingBuffer[j];
			if (slot2 != null)
			{
				flag = true;
				if (slot2.info.category != ItemCategory.Attire || !slot2.MoveToContainer(player.inventory.containerWear, j))
				{
					slot2.Drop(GetDropPosition(), GetDropVelocity());
				}
			}
			if (item != null)
			{
				flag = true;
				if (item.info.category != ItemCategory.Attire || !item.MoveToContainer(base.inventory, num3))
				{
					item.Drop(GetDropPosition(), GetDropVelocity());
				}
			}
			clothingBuffer[j] = null;
		}
		for (int k = 0; k < 6; k++)
		{
			int num4 = num2 + k + 7;
			int iTargetPos = k;
			Item slot3 = base.inventory.GetSlot(num4);
			Item slot4 = player.inventory.containerBelt.GetSlot(k);
			slot4?.RemoveFromContainer();
			if (slot3 != null)
			{
				flag = true;
				if (!slot3.MoveToContainer(player.inventory.containerBelt, iTargetPos))
				{
					slot3.Drop(GetDropPosition(), GetDropVelocity());
				}
			}
			if (slot4 != null)
			{
				flag = true;
				if (!slot4.MoveToContainer(base.inventory, num4))
				{
					slot4.Drop(GetDropPosition(), GetDropVelocity());
				}
			}
		}
		if (flag)
		{
			Effect.server.Run(equipSound.resourcePath, player, StringPool.Get("spine3"), Vector3.zero, Vector3.zero);
			SetFlag(Flags.Reserved1, b: true);
			Invoke(ClearEquipping, 1.5f);
		}
	}
}
