using System;
using UnityEngine;

public class AIPoint : BaseMonoBehaviour
{
	private BaseEntity currentUser;

	public bool InUse()
	{
		return (Object)(object)currentUser != (Object)null;
	}

	public bool IsUsedBy(BaseEntity user)
	{
		if (!InUse())
		{
			return false;
		}
		if ((Object)(object)user == (Object)null)
		{
			return false;
		}
		return (Object)(object)user == (Object)(object)currentUser;
	}

	public bool CanBeUsedBy(BaseEntity user)
	{
		if ((Object)(object)user != (Object)null && (Object)(object)currentUser == (Object)(object)user)
		{
			return true;
		}
		return !InUse();
	}

	public void SetUsedBy(BaseEntity user, float duration = 5f)
	{
		currentUser = user;
		((FacepunchBehaviour)this).CancelInvoke((Action)ClearUsed);
		((FacepunchBehaviour)this).Invoke((Action)ClearUsed, duration);
	}

	public void SetUsedBy(BaseEntity user)
	{
		currentUser = user;
	}

	public void ClearUsed()
	{
		currentUser = null;
	}

	public void ClearIfUsedBy(BaseEntity user)
	{
		if ((Object)(object)currentUser == (Object)(object)user)
		{
			ClearUsed();
		}
	}
}
