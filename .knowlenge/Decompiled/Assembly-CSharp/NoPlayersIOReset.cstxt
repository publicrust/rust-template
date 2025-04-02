using System;
using UnityEngine;

public class NoPlayersIOReset : FacepunchBehaviour
{
	[SerializeField]
	private IOEntity[] entitiesToReset;

	[SerializeField]
	private float radius;

	[SerializeField]
	private float timeBetweenChecks;

	protected void OnEnable()
	{
		((FacepunchBehaviour)this).InvokeRandomized((Action)Check, timeBetweenChecks, timeBetweenChecks, timeBetweenChecks * 0.1f);
	}

	protected void OnDisable()
	{
		((FacepunchBehaviour)this).CancelInvoke((Action)Check);
	}

	private void Check()
	{
		if (!PuzzleReset.AnyPlayersWithinDistance(((Component)this).transform, radius))
		{
			Reset();
		}
	}

	private void Reset()
	{
		IOEntity[] array = entitiesToReset;
		foreach (IOEntity iOEntity in array)
		{
			if (iOEntity.IsValid() && iOEntity.isServer)
			{
				iOEntity.ResetIOState();
				iOEntity.MarkDirty();
			}
		}
	}
}
