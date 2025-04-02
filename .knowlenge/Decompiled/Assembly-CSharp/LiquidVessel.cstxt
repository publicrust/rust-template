using System;
using System.Collections.Generic;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class LiquidVessel : HeldEntity
{
	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		TimeWarning val = TimeWarning.New("LiquidVessel.OnRpcMessage", 0);
		try
		{
			if (rpc == 4034725537u && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - DoEmpty "));
				}
				TimeWarning val2 = TimeWarning.New("DoEmpty", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Conditions", 0);
					try
					{
						if (!RPC_Server.IsActiveItem.Test(4034725537u, "DoEmpty", this, player))
						{
							return true;
						}
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
					try
					{
						val3 = TimeWarning.New("Call", 0);
						try
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg2 = rPCMessage;
							DoEmpty(msg2);
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
					}
					catch (Exception ex)
					{
						Debug.LogException(ex);
						player.Kick("RPC Error in DoEmpty");
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				return true;
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public bool CanDrink()
	{
		BasePlayer ownerPlayer = GetOwnerPlayer();
		if (!Object.op_Implicit((Object)(object)ownerPlayer))
		{
			return false;
		}
		if (!ownerPlayer.metabolism.CanConsume())
		{
			return false;
		}
		Item item = GetItem();
		if (item == null)
		{
			return false;
		}
		if (item.contents == null)
		{
			return false;
		}
		if (item.contents.itemList == null)
		{
			return false;
		}
		if (item.contents.itemList.Count == 0)
		{
			return false;
		}
		return true;
	}

	[RPC_Server]
	[RPC_Server.IsActiveItem]
	private void DoEmpty(RPCMessage msg)
	{
		if (!msg.player.CanInteract())
		{
			return;
		}
		Item item = GetItem();
		if (item == null || item.contents == null || !msg.player.metabolism.CanConsume())
		{
			return;
		}
		using List<Item>.Enumerator enumerator = item.contents.itemList.GetEnumerator();
		if (enumerator.MoveNext())
		{
			enumerator.Current.UseItem(50);
		}
	}

	public void AddLiquid(ItemDefinition liquidType, int amount)
	{
		if (amount <= 0)
		{
			return;
		}
		Item item = GetItem();
		Item item2 = item.contents.GetSlot(0);
		ItemModContainer component = ((Component)item.info).GetComponent<ItemModContainer>();
		if (item2 == null)
		{
			ItemManager.Create(liquidType, amount, 0uL)?.MoveToContainer(item.contents);
			return;
		}
		int num = Mathf.Clamp(item2.amount + amount, 0, component.maxStackSize);
		ItemDefinition itemDefinition = WaterResource.Merge(item2.info, liquidType);
		if ((Object)(object)itemDefinition != (Object)(object)item2.info)
		{
			item2.Remove();
			item2 = ItemManager.Create(itemDefinition, num, 0uL);
			item2.MoveToContainer(item.contents);
		}
		else
		{
			item2.amount = num;
		}
		item2.MarkDirty();
		SendNetworkUpdateImmediate();
	}

	public bool CanFillHere(Vector3 pos)
	{
		BasePlayer ownerPlayer = GetOwnerPlayer();
		if (!Object.op_Implicit((Object)(object)ownerPlayer))
		{
			return false;
		}
		if ((double)ownerPlayer.WaterFactor() > 0.05)
		{
			return true;
		}
		return false;
	}

	public int AmountHeld()
	{
		return GetItem().contents.GetSlot(0)?.amount ?? 0;
	}

	public float HeldFraction()
	{
		return (float)AmountHeld() / (float)MaxHoldable();
	}

	public bool IsFull()
	{
		return HeldFraction() >= 1f;
	}

	public int MaxHoldable()
	{
		return ((Component)GetItem().info).GetComponent<ItemModContainer>().maxStackSize;
	}
}
