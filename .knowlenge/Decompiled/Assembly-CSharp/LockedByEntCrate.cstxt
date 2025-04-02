using System;
using UnityEngine;

public class LockedByEntCrate : LootContainer
{
	public GameObject lockingEnt;

	public void SetLockingEnt(GameObject ent)
	{
		((FacepunchBehaviour)this).CancelInvoke((Action)Think);
		SetLocked(isLocked: false);
		lockingEnt = ent;
		if ((Object)(object)lockingEnt != (Object)null)
		{
			((FacepunchBehaviour)this).InvokeRepeating((Action)Think, Random.Range(0f, 1f), 1f);
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
		if ((Object)(object)lockingEnt == (Object)null && IsLocked())
		{
			SetLockingEnt(null);
		}
	}
}
