using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using UnityEngine;

[SuppressUnmanagedCodeSecurity]
public static class ServerProfiler
{
	public struct Mark
	{
		public enum Type : byte
		{
			Sync,
			Enter,
			Exit,
			Exception,
			Alloc,
			GCBegin,
			GCEnd
		}

		public long Timestamp;

		public Type Event;
	}

	public struct Profile
	{
		public unsafe Mark* Marks;

		public unsafe IntPtr* Methods;

		public unsafe uint* Allocs;

		public uint MarksCreated;

		public uint MethodsCreated;

		public uint AllocsCreated;

		public int ThreadId;

		public long Timestamp;

		public uint MarksCapacity;

		public uint MethodsCapacity;

		public uint AllocsCapacity;
	}

	private static class Native
	{
		[StructLayout(LayoutKind.Explicit)]
		public struct MonoImage
		{
			[FieldOffset(48)]
			public unsafe byte* AssemblyName;
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct MonoClass
		{
			[FieldOffset(64)]
			public unsafe MonoImage* Image;

			[FieldOffset(72)]
			public unsafe byte* Name;

			[FieldOffset(80)]
			public unsafe byte* Namespace;
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct MonoMethod
		{
			[FieldOffset(8)]
			public unsafe MonoClass* Class;

			[FieldOffset(24)]
			public unsafe byte* Name;
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct MonoVTable
		{
			[FieldOffset(0)]
			public unsafe MonoClass* Class;
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct MonoObject
		{
			[FieldOffset(0)]
			public unsafe MonoVTable* VTable;
		}

		[DllImport("ServerProfiler.Core")]
		public static extern void Install();

		[DllImport("ServerProfiler.Core")]
		public static extern void StartRecording(byte frameCount);

		[DllImport("ServerProfiler.Core")]
		public static extern bool OnFrameEnd();

		[DllImport("ServerProfiler.Core")]
		public unsafe static extern void GetData(out Profile** profiles, out byte count);

		[DllImport("ServerProfiler.Core")]
		public static extern bool ReleaseResources();
	}

	public const byte MaxFrames = 10;

	private static bool canBeActivated;

	private static Action<IList<Profile>> onDoneCallback;

	private static int mainThreadId;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	public static void Init()
	{
		if (!Environment.CommandLine.Contains("-enableProfiler"))
		{
			Debug.Log("Profiler Disabled!");
			return;
		}
		mainThreadId = Environment.CurrentManagedThreadId;
		Native.Install();
		canBeActivated = true;
		Debug.Log("Profiler Initialized!");
	}

	public static void RecordNextFrames(int frames, Action<IList<Profile>> onDone)
	{
		if (onDone != null && IsEnabled())
		{
			onDoneCallback = onDone;
			Native.StartRecording((byte)Math.Clamp(frames, 1, 10));
			PostUpdateHook.EndOfFrame = (Action)Delegate.Combine(PostUpdateHook.EndOfFrame, new Action(OnFrameEnd));
		}
	}

	public static void ReleaseResources()
	{
		Native.ReleaseResources();
	}

	public static bool IsEnabled()
	{
		return canBeActivated;
	}

	private unsafe static void OnFrameEnd()
	{
		if (!Native.OnFrameEnd())
		{
			return;
		}
		List<Profile> list = null;
		Native.GetData(out var profiles, out var count);
		list = new List<Profile>(count);
		for (byte b = 0; b < count; b++)
		{
			if (profiles[(int)b]->MarksCreated != 0)
			{
				list.Add(*profiles[(int)b]);
			}
		}
		onDoneCallback(list);
		onDoneCallback = null;
		PostUpdateHook.EndOfFrame = (Action)Delegate.Remove(PostUpdateHook.EndOfFrame, new Action(OnFrameEnd));
	}

	public static TimeSpan TimestampToTimespan(long stamp)
	{
		return TimeSpan.FromMilliseconds((double)stamp / 1000000.0);
	}

	public static long TimestampToMicros(long stamp)
	{
		return stamp / 1000;
	}

	public unsafe static string GetName(IntPtr methodPtr)
	{
		_ = string.Empty;
		Native.MonoMethod* ptr = (Native.MonoMethod*)(void*)methodPtr;
		string text = Marshal.PtrToStringAnsi((IntPtr)ptr->Class->Image->AssemblyName);
		string text2 = Marshal.PtrToStringAnsi((IntPtr)ptr->Class->Name);
		string text3 = Marshal.PtrToStringAnsi((IntPtr)ptr->Name);
		return text + "!" + text2 + "::" + text3;
	}

	public unsafe static void AppenNameTo(IntPtr methodPtr, StringBuilder builder)
	{
		Native.MonoMethod* ptr = (Native.MonoMethod*)(void*)methodPtr;
		for (byte* ptr2 = ptr->Class->Image->AssemblyName; *ptr2 != 0; ptr2++)
		{
			builder.Append((char)(*ptr2));
		}
		builder.Append('!');
		for (byte* ptr2 = ptr->Class->Name; *ptr2 != 0; ptr2++)
		{
			builder.Append((char)(*ptr2));
		}
		builder.Append("::");
		for (byte* ptr2 = ptr->Name; *ptr2 != 0; ptr2++)
		{
			builder.Append((char)(*ptr2));
		}
	}

	public unsafe static void SerializeNameTo(IntPtr methodPtr, MemoryStream stream)
	{
		long position = stream.Position;
		ushort num = 0;
		stream.WriteByte(0);
		stream.WriteByte(0);
		Native.MonoMethod* ptr = (Native.MonoMethod*)(void*)methodPtr;
		byte* ptr2 = ptr->Class->Image->AssemblyName;
		while (*ptr2 != 0)
		{
			stream.WriteByte(*ptr2);
			ptr2++;
			num++;
		}
		stream.WriteByte(33);
		num++;
		ptr2 = ptr->Class->Name;
		while (*ptr2 != 0)
		{
			stream.WriteByte(*ptr2);
			ptr2++;
			num++;
		}
		stream.WriteByte(58);
		stream.WriteByte(58);
		num += 2;
		ptr2 = ptr->Name;
		while (*ptr2 != 0)
		{
			stream.WriteByte(*ptr2);
			ptr2++;
			num++;
		}
		byte[] buffer = stream.GetBuffer();
		buffer[position] = (byte)(num >> 8);
		buffer[position + 1] = (byte)num;
	}

	public static int GetMainThreadId()
	{
		return mainThreadId;
	}
}
