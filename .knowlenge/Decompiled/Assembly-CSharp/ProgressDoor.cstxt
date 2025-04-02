using UnityEngine;

public class ProgressDoor : IOEntity
{
	public float storedEnergy;

	public float energyForOpen = 1f;

	public float secondsToClose = 1f;

	public float openProgress;

	public override void ResetIOState()
	{
		storedEnergy = 0f;
		UpdateProgress();
	}

	public override float IOInput(IOEntity from, IOType inputType, float inputAmount, int slot = 0)
	{
		if (inputAmount > 0f)
		{
			AddEnergy(inputAmount);
			if (storedEnergy == energyForOpen)
			{
				return inputAmount;
			}
			return 0f;
		}
		NoEnergy();
		return inputAmount;
	}

	public virtual void NoEnergy()
	{
	}

	public virtual void AddEnergy(float amount)
	{
		if (!(amount <= 0f))
		{
			storedEnergy += amount;
			storedEnergy = Mathf.Clamp(storedEnergy, 0f, energyForOpen);
		}
	}

	public virtual void UpdateProgress()
	{
		SendNetworkUpdate();
	}
}
