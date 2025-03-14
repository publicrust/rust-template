using UnityEngine;

public class BaseScriptableObject : ScriptableObject
{
	[HideInInspector]
	public uint FilenameStringId;

	public string LookupFileName()
	{
		return StringPool.Get(FilenameStringId);
	}

	public static bool operator ==(BaseScriptableObject a, BaseScriptableObject b)
	{
		if ((object)a == b)
		{
			return true;
		}
		if ((object)a == null || (object)b == null)
		{
			return false;
		}
		return a.FilenameStringId == b.FilenameStringId;
	}

	public static bool operator !=(BaseScriptableObject a, BaseScriptableObject b)
	{
		return !(a == b);
	}

	public override int GetHashCode()
	{
		return (int)FilenameStringId;
	}

	public override bool Equals(object o)
	{
		if (o != null && o is BaseScriptableObject)
		{
			return o as BaseScriptableObject == this;
		}
		return false;
	}
}
