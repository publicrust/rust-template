using System;
using System.Runtime.InteropServices;
using UnityEngine;

public static class SystemInfoEx
{
	private static bool[] supportedRenderTextureFormats;

	public static int systemMemoryUsed => (int)(System_GetMemoryUsage() / 1024 / 1024);

	[DllImport("RustNative")]
	private static extern ulong System_GetMemoryUsage();

	public static bool SupportsRenderTextureFormat(RenderTextureFormat format)
	{
		if (supportedRenderTextureFormats == null)
		{
			Array values = Enum.GetValues(typeof(RenderTextureFormat));
			int num = (int)values.GetValue(values.Length - 1);
			supportedRenderTextureFormats = new bool[num + 1];
			for (int i = 0; i <= num; i++)
			{
				bool flag = Enum.IsDefined(typeof(RenderTextureFormat), i);
				supportedRenderTextureFormats[i] = flag && SystemInfo.SupportsRenderTextureFormat((RenderTextureFormat)i);
			}
		}
		return supportedRenderTextureFormats[(int)format];
	}
}
