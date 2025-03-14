using System.Collections.Generic;
using Facepunch;
using Oxide.Core;
using Rust;
using UnityEngine;

public class ModularCarCodeLock
{
	public enum LockType
	{
		Door,
		General
	}

	private readonly bool isServer;

	public readonly ModularCar owner;

	public const BaseEntity.Flags FLAG_CENTRAL_LOCKING = BaseEntity.Flags.Reserved2;

	public const BaseEntity.Flags FLAG_CODE_ENTRY_BLOCKED = BaseEntity.Flags.Reserved10;

	public const float LOCK_DESTROY_HEALTH = 0.2f;

	private List<ulong> whitelistPlayers = new List<ulong>();

	private int wrongCodes;

	private float lastWrongTime = float.NegativeInfinity;

	public bool HasALock
	{
		get
		{
			if (isServer)
			{
				return !string.IsNullOrEmpty(Code);
			}
			return false;
		}
	}

	public bool CentralLockingIsOn
	{
		get
		{
			if (owner != null)
			{
				return owner.HasFlag(BaseEntity.Flags.Reserved2);
			}
			return false;
		}
	}

	public IList<ulong> WhitelistPlayers => whitelistPlayers.AsReadOnly();

	public string Code { get; private set; } = "";

	public ModularCarCodeLock(ModularCar owner, bool isServer)
	{
		this.owner = owner;
		this.isServer = isServer;
		if (isServer)
		{
			CheckEnableCentralLocking();
		}
	}

	public bool PlayerCanDestroyLock(BaseVehicleModule viaModule)
	{
		if (!HasALock)
		{
			return false;
		}
		return viaModule.healthFraction <= 0.2f;
	}

	public bool CodeEntryBlocked(BasePlayer player)
	{
		if (!HasALock)
		{
			return true;
		}
		if (HasLockPermission(player))
		{
			return false;
		}
		if (owner != null)
		{
			return owner.HasFlag(BaseEntity.Flags.Reserved10);
		}
		return false;
	}

	public void Load(BaseNetworkable.LoadInfo info)
	{
		Code = info.msg.modularCar.lockCode;
		if (Code == null)
		{
			Code = "";
		}
		whitelistPlayers.Clear();
		whitelistPlayers.AddRange(info.msg.modularCar.whitelistUsers);
	}

	public bool HasLockPermission(ulong steamId)
	{
		if (!HasALock)
		{
			return true;
		}
		return whitelistPlayers.Contains(steamId);
	}

	public bool HasLockPermission(BasePlayer player)
	{
		if (!player.IsValid() || player.IsDead())
		{
			return false;
		}
		object obj = Interface.CallHook("CanLock", player, owner, this);
		if (obj is bool)
		{
			return (bool)obj;
		}
		return HasLockPermission(player.userID);
	}

	public bool PlayerCanUseThis(BasePlayer player, LockType lockType)
	{
		if (lockType == LockType.Door && !CentralLockingIsOn)
		{
			return true;
		}
		return HasLockPermission(player);
	}

	public void PostServerLoad()
	{
		owner.SetFlag(BaseEntity.Flags.Reserved10, b: false);
		CheckEnableCentralLocking();
	}

	public bool CanHaveALock()
	{
		object obj = Interface.CallHook("OnVehicleLockableCheck", this);
		if (obj != null)
		{
			if (!(obj is bool))
			{
				return false;
			}
			return (bool)obj;
		}
		if (!owner.IsDead())
		{
			return owner.HasDriverMountPoints();
		}
		return false;
	}

	public bool TryAddALock(string code, ulong userID)
	{
		if (!isServer)
		{
			return false;
		}
		if (owner.IsDead())
		{
			return false;
		}
		TrySetNewCode(code, userID);
		return HasALock;
	}

	public bool IsValidLockCode(string code)
	{
		if (code != null && code.Length == 4)
		{
			return code.IsNumeric();
		}
		return false;
	}

	public bool TrySetNewCode(string newCode, ulong userID)
	{
		if (!IsValidLockCode(newCode))
		{
			return false;
		}
		Code = newCode;
		whitelistPlayers.Clear();
		whitelistPlayers.Add(userID);
		owner.SendNetworkUpdate();
		return true;
	}

	public void RemoveLock()
	{
		if (isServer && HasALock)
		{
			Code = "";
			owner.SendNetworkUpdate();
		}
	}

	public bool TryOpenWithCode(BasePlayer player, string codeEntered)
	{
		object obj = Interface.CallHook("CanUnlock", player, this, codeEntered);
		if (obj is bool)
		{
			return (bool)obj;
		}
		if (CodeEntryBlocked(player))
		{
			return false;
		}
		if (!(codeEntered == Code))
		{
			if (Time.realtimeSinceStartup > lastWrongTime + 60f)
			{
				wrongCodes = 0;
			}
			player.Hurt((float)(wrongCodes + 1) * 5f, DamageType.ElectricShock, owner, useProtection: false);
			wrongCodes++;
			if (wrongCodes > 5)
			{
				player.ShowToast(GameTip.Styles.Red_Normal, CodeLock.blockwarning, false);
			}
			if ((float)wrongCodes >= CodeLock.maxFailedAttempts)
			{
				owner.SetFlag(BaseEntity.Flags.Reserved10, b: true);
				owner.Invoke(ClearCodeEntryBlocked, CodeLock.lockoutCooldown);
			}
			lastWrongTime = Time.realtimeSinceStartup;
			return false;
		}
		if (TryAddPlayer(player.userID))
		{
			wrongCodes = 0;
		}
		owner.SendNetworkUpdate();
		return true;
	}

	private void ClearCodeEntryBlocked()
	{
		owner.SetFlag(BaseEntity.Flags.Reserved10, b: false);
		wrongCodes = 0;
	}

	public void CheckEnableCentralLocking()
	{
		if (CentralLockingIsOn)
		{
			return;
		}
		bool flag = false;
		foreach (BaseVehicleModule attachedModuleEntity in owner.AttachedModuleEntities)
		{
			if (attachedModuleEntity is VehicleModuleSeating vehicleModuleSeating && vehicleModuleSeating.HasADriverSeat() && vehicleModuleSeating.AnyMounted())
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			owner.SetFlag(BaseEntity.Flags.Reserved2, b: true);
		}
	}

	public void ToggleCentralLocking()
	{
		owner.SetFlag(BaseEntity.Flags.Reserved2, !CentralLockingIsOn);
	}

	public void Save(BaseNetworkable.SaveInfo info)
	{
		info.msg.modularCar.hasLock = HasALock;
		if (info.forDisk)
		{
			info.msg.modularCar.lockCode = Code;
		}
		info.msg.modularCar.whitelistUsers = Pool.Get<List<ulong>>();
		info.msg.modularCar.whitelistUsers.AddRange(whitelistPlayers);
	}

	public bool TryAddPlayer(ulong userID)
	{
		if (!whitelistPlayers.Contains(userID))
		{
			whitelistPlayers.Add(userID);
			return true;
		}
		return false;
	}

	public bool TryRemovePlayer(ulong userID)
	{
		return whitelistPlayers.Remove(userID);
	}
}
