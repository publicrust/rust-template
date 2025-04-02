using System;

public struct ItemContainerId : IEquatable<ItemContainerId>
{
	public ulong Value;

	public static readonly ItemContainerId Invalid = new ItemContainerId(ulong.MaxValue);

	public bool IsValid => Value != 0;

	public ItemContainerId(ulong value)
	{
		Value = value;
	}

	public override string ToString()
	{
		return Value.ToString("G");
	}

	public bool Equals(ItemContainerId other)
	{
		return Value == other.Value;
	}

	public override bool Equals(object obj)
	{
		if (obj is ItemContainerId other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}

	public static bool operator ==(ItemContainerId left, ItemContainerId right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(ItemContainerId left, ItemContainerId right)
	{
		return !left.Equals(right);
	}
}
