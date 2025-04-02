using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ConVar;
using Facepunch;
using Network;
using ProtoBuf;
using Rust;
using UnityEngine;

public class GlobalNetworkHandler : PointEntity
{
	public static GlobalNetworkHandler server;

	[NonSerialized]
	public Dictionary<NetworkableId, GlobalEntityData> serverData = new Dictionary<NetworkableId, GlobalEntityData>();

	private List<Connection> globalConnections = new List<Connection>();

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("GlobalNetworkHandler.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public static bool ShouldSendEntity(BaseEntity entity)
	{
		if (entity == null || entity.IsDestroyed)
		{
			return false;
		}
		if (entity.HasParent())
		{
			return false;
		}
		if (entity.net != null && entity.net.group != null && entity.net.group.restricted)
		{
			return false;
		}
		if (entity.globalBuildingBlock)
		{
			return true;
		}
		return false;
	}

	public override void ServerInit()
	{
		server = this;
		base.ServerInit();
		if (!Rust.Application.isLoadingSave)
		{
			LoadEntitiesOnStartup();
		}
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		LoadEntitiesOnStartup();
	}

	public void OnClientConnected(Connection connection)
	{
		if (connection.globalNetworking)
		{
			globalConnections.Add(connection);
		}
	}

	public void OnClientDisconnected(Connection connection)
	{
		globalConnections.Remove(connection);
	}

	private void LoadEntitiesOnStartup()
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		UnityEngine.Debug.Log("Starting to load entities into GlobalNetworkHandler...");
		foreach (BaseEntity item in BaseNetworkable.serverEntities.OfType<BaseEntity>())
		{
			if (ShouldSendEntity(item))
			{
				OnEntityUpdate(item, sendNetworkUpdate: false);
			}
		}
		UnityEngine.Debug.Log($"Took {stopwatch.ElapsedMilliseconds}ms to load entities into GlobalNetworkHandler");
	}

	public void TrySendNetworkUpdate(BaseNetworkable net)
	{
		if (net is BaseEntity entity && ShouldSendEntity(entity))
		{
			OnEntityUpdate(entity);
		}
	}

	private void OnEntityUpdate(BaseEntity entity, bool sendNetworkUpdate = true)
	{
		if (entity.net != null)
		{
			GlobalEntityData globalEntityData = Facepunch.Pool.Get<GlobalEntityData>();
			globalEntityData.prefabId = entity.prefabID;
			globalEntityData.uid = entity.net.ID;
			globalEntityData.pos = entity.transform.position;
			globalEntityData.rot = entity.transform.rotation.eulerAngles;
			if (entity is BuildingBlock buildingBlock)
			{
				globalEntityData.grade = (int)buildingBlock.grade;
				globalEntityData.modelState = buildingBlock.modelState;
				globalEntityData.skin = buildingBlock.skinID;
				globalEntityData.customColor = (int)buildingBlock.customColour;
			}
			if (entity is Door door)
			{
				globalEntityData.flags = (int)(door.flags & Flags.Open);
			}
			if (serverData.TryGetValue(entity.net.ID, out var value))
			{
				Facepunch.Pool.Free(ref value);
			}
			serverData[entity.net.ID] = globalEntityData;
			if (sendNetworkUpdate)
			{
				SendGlobalEntity(globalEntityData, new SendInfo(ConVar.Net.limit_global_update_broadcast ? globalConnections : Network.Net.sv.connections));
			}
		}
	}

	public void OnEntityKilled(BaseNetworkable entity)
	{
		if (serverData.Remove(entity.net.ID))
		{
			SendEntityDelete(entity.net.ID, new SendInfo(ConVar.Net.limit_global_update_broadcast ? globalConnections : Network.Net.sv.connections));
		}
	}

	public void StartSendingSnapshot(BasePlayer player)
	{
		OnClientConnected(player.Connection);
		if (!ConVar.Net.limit_global_update_broadcast || player.Connection.globalNetworking)
		{
			SendAsSnapshot(player.Connection);
			SendSnapshot(player);
		}
	}

	private void SendSnapshot(BasePlayer player)
	{
		if (!ConVar.Net.globalNetworkedBases)
		{
			return;
		}
		Stopwatch stopwatch = Stopwatch.StartNew();
		using (GlobalEntityCollection globalEntityCollection = Facepunch.Pool.Get<GlobalEntityCollection>())
		{
			globalEntityCollection.entities = Facepunch.Pool.Get<List<GlobalEntityData>>();
			foreach (GlobalEntityData value in serverData.Values)
			{
				globalEntityCollection.entities.Add(value);
				if (globalEntityCollection.entities.Count >= ConVar.Server.maxpacketsize_globalentities)
				{
					SendGlobalEntities(globalEntityCollection, new SendInfo(player.Connection));
					globalEntityCollection.entities.Clear();
				}
			}
			if (globalEntityCollection.entities.Count > 0)
			{
				SendGlobalEntities(globalEntityCollection, new SendInfo(player.Connection));
				globalEntityCollection.entities.Clear();
			}
		}
		stopwatch.Stop();
		if (ConVar.Net.global_network_debug)
		{
			UnityEngine.Debug.Log($"Took {stopwatch.ElapsedMilliseconds}ms to send {serverData.Count} global entities to {player.ToString()}");
		}
	}

	private void SendEntityDelete(NetworkableId networkableId, SendInfo info)
	{
		if (ConVar.Net.globalNetworkedBases)
		{
			NetWrite netWrite = ClientRPCStart("CLIENT_EntityDeletes");
			int num = Math.Min(ConVar.Server.maxpacketsize_globalentities, 1);
			netWrite.UInt16((ushort)num);
			for (int i = 0; i < num; i++)
			{
				netWrite.EntityID(networkableId);
			}
			ClientRPCSend(netWrite, info);
		}
	}

	private void SendGlobalEntities(GlobalEntityCollection entities, SendInfo info)
	{
		if (ConVar.Net.globalNetworkedBases)
		{
			ClientRPC(RpcTarget.SendInfo("CLIENT_EntityUpdates", info), entities);
		}
	}

	private void SendGlobalEntity(GlobalEntityData entity, SendInfo info)
	{
		if (!ConVar.Net.globalNetworkedBases)
		{
			return;
		}
		using GlobalEntityCollection globalEntityCollection = Facepunch.Pool.Get<GlobalEntityCollection>();
		globalEntityCollection.entities = Facepunch.Pool.Get<List<GlobalEntityData>>();
		globalEntityCollection.entities.Add(entity);
		SendGlobalEntities(globalEntityCollection, info);
		globalEntityCollection.entities.Clear();
	}
}
