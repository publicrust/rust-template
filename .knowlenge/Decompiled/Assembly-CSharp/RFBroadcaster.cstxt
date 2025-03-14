#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using Oxide.Core;
using UnityEngine;
using UnityEngine.Assertions;

public class RFBroadcaster : IOEntity, IRFObject
{
	public int frequency;

	public GameObjectRef frequencyPanelPrefab;

	public const Flags Flag_Broadcasting = Flags.Reserved3;

	public bool playerUsable = true;

	private float nextChangeTime;

	private float nextStopTime;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("RFBroadcaster.OnRpcMessage"))
		{
			if (rpc == 2778616053u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - ServerSetFrequency "));
				}
				using (TimeWarning.New("ServerSetFrequency"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(2778616053u, "ServerSetFrequency", this, player, 3f))
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
							ServerSetFrequency(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in ServerSetFrequency");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public int GetFrequency()
	{
		return frequency;
	}

	public override bool WantsPower()
	{
		return true;
	}

	public Vector3 GetPosition()
	{
		return base.transform.position;
	}

	public float GetMaxRange()
	{
		return 100000f;
	}

	public void RFSignalUpdate(bool on)
	{
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void ServerSetFrequency(RPCMessage msg)
	{
		if (!(msg.player == null) && msg.player.CanBuild() && playerUsable && !(UnityEngine.Time.time < nextChangeTime))
		{
			nextChangeTime = UnityEngine.Time.time + 2f;
			int num = msg.read.Int32();
			if (RFManager.IsReserved(num))
			{
				RFManager.ReserveErrorPrint(msg.player);
			}
			else if (Interface.CallHook("OnRfFrequencyChange", this, num, msg.player) == null)
			{
				RFManager.ChangeFrequency(frequency, num, this, isListener: false, IsPowered());
				frequency = num;
				MarkDirty();
				SendNetworkUpdate();
				Interface.CallHook("OnRfFrequencyChanged", this, num, msg.player);
			}
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.ioEntity.genericInt1 = frequency;
	}

	public override void IOStateChanged(int inputAmount, int inputSlot)
	{
		if (inputAmount > 0)
		{
			CancelInvoke(StopBroadcasting);
			RFManager.AddBroadcaster(frequency, this);
			SetFlag(Flags.Reserved3, b: true);
			nextStopTime = UnityEngine.Time.time + 1f;
		}
		else
		{
			Invoke(StopBroadcasting, Mathf.Clamp01(nextStopTime - UnityEngine.Time.time));
		}
	}

	public void StopBroadcasting()
	{
		SetFlag(Flags.Reserved3, b: false);
		RFManager.RemoveBroadcaster(frequency, this);
	}

	internal override void DoServerDestroy()
	{
		RFManager.RemoveBroadcaster(frequency, this);
		base.DoServerDestroy();
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.ioEntity != null)
		{
			frequency = info.msg.ioEntity.genericInt1;
		}
	}
}
