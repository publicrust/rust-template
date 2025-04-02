using System;
using ConVar;
using Network;
using Rust;
using UnityEngine;
using UnityEngine.Assertions;

public class StrobeLight : IOEntity
{
	public float frequency;

	public MeshRenderer lightMesh;

	public Light strobeLight;

	private float speedSlow = 10f;

	private float speedMed = 20f;

	private float speedFast = 40f;

	public float burnRate = 10f;

	public float lifeTimeSeconds = 21600f;

	public const Flags Flag_Slow = Flags.Reserved6;

	public const Flags Flag_Med = Flags.Reserved7;

	public const Flags Flag_Fast = Flags.Reserved8;

	private int currentSpeed = 1;

	public float GetFrequency()
	{
		if (HasFlag(Flags.Reserved6))
		{
			return speedSlow;
		}
		if (HasFlag(Flags.Reserved7))
		{
			return speedMed;
		}
		if (HasFlag(Flags.Reserved8))
		{
			return speedFast;
		}
		return speedSlow;
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void SetStrobe(RPCMessage msg)
	{
		bool strobe = msg.read.Bit();
		SetStrobe(strobe);
	}

	private void SetStrobe(bool wantsOn)
	{
		ServerEnableStrobing(wantsOn);
		if (wantsOn)
		{
			UpdateSpeedFlags();
		}
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void SetStrobeSpeed(RPCMessage msg)
	{
		int num = msg.read.Int32();
		currentSpeed = num;
		UpdateSpeedFlags();
	}

	public void UpdateSpeedFlags()
	{
		SetFlag(Flags.Reserved6, currentSpeed == 1);
		SetFlag(Flags.Reserved7, currentSpeed == 2);
		SetFlag(Flags.Reserved8, currentSpeed == 3);
	}

	public void ServerEnableStrobing(bool wantsOn)
	{
		SetFlag(Flags.Reserved6, b: false);
		SetFlag(Flags.Reserved7, b: false);
		SetFlag(Flags.Reserved8, b: false);
		SetFlag(Flags.On, wantsOn);
		SendNetworkUpdateImmediate();
		UpdateSpeedFlags();
		if (wantsOn)
		{
			((FacepunchBehaviour)this).InvokeRandomized((Action)SelfDamage, 0f, 10f, 0.1f);
		}
		else
		{
			((FacepunchBehaviour)this).CancelInvoke((Action)SelfDamage);
		}
	}

	public void SelfDamage()
	{
		float num = burnRate / lifeTimeSeconds;
		Hurt(num * MaxHealth(), DamageType.Decay, this, useProtection: false);
	}

	public override void UpdateHasPower(int inputAmount, int inputSlot)
	{
		base.UpdateHasPower(inputAmount, inputSlot);
		bool strobe = false;
		switch (inputSlot)
		{
		case 0:
			strobe = inputAmount > 0;
			break;
		case 1:
			if (inputAmount == 0)
			{
				return;
			}
			strobe = true;
			break;
		case 2:
			if (inputAmount == 0)
			{
				return;
			}
			strobe = false;
			break;
		}
		SetStrobe(strobe);
	}

	public override int ConsumptionAmount()
	{
		return 0;
	}

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		TimeWarning val = TimeWarning.New("StrobeLight.OnRpcMessage", 0);
		try
		{
			if (rpc == 1433326740 && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - SetStrobe "));
				}
				TimeWarning val2 = TimeWarning.New("SetStrobe", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Conditions", 0);
					try
					{
						if (!RPC_Server.IsVisible.Test(1433326740u, "SetStrobe", this, player, 3f))
						{
							return true;
						}
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
					try
					{
						val3 = TimeWarning.New("Call", 0);
						try
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage strobe = rPCMessage;
							SetStrobe(strobe);
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
					}
					catch (Exception ex)
					{
						Debug.LogException(ex);
						player.Kick("RPC Error in SetStrobe");
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				return true;
			}
			if (rpc == 1814332702 && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - SetStrobeSpeed "));
				}
				TimeWarning val2 = TimeWarning.New("SetStrobeSpeed", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Conditions", 0);
					try
					{
						if (!RPC_Server.IsVisible.Test(1814332702u, "SetStrobeSpeed", this, player, 3f))
						{
							return true;
						}
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
					try
					{
						val3 = TimeWarning.New("Call", 0);
						try
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage strobeSpeed = rPCMessage;
							SetStrobeSpeed(strobeSpeed);
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
					}
					catch (Exception ex2)
					{
						Debug.LogException(ex2);
						player.Kick("RPC Error in SetStrobeSpeed");
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				return true;
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return base.OnRpcMessage(player, rpc, msg);
	}
}
