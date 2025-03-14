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

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("GunTrap.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
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
		Vector3 arg = vector + vector2 * 300f;
		ClientRPC(null, "CLIENT_FireGun", arg);
		List<RaycastHit> list = Pool.GetList<RaycastHit>();
		int layerMask = 1219701505;
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
				arg = hit.point;
				break;
			}
		}
	}

	public override void ServerInit()
	{
		base.ServerInit();
		InvokeRandomized(TriggerCheck, UnityEngine.Random.Range(0f, 1f), 0.5f, 0.1f);
	}

	public void TriggerCheck()
	{
		if (CheckTrigger())
		{
			FireWeapon();
		}
	}

	public bool CheckTrigger()
	{
		List<RaycastHit> obj = Pool.GetList<RaycastHit>();
		HashSet<BaseEntity> entityContents = trigger.entityContents;
		bool flag = false;
		if (entityContents != null)
		{
			foreach (BaseEntity item in entityContents)
			{
				BasePlayer component = item.GetComponent<BasePlayer>();
				if (component.IsSleeping() || !component.IsAlive() || component.IsBuildingAuthed())
				{
					continue;
				}
				object obj2 = Interface.CallHook("CanBeTargeted", component, this);
				if (obj2 is bool)
				{
					Pool.FreeList(ref obj);
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
		}
		Pool.FreeList(ref obj);
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
