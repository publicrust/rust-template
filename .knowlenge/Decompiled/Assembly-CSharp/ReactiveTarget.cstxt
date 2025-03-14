#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using Oxide.Core;
using Rust;
using UnityEngine;
using UnityEngine.Assertions;

public class ReactiveTarget : IOEntity
{
	public Animator myAnimator;

	public GameObjectRef bullseyeEffect;

	public GameObjectRef knockdownEffect;

	public float activationPowerTime = 0.5f;

	public int activationPowerAmount = 1;

	private float lastToggleTime = float.NegativeInfinity;

	public float knockdownHealth = 100f;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("ReactiveTarget.OnRpcMessage"))
		{
			if (rpc == 1798082523 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (ConVar.Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - RPC_Lower "));
				}
				using (TimeWarning.New("RPC_Lower"))
				{
					try
					{
						using (TimeWarning.New("Call"))
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg2 = rPCMessage;
							RPC_Lower(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in RPC_Lower");
					}
				}
				return true;
			}
			if (rpc == 2169477377u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (ConVar.Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - RPC_Reset "));
				}
				using (TimeWarning.New("RPC_Reset"))
				{
					try
					{
						using (TimeWarning.New("Call"))
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg3 = rPCMessage;
							RPC_Reset(msg3);
						}
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
						player.Kick("RPC Error in RPC_Reset");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public void OnHitShared(HitInfo info)
	{
		if (IsKnockedDown())
		{
			return;
		}
		bool num = info.HitBone == StringPool.Get("target_collider");
		bool flag = info.HitBone == StringPool.Get("target_collider_bullseye");
		if ((num || flag) && base.isServer)
		{
			float num2 = info.damageTypes.Total();
			if (flag)
			{
				num2 *= 2f;
				Effect.server.Run(bullseyeEffect.resourcePath, this, StringPool.Get("target_collider_bullseye"), Vector3.zero, Vector3.zero);
			}
			knockdownHealth -= num2;
			if (knockdownHealth <= 0f)
			{
				Effect.server.Run(knockdownEffect.resourcePath, this, StringPool.Get("target_collider_bullseye"), Vector3.zero, Vector3.zero);
				SetFlag(Flags.On, b: false);
				QueueReset();
				SendPowerBurst();
				SendNetworkUpdate();
			}
			else
			{
				ClientRPC(null, "HitEffect", info.Initiator.net.ID);
			}
			Hurt(1f, DamageType.Suicide, info.Initiator, useProtection: false);
		}
	}

	public bool IsKnockedDown()
	{
		return !HasFlag(Flags.On);
	}

	public override void OnAttacked(HitInfo info)
	{
		OnHitShared(info);
		base.OnAttacked(info);
	}

	public override bool CanPickup(BasePlayer player)
	{
		if (base.CanPickup(player))
		{
			return CanToggle();
		}
		return false;
	}

	public bool CanToggle()
	{
		return UnityEngine.Time.time > lastToggleTime + 1f;
	}

	public void QueueReset()
	{
		Invoke(ResetTarget, 6f);
	}

	public void ResetTarget()
	{
		if (IsKnockedDown() && CanToggle())
		{
			CancelInvoke(ResetTarget);
			SetFlag(Flags.On, b: true);
			knockdownHealth = 100f;
			SendPowerBurst();
			Interface.CallHook("OnReactiveTargetReset", this);
		}
	}

	private void LowerTarget()
	{
		if (!IsKnockedDown() && CanToggle())
		{
			SetFlag(Flags.On, b: false);
			SendPowerBurst();
		}
	}

	private void SendPowerBurst()
	{
		lastToggleTime = UnityEngine.Time.time;
		MarkDirtyForceUpdateOutputs();
		Invoke(base.MarkDirtyForceUpdateOutputs, activationPowerTime * 1.01f);
	}

	public override int ConsumptionAmount()
	{
		return 1;
	}

	public override bool IsRootEntity()
	{
		return true;
	}

	public override void UpdateFromInput(int inputAmount, int inputSlot)
	{
		if (inputSlot == 0)
		{
			base.UpdateFromInput(inputAmount, inputSlot);
		}
		else if (inputAmount > 0)
		{
			switch (inputSlot)
			{
			case 1:
				ResetTarget();
				break;
			case 2:
				LowerTarget();
				break;
			}
		}
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		if (IsKnockedDown())
		{
			if (IsPowered())
			{
				return base.GetPassthroughAmount();
			}
			if (UnityEngine.Time.time < lastToggleTime + activationPowerTime)
			{
				return activationPowerAmount;
			}
		}
		return 0;
	}

	[RPC_Server]
	public void RPC_Reset(RPCMessage msg)
	{
		ResetTarget();
	}

	[RPC_Server]
	public void RPC_Lower(RPCMessage msg)
	{
		LowerTarget();
	}
}
