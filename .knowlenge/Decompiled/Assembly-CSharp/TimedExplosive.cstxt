using System;
using System.Collections.Generic;
using Facepunch;
using Facepunch.Rust;
using Oxide.Core;
using Rust;
using Rust.Ai;
using UnityEngine;

public class TimedExplosive : BaseEntity, ServerProjectile.IProjectileImpact
{
	public float timerAmountMin = 10f;

	public float timerAmountMax = 20f;

	public float minExplosionRadius;

	public float explosionRadius = 10f;

	public bool explodeOnContact;

	public bool canStick;

	public bool onlyDamageParent;

	public bool BlindAI;

	public float aiBlindDuration = 2.5f;

	public float aiBlindRange = 4f;

	public GameObjectRef explosionEffect;

	[Tooltip("Optional: Will fall back to explosionEffect if not assigned.")]
	public GameObjectRef underwaterExplosionEffect;

	public GameObjectRef stickEffect;

	public GameObjectRef bounceEffect;

	public bool explosionUsesForward;

	public bool waterCausesExplosion;

	public List<DamageTypeEntry> damageTypes = new List<DamageTypeEntry>();

	[NonSerialized]
	private float lastBounceTime;

	private CollisionDetectionMode? initialCollisionDetectionMode;

	private static BaseEntity[] queryResults = new BaseEntity[64];

	protected virtual bool AlwaysRunWaterCheck => false;

	public void SetDamageScale(float scale)
	{
		foreach (DamageTypeEntry damageType in damageTypes)
		{
			damageType.amount *= scale;
		}
	}

	public override float GetNetworkTime()
	{
		return Time.fixedTime;
	}

	public override void ServerInit()
	{
		lastBounceTime = Time.time;
		base.ServerInit();
		SetFuse(GetRandomTimerTime());
		ReceiveCollisionMessages(b: true);
		if (waterCausesExplosion || AlwaysRunWaterCheck)
		{
			InvokeRepeating(WaterCheck, 0f, 0.5f);
		}
	}

	public virtual void WaterCheck()
	{
		if (waterCausesExplosion && WaterFactor() >= 0.5f)
		{
			Explode();
		}
	}

	public virtual void SetFuse(float fuseLength)
	{
		if (base.isServer)
		{
			object obj = Interface.CallHook("OnExplosiveFuseSet", this, fuseLength);
			if (obj is float)
			{
				fuseLength = (float)obj;
			}
			Invoke(Explode, fuseLength);
			SetFlag(Flags.Reserved2, b: true);
		}
	}

	public virtual float GetRandomTimerTime()
	{
		return UnityEngine.Random.Range(timerAmountMin, timerAmountMax);
	}

	public virtual void ProjectileImpact(RaycastHit info, Vector3 rayOrigin)
	{
		Explode();
	}

	public virtual void Explode()
	{
		Explode(PivotPoint());
	}

	public virtual void Explode(Vector3 explosionFxPos)
	{
		Facepunch.Rust.Analytics.Azure.OnExplosion(this);
		Collider component = GetComponent<Collider>();
		if ((bool)component)
		{
			component.enabled = false;
		}
		bool flag = false;
		if (underwaterExplosionEffect.isValid)
		{
			flag = WaterLevel.GetWaterDepth(base.transform.position) > 1f;
		}
		if (flag)
		{
			Effect.server.Run(underwaterExplosionEffect.resourcePath, explosionFxPos, explosionUsesForward ? base.transform.forward : Vector3.up, null, broadcast: true);
		}
		else if (explosionEffect.isValid)
		{
			Effect.server.Run(explosionEffect.resourcePath, explosionFxPos, explosionUsesForward ? base.transform.forward : Vector3.up, null, broadcast: true);
		}
		if (damageTypes.Count > 0)
		{
			if (onlyDamageParent)
			{
				Vector3 vector = CenterPoint();
				DamageUtil.RadiusDamage(creatorEntity, LookupPrefab(), vector, minExplosionRadius, explosionRadius, damageTypes, 166144, useLineOfSight: true);
				BaseEntity baseEntity = GetParentEntity();
				BaseCombatEntity baseCombatEntity = baseEntity as BaseCombatEntity;
				while (baseCombatEntity == null && baseEntity != null && baseEntity.HasParent())
				{
					baseEntity = baseEntity.GetParentEntity();
					baseCombatEntity = baseEntity as BaseCombatEntity;
				}
				if (baseEntity == null || !GameObjectEx.IsOnLayer(baseEntity.gameObject, Layer.Construction))
				{
					List<BuildingBlock> obj = Pool.GetList<BuildingBlock>();
					Vis.Entities(vector, explosionRadius, obj, 2097152, QueryTriggerInteraction.Ignore);
					BuildingBlock buildingBlock = null;
					float num = float.PositiveInfinity;
					foreach (BuildingBlock item in obj)
					{
						if (!item.isClient && !item.IsDestroyed && !(item.healthFraction <= 0f))
						{
							float num2 = Vector3.Distance(item.ClosestPoint(vector), vector);
							if (num2 < num && item.IsVisible(vector, explosionRadius))
							{
								buildingBlock = item;
								num = num2;
							}
						}
					}
					if ((bool)buildingBlock)
					{
						HitInfo hitInfo = new HitInfo();
						hitInfo.Initiator = creatorEntity;
						hitInfo.WeaponPrefab = LookupPrefab();
						hitInfo.damageTypes.Add(damageTypes);
						hitInfo.PointStart = vector;
						hitInfo.PointEnd = buildingBlock.transform.position;
						float amount = 1f - Mathf.Clamp01((num - minExplosionRadius) / (explosionRadius - minExplosionRadius));
						hitInfo.damageTypes.ScaleAll(amount);
						buildingBlock.Hurt(hitInfo);
					}
					Pool.FreeList(ref obj);
				}
				if ((bool)baseCombatEntity)
				{
					HitInfo hitInfo2 = new HitInfo();
					hitInfo2.Initiator = creatorEntity;
					hitInfo2.WeaponPrefab = LookupPrefab();
					hitInfo2.damageTypes.Add(damageTypes);
					baseCombatEntity.Hurt(hitInfo2);
				}
				else if (baseEntity != null)
				{
					HitInfo hitInfo3 = new HitInfo();
					hitInfo3.Initiator = creatorEntity;
					hitInfo3.WeaponPrefab = LookupPrefab();
					hitInfo3.damageTypes.Add(damageTypes);
					hitInfo3.PointStart = vector;
					hitInfo3.PointEnd = baseEntity.transform.position;
					baseEntity.OnAttacked(hitInfo3);
				}
				if (creatorEntity != null && damageTypes != null)
				{
					float num3 = 0f;
					foreach (DamageTypeEntry damageType in damageTypes)
					{
						num3 += damageType.amount;
					}
					Sensation sensation = default(Sensation);
					sensation.Type = SensationType.Explosion;
					sensation.Position = creatorEntity.transform.position;
					sensation.Radius = explosionRadius * 17f;
					sensation.DamagePotential = num3;
					sensation.InitiatorPlayer = creatorEntity as BasePlayer;
					sensation.Initiator = creatorEntity;
					Sense.Stimulate(sensation);
				}
			}
			else
			{
				DamageUtil.RadiusDamage(creatorEntity, LookupPrefab(), CenterPoint(), minExplosionRadius, explosionRadius, damageTypes, 1076005121, useLineOfSight: true);
				if (creatorEntity != null && damageTypes != null)
				{
					float num4 = 0f;
					foreach (DamageTypeEntry damageType2 in damageTypes)
					{
						num4 += damageType2.amount;
					}
					Sensation sensation = default(Sensation);
					sensation.Type = SensationType.Explosion;
					sensation.Position = creatorEntity.transform.position;
					sensation.Radius = explosionRadius * 17f;
					sensation.DamagePotential = num4;
					sensation.InitiatorPlayer = creatorEntity as BasePlayer;
					sensation.Initiator = creatorEntity;
					Sense.Stimulate(sensation);
				}
			}
			BlindAnyAI();
		}
		if (!base.IsDestroyed && !HasFlag(Flags.Broken))
		{
			Kill(DestroyMode.Gib);
		}
	}

	private void BlindAnyAI()
	{
		if (!BlindAI)
		{
			return;
		}
		int brainsInSphere = Query.Server.GetBrainsInSphere(base.transform.position, 10f, queryResults);
		for (int i = 0; i < brainsInSphere; i++)
		{
			BaseEntity baseEntity = queryResults[i];
			if (Vector3.Distance(base.transform.position, baseEntity.transform.position) > aiBlindRange)
			{
				continue;
			}
			BaseAIBrain component = baseEntity.GetComponent<BaseAIBrain>();
			if (!(component == null))
			{
				BaseEntity brainBaseEntity = component.GetBrainBaseEntity();
				if (!(brainBaseEntity == null) && brainBaseEntity.IsVisible(CenterPoint()))
				{
					float blinded = aiBlindDuration * component.BlindDurationMultiplier * UnityEngine.Random.Range(0.6f, 1.4f);
					component.SetBlinded(blinded);
					queryResults[i] = null;
				}
			}
		}
	}

	public override void OnCollision(Collision collision, BaseEntity hitEntity)
	{
		if (canStick && !IsStuck())
		{
			bool flag = true;
			if ((bool)hitEntity)
			{
				flag = CanStickTo(hitEntity);
				if (!flag)
				{
					Collider component = GetComponent<Collider>();
					if (collision.collider != null && component != null)
					{
						Physics.IgnoreCollision(collision.collider, component);
					}
				}
			}
			if (flag)
			{
				DoCollisionStick(collision, hitEntity);
			}
		}
		if (explodeOnContact && !IsBusy())
		{
			SetMotionEnabled(wantsMotion: false);
			SetFlag(Flags.Busy, b: true, recursive: false, networkupdate: false);
			Invoke(Explode, 0.015f);
		}
		else
		{
			DoBounceEffect();
		}
	}

	public virtual bool CanStickTo(BaseEntity entity)
	{
		object obj = Interface.CallHook("CanExplosiveStick", this, entity);
		if (obj is bool)
		{
			return (bool)obj;
		}
		if (entity.TryGetComponent<DecorDeployable>(out var _))
		{
			return false;
		}
		if (entity is Drone)
		{
			return false;
		}
		return true;
	}

	private void DoBounceEffect()
	{
		if (!bounceEffect.isValid || Time.time - lastBounceTime < 0.2f)
		{
			return;
		}
		Rigidbody component = GetComponent<Rigidbody>();
		if (!component || !(component.velocity.magnitude < 1f))
		{
			if (bounceEffect.isValid)
			{
				Effect.server.Run(bounceEffect.resourcePath, base.transform.position, Vector3.up, null, broadcast: true);
			}
			lastBounceTime = Time.time;
		}
	}

	private void DoCollisionStick(Collision collision, BaseEntity ent)
	{
		ContactPoint contact = collision.GetContact(0);
		DoStick(contact.point, contact.normal, ent, collision.collider);
	}

	public virtual void SetMotionEnabled(bool wantsMotion)
	{
		Rigidbody component = GetComponent<Rigidbody>();
		if ((bool)component)
		{
			if (!initialCollisionDetectionMode.HasValue)
			{
				initialCollisionDetectionMode = component.collisionDetectionMode;
			}
			component.useGravity = wantsMotion;
			if (!wantsMotion)
			{
				component.collisionDetectionMode = CollisionDetectionMode.Discrete;
			}
			component.isKinematic = !wantsMotion;
			if (wantsMotion)
			{
				component.collisionDetectionMode = initialCollisionDetectionMode.Value;
			}
		}
	}

	public bool IsStuck()
	{
		Rigidbody component = GetComponent<Rigidbody>();
		if ((bool)component && !component.isKinematic)
		{
			return false;
		}
		Collider component2 = GetComponent<Collider>();
		if ((bool)component2 && component2.enabled)
		{
			return false;
		}
		return parentEntity.IsValid(serverside: true);
	}

	public void DoStick(Vector3 position, Vector3 normal, BaseEntity ent, Collider collider)
	{
		if (ent == null)
		{
			return;
		}
		if (ent is TimedExplosive)
		{
			if (!ent.HasParent())
			{
				return;
			}
			position = ent.transform.position;
			ent = ent.parentEntity.Get(serverside: true);
		}
		SetMotionEnabled(wantsMotion: false);
		SetCollisionEnabled(wantsCollision: false);
		if (!HasChild(ent))
		{
			base.transform.position = position;
			base.transform.rotation = Quaternion.LookRotation(normal, base.transform.up);
			if (collider != null)
			{
				SetParent(ent, ent.FindBoneID(collider.transform), worldPositionStays: true);
			}
			else
			{
				SetParent(ent, StringPool.closest, worldPositionStays: true);
			}
			if (stickEffect.isValid)
			{
				Effect.server.Run(stickEffect.resourcePath, base.transform.position, Vector3.up, null, broadcast: true);
			}
			ReceiveCollisionMessages(b: false);
		}
	}

	private void UnStick()
	{
		if ((bool)GetParentEntity())
		{
			SetParent(null, worldPositionStays: true, sendImmediate: true);
			SetMotionEnabled(wantsMotion: true);
			SetCollisionEnabled(wantsCollision: true);
			ReceiveCollisionMessages(b: true);
		}
	}

	internal override void OnParentRemoved()
	{
		UnStick();
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		if (parentEntity.IsValid(serverside: true))
		{
			DoStick(base.transform.position, base.transform.forward, parentEntity.Get(serverside: true), null);
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.explosive != null)
		{
			parentEntity.uid = info.msg.explosive.parentid;
		}
	}

	public virtual void SetCollisionEnabled(bool wantsCollision)
	{
		Collider component = GetComponent<Collider>();
		if ((bool)component && component.enabled != wantsCollision)
		{
			component.enabled = wantsCollision;
		}
	}
}
