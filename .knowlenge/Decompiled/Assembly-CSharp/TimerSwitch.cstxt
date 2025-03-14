#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class TimerSwitch : IOEntity
{
	public float timerLength = 10f;

	public Transform timerDrum;

	private float timePassed = -1f;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("TimerSwitch.OnRpcMessage"))
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

	public override void ResetIOState()
	{
		base.ResetIOState();
		SetFlag(Flags.On, b: false);
		if (IsInvoking(AdvanceTime))
		{
			EndTimer();
		}
	}

	public override bool WantsPassthroughPower()
	{
		if (IsPowered())
		{
			return IsOn();
		}
		return false;
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		if (!IsPowered() || !IsOn())
		{
			return 0;
		}
		return base.GetPassthroughAmount();
	}

	public override void UpdateHasPower(int inputAmount, int inputSlot)
	{
		if (inputSlot == 0)
		{
			SetFlag(Flags.Reserved8, inputAmount > 0, recursive: false, networkupdate: false);
		}
	}

	public override void UpdateFromInput(int inputAmount, int inputSlot)
	{
		switch (inputSlot)
		{
		case 0:
			base.UpdateFromInput(inputAmount, inputSlot);
			if (!IsPowered() && IsInvoking(AdvanceTime))
			{
				EndTimer();
			}
			else if (timePassed != -1f)
			{
				SetFlag(Flags.On, b: false, recursive: false, networkupdate: false);
				SwitchPressed();
			}
			break;
		case 1:
			if (inputAmount > 0)
			{
				SwitchPressed();
			}
			break;
		}
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void SVSwitch(RPCMessage msg)
	{
		SwitchPressed();
	}

	public void SwitchPressed()
	{
		if (!IsOn() && IsPowered())
		{
			SetFlag(Flags.On, b: true);
			MarkDirty();
			InvokeRepeating(AdvanceTime, 0f, 0.1f);
			SendNetworkUpdateImmediate();
		}
	}

	public void AdvanceTime()
	{
		if (timePassed < 0f)
		{
			timePassed = 0f;
		}
		timePassed += 0.1f;
		if (timePassed >= timerLength)
		{
			EndTimer();
		}
		else
		{
			SendNetworkUpdate();
		}
	}

	public void EndTimer()
	{
		CancelInvoke(AdvanceTime);
		timePassed = -1f;
		SetFlag(Flags.On, b: false);
		SendNetworkUpdateImmediate();
		MarkDirty();
	}

	public float GetPassedTime()
	{
		return timePassed;
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		if (timePassed == -1f)
		{
			if (IsOn())
			{
				SetFlag(Flags.On, b: false);
			}
		}
		else
		{
			SwitchPressed();
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.ioEntity.genericFloat1 = GetPassedTime();
		info.msg.ioEntity.genericFloat2 = timerLength;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.ioEntity != null)
		{
			timerLength = info.msg.ioEntity.genericFloat2;
			timePassed = info.msg.ioEntity.genericFloat1;
		}
	}
}
