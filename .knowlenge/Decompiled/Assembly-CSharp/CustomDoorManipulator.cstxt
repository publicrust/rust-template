#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class CustomDoorManipulator : DoorManipulator
{
	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("CustomDoorManipulator.OnRpcMessage"))
		{
			if (rpc == 1224330484 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - DoPair "));
				}
				using (TimeWarning.New("DoPair"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(1224330484u, "DoPair", this, player, 3f))
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
							DoPair(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in DoPair");
					}
				}
				return true;
			}
			if (rpc == 3800726972u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - ServerActionChange "));
				}
				using (TimeWarning.New("ServerActionChange"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(3800726972u, "ServerActionChange", this, player, 3f))
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
							RPCMessage msg3 = rPCMessage;
							ServerActionChange(msg3);
						}
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
						player.Kick("RPC Error in ServerActionChange");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override bool PairWithLockedDoors()
	{
		return false;
	}

	public bool CanPlayerAdmin(BasePlayer player)
	{
		if (player != null && player.CanBuild())
		{
			return !IsOn();
		}
		return false;
	}

	public bool IsPaired()
	{
		return targetDoor != null;
	}

	public void RefreshDoor()
	{
		SetTargetDoor(targetDoor);
	}

	private void OnPhysicsNeighbourChanged()
	{
		SetTargetDoor(targetDoor);
		Invoke(RefreshDoor, 0.1f);
	}

	public override void SetupInitialDoorConnection()
	{
		if (entityRef.IsValid(serverside: true) && targetDoor == null)
		{
			SetTargetDoor(entityRef.Get(serverside: true).GetComponent<Door>());
		}
	}

	public override void DoActionDoorMissing()
	{
		SetTargetDoor(null);
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void DoPair(RPCMessage msg)
	{
		Door door = targetDoor;
		Door door2 = FindDoor(PairWithLockedDoors());
		if (door2 != door)
		{
			SetTargetDoor(door2);
		}
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void ServerActionChange(RPCMessage msg)
	{
	}
}
