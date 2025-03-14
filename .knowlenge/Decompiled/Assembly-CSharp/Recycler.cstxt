#define UNITY_ASSERTIONS
using System;
using System.Collections.Generic;
using ConVar;
using Facepunch;
using Facepunch.Rust;
using Network;
using Oxide.Core;
using UnityEngine;
using UnityEngine.Assertions;

public class Recycler : StorageContainer
{
	public Animator Animator;

	public float recycleEfficiency = 0.5f;

	public SoundDefinition grindingLoopDef;

	public GameObjectRef startSound;

	public GameObjectRef stopSound;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("Recycler.OnRpcMessage"))
		{
			if (rpc == 4167839872u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - SVSwitch "));
				}
				using (TimeWarning.New("SVSwitch"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.MaxDistance.Test(4167839872u, "SVSwitch", this, player, 3f))
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
							SVSwitch(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in SVSwitch");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void ResetState()
	{
		base.ResetState();
	}

	private bool CanBeRecycled(Item item)
	{
		object obj = Interface.CallHook("CanBeRecycled", item, this);
		if (obj is bool)
		{
			return (bool)obj;
		}
		if (item != null)
		{
			return item.info.Blueprint != null;
		}
		return false;
	}

	public override void ServerInit()
	{
		base.ServerInit();
		ItemContainer itemContainer = base.inventory;
		itemContainer.canAcceptItem = (Func<Item, int, bool>)Delegate.Combine(itemContainer.canAcceptItem, new Func<Item, int, bool>(RecyclerItemFilter));
	}

	public bool RecyclerItemFilter(Item item, int targetSlot)
	{
		int num = Mathf.CeilToInt((float)base.inventory.capacity * 0.5f);
		if (targetSlot == -1)
		{
			bool flag = false;
			for (int i = 0; i < num; i++)
			{
				if (!base.inventory.SlotTaken(item, i))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		if (targetSlot < num)
		{
			return CanBeRecycled(item);
		}
		return true;
	}

	[RPC_Server]
	[RPC_Server.MaxDistance(3f)]
	private void SVSwitch(RPCMessage msg)
	{
		bool flag = msg.read.Bit();
		if (flag == IsOn() || msg.player == null || Interface.CallHook("OnRecyclerToggle", this, msg.player) != null || (flag && !HasRecyclable()))
		{
			return;
		}
		if (flag)
		{
			foreach (Item item in base.inventory.itemList)
			{
				item.CollectedForCrafting(msg.player);
			}
			StartRecycling();
		}
		else
		{
			StopRecycling();
		}
	}

	public bool MoveItemToOutput(Item newItem)
	{
		int num = -1;
		for (int i = 6; i < 12; i++)
		{
			Item slot = base.inventory.GetSlot(i);
			if (slot == null)
			{
				num = i;
				break;
			}
			if (slot.CanStack(newItem))
			{
				if (slot.amount + newItem.amount <= slot.MaxStackable())
				{
					num = i;
					break;
				}
				int num2 = Mathf.Min(slot.MaxStackable() - slot.amount, newItem.amount);
				newItem.UseItem(num2);
				slot.amount += num2;
				slot.MarkDirty();
				newItem.MarkDirty();
			}
			if (newItem.amount <= 0)
			{
				return true;
			}
		}
		if (num != -1 && newItem.MoveToContainer(base.inventory, num))
		{
			return true;
		}
		newItem.Drop(base.transform.position + new Vector3(0f, 2f, 0f), GetInheritedDropVelocity() + base.transform.forward * 2f);
		return false;
	}

	public bool HasRecyclable()
	{
		for (int i = 0; i < 6; i++)
		{
			Item slot = base.inventory.GetSlot(i);
			if (slot != null)
			{
				object obj = Interface.CallHook("CanRecycle", this, slot);
				if (obj is bool)
				{
					return (bool)obj;
				}
				if (slot.info.Blueprint != null)
				{
					return true;
				}
			}
		}
		return false;
	}

	public void RecycleThink()
	{
		bool flag = false;
		float num = recycleEfficiency;
		int num2 = 0;
		while (true)
		{
			if (num2 < 6)
			{
				Item slot = base.inventory.GetSlot(num2);
				if (!CanBeRecycled(slot))
				{
					num2++;
					continue;
				}
				if (Interface.CallHook("OnItemRecycle", slot, this) != null)
				{
					if (!HasRecyclable())
					{
						StopRecycling();
					}
					break;
				}
				if (slot.hasCondition)
				{
					num = Mathf.Clamp01(num * Mathf.Clamp(slot.conditionNormalized * slot.maxConditionNormalized, 0.1f, 1f));
				}
				int num3 = 1;
				if (slot.amount > 1)
				{
					num3 = Mathf.CeilToInt(Mathf.Min(slot.amount, (float)slot.MaxStackable() * 0.1f));
				}
				object obj = Interface.CallHook("OnItemRecycleAmount", slot, num3, this);
				if (obj is int)
				{
					num3 = (int)obj;
				}
				if (slot.info.Blueprint.scrapFromRecycle > 0)
				{
					int num4 = slot.info.Blueprint.scrapFromRecycle * num3;
					if (slot.MaxStackable() == 1 && slot.hasCondition)
					{
						num4 = Mathf.CeilToInt((float)num4 * slot.conditionNormalized);
					}
					if (num4 >= 1)
					{
						Item item = ItemManager.CreateByName("scrap", num4, 0uL);
						Facepunch.Rust.Analytics.Azure.OnRecyclerItemProduced(item.info.shortname, item.amount, this, slot);
						MoveItemToOutput(item);
					}
				}
				if (!string.IsNullOrEmpty(slot.info.Blueprint.RecycleStat))
				{
					List<BasePlayer> obj2 = Facepunch.Pool.GetList<BasePlayer>();
					Vis.Entities(base.transform.position, 3f, obj2, 131072);
					foreach (BasePlayer item3 in obj2)
					{
						if (item3.IsAlive() && !item3.IsSleeping() && item3.inventory.loot.entitySource == this)
						{
							item3.stats.Add(slot.info.Blueprint.RecycleStat, num3, (Stats)5);
							item3.stats.Save();
						}
					}
					Facepunch.Pool.FreeList(ref obj2);
				}
				Facepunch.Rust.Analytics.Azure.OnItemRecycled(slot.info.shortname, num3, this);
				slot.UseItem(num3);
				foreach (ItemAmount ingredient in slot.info.Blueprint.ingredients)
				{
					if (ingredient.itemDef.shortname == "scrap")
					{
						continue;
					}
					float num5 = ingredient.amount / (float)slot.info.Blueprint.amountToCreate;
					int num6 = 0;
					if (num5 <= 1f)
					{
						for (int i = 0; i < num3; i++)
						{
							if (UnityEngine.Random.Range(0f, 1f) <= num5 * num)
							{
								num6++;
							}
						}
					}
					else
					{
						num6 = Mathf.CeilToInt(Mathf.Clamp(num5 * num * UnityEngine.Random.Range(1f, 1f), 0f, ingredient.amount)) * num3;
					}
					if (num6 <= 0)
					{
						continue;
					}
					int num7 = Mathf.CeilToInt((float)num6 / (float)ingredient.itemDef.stackable);
					for (int j = 0; j < num7; j++)
					{
						int num8 = ((num6 > ingredient.itemDef.stackable) ? ingredient.itemDef.stackable : num6);
						Item item2 = ItemManager.Create(ingredient.itemDef, num8, 0uL);
						Facepunch.Rust.Analytics.Azure.OnRecyclerItemProduced(item2.info.shortname, item2.amount, this, slot);
						if (!MoveItemToOutput(item2))
						{
							flag = true;
						}
						num6 -= num8;
						if (num6 <= 0)
						{
							break;
						}
					}
				}
			}
			if (flag || !HasRecyclable())
			{
				StopRecycling();
			}
			break;
		}
	}

	public void StartRecycling()
	{
		if (!IsOn())
		{
			InvokeRepeating(RecycleThink, 5f, 5f);
			Effect.server.Run(startSound.resourcePath, this, 0u, Vector3.zero, Vector3.zero);
			SetFlag(Flags.On, b: true);
			SendNetworkUpdateImmediate();
		}
	}

	public void StopRecycling()
	{
		CancelInvoke(RecycleThink);
		if (IsOn())
		{
			Effect.server.Run(stopSound.resourcePath, this, 0u, Vector3.zero, Vector3.zero);
			SetFlag(Flags.On, b: false);
			SendNetworkUpdateImmediate();
		}
	}

	public void PlayAnim()
	{
	}

	public void StopAnim()
	{
	}

	private void ToggleAnim(bool toggle)
	{
	}
}
