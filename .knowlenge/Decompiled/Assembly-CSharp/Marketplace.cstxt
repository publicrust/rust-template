using System;
using System.Collections.Generic;
using Facepunch;
using ProtoBuf;
using Rust;
using UnityEngine;

public class Marketplace : BaseEntity
{
	[Header("Marketplace")]
	public GameObjectRef terminalPrefab;

	public Transform[] terminalPoints;

	public Transform droneLaunchPoint;

	public GameObjectRef deliveryDronePrefab;

	[NonSerialized]
	public EntityRef<MarketTerminal>[] terminalEntities;

	public NetworkableId SendDrone(BasePlayer player, MarketTerminal sourceTerminal, VendingMachine vendingMachine)
	{
		if (sourceTerminal == null || vendingMachine == null)
		{
			return default(NetworkableId);
		}
		BaseEntity baseEntity = GameManager.server.CreateEntity(deliveryDronePrefab?.resourcePath, droneLaunchPoint.position, droneLaunchPoint.rotation);
		if (!(baseEntity is DeliveryDrone deliveryDrone))
		{
			baseEntity.Kill();
			return default(NetworkableId);
		}
		deliveryDrone.OwnerID = player.userID;
		deliveryDrone.Spawn();
		deliveryDrone.Setup(this, sourceTerminal, vendingMachine);
		return deliveryDrone.net.ID;
	}

	public void ReturnDrone(DeliveryDrone deliveryDrone)
	{
		if (deliveryDrone.sourceTerminal.TryGet(serverside: true, out var entity))
		{
			entity.CompleteOrder(deliveryDrone.targetVendingMachine.uid);
		}
		deliveryDrone.Kill();
	}

	public override void Spawn()
	{
		base.Spawn();
		if (!Rust.Application.isLoadingSave)
		{
			SpawnSubEntities();
		}
	}

	private void SpawnSubEntities()
	{
		if (!base.isServer)
		{
			return;
		}
		if (terminalEntities != null && terminalEntities.Length > terminalPoints.Length)
		{
			for (int i = terminalPoints.Length; i < terminalEntities.Length; i++)
			{
				if (terminalEntities[i].TryGet(serverside: true, out var entity))
				{
					entity.Kill();
				}
			}
		}
		Array.Resize(ref terminalEntities, terminalPoints.Length);
		for (int j = 0; j < terminalPoints.Length; j++)
		{
			Transform transform = terminalPoints[j];
			if (!terminalEntities[j].TryGet(serverside: true, out var _))
			{
				BaseEntity baseEntity = GameManager.server.CreateEntity(terminalPrefab?.resourcePath, transform.position, transform.rotation);
				baseEntity.SetParent(this, worldPositionStays: true);
				baseEntity.Spawn();
				if (!(baseEntity is MarketTerminal marketTerminal))
				{
					Debug.LogError("Marketplace.terminalPrefab did not spawn a MarketTerminal (it spawned " + baseEntity.GetType().FullName + ")");
					baseEntity.Kill();
				}
				else
				{
					marketTerminal.Setup(this);
					terminalEntities[j].Set(marketTerminal);
				}
			}
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.subEntityList != null)
		{
			List<NetworkableId> subEntityIds = info.msg.subEntityList.subEntityIds;
			Array.Resize(ref terminalEntities, subEntityIds.Count);
			for (int i = 0; i < subEntityIds.Count; i++)
			{
				terminalEntities[i] = new EntityRef<MarketTerminal>(subEntityIds[i]);
			}
		}
		SpawnSubEntities();
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.subEntityList = Pool.Get<SubEntityList>();
		info.msg.subEntityList.subEntityIds = Pool.Get<List<NetworkableId>>();
		if (terminalEntities != null)
		{
			for (int i = 0; i < terminalEntities.Length; i++)
			{
				info.msg.subEntityList.subEntityIds.Add(terminalEntities[i].uid);
			}
		}
	}
}
