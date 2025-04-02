using UnityEngine;

public class LockedByEntCrate : LootContainer
{
	public GameObject lockingEnt;

	public void SetLockingEnt(GameObject ent)
	{
		CancelInvoke(Think);
		SetLocked(isLocked: false);
		lockingEnt = ent;
		if (lockingEnt != null)
		{
			InvokeRepeating(Think, Random.Range(0f, 1f), 1f);
			SetLocked(isLocked: true);
		}
	}

	public void SetLocked(bool isLocked)
	{
		SetFlag(Flags.OnFire, isLocked);
		SetFlag(Flags.Locked, isLocked);
	}

	public void Think()
	{
		if (lockingEnt == null && IsLocked())
		{
			SetLockingEnt(null);
		}
	}
}
