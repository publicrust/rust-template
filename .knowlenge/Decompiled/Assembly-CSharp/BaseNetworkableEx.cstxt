using UnityEngine;

public static class BaseNetworkableEx
{
	public static bool IsValid(this BaseNetworkable ent)
	{
		if ((Object)(object)ent == (Object)null)
		{
			return false;
		}
		if (ent.net == null)
		{
			return false;
		}
		return true;
	}

	public static bool IsRealNull(this BaseNetworkable ent)
	{
		return ent == null;
	}
}
