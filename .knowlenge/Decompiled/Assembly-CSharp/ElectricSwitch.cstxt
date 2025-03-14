#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using Oxide.Core;
using UnityEngine;
using UnityEngine.Assertions;

public class ElectricSwitch : IOEntity
{
	public bool isToggleSwitch;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("ElectricSwitch.OnRpcMessage"))
		{
			if (rpc == 4167839872u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - SVSwitch "));
				}
				using (TimeWarning.New("SVSwitch"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(4167839872u, "SVSwitch", this, player, 3f))
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
							SVSwitch(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in SVSwitch");
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

	public override void ServerInit()
	{
		base.ServerInit();
		SetFlag(Flags.Busy, b: false);
	}

	public virtual void SetSwitch(bool wantsOn)
	{
		if (wantsOn != IsOn())
		{
			SetFlag(Flags.On, wantsOn);
			SetFlag(Flags.Busy, b: true);
			Invoke(Unbusy, 0.5f);
			SendNetworkUpdateImmediate();
			MarkDirty();
		}
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void SVSwitch(RPCMessage msg)
	{
		if (Interface.CallHook("OnSwitchToggle", this, msg.player) == null)
		{
			SetSwitch(!IsOn());
			Interface.CallHook("OnSwitchToggled", this, msg.player);
		}
	}

	public void Unbusy()
	{
		SetFlag(Flags.Busy, b: false);
	}
}
