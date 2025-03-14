using System.IO;

public static class StreamEx
{
	private static readonly byte[] StaticBuffer = new byte[16384];

	public static void WriteToOtherStream(this Stream self, Stream target)
	{
		int count;
		while ((count = self.Read(StaticBuffer, 0, StaticBuffer.Length)) > 0)
		{
			target.Write(StaticBuffer, 0, count);
		}
	}
}
