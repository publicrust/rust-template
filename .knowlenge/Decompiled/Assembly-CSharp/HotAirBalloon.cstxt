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

public class HotAirBalloon : BaseCombatEntity, SamSite.ISamSiteTarget
{
	protected const Flags Flag_HasFuel = Flags.Reserved6;

	protected const Flags Flag_HalfInflated = Flags.Reserved1;

	protected const Flags Flag_FullInflated = Flags.Reserved2;

	public Transform centerOfMass;

	public Rigidbody myRigidbody;

	public Transform buoyancyPoint;

	public float liftAmount = 10f;

	public Transform windSock;

	public Transform[] windFlags;

	public GameObject staticBalloonDeflated;

	public GameObject staticBalloon;

	public GameObject animatedBalloon;

	public Animator balloonAnimator;

	public Transform groundSample;

	public float inflationLevel;

	[Header("Fuel")]
	public GameObjectRef fuelStoragePrefab;

	public float fuelPerSec = 0.25f;

	[Header("Storage")]
	public GameObjectRef storageUnitPrefab;

	public EntityRef<StorageContainer> storageUnitInstance;

	[Header("Damage")]
	public DamageRenderer damageRenderer;

	public Transform engineHeight;

	public GameObject[] killTriggers;

	public EntityFuelSystem fuelSystem;

	[ServerVar(Help = "Population active on the server", ShowInAdminUI = true)]
	public static float population = 1f;

	[ServerVar(Help = "How long before a HAB loses all its health while outside")]
	public static float outsidedecayminutes = 180f;

	public float windForce = 30000f;

	public Vector3 currentWindVec = Vector3.zero;

	public Bounds collapsedBounds;

	public Bounds raisedBounds;

	public GameObject[] balloonColliders;

	[ServerVar]
	public static float serviceCeiling = 200f;

	public float currentBuoyancy;

	public float lastBlastTime;

	public float avgTerrainHeight;

	public bool grounded;

	public bool IsFullyInflated => inflationLevel >= 1f;

	public SamSite.SamTargetType SAMTargetType => SamSite.targetTypeVehicle;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("HotAirBalloon.OnRpcMessage"))
		{
			if (rpc == 578721460 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (ConVar.Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - EngineSwitch "));
				}
				using (TimeWarning.New("EngineSwitch"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(578721460u, "EngineSwitch", this, player, 3f))
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
							EngineSwitch(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in EngineSwitch");
					}
				}
				return true;
			}
			if (rpc == 1851540757 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (ConVar.Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - RPC_OpenFuel "));
				}
				using (TimeWarning.New("RPC_OpenFuel"))
				{
					try
					{
						using (TimeWarning.New("Call"))
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg3 = rPCMessage;
							RPC_OpenFuel(msg3);
						}
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
						player.Kick("RPC Error in RPC_OpenFuel");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void InitShared()
	{
		fuelSystem = new EntityFuelSystem(base.isServer, fuelStoragePrefab, children);
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.hotAirBalloon != null)
		{
			inflationLevel = info.msg.hotAirBalloon.inflationAmount;
			if (info.fromDisk && (bool)myRigidbody)
			{
				myRigidbody.velocity = info.msg.hotAirBalloon.velocity;
			}
		}
		if (info.msg.motorBoat != null)
		{
			fuelSystem.fuelStorageInstance.uid = info.msg.motorBoat.fuelStorageID;
			storageUnitInstance.uid = info.msg.motorBoat.storageid;
		}
	}

	public bool WaterLogged()
	{
		return WaterLevel.Test(engineHeight.position, waves: true, this);
	}

	protected override void OnChildAdded(BaseEntity child)
	{
		base.OnChildAdded(child);
		if (base.isServer)
		{
			if (isSpawned)
			{
				fuelSystem.CheckNewChild(child);
			}
			if (child.prefabID == storageUnitPrefab.GetEntity().prefabID)
			{
				storageUnitInstance.Set((StorageContainer)child);
			}
		}
	}

	internal override void DoServerDestroy()
	{
		if (vehicle.vehiclesdroploot && storageUnitInstance.IsValid(base.isServer))
		{
			storageUnitInstance.Get(base.isServer).DropItems();
		}
		base.DoServerDestroy();
	}

	public bool IsValidSAMTarget(bool staticRespawn)
	{
		if (staticRespawn)
		{
			return IsFullyInflated;
		}
		if (IsFullyInflated)
		{
			return !BaseVehicle.InSafeZone(triggers, base.transform.position);
		}
		return false;
	}

	public override float GetNetworkTime()
	{
		return UnityEngine.Time.fixedTime;
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		SetFlag(Flags.On, b: false);
	}

	[RPC_Server]
	public void RPC_OpenFuel(RPCMessage msg)
	{
		BasePlayer player = msg.player;
		if (!(player == null))
		{
			fuelSystem.LootFuel(player);
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.hotAirBalloon = Facepunch.Pool.Get<ProtoBuf.HotAirBalloon>();
		info.msg.hotAirBalloon.inflationAmount = inflationLevel;
		if (info.forDisk && (bool)myRigidbody)
		{
			info.msg.hotAirBalloon.velocity = myRigidbody.velocity;
		}
		info.msg.motorBoat = Facepunch.Pool.Get<Motorboat>();
		info.msg.motorBoat.storageid = storageUnitInstance.uid;
		info.msg.motorBoat.fuelStorageID = fuelSystem.fuelStorageInstance.uid;
	}

	public override void ServerInit()
	{
		myRigidbody.centerOfMass = centerOfMass.localPosition;
		myRigidbody.isKinematic = false;
		avgTerrainHeight = TerrainMeta.HeightMap.GetHeight(base.transform.position);
		base.ServerInit();
		bounds = collapsedBounds;
		InvokeRandomized(DecayTick, UnityEngine.Random.Range(30f, 60f), 60f, 6f);
		InvokeRandomized(UpdateIsGrounded, 0f, 3f, 0.2f);
	}

	public void DecayTick()
	{
		if (base.healthFraction != 0f && !IsFullyInflated && !(UnityEngine.Time.time < lastBlastTime + 600f))
		{
			float num = 1f / outsidedecayminutes;
			if (IsOutside())
			{
				Hurt(MaxHealth() * num, DamageType.Decay, this, useProtection: false);
			}
		}
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void EngineSwitch(RPCMessage msg)
	{
		if (Interface.CallHook("OnHotAirBalloonToggle", this, msg.player) == null)
		{
			bool b = msg.read.Bit();
			SetFlag(Flags.On, b);
			if (IsOn())
			{
				Invoke(ScheduleOff, 60f);
				Interface.CallHook("OnHotAirBalloonToggled", this, msg.player);
			}
			else
			{
				CancelInvoke(ScheduleOff);
				Interface.CallHook("OnHotAirBalloonToggled", this, msg.player);
			}
		}
	}

	public void ScheduleOff()
	{
		SetFlag(Flags.On, b: false);
	}

	public void UpdateIsGrounded()
	{
		if (!(lastBlastTime + 5f > UnityEngine.Time.time))
		{
			List<Collider> obj = Facepunch.Pool.GetList<Collider>();
			GamePhysics.OverlapSphere(groundSample.transform.position, 1.25f, obj, 1218511105);
			grounded = obj.Count > 0;
			CheckGlobal(flags);
			Facepunch.Pool.FreeList(ref obj);
		}
	}

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
		if (base.isServer)
		{
			CheckGlobal(next);
		}
	}

	private void CheckGlobal(Flags flags)
	{
		bool wants = flags.HasFlag(Flags.On) || flags.HasFlag(Flags.Reserved2) || flags.HasFlag(Flags.Reserved1) || !grounded;
		EnableGlobalBroadcast(wants);
	}

	protected void FixedUpdate()
	{
		if (!isSpawned || base.isClient)
		{
			return;
		}
		if (!fuelSystem.HasFuel() || WaterLogged())
		{
			SetFlag(Flags.On, b: false);
		}
		if (IsOn())
		{
			fuelSystem.TryUseFuel(UnityEngine.Time.fixedDeltaTime, fuelPerSec);
		}
		SetFlag(Flags.Reserved6, fuelSystem.HasFuel());
		bool flag = (IsFullyInflated && myRigidbody.velocity.y < 0f) || myRigidbody.velocity.y < 0.75f;
		GameObject[] array = killTriggers;
		foreach (GameObject gameObject in array)
		{
			if (gameObject.activeSelf != flag)
			{
				gameObject.SetActive(flag);
			}
		}
		float num = inflationLevel;
		if (IsOn() && !IsFullyInflated)
		{
			inflationLevel = Mathf.Clamp01(inflationLevel + UnityEngine.Time.fixedDeltaTime / 10f);
		}
		else if (grounded && inflationLevel > 0f && !IsOn() && (UnityEngine.Time.time > lastBlastTime + 30f || WaterLogged()))
		{
			inflationLevel = Mathf.Clamp01(inflationLevel - UnityEngine.Time.fixedDeltaTime / 10f);
		}
		if (num != inflationLevel)
		{
			if (IsFullyInflated)
			{
				bounds = raisedBounds;
			}
			else if (inflationLevel == 0f)
			{
				bounds = collapsedBounds;
			}
			SetFlag(Flags.Reserved1, inflationLevel > 0.3f);
			SetFlag(Flags.Reserved2, inflationLevel >= 1f);
			SendNetworkUpdate();
			_ = inflationLevel;
		}
		bool flag2 = !myRigidbody.IsSleeping() || inflationLevel > 0f;
		array = balloonColliders;
		foreach (GameObject gameObject2 in array)
		{
			if (gameObject2.activeSelf != flag2)
			{
				gameObject2.SetActive(flag2);
			}
		}
		if (IsOn())
		{
			if (IsFullyInflated)
			{
				currentBuoyancy += UnityEngine.Time.fixedDeltaTime * 0.2f;
				lastBlastTime = UnityEngine.Time.time;
			}
		}
		else
		{
			currentBuoyancy -= UnityEngine.Time.fixedDeltaTime * 0.1f;
		}
		currentBuoyancy = Mathf.Clamp(currentBuoyancy, 0f, 0.8f + 0.2f * base.healthFraction);
		if (inflationLevel > 0f)
		{
			avgTerrainHeight = Mathf.Lerp(avgTerrainHeight, TerrainMeta.HeightMap.GetHeight(base.transform.position), UnityEngine.Time.deltaTime);
			float num2 = 1f - Mathf.InverseLerp(avgTerrainHeight + serviceCeiling - 20f, avgTerrainHeight + serviceCeiling, buoyancyPoint.position.y);
			myRigidbody.AddForceAtPosition(Vector3.up * (0f - UnityEngine.Physics.gravity.y) * myRigidbody.mass * 0.5f * inflationLevel, buoyancyPoint.position, ForceMode.Force);
			myRigidbody.AddForceAtPosition(Vector3.up * liftAmount * currentBuoyancy * num2, buoyancyPoint.position, ForceMode.Force);
			Vector3 windAtPos = GetWindAtPos(buoyancyPoint.position);
			_ = windAtPos.magnitude;
			float num3 = 1f;
			float num4 = Mathf.Max(TerrainMeta.HeightMap.GetHeight(buoyancyPoint.position), TerrainMeta.WaterMap.GetHeight(buoyancyPoint.position));
			float num5 = Mathf.InverseLerp(num4 + 20f, num4 + 60f, buoyancyPoint.position.y);
			float num6 = 1f;
			if (UnityEngine.Physics.SphereCast(new Ray(base.transform.position + Vector3.up * 2f, Vector3.down), 1.5f, out var hitInfo, 5f, 1218511105))
			{
				num6 = Mathf.Clamp01(hitInfo.distance / 5f);
			}
			num3 *= num5 * num2 * num6;
			num3 *= 0.2f + 0.8f * base.healthFraction;
			Vector3 vector = windAtPos.normalized * num3 * windForce;
			currentWindVec = Vector3.Lerp(currentWindVec, vector, UnityEngine.Time.fixedDeltaTime * 0.25f);
			myRigidbody.AddForceAtPosition(vector * 0.1f, buoyancyPoint.position, ForceMode.Force);
			myRigidbody.AddForce(vector * 0.9f, ForceMode.Force);
		}
	}

	public override Vector3 GetLocalVelocityServer()
	{
		if (myRigidbody == null)
		{
			return Vector3.zero;
		}
		return myRigidbody.velocity;
	}

	public override Quaternion GetAngularVelocityServer()
	{
		if (myRigidbody == null)
		{
			return Quaternion.identity;
		}
		if (myRigidbody.angularVelocity.sqrMagnitude < 0.1f)
		{
			return Quaternion.identity;
		}
		return Quaternion.LookRotation(myRigidbody.angularVelocity, base.transform.up);
	}

	public Vector3 GetWindAtPos(Vector3 pos)
	{
		float num = pos.y * 6f;
		return new Vector3(Mathf.Sin(num * ((float)Math.PI / 180f)), 0f, Mathf.Cos(num * ((float)Math.PI / 180f))).normalized * 1f;
	}
}
