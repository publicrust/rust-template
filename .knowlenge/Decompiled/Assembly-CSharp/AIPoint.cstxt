public class AIPoint : BaseMonoBehaviour
{
	private BaseEntity currentUser;

	public bool InUse()
	{
		return currentUser != null;
	}

	public bool IsUsedBy(BaseEntity user)
	{
		if (!InUse())
		{
			return false;
		}
		if (user == null)
		{
			return false;
		}
		return user == currentUser;
	}

	public bool CanBeUsedBy(BaseEntity user)
	{
		if (user != null && currentUser == user)
		{
			return true;
		}
		return !InUse();
	}

	public void SetUsedBy(BaseEntity user, float duration = 5f)
	{
		currentUser = user;
		CancelInvoke(ClearUsed);
		Invoke(ClearUsed, duration);
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
		if (currentUser == user)
		{
			ClearUsed();
		}
	}
}
