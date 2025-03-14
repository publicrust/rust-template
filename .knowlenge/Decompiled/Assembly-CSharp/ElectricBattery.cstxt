using System.Collections.Generic;
using Facepunch;
using Network;
using ProtoBuf;
using UnityEngine;

public class ElectricBattery : IOEntity, IInstanceDataReceiver
{
	public int maxOutput;

	public float maxCapactiySeconds;

	public float rustWattSeconds;

	private int activeDrain;

	public bool rechargable;

	[Tooltip("How much energy we can request from power sources for charging is this value * our maxOutput")]
	public float maximumInboundEnergyRatio = 4f;

	public float chargeRatio = 0.25f;

	private const float tickRateSeconds = 1f;

	public const Flags Flag_HalfFull = Flags.Reserved5;

	public const Flags Flag_VeryFull = Flags.Reserved6;

	private bool wasLoaded;

	private HashSet<IOEntity> connectedList = new HashSet<IOEntity>();

	public override bool IsRootEntity()
	{
		return true;
	}

	public override int ConsumptionAmount()
	{
		return 0;
	}

	public override int MaximalPowerOutput()
	{
		return maxOutput;
	}

	public int GetActiveDrain()
	{
		if (!IsOn())
		{
			return 0;
		}
		return activeDrain;
	}

	public void ReceiveInstanceData(ProtoBuf.Item.InstanceData data)
	{
		rustWattSeconds = data.dataInt;
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		wasLoaded = true;
	}

	public override void OnPickedUp(Item createdItem, BasePlayer player)
	{
		base.OnPickedUp(createdItem, player);
		if (createdItem.instanceData == null)
		{
			createdItem.instanceData = new ProtoBuf.Item.InstanceData();
		}
		createdItem.instanceData.ShouldPool = false;
		createdItem.instanceData.dataInt = Mathf.FloorToInt(rustWattSeconds);
	}

	public override int GetCurrentEnergy()
	{
		return currentEnergy;
	}

	public override int DesiredPower()
	{
		if (rustWattSeconds >= maxCapactiySeconds)
		{
			return 0;
		}
		return Mathf.FloorToInt((float)maxOutput * maximumInboundEnergyRatio);
	}

	public override void SendAdditionalData(BasePlayer player, int slot, bool input)
	{
		int passthroughAmountForAnySlot = GetPassthroughAmountForAnySlot(slot, input);
		ClientRPCPlayer((Connection)null, player, "Client_ReceiveAdditionalData", currentEnergy, passthroughAmountForAnySlot, rustWattSeconds, (float)activeDrain);
	}

	public override void ServerInit()
	{
		base.ServerInit();
		InvokeRandomized(CheckDischarge, Random.Range(0f, 1f), 1f, 0.1f);
	}

	public int GetDrainFor(IOEntity ent)
	{
		return 0;
	}

	public void AddConnectedRecursive(IOEntity root, ref HashSet<IOEntity> listToUse)
	{
		listToUse.Add(root);
		if (!root.WantsPassthroughPower())
		{
			return;
		}
		for (int i = 0; i < root.outputs.Length; i++)
		{
			if (!root.AllowDrainFrom(i))
			{
				continue;
			}
			IOSlot iOSlot = root.outputs[i];
			if (iOSlot.type != 0)
			{
				continue;
			}
			IOEntity iOEntity = iOSlot.connectedTo.Get();
			if (!(iOEntity != null))
			{
				continue;
			}
			bool flag = iOEntity.WantsPower();
			if (!listToUse.Contains(iOEntity))
			{
				if (flag)
				{
					AddConnectedRecursive(iOEntity, ref listToUse);
				}
				else
				{
					listToUse.Add(iOEntity);
				}
			}
		}
	}

	public int GetDrain()
	{
		connectedList.Clear();
		IOEntity iOEntity = outputs[0].connectedTo.Get();
		if ((bool)iOEntity)
		{
			AddConnectedRecursive(iOEntity, ref connectedList);
		}
		int num = 0;
		foreach (IOEntity connected in connectedList)
		{
			if (connected.ShouldDrainBattery(this))
			{
				num += connected.DesiredPower();
				if (num >= maxOutput)
				{
					num = maxOutput;
					break;
				}
			}
		}
		return num;
	}

	public override void OnCircuitChanged(bool forceUpdate)
	{
		base.OnCircuitChanged(forceUpdate);
		int drain = GetDrain();
		activeDrain = drain;
	}

	public void CheckDischarge()
	{
		if (rustWattSeconds < 5f)
		{
			SetDischarging(wantsOn: false);
			return;
		}
		IOEntity iOEntity = outputs[0].connectedTo.Get();
		int drain = GetDrain();
		activeDrain = drain;
		if ((bool)iOEntity)
		{
			SetDischarging(iOEntity.WantsPower());
		}
		else
		{
			SetDischarging(wantsOn: false);
		}
	}

	public void SetDischarging(bool wantsOn)
	{
		SetPassthroughOn(wantsOn);
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		if (IsOn())
		{
			return Mathf.FloorToInt((float)maxOutput * ((rustWattSeconds >= 1f) ? 1f : 0f));
		}
		return 0;
	}

	public override bool WantsPower()
	{
		return rustWattSeconds < maxCapactiySeconds;
	}

	public override void IOStateChanged(int inputAmount, int inputSlot)
	{
		base.IOStateChanged(inputAmount, inputSlot);
		if (inputSlot != 0)
		{
			return;
		}
		if (!IsPowered())
		{
			if (rechargable)
			{
				CancelInvoke(AddCharge);
			}
		}
		else if (rechargable && !IsInvoking(AddCharge))
		{
			InvokeRandomized(AddCharge, 1f, 1f, 0.1f);
		}
	}

	public void TickUsage()
	{
		float oldCharge = rustWattSeconds;
		bool num = rustWattSeconds > 0f;
		if (rustWattSeconds >= 1f)
		{
			float num2 = 1f * (float)activeDrain;
			rustWattSeconds -= num2;
		}
		if (rustWattSeconds <= 0f)
		{
			rustWattSeconds = 0f;
		}
		bool flag = rustWattSeconds > 0f;
		ChargeChanged(oldCharge);
		if (num != flag)
		{
			MarkDirty();
			SendNetworkUpdate();
		}
	}

	public virtual void ChargeChanged(float oldCharge)
	{
		_ = rustWattSeconds;
		bool flag = rustWattSeconds > maxCapactiySeconds * 0.25f;
		bool flag2 = rustWattSeconds > maxCapactiySeconds * 0.75f;
		if (HasFlag(Flags.Reserved5) != flag || HasFlag(Flags.Reserved6) != flag2)
		{
			SetFlag(Flags.Reserved5, flag, recursive: false, networkupdate: false);
			SetFlag(Flags.Reserved6, flag2, recursive: false, networkupdate: false);
			SendNetworkUpdate();
		}
	}

	public void AddCharge()
	{
		float oldCharge = rustWattSeconds;
		float num = (float)Mathf.Min(currentEnergy, DesiredPower()) * 1f * chargeRatio;
		rustWattSeconds += num;
		rustWattSeconds = Mathf.Clamp(rustWattSeconds, 0f, maxCapactiySeconds);
		ChargeChanged(oldCharge);
	}

	public void SetPassthroughOn(bool wantsOn)
	{
		if (wantsOn == IsOn() && !wasLoaded)
		{
			return;
		}
		wasLoaded = false;
		SetFlag(Flags.On, wantsOn);
		if (IsOn())
		{
			if (!IsInvoking(TickUsage))
			{
				InvokeRandomized(TickUsage, 1f, 1f, 0.1f);
			}
		}
		else
		{
			CancelInvoke(TickUsage);
		}
		MarkDirty();
	}

	public void Unbusy()
	{
		SetFlag(Flags.Busy, b: false);
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (info.msg.ioEntity == null)
		{
			info.msg.ioEntity = Pool.Get<ProtoBuf.IOEntity>();
		}
		info.msg.ioEntity.genericFloat1 = rustWattSeconds;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.ioEntity != null)
		{
			rustWattSeconds = info.msg.ioEntity.genericFloat1;
		}
	}
}
