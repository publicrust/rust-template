using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

public class Checksum
{
	private List<byte> values = new List<byte>();

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private float NormalizeFloat(float f)
	{
		if (f == -0f)
		{
			f = 0f;
		}
		return f;
	}

	public void Add(float f, int bytes)
	{
		f = NormalizeFloat(f);
		Union32 union = default(Union32);
		union.f = f;
		if (bytes >= 4)
		{
			values.Add(union.b1);
		}
		if (bytes >= 3)
		{
			values.Add(union.b2);
		}
		if (bytes >= 2)
		{
			values.Add(union.b3);
		}
		if (bytes >= 1)
		{
			values.Add(union.b4);
		}
	}

	public void Add(float f)
	{
		f = NormalizeFloat(f);
		Union32 union = default(Union32);
		union.f = f;
		values.Add(union.b1);
		values.Add(union.b2);
		values.Add(union.b3);
		values.Add(union.b4);
	}

	public void Add(int i)
	{
		Union32 union = default(Union32);
		union.i = i;
		values.Add(union.b1);
		values.Add(union.b2);
		values.Add(union.b3);
		values.Add(union.b4);
	}

	public void Add(uint u)
	{
		Union32 union = default(Union32);
		union.u = u;
		values.Add(union.b1);
		values.Add(union.b2);
		values.Add(union.b3);
		values.Add(union.b4);
	}

	public void Add(short i)
	{
		Union16 union = default(Union16);
		union.i = i;
		values.Add(union.b1);
		values.Add(union.b2);
	}

	public void Add(ushort u)
	{
		Union16 union = default(Union16);
		union.u = u;
		values.Add(union.b1);
		values.Add(union.b2);
	}

	public void Add(byte b)
	{
		values.Add(b);
	}

	public void Clear()
	{
		values.Clear();
	}

	public string MD5()
	{
		byte[] bytes = new MD5CryptoServiceProvider().ComputeHash(values.ToArray());
		return BytesToString(bytes);
	}

	public string SHA1()
	{
		byte[] bytes = new SHA1CryptoServiceProvider().ComputeHash(values.ToArray());
		return BytesToString(bytes);
	}

	public override string ToString()
	{
		return BytesToString(values.ToArray());
	}

	private string BytesToString(byte[] bytes)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < bytes.Length; i++)
		{
			stringBuilder.Append(bytes[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}
}
