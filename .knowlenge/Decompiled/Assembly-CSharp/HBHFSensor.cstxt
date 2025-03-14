#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using Oxide.Core;
using UnityEngine;
using UnityEngine.Assertions;

public class HBHFSensor : BaseDetector
{
	public GameObjectRef detectUp;

	public GameObjectRef detectDown;

	public const Flags Flag_IncludeOthers = Flags.Reserved2;

	public const Flags Flag_IncludeAuthed = Flags.Reserved3;

	private int detectedPlayers;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("HBHFSensor.OnRpcMessage"))
		{
			if (rpc == 3206885720u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - SetIncludeAuth "));
				}
				using (TimeWarning.New("SetIncludeAuth"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(3206885720u, "SetIncludeAuth", this, player, 3f))
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
							RPCMessage includeAuth = rPCMessage;
							SetIncludeAuth(includeAuth);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in SetIncludeAuth");
					}
				}
				return true;
			}
			if (rpc == 2223203375u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - SetIncludeOthers "));
				}
				using (TimeWarning.New("SetIncludeOthers"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(2223203375u, "SetIncludeOthers", this, player, 3f))
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
							RPCMessage includeOthers = rPCMessage;
							SetIncludeOthers(includeOthers);
						}
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
						player.Kick("RPC Error in SetIncludeOthers");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		return Mathf.Min(detectedPlayers, GetCurrentEnergy());
	}

	public override void OnObjects()
	{
		base.OnObjects();
		UpdatePassthroughAmount();
		InvokeRandomized(UpdatePassthroughAmount, 0f, 1f, 0.1f);
	}

	public override void OnEmpty()
	{
		base.OnEmpty();
		UpdatePassthroughAmount();
		CancelInvoke(UpdatePassthroughAmount);
	}

	public void UpdatePassthroughAmount()
	{
		if (base.isClient)
		{
			return;
		}
		int num = detectedPlayers;
		detectedPlayers = 0;
		if (myTrigger.entityContents != null)
		{
			foreach (BaseEntity entityContent in myTrigger.entityContents)
			{
				if (entityContent == null || !entityContent.IsVisible(base.transform.position + base.transform.forward * 0.1f, 10f))
				{
					continue;
				}
				BasePlayer component = entityContent.GetComponent<BasePlayer>();
				if (Interface.CallHook("OnSensorDetect", this, component) == null)
				{
					bool flag = component.CanBuild();
					if ((!flag || ShouldIncludeAuthorized()) && (flag || ShouldIncludeOthers()) && component != null && component.IsAlive() && !component.IsSleeping() && component.isServer)
					{
						detectedPlayers++;
					}
				}
			}
		}
		if (num != detectedPlayers && IsPowered())
		{
			MarkDirty();
			if (detectedPlayers > num)
			{
				Effect.server.Run(detectUp.resourcePath, base.transform.position, Vector3.up);
			}
			else if (detectedPlayers < num)
			{
				Effect.server.Run(detectDown.resourcePath, base.transform.position, Vector3.up);
			}
		}
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void SetIncludeAuth(RPCMessage msg)
	{
		bool b = msg.read.Bit();
		if (msg.player.CanBuild() && IsPowered())
		{
			SetFlag(Flags.Reserved3, b);
		}
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void SetIncludeOthers(RPCMessage msg)
	{
		bool b = msg.read.Bit();
		if (msg.player.CanBuild() && IsPowered())
		{
			SetFlag(Flags.Reserved2, b);
		}
	}

	public bool ShouldIncludeAuthorized()
	{
		return HasFlag(Flags.Reserved3);
	}

	public bool ShouldIncludeOthers()
	{
		return HasFlag(Flags.Reserved2);
	}
}
