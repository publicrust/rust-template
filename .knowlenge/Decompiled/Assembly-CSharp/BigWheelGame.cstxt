using System;
using System.Collections.Generic;
using System.Linq;
using Facepunch.Rust;
using Oxide.Core;
using UnityEngine;

public class BigWheelGame : SpinnerWheel
{
	public HitNumber[] hitNumbers;

	public GameObject indicator;

	public GameObjectRef winEffect;

	[ServerVar]
	public static float spinFrequencySeconds = 45f;

	public int spinNumber;

	public int lastPaidSpinNumber = -1;

	public List<BigWheelBettingTerminal> terminals = new List<BigWheelBettingTerminal>();

	public override bool AllowPlayerSpins()
	{
		return false;
	}

	public override bool CanUpdateSign(BasePlayer player)
	{
		return false;
	}

	public override float GetMaxSpinSpeed()
	{
		return 180f;
	}

	public override void ServerInit()
	{
		base.ServerInit();
		Invoke(InitBettingTerminals, 3f);
		Invoke(DoSpin, 10f);
	}

	public void DoSpin()
	{
		if (!(velocity > 0f))
		{
			velocity += UnityEngine.Random.Range(7f, 16f);
			spinNumber++;
			SetTerminalsLocked(isLocked: true);
		}
	}

	public void SetTerminalsLocked(bool isLocked)
	{
		foreach (BigWheelBettingTerminal terminal in terminals)
		{
			terminal.inventory.SetLocked(isLocked);
		}
	}

	public void RemoveTerminal(BigWheelBettingTerminal terminal)
	{
		terminals.Remove(terminal);
	}

	public void InitBettingTerminals()
	{
		terminals.Clear();
		Vis.Entities(base.transform.position, 30f, terminals, 256);
		terminals = terminals.Distinct().ToList();
	}

	public override void Update_Server()
	{
		float num = velocity;
		base.Update_Server();
		float num2 = velocity;
		if (num > 0f && num2 == 0f && spinNumber > lastPaidSpinNumber)
		{
			Payout();
			lastPaidSpinNumber = spinNumber;
			QueueSpin();
		}
	}

	public float SpinSpacing()
	{
		return spinFrequencySeconds;
	}

	public void QueueSpin()
	{
		foreach (BigWheelBettingTerminal terminal in terminals)
		{
			terminal.ClientRPC(null, "SetTimeUntilNextSpin", SpinSpacing());
		}
		Invoke(DoSpin, SpinSpacing());
	}

	public void Payout()
	{
		HitNumber currentHitType = GetCurrentHitType();
		Guid value = Guid.NewGuid();
		foreach (BigWheelBettingTerminal terminal in terminals)
		{
			if (terminal.isClient)
			{
				continue;
			}
			bool flag = false;
			bool flag2 = false;
			Item slot = terminal.inventory.GetSlot((int)currentHitType.hitType);
			if (slot != null)
			{
				int num = currentHitType.ColorToMultiplier(currentHitType.hitType);
				int amount = slot.amount;
				if (Interface.CallHook("OnBigWheelWin", this, slot, terminal, num) == null)
				{
					slot.amount += slot.amount * num;
					slot.RemoveFromContainer();
					slot.MoveToContainer(terminal.inventory, 5);
					flag = true;
					Facepunch.Rust.Analytics.Azure.OnGamblingResult(terminal.lastPlayer, terminal, amount, slot.amount, value);
				}
			}
			for (int i = 0; i < 5; i++)
			{
				Item slot2 = terminal.inventory.GetSlot(i);
				if (slot2 != null && Interface.CallHook("OnBigWheelLoss", this, slot2, terminal) == null)
				{
					Facepunch.Rust.Analytics.Azure.OnGamblingResult(terminal.lastPlayer, terminal, slot2.amount, 0, value);
					slot2.Remove();
					flag2 = true;
				}
			}
			if (flag || flag2)
			{
				terminal.ClientRPC(null, "WinOrLoseSound", flag);
			}
		}
		ItemManager.DoRemoves();
		SetTerminalsLocked(isLocked: false);
	}

	public HitNumber GetCurrentHitType()
	{
		HitNumber result = null;
		float num = float.PositiveInfinity;
		HitNumber[] array = hitNumbers;
		foreach (HitNumber hitNumber in array)
		{
			float num2 = Vector3.Distance(indicator.transform.position, hitNumber.transform.position);
			if (num2 < num)
			{
				result = hitNumber;
				num = num2;
			}
		}
		return result;
	}

	[ContextMenu("LoadHitNumbers")]
	public void LoadHitNumbers()
	{
		HitNumber[] componentsInChildren = GetComponentsInChildren<HitNumber>();
		hitNumbers = componentsInChildren;
	}
}
