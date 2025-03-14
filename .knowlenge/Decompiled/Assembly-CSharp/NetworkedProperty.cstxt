using System;

public class NetworkedProperty<T> where T : IEquatable<T>
{
	private T val;

	private BaseEntity entity;

	public T Value
	{
		get
		{
			return val;
		}
		set
		{
			if (!val.Equals(value))
			{
				val = value;
				if (entity.isServer)
				{
					entity.SendNetworkUpdate();
				}
			}
		}
	}

	public NetworkedProperty(BaseEntity entity)
	{
		this.entity = entity;
	}

	public static implicit operator T(NetworkedProperty<T> value)
	{
		return value.Value;
	}
}
