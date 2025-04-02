using System;
using UnityEngine;

public struct InvokeAction : IEquatable<InvokeAction>
{
	public InvokeTrackingKey Key;

	public InvokeTrackingData TrackingData;

	public Behaviour sender;

	public Action action;

	public float initial;

	public float repeat;

	public float random;

	public InvokeAction(Behaviour sender, Action action, InvokeTrackingData tracking, float initial = 0f, float repeat = -1f, float random = 0f)
	{
		this.sender = sender;
		this.action = action;
		this.initial = initial;
		this.repeat = repeat;
		this.random = random;
		TrackingData = tracking;
		Key = tracking?.Key ?? InvokeTrackingKey.Unknown;
	}

	public bool Equals(InvokeAction other)
	{
		if (sender == other.sender)
		{
			return action == other.action;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is InvokeAction)
		{
			return Equals((InvokeAction)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return sender.GetHashCode();
	}

	public static bool operator ==(InvokeAction x, InvokeAction y)
	{
		return x.Equals(y);
	}

	public static bool operator !=(InvokeAction x, InvokeAction y)
	{
		return !x.Equals(y);
	}
}
