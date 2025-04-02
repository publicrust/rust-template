using System.Collections.Generic;
using System.IO;

public static class RawWriter
{
	public static void Write(IEnumerable<byte> data, string path)
	{
		using FileStream output = File.Open(path, FileMode.Create);
		using BinaryWriter binaryWriter = new BinaryWriter(output);
		foreach (byte datum in data)
		{
			binaryWriter.Write(datum);
		}
	}

	public static void Write(IEnumerable<int> data, string path)
	{
		using FileStream output = File.Open(path, FileMode.Create);
		using BinaryWriter binaryWriter = new BinaryWriter(output);
		foreach (int datum in data)
		{
			binaryWriter.Write(datum);
		}
	}

	public static void Write(IEnumerable<short> data, string path)
	{
		using FileStream output = File.Open(path, FileMode.Create);
		using BinaryWriter binaryWriter = new BinaryWriter(output);
		foreach (short datum in data)
		{
			binaryWriter.Write(datum);
		}
	}

	public static void Write(IEnumerable<float> data, string path)
	{
		using FileStream output = File.Open(path, FileMode.Create);
		using BinaryWriter binaryWriter = new BinaryWriter(output);
		foreach (float datum in data)
		{
			binaryWriter.Write(datum);
		}
	}
}
