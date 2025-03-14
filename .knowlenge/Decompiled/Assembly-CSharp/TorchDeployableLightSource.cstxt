#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class TorchDeployableLightSource : StorageContainer, ISplashable, IIgniteable
{
	public ItemDefinition[] AllowedTorches;

	public Transform TorchRoot;

	public const Flags HasTorch = Flags.Reserved1;

	public const Flags UseBuiltInFx = Flags.Reserved2;

	public ItemDefinition[] BuiltInFxItems = new ItemDefinition[0];

	private EntityRef<TorchWeapon> spawnedTorch;

	private ItemDefinition spawnedTorchDef;

	private Item CurrentTorch => base.inventory.GetSlot(0);

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("TorchDeployableLightSource.OnRpcMessage"))
		{
			if (rpc == 3305620958u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - RequestTurnOnOff ");
				}
				using (TimeWarning.New("RequestTurnOnOff"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(3305620958u, "RequestTurnOnOff", this, player, 3f))
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
							RequestTurnOnOff(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in RequestTurnOnOff");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override bool ItemFilter(Item item, int targetSlot)
	{
		ItemDefinition[] allowedTorches = AllowedTorches;
		for (int i = 0; i < allowedTorches.Length; i++)
		{
			if (allowedTorches[i] == item.info)
			{
				return true;
			}
		}
		return false;
	}

	private bool ShouldUseBuiltInFx(ItemDefinition def)
	{
		if (def == null)
		{
			return false;
		}
		ItemDefinition[] builtInFxItems = BuiltInFxItems;
		for (int i = 0; i < builtInFxItems.Length; i++)
		{
			if (builtInFxItems[i] == def)
			{
				return true;
			}
		}
		return false;
	}

	private void UpdateTorch()
	{
		Item item = CurrentTorch;
		if (item != null && item.isBroken)
		{
			item = null;
		}
		ItemDefinition itemDefinition = item?.info;
		if (itemDefinition != spawnedTorchDef)
		{
			spawnedTorchDef = itemDefinition;
			SetFlag(Flags.Reserved2, ShouldUseBuiltInFx(itemDefinition), recursive: false, networkupdate: false);
			TorchWeapon torchWeapon = spawnedTorch.Get(serverside: true);
			if (torchWeapon != null)
			{
				torchWeapon.Kill();
			}
			spawnedTorch.Set(null);
			if (itemDefinition != null)
			{
				TorchWeapon component = GameManager.server.CreateEntity(itemDefinition.GetComponent<ItemModEntity>().entityPrefab.resourcePath, TorchRoot.position, TorchRoot.rotation).GetComponent<TorchWeapon>();
				component.SetParent(this, worldPositionStays: true);
				component.SetFlag(Flags.Reserved1, b: true);
				component.Spawn();
				spawnedTorch.Set(component);
			}
			else
			{
				SetFlag(Flags.On, b: false);
			}
		}
		SetFlag(Flags.Reserved1, spawnedTorch.Get(serverside: true) != null);
		if (!HasFlag(Flags.Reserved1) && IsInvoking(TickTorchDurability))
		{
			CancelInvoke(TickTorchDurability);
		}
	}

	private void TickTorchDurability()
	{
		CurrentTorch?.LoseCondition(1f / 12f);
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		foreach (BaseEntity child in children)
		{
			if (child is TorchWeapon torchWeapon)
			{
				spawnedTorch.Set(torchWeapon);
				torchWeapon.SetFlag(Flags.On, IsOn());
				break;
			}
		}
		if (HasFlag(Flags.Reserved1) && IsOn())
		{
			InvokeRepeating(TickTorchDurability, 1f, 1f);
		}
	}

	public override void OnItemAddedOrRemoved(Item item, bool added)
	{
		base.OnItemAddedOrRemoved(item, added);
		UpdateTorch();
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	private void RequestTurnOnOff(RPCMessage msg)
	{
		bool wantsOn = msg.read.Bit();
		TryToggle(wantsOn);
	}

	private void TryToggle(bool wantsOn)
	{
		if (CurrentTorch == null)
		{
			return;
		}
		TorchWeapon torchWeapon = spawnedTorch.Get(serverside: true);
		if (!(torchWeapon == null))
		{
			torchWeapon.SetFlag(Flags.On, wantsOn);
			SetFlag(Flags.On, wantsOn);
			if (HasFlag(Flags.Reserved1) && wantsOn)
			{
				InvokeRepeating(TickTorchDurability, 1f, 1f);
			}
			else
			{
				CancelInvoke(TickTorchDurability);
			}
		}
	}

	public bool WantsSplash(ItemDefinition splashType, int amount)
	{
		if (HasFlag(Flags.Reserved1))
		{
			return IsOn();
		}
		return false;
	}

	public int DoSplash(ItemDefinition splashType, int amount)
	{
		TryToggle(wantsOn: false);
		return 10;
	}

	public void Ignite(Vector3 fromPos)
	{
		TryToggle(wantsOn: true);
	}

	public bool CanIgnite()
	{
		if (HasFlag(Flags.Reserved1))
		{
			return !IsOn();
		}
		return false;
	}
}
