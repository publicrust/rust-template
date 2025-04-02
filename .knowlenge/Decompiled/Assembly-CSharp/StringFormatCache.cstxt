using System;
using System.Collections.Generic;

public static class StringFormatCache
{
	private struct Key1 : IEquatable<Key1>
	{
		public string format;

		public string value1;

		public Key1(string format, string value1)
		{
			this.format = format;
			this.value1 = value1;
		}

		public override int GetHashCode()
		{
			return format.GetHashCode() ^ value1.GetHashCode();
		}

		public override bool Equals(object other)
		{
			if (!(other is Key1))
			{
				return false;
			}
			return Equals((Key1)other);
		}

		public bool Equals(Key1 other)
		{
			if (format == other.format)
			{
				return value1 == other.value1;
			}
			return false;
		}
	}

	private struct Key2 : IEquatable<Key2>
	{
		public string format;

		public string value1;

		public string value2;

		public Key2(string format, string value1, string value2)
		{
			this.format = format;
			this.value1 = value1;
			this.value2 = value2;
		}

		public override int GetHashCode()
		{
			return format.GetHashCode() ^ value1.GetHashCode() ^ value2.GetHashCode();
		}

		public override bool Equals(object other)
		{
			if (!(other is Key2))
			{
				return false;
			}
			return Equals((Key2)other);
		}

		public bool Equals(Key2 other)
		{
			if (format == other.format && value1 == other.value1)
			{
				return value2 == other.value2;
			}
			return false;
		}
	}

	private struct Key3 : IEquatable<Key3>
	{
		public string format;

		public string value1;

		public string value2;

		public string value3;

		public Key3(string format, string value1, string value2, string value3)
		{
			this.format = format;
			this.value1 = value1;
			this.value2 = value2;
			this.value3 = value3;
		}

		public override int GetHashCode()
		{
			return format.GetHashCode() ^ value1.GetHashCode() ^ value2.GetHashCode() ^ value3.GetHashCode();
		}

		public override bool Equals(object other)
		{
			if (!(other is Key3))
			{
				return false;
			}
			return Equals((Key3)other);
		}

		public bool Equals(Key3 other)
		{
			if (format == other.format && value1 == other.value1 && value2 == other.value2)
			{
				return value3 == other.value3;
			}
			return false;
		}
	}

	private struct Key4 : IEquatable<Key4>
	{
		public string format;

		public string value1;

		public string value2;

		public string value3;

		public string value4;

		public Key4(string format, string value1, string value2, string value3, string value4)
		{
			this.format = format;
			this.value1 = value1;
			this.value2 = value2;
			this.value3 = value3;
			this.value4 = value4;
		}

		public override int GetHashCode()
		{
			return format.GetHashCode() ^ value1.GetHashCode() ^ value2.GetHashCode() ^ value3.GetHashCode() ^ value4.GetHashCode();
		}

		public override bool Equals(object other)
		{
			if (!(other is Key4))
			{
				return false;
			}
			return Equals((Key4)other);
		}

		public bool Equals(Key4 other)
		{
			if (format == other.format && value1 == other.value1 && value2 == other.value2 && value3 == other.value3)
			{
				return value4 == other.value4;
			}
			return false;
		}
	}

	private static Dictionary<Key1, string> dict1 = new Dictionary<Key1, string>();

	private static Dictionary<Key2, string> dict2 = new Dictionary<Key2, string>();

	private static Dictionary<Key3, string> dict3 = new Dictionary<Key3, string>();

	private static Dictionary<Key4, string> dict4 = new Dictionary<Key4, string>();

	public static string Get(string format, string value1)
	{
		Key1 key = new Key1(format, value1);
		if (!dict1.TryGetValue(key, out var value2))
		{
			value2 = string.Format(format, value1);
			dict1.Add(key, value2);
		}
		return value2;
	}

	public static string Get(string format, string value1, string value2)
	{
		Key2 key = new Key2(format, value1, value2);
		if (!dict2.TryGetValue(key, out var value3))
		{
			value3 = string.Format(format, value1, value2);
			dict2.Add(key, value3);
		}
		return value3;
	}

	public static string Get(string format, string value1, string value2, string value3)
	{
		Key3 key = new Key3(format, value1, value2, value3);
		if (!dict3.TryGetValue(key, out var value4))
		{
			value4 = string.Format(format, value1, value2, value3);
			dict3.Add(key, value4);
		}
		return value4;
	}

	public static string Get(string format, string value1, string value2, string value3, string value4)
	{
		Key4 key = new Key4(format, value1, value2, value3, value4);
		if (!dict4.TryGetValue(key, out var value5))
		{
			value5 = string.Format(format, value1, value2, value3, value4);
			dict4.Add(key, value5);
		}
		return value5;
	}
}
