#define UNITY_ASSERTIONS
using System;
using ConVar;
using Facepunch.Rust;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class FreeableLootContainer : LootContainer
{
	private const Flags tiedDown = Flags.Reserved8;

	public Buoyancy buoyancy;

	public GameObjectRef freedEffect;

	private Rigidbody rb;

	public uint skinOverride;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("FreeableLootContainer.OnRpcMessage"))
		{
			if (rpc == 2202685945u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - RPC_FreeCrate "));
				}
				using (TimeWarning.New("RPC_FreeCrate"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.MaxDistance.Test(2202685945u, "RPC_FreeCrate", this, player, 3f))
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
							RPC_FreeCrate(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in RPC_FreeCrate");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public Rigidbody GetRB()
	{
		if (rb == null)
		{
			rb = GetComponent<Rigidbody>();
		}
		return rb;
	}

	public bool IsTiedDown()
	{
		return HasFlag(Flags.Reserved8);
	}

	public override void ServerInit()
	{
		GetRB().isKinematic = true;
		buoyancy.buoyancyScale = 0f;
		buoyancy.enabled = false;
		base.ServerInit();
		if (skinOverride != 0)
		{
			skinID = skinOverride;
			SendNetworkUpdate();
		}
	}

	[RPC_Server]
	[RPC_Server.MaxDistance(3f)]
	public void RPC_FreeCrate(RPCMessage msg)
	{
		if (IsTiedDown())
		{
			GetRB().isKinematic = false;
			buoyancy.enabled = true;
			buoyancy.buoyancyScale = 1f;
			SetFlag(Flags.Reserved8, b: false);
			if (freedEffect.isValid)
			{
				Effect.server.Run(freedEffect.resourcePath, base.transform.position, Vector3.up);
			}
			BasePlayer player = msg.player;
			if ((bool)player)
			{
				player.ProcessMissionEvent(BaseMission.MissionEventType.FREE_CRATE, "", 1f);
				Analytics.Server.FreeUnderwaterCrate();
				Analytics.Azure.OnFreeUnderwaterCrate(msg.player, this);
			}
		}
	}
}
