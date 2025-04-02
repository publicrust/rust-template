using System.Collections.Generic;
using Facepunch;
using Network;
using Oxide.Core;
using Rust;
using UnityEngine;

public class GunTrap : StorageContainer
{
	public static class GunTrapFlags
	{
		public const Flags Triggered = Flags.Reserved1;
	}

	public class GunTrapScanWorkQueue : PersistentObjectWorkQueue<GunTrap>
	{
		protected override void RunJob(GunTrap entity)
		{
			if (ShouldAdd(entity))
			{
				entity.TriggerCheck();
			}
		}

		protected override bool ShouldAdd(GunTrap entity)
		{
			if (base.ShouldAdd(entity))
			{
				return entity.IsValid();
			}
			return false;
		}
	}

	public GameObjectRef gun_fire_effect;

	public GameObjectRef bulletEffect;

	public GameObjectRef triggeredEffect;

	public Transform muzzlePos;

	public Transform eyeTransform;

	public int numPellets = 15;

	public int aimCone = 30;

	public float sensorRadius = 1.25f;

	public ItemDefinition ammoType;

	public TargetTrigger trigger;

	private float triggerCooldown;

	private BuildingPrivlidge _cachedTc;

	private float _cacheTimeout;

	[ServerVar(Help = "How many milliseconds to spend on target scanning per frame")]
	public static float gun_trap_budget_ms = 0.5f;

	public static GunTrapScanWorkQueue updateGunTrapWorkQueue = new GunTrapScanWorkQueue();

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("GunTrap.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override string Categorize()
	{
		return "GunTrap";
	}

	public bool CanFire()
	{
		foreach (Item item in base.inventory.itemList)
		{
			if (item.info == ammoType && item.amount > 0)
			{
				return true;
			}
		}
		return false;
	}

	public bool UseAmmo()
	{
		foreach (Item item in base.inventory.itemList)
		{
			if (item.info == ammoType && item.amount > 0)
			{
				item.UseItem();
				return true;
			}
		}
		return false;
	}

	public void FireWeapon()
	{
		if (UseAmmo())
		{
			Effect.server.Run(gun_fire_effect.resourcePath, this, StringPool.Get(muzzlePos.gameObject.name), Vector3.zero, Vector3.zero);
			for (int i = 0; i < numPellets; i++)
			{
				FireBullet();
			}
		}
	}

	public void FireBullet()
	{
		float damageAmount = 10f;
		Vector3 vector = muzzlePos.transform.position - muzzlePos.forward * 0.25f;
		Vector3 vector2 = AimConeUtil.GetModifiedAimConeDirection(inputVec: muzzlePos.transform.forward, aimCone: aimCone);
		ClientRPC(arg1: vector + vector2 * 300f, target: RpcTarget.NetworkGroup("CLIENT_FireGun"));
		List<RaycastHit> list = Pool.Get<List<RaycastHit>>();
		int layerMask = 1220225793;
		GamePhysics.TraceAll(new Ray(vector, vector2), 0.1f, list, 300f, layerMask);
		for (int i = 0; i < list.Count; i++)
		{
			RaycastHit hit = list[i];
			BaseEntity entity = RaycastHitEx.GetEntity(hit);
			if (entity != null && (entity == this || entity.EqualNetID(this)))
			{
				continue;
			}
			if (entity as BaseCombatEntity != null)
			{
				HitInfo info = new HitInfo(this, entity, DamageType.Bullet, damageAmount, hit.point);
				entity.OnAttacked(info);
				if (entity is BasePlayer || entity is BaseNpc)
				{
					Effect.server.ImpactEffect(new HitInfo
					{
						HitPositionWorld = hit.point,
						HitNormalWorld = -hit.normal,
						HitMaterial = StringPool.Get("Flesh")
					});
				}
			}
			if (!(entity != null) || entity.ShouldBlockProjectiles())
			{
				Vector3 point = hit.point;
				break;
			}
		}
	}

	public override void ServerInit()
	{
		base.ServerInit();
		updateGunTrapWorkQueue.Add(this);
	}

	internal override void DoServerDestroy()
	{
		base.DoServerDestroy();
		updateGunTrapWorkQueue.Remove(this);
	}

	public void TriggerCheck()
	{
		if (!(triggerCooldown > Time.realtimeSinceStartup) && CheckTrigger())
		{
			FireWeapon();
			triggerCooldown = Time.realtimeSinceStartup + 0.5f;
		}
	}

	private BuildingPrivlidge GetCachedTc()
	{
		if (_cachedTc != null && _cachedTc.IsDestroyed)
		{
			_cachedTc = null;
		}
		if (_cachedTc == null || Time.realtimeSinceStartup > _cacheTimeout)
		{
			_cachedTc = null;
			BuildingManager.Building building = GetBuilding();
			if (building != null)
			{
				_cachedTc = building.GetDominatingBuildingPrivilege();
			}
			if (_cachedTc == null)
			{
				return GetNearestBuildingPrivilege(cached: true, 3f);
			}
			_cacheTimeout = Time.realtimeSinceStartup + 3f;
		}
		return _cachedTc;
	}

	public bool CheckTrigger()
	{
		HashSet<BaseEntity> entityContents = trigger.entityContents;
		if (entityContents == null || entityContents.Count == 0)
		{
			return false;
		}
		if (!CanFire())
		{
			return false;
		}
		List<RaycastHit> obj = Pool.Get<List<RaycastHit>>();
		BuildingPrivlidge cachedTc = GetCachedTc();
		bool flag = false;
		foreach (BaseEntity item in entityContents)
		{
			BasePlayer component = item.GetComponent<BasePlayer>();
			if (component.IsSleeping() || !component.IsAlive() || (!(cachedTc == null) && cachedTc.IsAuthed(component)))
			{
				continue;
			}
			object obj2 = Interface.CallHook("CanBeTargeted", component, this);
			if (obj2 is bool)
			{
				Pool.FreeUnmanaged(ref obj);
				return (bool)obj2;
			}
			obj.Clear();
			GamePhysics.TraceAll(new Ray(component.eyes.position, (GetEyePosition() - component.eyes.position).normalized), 0f, obj, 9f, 1218519297);
			for (int i = 0; i < obj.Count; i++)
			{
				BaseEntity entity = RaycastHitEx.GetEntity(obj[i]);
				if (entity != null && (entity == this || entity.EqualNetID(this)))
				{
					flag = true;
					break;
				}
				if (!(entity != null) || entity.ShouldBlockProjectiles())
				{
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		Pool.FreeUnmanaged(ref obj);
		return flag;
	}

	public bool IsTriggered()
	{
		return HasFlag(Flags.Reserved1);
	}

	public Vector3 GetEyePosition()
	{
		return eyeTransform.position;
	}
}
