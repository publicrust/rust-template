public abstract class BaseMonoBehaviour : FacepunchBehaviour
{
	public virtual bool IsDebugging()
	{
		return false;
	}

	public virtual string GetLogColor()
	{
		return "yellow";
	}

	public void LogEntry(RustLog.EntryType log, int level, string fmtString)
	{
		if (IsDebugging() || RustLog.GetLevel(log) >= level)
		{
			LogImpl(log, level, fmtString);
		}
	}

	public void LogEntry<T1>(RustLog.EntryType log, int level, string fmtString, T1 arg1)
	{
		if (IsDebugging() || RustLog.GetLevel(log) >= level)
		{
			string message = string.Format(fmtString, arg1);
			LogImpl(log, level, message);
		}
	}

	public void LogEntry<T1, T2>(RustLog.EntryType log, int level, string fmtString, T1 arg1, T2 arg2)
	{
		if (IsDebugging() || RustLog.GetLevel(log) >= level)
		{
			string message = string.Format(fmtString, arg1, arg2);
			LogImpl(log, level, message);
		}
	}

	public void LogEntry<T1, T2, T3>(RustLog.EntryType log, int level, string fmtString, T1 arg1, T2 arg2, T3 arg3)
	{
		if (IsDebugging() || RustLog.GetLevel(log) >= level)
		{
			string message = string.Format(fmtString, arg1, arg2, arg3);
			LogImpl(log, level, message);
		}
	}

	protected virtual string GetLogIdentity()
	{
		return $"{this} (InstID: {base.gameObject.GetInstanceID():x})";
	}

	private void LogImpl(RustLog.EntryType entryType, int level, string message)
	{
		string msgFormat = "<color={0}>{1}</color>: {2}";
		RustLog.Log(entryType, level, base.gameObject, msgFormat, GetLogColor(), GetLogIdentity(), message);
	}
}
