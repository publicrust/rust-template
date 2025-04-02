using System;
using Facepunch;
using ProtoBuf;
using UnityEngine;

public class ElectricGenerator : IOEntity
{
	public float electricAmount = 8f;

	public override bool IsRootEntity()
	{
		return true;
	}

	public override int MaximalPowerOutput()
	{
		return Mathf.FloorToInt(electricAmount);
	}

	public override int ConsumptionAmount()
	{
		return 0;
	}

	public override int GetCurrentEnergy()
	{
		return (int)electricAmount;
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		return GetCurrentEnergy();
	}

	public override void UpdateOutputs()
	{
		currentEnergy = GetCurrentEnergy();
		IOSlot[] array = outputs;
		foreach (IOSlot iOSlot in array)
		{
			if ((Object)(object)iOSlot.connectedTo.Get() != (Object)null)
			{
				iOSlot.connectedTo.Get().UpdateFromInput(currentEnergy, iOSlot.connectedToSlot);
			}
		}
	}

	public override void IOStateChanged(int inputAmount, int inputSlot)
	{
		base.IOStateChanged(inputAmount, inputSlot);
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		((FacepunchBehaviour)this).Invoke((Action)ForcePuzzleReset, 1f);
	}

	private void ForcePuzzleReset()
	{
		PuzzleReset component = ((Component)this).GetComponent<PuzzleReset>();
		if ((Object)(object)component != (Object)null)
		{
			component.DoReset();
			component.ResetTimer();
		}
	}

	public override void Save(SaveInfo info)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		base.Save(info);
		if (!info.forDisk)
		{
			return;
		}
		PuzzleReset component = ((Component)this).GetComponent<PuzzleReset>();
		if (Object.op_Implicit((Object)(object)component))
		{
			info.msg.puzzleReset = Pool.Get<PuzzleReset>();
			info.msg.puzzleReset.playerBlocksReset = component.playersBlockReset;
			if ((Object)(object)component.playerDetectionOrigin != (Object)null)
			{
				info.msg.puzzleReset.playerDetectionOrigin = component.playerDetectionOrigin.position;
			}
			info.msg.puzzleReset.playerDetectionRadius = component.playerDetectionRadius;
			info.msg.puzzleReset.scaleWithServerPopulation = component.scaleWithServerPopulation;
			info.msg.puzzleReset.timeBetweenResets = component.timeBetweenResets;
		}
	}

	public override void Load(LoadInfo info)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		base.Load(info);
		if (!info.fromDisk || info.msg.puzzleReset == null)
		{
			return;
		}
		PuzzleReset component = ((Component)this).GetComponent<PuzzleReset>();
		if ((Object)(object)component != (Object)null)
		{
			component.playersBlockReset = info.msg.puzzleReset.playerBlocksReset;
			if ((Object)(object)component.playerDetectionOrigin != (Object)null)
			{
				component.playerDetectionOrigin.position = info.msg.puzzleReset.playerDetectionOrigin;
			}
			component.playerDetectionRadius = info.msg.puzzleReset.playerDetectionRadius;
			component.scaleWithServerPopulation = info.msg.puzzleReset.scaleWithServerPopulation;
			component.timeBetweenResets = info.msg.puzzleReset.timeBetweenResets;
			component.ResetTimer();
		}
	}
}
