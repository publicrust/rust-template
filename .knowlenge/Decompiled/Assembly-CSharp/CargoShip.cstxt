using System.Collections.Generic;
using Facepunch;
using Network;
using Oxide.Core;
using ProtoBuf;
using Rust;
using UnityEngine;

public class CargoShip : BaseEntity
{
	public int targetNodeIndex = -1;

	public GameObject wakeParent;

	public GameObjectRef scientistTurretPrefab;

	public Transform[] scientistSpawnPoints;

	public List<Transform> crateSpawns;

	public GameObjectRef lockedCratePrefab;

	public GameObjectRef militaryCratePrefab;

	public GameObjectRef eliteCratePrefab;

	public GameObjectRef junkCratePrefab;

	public Transform waterLine;

	public Transform rudder;

	public Transform propeller;

	public GameObjectRef escapeBoatPrefab;

	public Transform escapeBoatPoint;

	public GameObjectRef microphonePrefab;

	public Transform microphonePoint;

	public GameObjectRef speakerPrefab;

	public Transform[] speakerPoints;

	public GameObject radiation;

	public GameObjectRef mapMarkerEntityPrefab;

	public GameObject hornOrigin;

	public SoundDefinition hornDef;

	public CargoShipSounds cargoShipSounds;

	public GameObject[] layouts;

	public GameObjectRef playerTest;

	private uint layoutChoice;

	[ServerVar]
	public static bool event_enabled = true;

	[ServerVar]
	public static float event_duration_minutes = 50f;

	[ServerVar]
	public static float egress_duration_minutes = 10f;

	[ServerVar]
	public static int loot_rounds = 3;

	[ServerVar]
	public static float loot_round_spacing_minutes = 10f;

	public BaseEntity mapMarkerInstance;

	public Vector3 currentVelocity = Vector3.zero;

	public float currentThrottle;

	public float currentTurnSpeed;

	public float turnScale;

	public int lootRoundsPassed;

	public int hornCount;

	public float currentRadiation;

	public bool egressing;

	public override float GetNetworkTime()
	{
		return Time.fixedTime;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.simpleUint != null)
		{
			layoutChoice = info.msg.simpleUint.value;
		}
	}

	public void RefreshActiveLayout()
	{
		for (int i = 0; i < layouts.Length; i++)
		{
			layouts[i].SetActive(layoutChoice == i);
		}
	}

	public void TriggeredEventSpawn()
	{
		Vector3 vector = TerrainMeta.RandomPointOffshore();
		vector.y = TerrainMeta.WaterMap.GetHeight(vector);
		base.transform.position = vector;
		if (!event_enabled || event_duration_minutes == 0f)
		{
			Invoke(DelayedDestroy, 1f);
		}
	}

	public void CreateMapMarker()
	{
		if ((bool)mapMarkerInstance)
		{
			mapMarkerInstance.Kill();
		}
		BaseEntity baseEntity = GameManager.server.CreateEntity(mapMarkerEntityPrefab.resourcePath, Vector3.zero, Quaternion.identity);
		baseEntity.Spawn();
		baseEntity.SetParent(this);
		mapMarkerInstance = baseEntity;
	}

	public void DisableCollisionTest()
	{
	}

	public void SpawnCrate(string resourcePath)
	{
		int index = UnityEngine.Random.Range(0, crateSpawns.Count);
		Vector3 position = crateSpawns[index].position;
		Quaternion rotation = crateSpawns[index].rotation;
		crateSpawns.Remove(crateSpawns[index]);
		BaseEntity baseEntity = GameManager.server.CreateEntity(resourcePath, position, rotation);
		if ((bool)baseEntity)
		{
			baseEntity.enableSaving = false;
			baseEntity.SendMessage("SetWasDropped", SendMessageOptions.DontRequireReceiver);
			baseEntity.Spawn();
			baseEntity.SetParent(this, worldPositionStays: true);
			Rigidbody component = baseEntity.GetComponent<Rigidbody>();
			if (component != null)
			{
				component.isKinematic = true;
			}
		}
	}

	public void RespawnLoot()
	{
		if (Interface.CallHook("OnCargoShipSpawnCrate", this) == null)
		{
			InvokeRepeating(PlayHorn, 0f, 8f);
			SpawnCrate(lockedCratePrefab.resourcePath);
			SpawnCrate(eliteCratePrefab.resourcePath);
			for (int i = 0; i < 4; i++)
			{
				SpawnCrate(militaryCratePrefab.resourcePath);
			}
			for (int j = 0; j < 4; j++)
			{
				SpawnCrate(junkCratePrefab.resourcePath);
			}
			lootRoundsPassed++;
			if (lootRoundsPassed >= loot_rounds)
			{
				CancelInvoke(RespawnLoot);
			}
		}
	}

	public void SpawnSubEntities()
	{
		if (!Rust.Application.isLoadingSave)
		{
			BaseEntity baseEntity = GameManager.server.CreateEntity(escapeBoatPrefab.resourcePath, escapeBoatPoint.position, escapeBoatPoint.rotation);
			if ((bool)baseEntity)
			{
				baseEntity.SetParent(this, worldPositionStays: true);
				baseEntity.Spawn();
				RHIB component = baseEntity.GetComponent<RHIB>();
				component.SetToKinematic();
				if ((bool)component)
				{
					component.AddFuel(50);
				}
			}
		}
		MicrophoneStand microphoneStand = GameManager.server.CreateEntity(microphonePrefab.resourcePath, microphonePoint.position, microphonePoint.rotation) as MicrophoneStand;
		if ((bool)microphoneStand)
		{
			microphoneStand.enableSaving = false;
			microphoneStand.SetParent(this, worldPositionStays: true);
			microphoneStand.Spawn();
			microphoneStand.SpawnChildEntity();
			IOEntity iOEntity = microphoneStand.ioEntity.Get(serverside: true);
			Transform[] array = speakerPoints;
			foreach (Transform transform in array)
			{
				IOEntity iOEntity2 = GameManager.server.CreateEntity(speakerPrefab.resourcePath, transform.position, transform.rotation) as IOEntity;
				iOEntity2.enableSaving = false;
				iOEntity2.SetParent(this, worldPositionStays: true);
				iOEntity2.Spawn();
				iOEntity.outputs[0].connectedTo.Set(iOEntity2);
				iOEntity2.inputs[0].connectedTo.Set(iOEntity);
				iOEntity = iOEntity2;
			}
			microphoneStand.ioEntity.Get(serverside: true).MarkDirtyForceUpdateOutputs();
		}
	}

	protected override void OnChildAdded(BaseEntity child)
	{
		base.OnChildAdded(child);
		if (base.isServer && Rust.Application.isLoadingSave && child is RHIB rHIB)
		{
			Vector3 localPosition = rHIB.transform.localPosition;
			Vector3 b = base.transform.InverseTransformPoint(escapeBoatPoint.transform.position);
			if (Vector3.Distance(localPosition, b) < 1f)
			{
				rHIB.SetToKinematic();
			}
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.simpleUint = Pool.Get<SimpleUInt>();
		info.msg.simpleUint.value = layoutChoice;
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		RefreshActiveLayout();
	}

	public void PlayHorn()
	{
		ClientRPC(null, "DoHornSound");
		hornCount++;
		if (hornCount >= 3)
		{
			hornCount = 0;
			CancelInvoke(PlayHorn);
		}
	}

	public override void Spawn()
	{
		if (!Rust.Application.isLoadingSave)
		{
			layoutChoice = (uint)UnityEngine.Random.Range(0, layouts.Length);
			SendNetworkUpdate();
			RefreshActiveLayout();
		}
		base.Spawn();
	}

	public override void ServerInit()
	{
		base.ServerInit();
		Invoke(FindInitialNode, 2f);
		InvokeRepeating(BuildingCheck, 1f, 5f);
		InvokeRepeating(RespawnLoot, 10f, 60f * loot_round_spacing_minutes);
		Invoke(DisableCollisionTest, 10f);
		float height = TerrainMeta.WaterMap.GetHeight(base.transform.position);
		Vector3 vector = base.transform.InverseTransformPoint(waterLine.transform.position);
		base.transform.position = new Vector3(base.transform.position.x, height - vector.y, base.transform.position.z);
		SpawnSubEntities();
		Invoke(StartEgress, 60f * event_duration_minutes);
		CreateMapMarker();
	}

	public void UpdateRadiation()
	{
		currentRadiation += 1f;
		TriggerRadiation[] componentsInChildren = radiation.GetComponentsInChildren<TriggerRadiation>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].RadiationAmountOverride = currentRadiation;
		}
	}

	public void StartEgress()
	{
		if (!egressing && Interface.CallHook("OnCargoShipEgress", this) == null)
		{
			egressing = true;
			CancelInvoke(PlayHorn);
			radiation.SetActive(value: true);
			SetFlag(Flags.Reserved8, b: true);
			InvokeRepeating(UpdateRadiation, 10f, 1f);
			Invoke(DelayedDestroy, 60f * egress_duration_minutes);
		}
	}

	public void DelayedDestroy()
	{
		Kill();
	}

	public void FindInitialNode()
	{
		targetNodeIndex = GetClosestNodeToUs();
	}

	public void BuildingCheck()
	{
		List<DecayEntity> obj = Pool.GetList<DecayEntity>();
		Vis.Entities(WorldSpaceBounds(), obj, 2097152);
		foreach (DecayEntity item in obj)
		{
			if (item.isServer && item.IsAlive())
			{
				item.Kill(DestroyMode.Gib);
			}
		}
		Pool.FreeList(ref obj);
	}

	public void FixedUpdate()
	{
		if (!base.isClient)
		{
			UpdateMovement();
		}
	}

	public void UpdateMovement()
	{
		if (TerrainMeta.Path.OceanPatrolFar == null || TerrainMeta.Path.OceanPatrolFar.Count == 0 || targetNodeIndex == -1)
		{
			return;
		}
		Vector3 vector = TerrainMeta.Path.OceanPatrolFar[targetNodeIndex];
		if (egressing)
		{
			vector = base.transform.position + (base.transform.position - Vector3.zero).normalized * 10000f;
		}
		float num = 0f;
		Vector3 normalized = (vector - base.transform.position).normalized;
		float value = Vector3.Dot(base.transform.forward, normalized);
		num = Mathf.InverseLerp(0f, 1f, value);
		float num2 = Vector3.Dot(base.transform.right, normalized);
		float num3 = 2.5f;
		float b = Mathf.InverseLerp(0.05f, 0.5f, Mathf.Abs(num2));
		turnScale = Mathf.Lerp(turnScale, b, Time.deltaTime * 0.2f);
		float num4 = ((!(num2 < 0f)) ? 1 : (-1));
		currentTurnSpeed = num3 * turnScale * num4;
		base.transform.Rotate(Vector3.up, Time.deltaTime * currentTurnSpeed, Space.World);
		currentThrottle = Mathf.Lerp(currentThrottle, num, Time.deltaTime * 0.2f);
		currentVelocity = base.transform.forward * (8f * currentThrottle);
		base.transform.position += currentVelocity * Time.deltaTime;
		if (Vector3.Distance(base.transform.position, vector) < 80f)
		{
			targetNodeIndex++;
			if (targetNodeIndex >= TerrainMeta.Path.OceanPatrolFar.Count)
			{
				targetNodeIndex = 0;
			}
		}
	}

	public int GetClosestNodeToUs()
	{
		int result = 0;
		float num = float.PositiveInfinity;
		for (int i = 0; i < TerrainMeta.Path.OceanPatrolFar.Count; i++)
		{
			Vector3 b = TerrainMeta.Path.OceanPatrolFar[i];
			float num2 = Vector3.Distance(base.transform.position, b);
			if (num2 < num)
			{
				result = i;
				num = num2;
			}
		}
		return result;
	}

	public override Vector3 GetLocalVelocityServer()
	{
		return currentVelocity;
	}

	public override Quaternion GetAngularVelocityServer()
	{
		return Quaternion.Euler(0f, currentTurnSpeed, 0f);
	}

	public override float InheritedVelocityScale()
	{
		return 1f;
	}

	public override bool BlocksWaterFor(BasePlayer player)
	{
		return true;
	}

	public override bool SupportsChildDeployables()
	{
		return true;
	}

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("CargoShip.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}
}
