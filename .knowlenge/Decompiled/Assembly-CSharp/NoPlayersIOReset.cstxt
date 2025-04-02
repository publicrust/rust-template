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
		InvokeRandomized(Check, timeBetweenChecks, timeBetweenChecks, timeBetweenChecks * 0.1f);
	}

	protected void OnDisable()
	{
		CancelInvoke(Check);
	}

	private void Check()
	{
		if (!PuzzleReset.AnyPlayersWithinDistance(base.transform, radius))
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
