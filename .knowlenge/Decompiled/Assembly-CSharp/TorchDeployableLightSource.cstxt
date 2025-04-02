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
		TimeWarning val = TimeWarning.New("TorchDeployableLightSource.OnRpcMessage", 0);
		try
		{
			if (rpc == 3305620958u && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - RequestTurnOnOff "));
				}
				TimeWarning val2 = TimeWarning.New("RequestTurnOnOff", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Conditions", 0);
					try
					{
						if (!RPC_Server.IsVisible.Test(3305620958u, "RequestTurnOnOff", this, player, 3f))
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
							RequestTurnOnOff(msg2);
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
					}
					catch (Exception ex)
					{
						Debug.LogException(ex);
						player.Kick("RPC Error in RequestTurnOnOff");
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

	public override bool ItemFilter(Item item, int targetSlot)
	{
		ItemDefinition[] allowedTorches = AllowedTorches;
		for (int i = 0; i < allowedTorches.Length; i++)
		{
			if ((Object)(object)allowedTorches[i] == (Object)(object)item.info)
			{
				return true;
			}
		}
		return false;
	}

	private bool ShouldUseBuiltInFx(ItemDefinition def)
	{
		if ((Object)(object)def == (Object)null)
		{
			return false;
		}
		ItemDefinition[] builtInFxItems = BuiltInFxItems;
		for (int i = 0; i < builtInFxItems.Length; i++)
		{
			if ((Object)(object)builtInFxItems[i] == (Object)(object)def)
			{
				return true;
			}
		}
		return false;
	}

	private void UpdateTorch()
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		Item item = CurrentTorch;
		if (item != null && item.isBroken)
		{
			item = null;
		}
		ItemDefinition itemDefinition = item?.info;
		if ((Object)(object)itemDefinition != (Object)(object)spawnedTorchDef)
		{
			spawnedTorchDef = itemDefinition;
			SetFlag(Flags.Reserved2, ShouldUseBuiltInFx(itemDefinition), recursive: false, networkupdate: false);
			TorchWeapon torchWeapon = spawnedTorch.Get(serverside: true);
			if ((Object)(object)torchWeapon != (Object)null)
			{
				torchWeapon.Kill();
			}
			spawnedTorch.Set(null);
			if ((Object)(object)itemDefinition != (Object)null)
			{
				TorchWeapon component = ((Component)GameManager.server.CreateEntity(((Component)itemDefinition).GetComponent<ItemModEntity>().entityPrefab.resourcePath, TorchRoot.position, TorchRoot.rotation)).GetComponent<TorchWeapon>();
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
		SetFlag(Flags.Reserved1, (Object)(object)spawnedTorch.Get(serverside: true) != (Object)null);
		if (!HasFlag(Flags.Reserved1) && ((FacepunchBehaviour)this).IsInvoking((Action)TickTorchDurability))
		{
			((FacepunchBehaviour)this).CancelInvoke((Action)TickTorchDurability);
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
			((FacepunchBehaviour)this).InvokeRepeating((Action)TickTorchDurability, 1f, 1f);
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
		if (!((Object)(object)torchWeapon == (Object)null))
		{
			torchWeapon.SetFlag(Flags.On, wantsOn);
			SetFlag(Flags.On, wantsOn);
			if (HasFlag(Flags.Reserved1) && wantsOn)
			{
				((FacepunchBehaviour)this).InvokeRepeating((Action)TickTorchDurability, 1f, 1f);
			}
			else
			{
				((FacepunchBehaviour)this).CancelInvoke((Action)TickTorchDurability);
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
