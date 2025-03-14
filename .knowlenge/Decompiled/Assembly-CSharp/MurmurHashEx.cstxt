using System.IO;
using System.Text;

public static class MurmurHashEx
{
	public static int MurmurHashSigned(this string str)
	{
		return MurmurHash.Signed(StringToStream(str));
	}

	public static uint MurmurHashUnsigned(this string str)
	{
		return MurmurHash.Unsigned(StringToStream(str));
	}

	private static MemoryStream StringToStream(string str)
	{
		return new MemoryStream(Encoding.UTF8.GetBytes(str ?? string.Empty));
	}
}
