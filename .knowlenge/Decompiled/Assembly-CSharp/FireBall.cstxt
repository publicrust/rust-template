using System;
using System.Collections.Generic;
using Facepunch;
using Oxide.Core;
using Rust;
using UnityEngine;

public class FireBall : BaseEntity, ISplashable
{
	public float lifeTimeMin = 20f;

	public float lifeTimeMax = 40f;

	public ParticleSystem[] movementSystems;

	public ParticleSystem[] restingSystems;

	[NonSerialized]
	public float generation;

	public GameObjectRef spreadSubEntity;

	public float tickRate = 0.5f;

	public float damagePerSecond = 2f;

	public float radius = 0.5f;

	public int waterToExtinguish = 200;

	public bool canMerge;

	public LayerMask AttackLayers = 1219701521;

	public bool ignoreNPC;

	private Vector3 lastPos = Vector3.zero;

	private float deathTime;

	private int wetness;

	private float spawnTime;

	private Vector3 delayedVelocity;

	public void SetDelayedVelocity(Vector3 delayed)
	{
		if (!(delayedVelocity != Vector3.zero))
		{
			delayedVelocity = delayed;
			Invoke(ApplyDelayedVelocity, 0.1f);
		}
	}

	private void ApplyDelayedVelocity()
	{
		SetVelocity(delayedVelocity);
		delayedVelocity = Vector3.zero;
	}

	public override void ServerInit()
	{
		base.ServerInit();
		InvokeRepeating(Think, UnityEngine.Random.Range(0f, 1f), tickRate);
		float num = UnityEngine.Random.Range(lifeTimeMin, lifeTimeMax);
		float num2 = num * UnityEngine.Random.Range(0.9f, 1.1f);
		Invoke(Extinguish, num2);
		Invoke(TryToSpread, num * UnityEngine.Random.Range(0.3f, 0.5f));
		deathTime = Time.realtimeSinceStartup + num2;
		spawnTime = Time.realtimeSinceStartup;
	}

	public float GetDeathTime()
	{
		return deathTime;
	}

	public void AddLife(float amountToAdd)
	{
		float time = Mathf.Clamp(GetDeathTime() + amountToAdd, 0f, MaxLifeTime());
		Invoke(Extinguish, time);
		deathTime = time;
	}

	public float MaxLifeTime()
	{
		return lifeTimeMax * 2.5f;
	}

	public float TimeLeft()
	{
		float num = deathTime - Time.realtimeSinceStartup;
		if (num < 0f)
		{
			num = 0f;
		}
		return num;
	}

	public void TryToSpread()
	{
		float num = 0.9f - generation * 0.1f;
		if (UnityEngine.Random.Range(0f, 1f) < num && spreadSubEntity.isValid)
		{
			BaseEntity baseEntity = GameManager.server.CreateEntity(spreadSubEntity.resourcePath);
			if ((bool)baseEntity)
			{
				baseEntity.transform.position = base.transform.position + Vector3.up * 0.25f;
				baseEntity.Spawn();
				Vector3 modifiedAimConeDirection = AimConeUtil.GetModifiedAimConeDirection(45f, Vector3.up);
				baseEntity.creatorEntity = ((creatorEntity == null) ? baseEntity : creatorEntity);
				Interface.CallHook("OnFireBallSpread", this, baseEntity);
				baseEntity.SetVelocity(modifiedAimConeDirection * UnityEngine.Random.Range(5f, 8f));
				baseEntity.SendMessage("SetGeneration", generation + 1f);
			}
		}
	}

	public void SetGeneration(int gen)
	{
		generation = gen;
	}

	public void Think()
	{
		if (base.isServer)
		{
			SetResting(Vector3.Distance(lastPos, base.transform.localPosition) < 0.25f);
			lastPos = base.transform.localPosition;
			if (IsResting())
			{
				DoRadialDamage();
			}
			if (WaterFactor() > 0.5f)
			{
				Extinguish();
			}
			if (wetness > waterToExtinguish)
			{
				Extinguish();
			}
		}
	}

	public void DoRadialDamage()
	{
		List<Collider> obj = Pool.GetList<Collider>();
		Vector3 position = base.transform.position + new Vector3(0f, radius * 0.75f, 0f);
		Vis.Colliders(position, radius, obj, AttackLayers);
		HitInfo hitInfo = new HitInfo();
		hitInfo.DoHitEffects = true;
		hitInfo.DidHit = true;
		hitInfo.HitBone = 0u;
		hitInfo.Initiator = ((creatorEntity == null) ? GameObjectEx.ToBaseEntity(base.gameObject) : creatorEntity);
		hitInfo.PointStart = base.transform.position;
		foreach (Collider item in obj)
		{
			if (item.isTrigger && (item.gameObject.layer == 29 || item.gameObject.layer == 18))
			{
				continue;
			}
			BaseCombatEntity baseCombatEntity = GameObjectEx.ToBaseEntity(item.gameObject) as BaseCombatEntity;
			if (!(baseCombatEntity == null) && baseCombatEntity.isServer && baseCombatEntity.IsAlive() && (!ignoreNPC || !baseCombatEntity.IsNpc) && baseCombatEntity.IsVisible(position))
			{
				if (baseCombatEntity is BasePlayer)
				{
					Effect.server.Run("assets/bundled/prefabs/fx/impacts/additive/fire.prefab", baseCombatEntity, 0u, new Vector3(0f, 1f, 0f), Vector3.up);
				}
				hitInfo.PointEnd = baseCombatEntity.transform.position;
				hitInfo.HitPositionWorld = baseCombatEntity.transform.position;
				hitInfo.damageTypes.Set(DamageType.Heat, damagePerSecond * tickRate);
				Interface.CallHook("OnFireBallDamage", this, baseCombatEntity, hitInfo);
				baseCombatEntity.OnAttacked(hitInfo);
			}
		}
		Pool.FreeList(ref obj);
	}

	public bool CanMerge()
	{
		if (canMerge)
		{
			return TimeLeft() < MaxLifeTime() * 0.8f;
		}
		return false;
	}

	public float TimeAlive()
	{
		return Time.realtimeSinceStartup - spawnTime;
	}

	public void SetResting(bool isResting)
	{
		if (isResting != IsResting() && isResting && TimeAlive() > 1f && CanMerge())
		{
			List<Collider> obj = Pool.GetList<Collider>();
			Vis.Colliders(base.transform.position, 0.5f, obj, 512);
			foreach (Collider item in obj)
			{
				BaseEntity baseEntity = GameObjectEx.ToBaseEntity(item.gameObject);
				if ((bool)baseEntity)
				{
					FireBall fireBall = baseEntity.ToServer<FireBall>();
					if ((bool)fireBall && fireBall.CanMerge() && fireBall != this)
					{
						fireBall.Invoke(Extinguish, 1f);
						fireBall.canMerge = false;
						AddLife(fireBall.TimeLeft() * 0.25f);
					}
				}
			}
			Pool.FreeList(ref obj);
		}
		SetFlag(Flags.OnFire, isResting);
	}

	public void Extinguish()
	{
		CancelInvoke(Extinguish);
		if (!base.IsDestroyed)
		{
			Kill();
		}
	}

	public bool WantsSplash(ItemDefinition splashType, int amount)
	{
		return !base.IsDestroyed;
	}

	public int DoSplash(ItemDefinition splashType, int amount)
	{
		wetness += amount;
		return amount;
	}

	public bool IsResting()
	{
		return HasFlag(Flags.OnFire);
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
	}
}
