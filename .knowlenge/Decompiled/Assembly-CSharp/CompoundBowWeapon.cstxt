using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class CompoundBowWeapon : BowWeapon
{
	public float stringHoldDurationMax = 3f;

	public float stringBonusDamage = 1f;

	public float stringBonusDistance = 0.5f;

	public float stringBonusVelocity = 1f;

	public float movementPenaltyRampUpTime = 0.5f;

	public float conditionLossPerSecondHeld = 1f;

	public float conditionLossHeldDelay = 3f;

	public SoundDefinition chargeUpSoundDef;

	public SoundDefinition stringHeldSoundDef;

	public SoundDefinition drawFinishSoundDef;

	private Sound chargeUpSound;

	private Sound stringHeldSound;

	protected float movementPenalty;

	internal float stringHoldTimeStart;

	protected float conditionLossCheckTickRate = 0.5f;

	protected float serverMovementCheckTickRate = 0.1f;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		TimeWarning val = TimeWarning.New("CompoundBowWeapon.OnRpcMessage", 0);
		try
		{
			if (rpc == 618693016 && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - RPC_StringHoldStatus "));
				}
				TimeWarning val2 = TimeWarning.New("RPC_StringHoldStatus", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Call", 0);
					try
					{
						RPCMessage rPCMessage = default(RPCMessage);
						rPCMessage.connection = msg.connection;
						rPCMessage.player = player;
						rPCMessage.read = msg.read;
						RPCMessage msg2 = rPCMessage;
						RPC_StringHoldStatus(msg2);
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
				}
				catch (Exception ex)
				{
					Debug.LogException(ex);
					player.Kick("RPC Error in RPC_StringHoldStatus");
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

	public void UpdateMovementPenalty(float delta)
	{
		BasePlayer ownerPlayer = GetOwnerPlayer();
		bool flag = false;
		if (base.isServer)
		{
			if ((Object)(object)ownerPlayer == (Object)null)
			{
				return;
			}
			flag = ownerPlayer.estimatedSpeed > 0.1f;
		}
		if (flag)
		{
			movementPenalty += delta * (1f / movementPenaltyRampUpTime);
		}
		else
		{
			movementPenalty -= delta * (1f / stringHoldDurationMax);
		}
		movementPenalty = Mathf.Clamp01(movementPenalty);
	}

	public void UpdateConditionLoss()
	{
		if (stringHoldTimeStart != 0f && Time.time - stringHoldTimeStart > conditionLossHeldDelay && GetStringBonusScale() > 0f)
		{
			GetOwnerItem()?.LoseCondition(conditionLossCheckTickRate * conditionLossPerSecondHeld);
		}
	}

	public void ServerMovementCheck()
	{
		UpdateMovementPenalty(serverMovementCheckTickRate);
	}

	public override void OnHeldChanged()
	{
		base.OnHeldChanged();
		if (IsDisabled())
		{
			((FacepunchBehaviour)this).CancelInvoke((Action)ServerMovementCheck);
			((FacepunchBehaviour)this).CancelInvoke((Action)UpdateConditionLoss);
		}
		else
		{
			((FacepunchBehaviour)this).InvokeRepeating((Action)ServerMovementCheck, 0f, serverMovementCheckTickRate);
			((FacepunchBehaviour)this).InvokeRepeating((Action)UpdateConditionLoss, 0f, conditionLossCheckTickRate);
		}
	}

	[RPC_Server]
	public void RPC_StringHoldStatus(RPCMessage msg)
	{
		if (msg.read.Bit())
		{
			stringHoldTimeStart = Time.time;
		}
		else
		{
			stringHoldTimeStart = 0f;
		}
	}

	public override void DidAttackServerside()
	{
		base.DidAttackServerside();
		stringHoldTimeStart = 0f;
	}

	public float GetLastPlayerMovementTime()
	{
		_ = base.isServer;
		return 0f;
	}

	public float GetStringBonusScale()
	{
		if (stringHoldTimeStart == 0f)
		{
			return 0f;
		}
		return Mathf.Clamp01(Mathf.Clamp01((Time.time - stringHoldTimeStart) / stringHoldDurationMax) - movementPenalty);
	}

	public override float GetDamageScale(bool getMax = false)
	{
		float num = (getMax ? 1f : GetStringBonusScale());
		return damageScale + stringBonusDamage * num;
	}

	public override float GetDistanceScale(bool getMax = false)
	{
		float num = (getMax ? 1f : GetStringBonusScale());
		return distanceScale + stringBonusDistance * num;
	}

	public override float GetProjectileVelocityScale(bool getMax = false)
	{
		float num = (getMax ? 1f : GetStringBonusScale());
		return projectileVelocityScale + stringBonusVelocity * num;
	}
}
