using System;
using System.Collections.Generic;
using System.Linq;
using Facepunch.Rust;
using Oxide.Core;
using UnityEngine;

public class BigWheelGame : SpinnerWheel
{
	public float baseSpeed = 180f;

	public float offset = 3.852f;

	public AnimationCurve decelerationCurve;

	public AnimationCurve speedCurve;

	public HitNumber[] hitNumbers;

	private float targetAngle;

	private float minimumSpinTime;

	private bool isSpinning;

	private bool decelerating;

	private float elapsedTime;

	private System.Random random;

	[ServerVar]
	public static float spinFrequencySeconds = 45f;

	public int spinNumber;

	protected int targetNumber;

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

	public override void ServerInit()
	{
		base.ServerInit();
		Invoke(InitBettingTerminals, 3f);
		Invoke(DoSpin, 10f);
	}

	public void DoSpin()
	{
		int seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
		random = new System.Random(seed);
		targetNumber = random.Next(0, hitNumbers.Length);
		targetAngle = 0f - 360f / (float)hitNumbers.Length * (float)targetNumber + offset;
		targetAngle += (float)(random.NextDouble() * 12.0 - 6.0);
		minimumSpinTime = (float)(random.NextDouble() * 5.0 + 13.0);
		elapsedTime = 0f;
		isSpinning = true;
		decelerating = false;
		spinNumber++;
		SetTerminalsLocked(isLocked: true);
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

	public float GetMaxSpinSpeed(float time)
	{
		return baseSpeed * speedCurve.Evaluate(time / minimumSpinTime);
	}

	public override void Update_Server()
	{
		if (!isSpinning)
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		elapsedTime += deltaTime;
		float num = NormalizeAngle(wheel.localEulerAngles.y);
		float num2 = NormalizeAngle(targetAngle);
		float num3 = (num2 - num + 360f) % 360f;
		if (!decelerating && (elapsedTime < minimumSpinTime || num3 < 120f))
		{
			float maxSpinSpeed = GetMaxSpinSpeed(elapsedTime);
			wheel.Rotate(base.transform.up, maxSpinSpeed * deltaTime, Space.World);
		}
		else
		{
			decelerating = true;
			float num4 = decelerationCurve.Evaluate(num3 / 180f);
			float num5 = GetMaxSpinSpeed(elapsedTime) * num4 * deltaTime;
			if (num5 > num3)
			{
				num5 = num3;
			}
			wheel.Rotate(base.transform.up, num5, Space.World);
			if (num3 < 0.1f)
			{
				wheel.localRotation = Quaternion.Euler(0f, num2, 0f);
				isSpinning = false;
				if (spinNumber > lastPaidSpinNumber)
				{
					Payout();
					lastPaidSpinNumber = spinNumber;
					QueueSpin();
				}
			}
		}
		SendNetworkUpdate();
	}

	private float NormalizeAngle(float angle)
	{
		angle %= 360f;
		if (angle < 0f)
		{
			angle += 360f;
		}
		return angle;
	}

	public float SpinSpacing()
	{
		return spinFrequencySeconds;
	}

	public void QueueSpin()
	{
		foreach (BigWheelBettingTerminal terminal in terminals)
		{
			terminal.ClientRPC(RpcTarget.NetworkGroup("SetTimeUntilNextSpin"), SpinSpacing());
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
				terminal.ClientRPC(RpcTarget.NetworkGroup("WinOrLoseSound"), flag);
			}
		}
		ItemManager.DoRemoves();
		SetTerminalsLocked(isLocked: false);
	}

	public HitNumber GetCurrentHitType()
	{
		return hitNumbers[targetNumber];
	}
}
