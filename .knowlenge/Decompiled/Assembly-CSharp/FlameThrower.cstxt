#define UNITY_ASSERTIONS
using System;
using System.Collections.Generic;
using ConVar;
using Facepunch;
using Network;
using Oxide.Core;
using ProtoBuf;
using Rust;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;

public class FlameThrower : AttackEntity
{
	[Header("Flame Thrower")]
	public int maxAmmo = 100;

	public int ammo = 100;

	public ItemDefinition fuelType;

	public float timeSinceLastAttack;

	[FormerlySerializedAs("nextAttackTime")]
	public float nextReadyTime;

	public float flameRange = 10f;

	public float flameRadius = 2.5f;

	public ParticleSystem[] flameEffects;

	public FlameJet jet;

	public GameObjectRef fireballPrefab;

	public List<DamageTypeEntry> damagePerSec;

	public SoundDefinition flameStart3P;

	public SoundDefinition flameLoop3P;

	public SoundDefinition flameStop3P;

	public SoundDefinition pilotLoopSoundDef;

	private float tickRate = 0.25f;

	private float lastFlameTick;

	public float fuelPerSec;

	private float ammoRemainder;

	public float reloadDuration = 3.5f;

	private float lastReloadTime = -10f;

	private float nextFlameTime;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("FlameThrower.OnRpcMessage"))
		{
			if (rpc == 3381353917u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (ConVar.Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - DoReload "));
				}
				using (TimeWarning.New("DoReload"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsActiveItem.Test(3381353917u, "DoReload", this, player))
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
							DoReload(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in DoReload");
					}
				}
				return true;
			}
			if (rpc == 3749570935u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (ConVar.Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - SetFiring "));
				}
				using (TimeWarning.New("SetFiring"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsActiveItem.Test(3749570935u, "SetFiring", this, player))
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
							RPCMessage firing = rPCMessage;
							SetFiring(firing);
						}
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
						player.Kick("RPC Error in SetFiring");
					}
				}
				return true;
			}
			if (rpc == 1057268396 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (ConVar.Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - TogglePilotLight "));
				}
				using (TimeWarning.New("TogglePilotLight"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsActiveItem.Test(1057268396u, "TogglePilotLight", this, player))
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
							RPCMessage msg3 = rPCMessage;
							TogglePilotLight(msg3);
						}
					}
					catch (Exception exception3)
					{
						Debug.LogException(exception3);
						player.Kick("RPC Error in TogglePilotLight");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	private bool IsWeaponBusy()
	{
		return UnityEngine.Time.realtimeSinceStartup < nextReadyTime;
	}

	private void SetBusyFor(float dur)
	{
		nextReadyTime = UnityEngine.Time.realtimeSinceStartup + dur;
	}

	private void ClearBusy()
	{
		nextReadyTime = UnityEngine.Time.realtimeSinceStartup - 1f;
	}

	public void ReduceAmmo(float firingTime)
	{
		ammoRemainder += fuelPerSec * firingTime;
		if (ammoRemainder >= 1f)
		{
			int num = Mathf.FloorToInt(ammoRemainder);
			ammoRemainder -= num;
			if (ammoRemainder >= 1f)
			{
				num++;
				ammoRemainder -= 1f;
			}
			ammo -= num;
			if (ammo <= 0)
			{
				ammo = 0;
			}
		}
	}

	public void PilotLightToggle_Shared()
	{
		SetFlag(Flags.On, !HasFlag(Flags.On));
		if (base.isServer)
		{
			SendNetworkUpdateImmediate();
		}
	}

	public bool IsPilotOn()
	{
		return HasFlag(Flags.On);
	}

	public bool IsFlameOn()
	{
		return HasFlag(Flags.OnFire);
	}

	public bool HasAmmo()
	{
		return GetAmmo() != null;
	}

	public Item GetAmmo()
	{
		BasePlayer ownerPlayer = GetOwnerPlayer();
		if (!ownerPlayer)
		{
			return null;
		}
		Item item = ownerPlayer.inventory.containerMain.FindItemsByItemName(fuelType.shortname);
		if (item == null)
		{
			item = ownerPlayer.inventory.containerBelt.FindItemsByItemName(fuelType.shortname);
		}
		return item;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.baseProjectile != null && info.msg.baseProjectile.primaryMagazine != null)
		{
			ammo = info.msg.baseProjectile.primaryMagazine.contents;
		}
	}

	public override void CollectedForCrafting(Item item, BasePlayer crafter)
	{
		ServerCommand(item, "unload_ammo", crafter);
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.baseProjectile = Facepunch.Pool.Get<ProtoBuf.BaseProjectile>();
		info.msg.baseProjectile.primaryMagazine = Facepunch.Pool.Get<Magazine>();
		info.msg.baseProjectile.primaryMagazine.contents = ammo;
	}

	[RPC_Server]
	[RPC_Server.IsActiveItem]
	public void SetFiring(RPCMessage msg)
	{
		bool flameState = msg.read.Bit();
		SetFlameState(flameState);
	}

	public override void ServerUse()
	{
		if (!IsOnFire())
		{
			SetFlameState(wantsOn: true);
			Invoke(StopFlameState, 0.2f);
			base.ServerUse();
		}
	}

	public override void TopUpAmmo()
	{
		ammo = maxAmmo;
	}

	public override float AmmoFraction()
	{
		return (float)ammo / (float)maxAmmo;
	}

	public override bool ServerIsReloading()
	{
		return UnityEngine.Time.time < lastReloadTime + reloadDuration;
	}

	public override bool CanReload()
	{
		return ammo < maxAmmo;
	}

	public override void ServerReload()
	{
		if (!ServerIsReloading())
		{
			lastReloadTime = UnityEngine.Time.time;
			StartAttackCooldown(reloadDuration);
			GetOwnerPlayer().SignalBroadcast(Signal.Reload);
			ammo = maxAmmo;
		}
	}

	public void StopFlameState()
	{
		SetFlameState(wantsOn: false);
	}

	[RPC_Server]
	[RPC_Server.IsActiveItem]
	public void DoReload(RPCMessage msg)
	{
		BasePlayer ownerPlayer = GetOwnerPlayer();
		if (!(ownerPlayer == null))
		{
			Item item = null;
			while (ammo < maxAmmo && (item = GetAmmo()) != null && item.amount > 0)
			{
				int num = Mathf.Min(maxAmmo - ammo, item.amount);
				ammo += num;
				item.UseItem(num);
			}
			SendNetworkUpdateImmediate();
			ItemManager.DoRemoves();
			ownerPlayer.inventory.ServerUpdate(0f);
		}
	}

	public void SetFlameState(bool wantsOn)
	{
		if (wantsOn)
		{
			ammo--;
			if (ammo < 0)
			{
				ammo = 0;
			}
		}
		if (wantsOn && ammo <= 0)
		{
			wantsOn = false;
		}
		SetFlag(Flags.OnFire, wantsOn);
		if (IsFlameOn())
		{
			nextFlameTime = UnityEngine.Time.realtimeSinceStartup + 1f;
			lastFlameTick = UnityEngine.Time.realtimeSinceStartup;
			InvokeRepeating(FlameTick, tickRate, tickRate);
		}
		else
		{
			CancelInvoke(FlameTick);
		}
	}

	[RPC_Server]
	[RPC_Server.IsActiveItem]
	public void TogglePilotLight(RPCMessage msg)
	{
		PilotLightToggle_Shared();
	}

	public override void OnHeldChanged()
	{
		SetFlameState(wantsOn: false);
		base.OnHeldChanged();
	}

	public void FlameTick()
	{
		float num = UnityEngine.Time.realtimeSinceStartup - lastFlameTick;
		lastFlameTick = UnityEngine.Time.realtimeSinceStartup;
		BasePlayer ownerPlayer = GetOwnerPlayer();
		if (!ownerPlayer)
		{
			return;
		}
		ReduceAmmo(num);
		SendNetworkUpdate();
		Ray ray = ownerPlayer.eyes.BodyRay();
		Vector3 origin = ray.origin;
		RaycastHit hitInfo;
		bool num2 = UnityEngine.Physics.SphereCast(ray, 0.3f, out hitInfo, flameRange, 1218652417);
		if (!num2)
		{
			hitInfo.point = origin + ray.direction * flameRange;
		}
		float num3 = (ownerPlayer.IsNpc ? npcDamageScale : 1f);
		float amount = damagePerSec[0].amount;
		damagePerSec[0].amount = amount * num * num3;
		DamageUtil.RadiusDamage(ownerPlayer, LookupPrefab(), hitInfo.point - ray.direction * 0.1f, flameRadius * 0.5f, flameRadius, damagePerSec, 2279681, useLineOfSight: true);
		damagePerSec[0].amount = amount;
		if (num2 && UnityEngine.Time.realtimeSinceStartup >= nextFlameTime && hitInfo.distance > 1.1f)
		{
			nextFlameTime = UnityEngine.Time.realtimeSinceStartup + 0.45f;
			Vector3 point = hitInfo.point;
			BaseEntity baseEntity = GameManager.server.CreateEntity(fireballPrefab.resourcePath, point - ray.direction * 0.25f);
			if ((bool)baseEntity)
			{
				Interface.CallHook("OnFlameThrowerBurn", this, baseEntity);
				baseEntity.creatorEntity = ownerPlayer;
				baseEntity.Spawn();
			}
		}
		if (ammo == 0)
		{
			SetFlameState(wantsOn: false);
		}
		GetOwnerItem()?.LoseCondition(num);
	}

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		if (item == null || !(command == "unload_ammo"))
		{
			return;
		}
		int num = ammo;
		if (num > 0)
		{
			ammo = 0;
			SendNetworkUpdateImmediate();
			Item item2 = ItemManager.Create(fuelType, num, 0uL);
			if (!item2.MoveToContainer(player.inventory.containerMain))
			{
				item2.Drop(player.eyes.position, player.eyes.BodyForward() * 2f);
			}
		}
	}
}
