using System;
using System.Collections.Generic;
using Facepunch;
using Network;
using Oxide.Core;
using ProtoBuf;
using Rust;
using UnityEngine;

public class BaseHelicopter : BaseCombatEntity
{
	[Serializable]
	public class weakspot
	{
		[NonSerialized]
		public BaseHelicopter body;

		public string[] bonenames;

		public float maxHealth;

		public float health;

		public float healthFractionOnDestroyed = 0.5f;

		public GameObjectRef destroyedParticles;

		public GameObjectRef damagedParticles;

		public GameObject damagedEffect;

		public GameObject destroyedEffect;

		public List<BasePlayer> attackers;

		private bool isDestroyed;

		public float HealthFraction()
		{
			return health / maxHealth;
		}

		public void Hurt(float amount, HitInfo info)
		{
			if (!isDestroyed)
			{
				health -= amount;
				Effect.server.Run(damagedParticles.resourcePath, body, StringPool.Get(bonenames[UnityEngine.Random.Range(0, bonenames.Length)]), Vector3.zero, Vector3.up, null, broadcast: true);
				if (health <= 0f)
				{
					health = 0f;
					WeakspotDestroyed();
				}
			}
		}

		public void Heal(float amount)
		{
			health += amount;
		}

		public void WeakspotDestroyed()
		{
			isDestroyed = true;
			Effect.server.Run(destroyedParticles.resourcePath, body, StringPool.Get(bonenames[UnityEngine.Random.Range(0, bonenames.Length)]), Vector3.zero, Vector3.up, null, broadcast: true);
			body.Hurt(body.MaxHealth() * healthFractionOnDestroyed, DamageType.Generic, null, useProtection: false);
		}
	}

	public weakspot[] weakspots;

	public GameObject rotorPivot;

	public GameObject mainRotor;

	public GameObject mainRotor_blades;

	public GameObject mainRotor_blur;

	public GameObject tailRotor;

	public GameObject tailRotor_blades;

	public GameObject tailRotor_blur;

	public GameObject rocket_tube_left;

	public GameObject rocket_tube_right;

	public GameObject left_gun_yaw;

	public GameObject left_gun_pitch;

	public GameObject left_gun_muzzle;

	public GameObject right_gun_yaw;

	public GameObject right_gun_pitch;

	public GameObject right_gun_muzzle;

	public GameObject spotlight_rotation;

	public GameObjectRef rocket_fire_effect;

	public GameObjectRef gun_fire_effect;

	public GameObjectRef bulletEffect;

	public GameObjectRef explosionEffect;

	public GameObjectRef fireBall;

	public GameObjectRef crateToDrop;

	public int maxCratesToSpawn = 4;

	public float bulletSpeed = 250f;

	public float bulletDamage = 20f;

	public GameObjectRef servergibs;

	public GameObjectRef debrisFieldMarker;

	public SoundDefinition rotorWashSoundDef;

	private Sound _rotorWashSound;

	public SoundDefinition flightEngineSoundDef;

	public SoundDefinition flightThwopsSoundDef;

	private Sound flightEngineSound;

	private Sound flightThwopsSound;

	public SoundModulation.Modulator flightEngineGainMod;

	public SoundModulation.Modulator flightThwopsGainMod;

	public float rotorGainModSmoothing = 0.25f;

	public float engineGainMin = 0.5f;

	public float engineGainMax = 1f;

	public float thwopGainMin = 0.5f;

	public float thwopGainMax = 1f;

	public float spotlightJitterAmount = 5f;

	public float spotlightJitterSpeed = 5f;

	public GameObject[] nightLights;

	public Vector3 spotlightTarget;

	public float engineSpeed = 1f;

	public float targetEngineSpeed = 1f;

	public float blur_rotationScale = 0.05f;

	public ParticleSystem[] _rotorWashParticles;

	public PatrolHelicopterAI myAI;

	public GameObjectRef mapMarkerEntityPrefab;

	public float lastNetworkUpdate = float.NegativeInfinity;

	private const float networkUpdateRate = 0.25f;

	private BaseEntity mapMarkerInstance;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("BaseHelicopter.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public void InitalizeWeakspots()
	{
		weakspot[] array = weakspots;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].body = this;
		}
	}

	public override void OnAttacked(HitInfo info)
	{
		base.OnAttacked(info);
		if (base.isServer)
		{
			myAI.WasAttacked(info);
		}
	}

	public override void Hurt(HitInfo info)
	{
		if (Interface.CallHook("OnHelicopterAttacked", this, info) != null)
		{
			return;
		}
		bool flag = false;
		if (info.damageTypes.Total() >= base.health)
		{
			base.health = 1000000f;
			myAI.CriticalDamage();
			flag = true;
		}
		base.Hurt(info);
		if (flag)
		{
			return;
		}
		weakspot[] array = weakspots;
		foreach (weakspot weakspot in array)
		{
			string[] bonenames = weakspot.bonenames;
			foreach (string str in bonenames)
			{
				if (info.HitBone == StringPool.Get(str))
				{
					weakspot.Hurt(info.damageTypes.Total(), info);
					myAI.WeakspotDamaged(weakspot, info);
				}
			}
		}
	}

	public override float MaxVelocity()
	{
		return 100f;
	}

	public override void InitShared()
	{
		base.InitShared();
		InitalizeWeakspots();
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.helicopter != null)
		{
			spotlightTarget = info.msg.helicopter.spotlightVec;
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.helicopter = Pool.Get<Helicopter>();
		info.msg.helicopter.tiltRot = rotorPivot.transform.localRotation.eulerAngles;
		info.msg.helicopter.spotlightVec = spotlightTarget;
		info.msg.helicopter.weakspothealths = Pool.Get<List<float>>();
		for (int i = 0; i < weakspots.Length; i++)
		{
			info.msg.helicopter.weakspothealths.Add(weakspots[i].health);
		}
	}

	public override void ServerInit()
	{
		base.ServerInit();
		myAI = GetComponent<PatrolHelicopterAI>();
		if (!myAI.hasInterestZone)
		{
			myAI.SetInitialDestination(Vector3.zero, 1.25f);
			myAI.targetThrottleSpeed = 1f;
			myAI.ExitCurrentState();
			myAI.State_Patrol_Enter();
		}
		CreateMapMarker();
	}

	public void CreateMapMarker()
	{
		if ((bool)mapMarkerInstance)
		{
			mapMarkerInstance.Kill();
		}
		BaseEntity baseEntity = GameManager.server.CreateEntity(mapMarkerEntityPrefab.resourcePath, Vector3.zero, Quaternion.identity);
		baseEntity.SetParent(this);
		baseEntity.Spawn();
		mapMarkerInstance = baseEntity;
	}

	public override void OnPositionalNetworkUpdate()
	{
		SendNetworkUpdate();
		base.OnPositionalNetworkUpdate();
	}

	public void CreateExplosionMarker(float durationMinutes)
	{
		BaseEntity baseEntity = GameManager.server.CreateEntity(debrisFieldMarker.resourcePath, base.transform.position, Quaternion.identity);
		baseEntity.Spawn();
		baseEntity.SendMessage("SetDuration", durationMinutes, SendMessageOptions.DontRequireReceiver);
	}

	public override void OnKilled(HitInfo info)
	{
		if (base.isClient)
		{
			return;
		}
		CreateExplosionMarker(10f);
		Effect.server.Run(explosionEffect.resourcePath, base.transform.position, Vector3.up, null, broadcast: true);
		Vector3 vector = myAI.GetLastMoveDir() * myAI.GetMoveSpeed() * 0.75f;
		GameObject gibSource = servergibs.Get().GetComponent<ServerGib>()._gibSource;
		List<ServerGib> list = ServerGib.CreateGibs(servergibs.resourcePath, base.gameObject, gibSource, vector, 3f);
		if (info.damageTypes.GetMajorityDamageType() != DamageType.Decay)
		{
			for (int i = 0; i < 12 - maxCratesToSpawn; i++)
			{
				BaseEntity baseEntity = GameManager.server.CreateEntity(this.fireBall.resourcePath, base.transform.position, base.transform.rotation);
				if (!baseEntity)
				{
					continue;
				}
				float min = 3f;
				float max = 10f;
				Vector3 onUnitSphere = UnityEngine.Random.onUnitSphere;
				baseEntity.transform.position = base.transform.position + new Vector3(0f, 1.5f, 0f) + onUnitSphere * UnityEngine.Random.Range(-4f, 4f);
				Collider component = baseEntity.GetComponent<Collider>();
				baseEntity.Spawn();
				baseEntity.SetVelocity(vector + onUnitSphere * UnityEngine.Random.Range(min, max));
				foreach (ServerGib item in list)
				{
					Physics.IgnoreCollision(component, item.GetCollider(), ignore: true);
				}
			}
		}
		for (int j = 0; j < maxCratesToSpawn; j++)
		{
			Vector3 onUnitSphere2 = UnityEngine.Random.onUnitSphere;
			Vector3 pos = base.transform.position + new Vector3(0f, 1.5f, 0f) + onUnitSphere2 * UnityEngine.Random.Range(2f, 3f);
			BaseEntity baseEntity2 = GameManager.server.CreateEntity(crateToDrop.resourcePath, pos, Quaternion.LookRotation(onUnitSphere2));
			baseEntity2.Spawn();
			LootContainer lootContainer = baseEntity2 as LootContainer;
			if ((bool)lootContainer)
			{
				lootContainer.Invoke(lootContainer.RemoveMe, 1800f);
			}
			Collider component2 = baseEntity2.GetComponent<Collider>();
			Rigidbody rigidbody = baseEntity2.gameObject.AddComponent<Rigidbody>();
			rigidbody.useGravity = true;
			rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
			rigidbody.mass = 2f;
			rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
			rigidbody.velocity = vector + onUnitSphere2 * UnityEngine.Random.Range(1f, 3f);
			rigidbody.angularVelocity = Vector3Ex.Range(-1.75f, 1.75f);
			rigidbody.drag = 0.5f * (rigidbody.mass / 5f);
			rigidbody.angularDrag = 0.2f * (rigidbody.mass / 5f);
			FireBall fireBall = GameManager.server.CreateEntity(this.fireBall.resourcePath) as FireBall;
			if ((bool)fireBall)
			{
				fireBall.SetParent(baseEntity2);
				fireBall.Spawn();
				fireBall.GetComponent<Rigidbody>().isKinematic = true;
				fireBall.GetComponent<Collider>().enabled = false;
			}
			baseEntity2.SendMessage("SetLockingEnt", fireBall.gameObject, SendMessageOptions.DontRequireReceiver);
			foreach (ServerGib item2 in list)
			{
				Physics.IgnoreCollision(component2, item2.GetCollider(), ignore: true);
			}
		}
		base.OnKilled(info);
	}

	public void Update()
	{
		if (base.isServer && Time.realtimeSinceStartup - lastNetworkUpdate >= 0.25f)
		{
			SendNetworkUpdate();
			lastNetworkUpdate = Time.realtimeSinceStartup;
		}
	}
}
