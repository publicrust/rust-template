using Network;
using ProtoBuf;
using Rust;
using UnityEngine;

public class HitInfo
{
	public BaseEntity Initiator;

	public BaseEntity WeaponPrefab;

	public AttackEntity Weapon;

	public bool DoHitEffects = true;

	public bool DoDecals = true;

	public bool IsPredicting;

	public bool UseProtection = true;

	public Connection Predicted;

	public bool DidHit;

	public BaseEntity HitEntity;

	public uint HitBone;

	public uint HitPart;

	public uint HitMaterial;

	public Vector3 HitPositionWorld;

	public Vector3 HitPositionLocal;

	public Vector3 HitNormalWorld;

	public Vector3 HitNormalLocal;

	public Vector3 PointStart;

	public Vector3 PointEnd;

	public int ProjectileID;

	public int ProjectileHits;

	public float ProjectileDistance;

	public float ProjectileIntegrity;

	public float ProjectileTravelTime;

	public float ProjectileTrajectoryMismatch;

	public Vector3 ProjectileVelocity;

	public Projectile ProjectilePrefab;

	public PhysicMaterial material;

	public DamageProperties damageProperties;

	public DamageTypeList damageTypes = new DamageTypeList();

	public bool CanGather;

	public bool DidGather;

	public float gatherScale = 1f;

	public BasePlayer InitiatorPlayer
	{
		get
		{
			if (!Initiator)
			{
				return null;
			}
			return Initiator.ToPlayer();
		}
	}

	public Vector3 attackNormal => (PointEnd - PointStart).normalized;

	public bool hasDamage => damageTypes.Total() > 0f;

	public bool isHeadshot
	{
		get
		{
			if (HitEntity == null)
			{
				return false;
			}
			BaseCombatEntity baseCombatEntity = HitEntity as BaseCombatEntity;
			if (baseCombatEntity == null)
			{
				return false;
			}
			if (baseCombatEntity.skeletonProperties == null)
			{
				return false;
			}
			SkeletonProperties.BoneProperty boneProperty = baseCombatEntity.skeletonProperties.FindBone(HitBone);
			if (boneProperty == null)
			{
				return false;
			}
			return boneProperty.area == HitArea.Head;
		}
	}

	public Translate.Phrase bonePhrase
	{
		get
		{
			if (HitEntity == null)
			{
				return null;
			}
			BaseCombatEntity baseCombatEntity = HitEntity as BaseCombatEntity;
			if (baseCombatEntity == null)
			{
				return null;
			}
			if (baseCombatEntity.skeletonProperties == null)
			{
				return null;
			}
			return baseCombatEntity.skeletonProperties.FindBone(HitBone)?.name;
		}
	}

	public string boneName
	{
		get
		{
			Translate.Phrase phrase = bonePhrase;
			if (phrase != null)
			{
				return phrase.english;
			}
			return "N/A";
		}
	}

	public HitArea boneArea
	{
		get
		{
			if (HitEntity == null)
			{
				return (HitArea)(-1);
			}
			BaseCombatEntity baseCombatEntity = HitEntity as BaseCombatEntity;
			if (baseCombatEntity == null)
			{
				return (HitArea)(-1);
			}
			return baseCombatEntity.SkeletonLookup(HitBone);
		}
	}

	public bool IsProjectile()
	{
		return ProjectileID != 0;
	}

	public HitInfo()
	{
	}

	public HitInfo(BaseEntity attacker, BaseEntity target, DamageType type, float damageAmount, Vector3 vhitPosition)
	{
		Initiator = attacker;
		HitEntity = target;
		HitPositionWorld = vhitPosition;
		if (attacker != null)
		{
			PointStart = attacker.transform.position;
		}
		damageTypes.Add(type, damageAmount);
	}

	public HitInfo(BaseEntity attacker, BaseEntity target, DamageType type, float damageAmount)
		: this(attacker, target, type, damageAmount, target.transform.position)
	{
	}

	public void LoadFromAttack(Attack attack, bool serverSide)
	{
		HitEntity = null;
		PointStart = attack.pointStart;
		PointEnd = attack.pointEnd;
		if (attack.hitID.IsValid)
		{
			DidHit = true;
			if (serverSide)
			{
				HitEntity = BaseNetworkable.serverEntities.Find(attack.hitID) as BaseEntity;
			}
			if ((bool)HitEntity)
			{
				HitBone = attack.hitBone;
				HitPart = attack.hitPartID;
			}
		}
		DidHit = true;
		HitPositionLocal = attack.hitPositionLocal;
		HitPositionWorld = attack.hitPositionWorld;
		HitNormalLocal = attack.hitNormalLocal.normalized;
		HitNormalWorld = attack.hitNormalWorld.normalized;
		HitMaterial = attack.hitMaterialID;
	}

	public Vector3 PositionOnRay(Vector3 position)
	{
		Ray ray = new Ray(PointStart, attackNormal);
		if (ProjectilePrefab == null)
		{
			return RayEx.ClosestPoint(ray, position);
		}
		if (new Sphere(position, ProjectilePrefab.thickness).Trace(ray, out var hit))
		{
			return hit.point;
		}
		return position;
	}

	public Vector3 HitPositionOnRay()
	{
		return PositionOnRay(HitPositionWorld);
	}

	public bool IsNaNOrInfinity()
	{
		if (PointStart.IsNaNOrInfinity())
		{
			return true;
		}
		if (PointEnd.IsNaNOrInfinity())
		{
			return true;
		}
		if (HitPositionWorld.IsNaNOrInfinity())
		{
			return true;
		}
		if (HitPositionLocal.IsNaNOrInfinity())
		{
			return true;
		}
		if (HitNormalWorld.IsNaNOrInfinity())
		{
			return true;
		}
		if (HitNormalLocal.IsNaNOrInfinity())
		{
			return true;
		}
		if (ProjectileVelocity.IsNaNOrInfinity())
		{
			return true;
		}
		if (float.IsNaN(ProjectileDistance))
		{
			return true;
		}
		if (float.IsInfinity(ProjectileDistance))
		{
			return true;
		}
		if (float.IsNaN(ProjectileIntegrity))
		{
			return true;
		}
		if (float.IsInfinity(ProjectileIntegrity))
		{
			return true;
		}
		if (float.IsNaN(ProjectileTravelTime))
		{
			return true;
		}
		if (float.IsInfinity(ProjectileTravelTime))
		{
			return true;
		}
		if (float.IsNaN(ProjectileTrajectoryMismatch))
		{
			return true;
		}
		if (float.IsInfinity(ProjectileTrajectoryMismatch))
		{
			return true;
		}
		return false;
	}
}
