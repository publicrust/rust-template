using System;
using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class HitTest : Pool.IPooled
{
	public enum Type
	{
		Generic,
		ProjectileEffect,
		Projectile,
		MeleeAttack,
		Use
	}

	public Type type;

	public Ray AttackRay;

	public float Radius;

	public float Forgiveness;

	public float MaxDistance;

	public RaycastHit RayHit;

	public bool MultiHit;

	public bool BestHit;

	public bool DidHit;

	public DamageProperties damageProperties;

	public GameObject gameObject;

	public Collider collider;

	public BaseEntity ignoreEntity;

	public List<System.Type> ignoredTypes = new List<System.Type>();

	public BaseEntity HitEntity;

	public Vector3 HitPoint;

	public Vector3 HitNormal;

	public float HitDistance;

	public Transform HitTransform;

	public uint HitPart;

	public string HitMaterial;

	public void EnterPool()
	{
		Clear();
	}

	public void LeavePool()
	{
	}

	public void CopyFrom(HitTest other, bool copyHitInfo = false)
	{
		type = other.type;
		AttackRay = other.AttackRay;
		Radius = other.Radius;
		Forgiveness = other.Forgiveness;
		MaxDistance = other.MaxDistance;
		RayHit = other.RayHit;
		damageProperties = other.damageProperties;
		ignoreEntity = other.ignoreEntity;
		ignoredTypes = other.ignoredTypes;
		if (copyHitInfo)
		{
			HitEntity = other.HitEntity;
			HitPoint = other.HitPoint;
			HitNormal = other.HitNormal;
			HitDistance = other.HitDistance;
			HitTransform = other.HitTransform;
			HitPart = other.HitPart;
			HitMaterial = other.HitMaterial;
			MultiHit = other.MultiHit;
			BestHit = other.BestHit;
			DidHit = other.DidHit;
		}
	}

	public Vector3 HitPointWorld()
	{
		if (HitEntity != null)
		{
			Transform transform = HitTransform;
			if (!transform)
			{
				transform = HitEntity.transform;
			}
			return transform.TransformPoint(HitPoint);
		}
		return HitPoint;
	}

	public Vector3 HitNormalWorld()
	{
		if (HitEntity != null)
		{
			Transform transform = HitTransform;
			if (!transform)
			{
				transform = HitEntity.transform;
			}
			return transform.TransformDirection(HitNormal);
		}
		return HitNormal;
	}

	public void Clear()
	{
		type = Type.Generic;
		AttackRay = default(Ray);
		Radius = 0f;
		Forgiveness = 0f;
		MaxDistance = 0f;
		RayHit = default(RaycastHit);
		MultiHit = false;
		BestHit = false;
		DidHit = false;
		damageProperties = null;
		gameObject = null;
		collider = null;
		ignoreEntity = null;
		HitEntity = null;
		HitPoint = default(Vector3);
		HitNormal = default(Vector3);
		HitDistance = 0f;
		HitTransform = null;
		HitPart = 0u;
		HitMaterial = null;
		ignoredTypes.Clear();
	}
}
