#define UNITY_ASSERTIONS
using System;
using ConVar;
using Facepunch;
using Network;
using ProtoBuf;
using Rust;
using UnityEngine;
using UnityEngine.Assertions;

public class TreeManager : BaseEntity
{
	public static ListHashSet<BaseEntity> entities = new ListHashSet<BaseEntity>();

	public static TreeManager server;

	private const int maxTreesPerPacket = 100;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("TreeManager.OnRpcMessage"))
		{
			if (rpc == 1907121457 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (ConVar.Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - SERVER_RequestTrees "));
				}
				using (TimeWarning.New("SERVER_RequestTrees"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.CallsPerSecond.Test(1907121457u, "SERVER_RequestTrees", this, player, 0uL))
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
							SERVER_RequestTrees(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in SERVER_RequestTrees");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public static Vector3 ProtoHalf3ToVec3(ProtoBuf.Half3 half3)
	{
		Vector3 result = default(Vector3);
		result.x = Mathf.HalfToFloat((ushort)half3.x);
		result.y = Mathf.HalfToFloat((ushort)half3.y);
		result.z = Mathf.HalfToFloat((ushort)half3.z);
		return result;
	}

	public static ProtoBuf.Half3 Vec3ToProtoHalf3(Vector3 vec3)
	{
		ProtoBuf.Half3 result = default(ProtoBuf.Half3);
		result.x = Mathf.FloatToHalf(vec3.x);
		result.y = Mathf.FloatToHalf(vec3.y);
		result.z = Mathf.FloatToHalf(vec3.z);
		return result;
	}

	public override void ServerInit()
	{
		base.ServerInit();
		server = this;
	}

	public static void OnTreeDestroyed(BaseEntity billboardEntity)
	{
		entities.Remove(billboardEntity);
		if (!Rust.Application.isLoading && !Rust.Application.isQuitting)
		{
			server.ClientRPC(null, "CLIENT_TreeDestroyed", billboardEntity.net.ID);
		}
	}

	public static void OnTreeSpawned(BaseEntity billboardEntity)
	{
		entities.Add(billboardEntity);
		if (Rust.Application.isLoading || Rust.Application.isQuitting)
		{
			return;
		}
		using ProtoBuf.Tree tree = Facepunch.Pool.Get<ProtoBuf.Tree>();
		ExtractTreeNetworkData(billboardEntity, tree);
		server.ClientRPC(null, "CLIENT_TreeSpawned", tree);
	}

	private static void ExtractTreeNetworkData(BaseEntity billboardEntity, ProtoBuf.Tree tree)
	{
		tree.netId = billboardEntity.net.ID;
		tree.prefabId = billboardEntity.prefabID;
		tree.position = Vec3ToProtoHalf3(billboardEntity.transform.position);
		tree.scale = billboardEntity.transform.lossyScale.y;
	}

	public static void SendSnapshot(BasePlayer player)
	{
		BufferList<BaseEntity> values = entities.Values;
		TreeList treeList = null;
		for (int i = 0; i < values.Count; i++)
		{
			BaseEntity billboardEntity = values[i];
			ProtoBuf.Tree tree = Facepunch.Pool.Get<ProtoBuf.Tree>();
			ExtractTreeNetworkData(billboardEntity, tree);
			if (treeList == null)
			{
				treeList = Facepunch.Pool.Get<TreeList>();
				treeList.trees = Facepunch.Pool.GetList<ProtoBuf.Tree>();
			}
			treeList.trees.Add(tree);
			if (treeList.trees.Count >= 100)
			{
				server.ClientRPCPlayer(null, player, "CLIENT_ReceiveTrees", treeList);
				treeList.Dispose();
				treeList = null;
			}
		}
		if (treeList != null)
		{
			server.ClientRPCPlayer(null, player, "CLIENT_ReceiveTrees", treeList);
			treeList.Dispose();
			treeList = null;
		}
	}

	[RPC_Server]
	[RPC_Server.CallsPerSecond(0uL)]
	private void SERVER_RequestTrees(RPCMessage msg)
	{
		SendSnapshot(msg.player);
	}
}
