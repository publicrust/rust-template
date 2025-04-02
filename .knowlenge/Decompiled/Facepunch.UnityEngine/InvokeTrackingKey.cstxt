using System;

public struct InvokeTrackingKey : IEquatable<InvokeTrackingKey>
{
	public static readonly InvokeTrackingKey Unknown = new InvokeTrackingKey
	{
		MethodName = "Unknown",
		Type = typeof(InvokeTrackingKey)
	};

	public Type Type;

	public string MethodName;

	public InvokeTrackingKey(Action action)
	{
		if (action == null || action.Target == null)
		{
			Type = Unknown.Type;
			MethodName = Unknown.MethodName;
		}
		else
		{
			Type = action.Target.GetType();
			MethodName = action.Method.Name;
		}
	}

	public InvokeTrackingKey(Type type, string methodName)
	{
		Type = type;
		MethodName = methodName;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Type, MethodName);
	}

	public bool Equals(InvokeTrackingKey other)
	{
		if (Type == other.Type)
		{
			return MethodName == other.MethodName;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is InvokeTrackingKey)
		{
			return Equals((InvokeTrackingKey)obj);
		}
		return false;
	}
}
