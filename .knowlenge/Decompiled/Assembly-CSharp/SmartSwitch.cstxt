#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using ProtoBuf;
using UnityEngine;
using UnityEngine.Assertions;

public class SmartSwitch : AppIOEntity
{
	[Header("Smart Switch")]
	public Animator ReceiverAnimator;

	public override AppEntityType Type => AppEntityType.Switch;

	public override bool Value
	{
		get
		{
			return IsOn();
		}
		set
		{
			SetSwitch(value);
		}
	}

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("SmartSwitch.OnRpcMessage"))
		{
			if (rpc == 2810053005u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - ToggleSwitch "));
				}
				using (TimeWarning.New("ToggleSwitch"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.CallsPerSecond.Test(2810053005u, "ToggleSwitch", this, player, 3uL))
						{
							return true;
						}
						if (!RPC_Server.IsVisible.Test(2810053005u, "ToggleSwitch", this, player, 3f))
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
							ToggleSwitch(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in ToggleSwitch");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override bool WantsPower()
	{
		return IsOn();
	}

	public override void ServerInit()
	{
		base.ServerInit();
		SetFlag(Flags.Busy, b: false);
	}

	public override int ConsumptionAmount()
	{
		if (!IsOn())
		{
			return 0;
		}
		return 1;
	}

	public override void ResetIOState()
	{
		SetFlag(Flags.On, b: false);
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		if (!IsOn())
		{
			return 0;
		}
		return GetCurrentEnergy();
	}

	public override void IOStateChanged(int inputAmount, int inputSlot)
	{
		if (inputSlot == 1 && inputAmount > 0)
		{
			SetSwitch(wantsOn: true);
		}
		if (inputSlot == 2 && inputAmount > 0)
		{
			SetSwitch(wantsOn: false);
		}
		base.IOStateChanged(inputAmount, inputSlot);
	}

	public void SetSwitch(bool wantsOn)
	{
		if (wantsOn != IsOn())
		{
			SetFlag(Flags.On, wantsOn);
			SetFlag(Flags.Busy, b: true);
			Invoke(Unbusy, 0.5f);
			SendNetworkUpdateImmediate();
			MarkDirty();
			BroadcastValueChange();
		}
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	[RPC_Server.CallsPerSecond(3uL)]
	public void ToggleSwitch(RPCMessage msg)
	{
		if (PlayerCanToggle(msg.player))
		{
			SetSwitch(!IsOn());
		}
	}

	public void Unbusy()
	{
		SetFlag(Flags.Busy, b: false);
	}

	private static bool PlayerCanToggle(BasePlayer player)
	{
		if (player != null)
		{
			return player.CanBuild();
		}
		return false;
	}
}
