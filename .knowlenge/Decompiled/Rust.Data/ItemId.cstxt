using System;

public struct ItemId : IEquatable<ItemId>
{
	public ulong Value;

	public bool IsValid => Value != 0;

	public ItemId(ulong value)
	{
		Value = value;
	}

	public override string ToString()
	{
		return Value.ToString("G");
	}

	public bool Equals(ItemId other)
	{
		return Value == other.Value;
	}

	public override bool Equals(object obj)
	{
		if (obj is ItemId other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}

	public static bool operator ==(ItemId left, ItemId right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(ItemId left, ItemId right)
	{
		return !left.Equals(right);
	}
}
