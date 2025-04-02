using System;
using System.Runtime.InteropServices;

public static class WindowsAffinityShim
{
	[DllImport("kernel32.dll")]
	public static extern bool SetProcessAffinityMask(IntPtr process, IntPtr mask);

	[DllImport("kernel32.dll")]
	public static extern bool SetPriorityClass(IntPtr process, uint mask);
}
