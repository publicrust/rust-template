using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ConVar;
using Facepunch.Utility;
using UnityEngine;

public static class ProfileExporter
{
	public static class JSON
	{
		public static void Export(string filename, IList<ServerProfiler.Profile> profiles)
		{
			Debug.Log("Starting JSON snapshot generation...");
			uint[] syncIndices = new uint[10];
			byte frames = Preprocess(profiles, ref syncIndices);
			StringBuilder stringBuilder = new StringBuilder(134217728);
			stringBuilder.Append('[');
			long startTimestamp = 0L;
			long firstMarkTimestamp = 0L;
			foreach (ServerProfiler.Profile profile in profiles)
			{
				ServerProfiler.Profile mainProfile = profile;
				if (mainProfile.ThreadId == ServerProfiler.GetMainThreadId())
				{
					startTimestamp = mainProfile.Timestamp;
					if (!ProcessMainProfile(in mainProfile, frames, syncIndices, startTimestamp, stringBuilder, out firstMarkTimestamp))
					{
						return;
					}
					break;
				}
			}
			foreach (ServerProfiler.Profile profile2 in profiles)
			{
				ServerProfiler.Profile workerProfile = profile2;
				if (workerProfile.ThreadId != ServerProfiler.GetMainThreadId() && !ProcessWorkerProfile(in workerProfile, firstMarkTimestamp, startTimestamp, stringBuilder))
				{
					return;
				}
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			stringBuilder.Append(']');
			Debug.Log("Generation done, compressing...");
			string s = stringBuilder.ToString();
			byte[] bytes = Encoding.Default.GetBytes(s);
			string text = Path.Join(Server.rootFolder, "profiler");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			File.WriteAllBytes(Path.Join(text, filename + ".json.gz"), Compression.Compress(bytes));
			Debug.Log("Snapshot json export done!");
		}

		private unsafe static bool ProcessMainProfile(in ServerProfiler.Profile mainProfile, byte frames, uint[] syncIndices, long startTimestamp, StringBuilder builder, out long firstMarkTimestamp)
		{
			int num = 0;
			uint num2 = 0u;
			uint num3 = syncIndices[0];
			firstMarkTimestamp = 0L;
			int num4 = FindStartingDepth(in mainProfile, num2, num3);
			if (num4 >= 0)
			{
				Debug.LogError("Unexpected missing starts for frame 0");
				return false;
			}
			uint namesOffset = 0u;
			uint allocOffset = 0u;
			uint num5 = FindFrameStart(in mainProfile, num2, num3, -num4, ref namesOffset, ref allocOffset);
			if (num5 == num3)
			{
				Debug.LogError("Unexpected frame start for frame 0");
				return false;
			}
			firstMarkTimestamp = mainProfile.Marks[num5].Timestamp;
			for (byte b = 0; b < frames; b++)
			{
				uint num6 = mainProfile.MarksCreated;
				num3 = syncIndices[b];
				if (b < frames - 1)
				{
					uint num7 = syncIndices[b + 1];
					int num8 = FindStartingDepth(in mainProfile, num3, num7);
					if (num8 >= 0)
					{
						Debug.LogError($"Unexpected missing starts for frame {b + 1}");
						return false;
					}
					uint namesOffset2 = 0u;
					uint allocOffset2 = 0u;
					num6 = FindFrameStart(in mainProfile, num3, num7, -num4, ref namesOffset2, ref allocOffset2);
					if (num6 == num7)
					{
						Debug.LogError($"Unexpected frame start for frame {b + 1}");
						return false;
					}
					num4 = num8;
				}
				long timestamp = mainProfile.Marks[num5].Timestamp;
				long frameEndTimestamp = ((b < frames - 1) ? mainProfile.Marks[num6].Timestamp : mainProfile.Marks[mainProfile.MarksCreated - 1].Timestamp);
				AddUnityFrame(b, timestamp, frameEndTimestamp, mainProfile.ThreadId, startTimestamp, builder);
				for (uint num9 = num5; num9 < num6; num9++)
				{
					ServerProfiler.Mark mark = mainProfile.Marks[num9];
					num += AdjustCallstackDepth(in mark);
					if (num < 0)
					{
						Debug.LogError($"Unexpected callstack depth: {num}, frame: {b}");
						return false;
					}
					AddMark(in mainProfile, num9, ref namesOffset, ref allocOffset, startTimestamp, builder);
				}
				num5 = num6;
				num2 = num3;
			}
			long timestamp2 = mainProfile.Marks[mainProfile.MarksCreated - 1].Timestamp;
			while (num > 0)
			{
				ServerProfiler.Mark mark2 = default(ServerProfiler.Mark);
				mark2.Event = ServerProfiler.Mark.Type.Exit;
				mark2.Timestamp = timestamp2;
				AddMark(mark2, null, mainProfile.ThreadId, startTimestamp, builder);
				num--;
			}
			return true;
		}

		private unsafe static bool ProcessWorkerProfile(in ServerProfiler.Profile workerProfile, long firstMarkTimestamp, long startTimestamp, StringBuilder builder)
		{
			uint num = 0u;
			uint nameInd = 0u;
			uint allocInd = 0u;
			int num2 = 0;
			while (workerProfile.Marks[num].Timestamp < firstMarkTimestamp)
			{
				num2 += AdjustCallstackDepth(in workerProfile.Marks[num]);
				switch (workerProfile.Marks[num].Event)
				{
				case ServerProfiler.Mark.Type.Enter:
					nameInd++;
					break;
				case ServerProfiler.Mark.Type.Alloc:
					allocInd++;
					break;
				}
				num++;
				if (num >= workerProfile.MarksCreated)
				{
					Debug.LogError($"Couldn't find start: {num}/{workerProfile.MarksCreated}, thread: {workerProfile.ThreadId}");
					return false;
				}
			}
			int num3 = FindStartingDepth(in workerProfile, 0u, workerProfile.MarksCreated);
			for (num3 += num2; num3 < 0; num3++)
			{
				ServerProfiler.Mark mark = default(ServerProfiler.Mark);
				mark.Event = ServerProfiler.Mark.Type.Enter;
				mark.Timestamp = startTimestamp;
				AddMark(mark, "Unknown", workerProfile.ThreadId, startTimestamp, builder);
			}
			for (uint num4 = num; num4 < workerProfile.MarksCreated; num4++)
			{
				ServerProfiler.Mark mark2 = workerProfile.Marks[num4];
				num3 += AdjustCallstackDepth(in mark2);
				if (num3 < 0)
				{
					Debug.LogError($"Unexpected callstack depth: {num3}, mark: {num4}, thread: {workerProfile.ThreadId}");
					return false;
				}
				AddMark(in workerProfile, num4, ref nameInd, ref allocInd, startTimestamp, builder);
			}
			long timestamp = workerProfile.Marks[workerProfile.MarksCreated - 1].Timestamp;
			while (num3 > 0)
			{
				ServerProfiler.Mark mark3 = default(ServerProfiler.Mark);
				mark3.Event = ServerProfiler.Mark.Type.Exit;
				mark3.Timestamp = timestamp;
				AddMark(mark3, null, workerProfile.ThreadId, startTimestamp, builder);
				num3--;
			}
			return true;
		}

		private unsafe static void AddMark(in ServerProfiler.Profile threadProfile, uint markInd, ref uint nameInd, ref uint allocInd, long startTimestamp, StringBuilder builder)
		{
			ServerProfiler.Mark mark = threadProfile.Marks[markInd];
			switch (mark.Event)
			{
			case ServerProfiler.Mark.Type.Enter:
				builder.Append("{\"name\":\"");
				ServerProfiler.AppenNameTo(threadProfile.Methods[nameInd++], builder);
				builder.Append("\",\"cat\":\"P\",\"ph\":\"B\",\"ts\":");
				builder.Append(ServerProfiler.TimestampToMicros(mark.Timestamp - startTimestamp));
				builder.Append(",\"pid\":0,\"tid\":");
				builder.Append(threadProfile.ThreadId);
				builder.Append("},");
				break;
			case ServerProfiler.Mark.Type.Exit:
			case ServerProfiler.Mark.Type.Exception:
			case ServerProfiler.Mark.Type.GCEnd:
				builder.Append("{\"ph\":\"E\",\"ts\":");
				builder.Append(ServerProfiler.TimestampToMicros(mark.Timestamp - startTimestamp));
				builder.Append(",\"pid\":0,\"tid\":");
				builder.Append(threadProfile.ThreadId);
				builder.Append("},");
				break;
			case ServerProfiler.Mark.Type.Alloc:
				builder.Append("{\"name\":\"");
				builder.Append("Alloc ");
				builder.Append(threadProfile.Allocs[allocInd++]);
				builder.Append("b\",\"ph\":\"i\",\"ts\":");
				builder.Append(ServerProfiler.TimestampToMicros(mark.Timestamp - startTimestamp));
				builder.Append(",\"pid\":0,\"tid\":");
				builder.Append(threadProfile.ThreadId);
				builder.Append(",\"s\":\"p\"},");
				break;
			case ServerProfiler.Mark.Type.GCBegin:
				builder.Append("{\"name\":\"");
				builder.Append("GC.Collect");
				builder.Append("\",\"cat\":\"P\",\"ph\":\"B\",\"ts\":");
				builder.Append(ServerProfiler.TimestampToMicros(mark.Timestamp - startTimestamp));
				builder.Append(",\"pid\":0,\"tid\":");
				builder.Append(threadProfile.ThreadId);
				builder.Append("},");
				break;
			}
		}

		private static void AddMark(ServerProfiler.Mark mark, string name, int threadId, long startTimestamp, StringBuilder builder)
		{
			switch (mark.Event)
			{
			case ServerProfiler.Mark.Type.Enter:
				builder.Append("{\"name\":\"");
				builder.Append(name);
				builder.Append("\",\"cat\":\"P\",\"ph\":\"B\",\"ts\":");
				builder.Append(ServerProfiler.TimestampToMicros(mark.Timestamp - startTimestamp));
				builder.Append(",\"pid\":0,\"tid\":");
				builder.Append(threadId);
				builder.Append("},");
				break;
			case ServerProfiler.Mark.Type.Exit:
			case ServerProfiler.Mark.Type.Exception:
				builder.Append("{\"ph\":\"E\",\"ts\":");
				builder.Append(ServerProfiler.TimestampToMicros(mark.Timestamp - startTimestamp));
				builder.Append(",\"pid\":0,\"tid\":");
				builder.Append(threadId);
				builder.Append("},");
				break;
			}
		}

		private static void AddUnityFrame(byte frameInd, long frameStartTimestamp, long frameEndTimestamp, int threadId, long startTimestamp, StringBuilder builder)
		{
			builder.Append("{\"name\":\"UnityFrame");
			builder.Append(frameInd);
			builder.Append("\",\"cat\":\"P\",\"ph\":\"X\",\"ts\":");
			builder.Append(ServerProfiler.TimestampToMicros(frameStartTimestamp - startTimestamp));
			builder.Append(",\"dur\":");
			builder.Append(ServerProfiler.TimestampToMicros(frameEndTimestamp - frameStartTimestamp));
			builder.Append(",\"pid\":0,\"tid\":");
			builder.Append(threadId);
			builder.Append("},");
		}

		private unsafe static int FindStartingDepth(in ServerProfiler.Profile threadProfile, uint start, uint end)
		{
			int num = 0;
			int num2 = 0;
			for (uint num3 = start; num3 < end; num3++)
			{
				ServerProfiler.Mark mark = threadProfile.Marks[num3];
				num += AdjustCallstackDepth(in mark);
				if (mark.Event == ServerProfiler.Mark.Type.Exit || mark.Event == ServerProfiler.Mark.Type.Exception)
				{
					num2 = Math.Min(num, num2);
				}
			}
			return num2;
		}

		private unsafe static uint FindFrameStart(in ServerProfiler.Profile threadProfile, uint frameStart, uint frameEnd, int callstackDepth, ref uint namesOffset, ref uint allocOffset)
		{
			for (uint num = frameStart; num < frameEnd; num++)
			{
				callstackDepth += AdjustCallstackDepth(in threadProfile.Marks[num]);
				namesOffset += ((threadProfile.Marks[num].Event == ServerProfiler.Mark.Type.Enter) ? 1u : 0u);
				allocOffset += ((threadProfile.Marks[num].Event == ServerProfiler.Mark.Type.Alloc) ? 1u : 0u);
				if (callstackDepth == 0)
				{
					return num + 1;
				}
			}
			return frameEnd;
		}

		private static int AdjustCallstackDepth(in ServerProfiler.Mark mark)
		{
			switch (mark.Event)
			{
			case ServerProfiler.Mark.Type.Enter:
				return 1;
			case ServerProfiler.Mark.Type.Exit:
			case ServerProfiler.Mark.Type.Exception:
				return -1;
			default:
				return 0;
			}
		}
	}

	public static class Binary
	{
		private enum Section : byte
		{
			Info,
			Thread,
			Marks
		}

		private struct SectionBlock : IDisposable
		{
			private MemoryStream stream;

			private long startPos;

			public static SectionBlock New(Section section, MemoryStream stream)
			{
				SectionBlock result = default(SectionBlock);
				result.stream = stream;
				result.startPos = stream.Position;
				result.Begin(section);
				return result;
			}

			private void Begin(Section section)
			{
				Write(4276993775u);
				Write((byte)section);
				Write(ulong.MaxValue);
			}

			private void End()
			{
				long num = startPos + 5;
				long num2 = stream.Position - num - 8;
				byte[] buffer = stream.GetBuffer();
				for (byte b = 0; b < 8; b++)
				{
					buffer[num + b] = (byte)(num2 >> 56 - b * 8);
				}
				Write(3735928559u);
			}

			public void Write(string text)
			{
				Write((ushort)text.Length);
				for (int i = 0; i < text.Length; i++)
				{
					stream.WriteByte((byte)text[i]);
				}
			}

			public void Write(ulong value)
			{
				for (byte b = 0; b < 8; b++)
				{
					stream.WriteByte((byte)(value >> 56 - b * 8));
				}
			}

			public void Write(uint value)
			{
				for (byte b = 0; b < 4; b++)
				{
					stream.WriteByte((byte)(value >> 24 - b * 8));
				}
			}

			public void Write(ushort value)
			{
				stream.WriteByte((byte)(value >> 8));
				stream.WriteByte((byte)value);
			}

			public void Write(byte value)
			{
				stream.WriteByte(value);
			}

			void IDisposable.Dispose()
			{
				End();
			}
		}

		public unsafe static void Export(IList<ServerProfiler.Profile> profiles)
		{
			uint[] syncIndices = new uint[10];
			Preprocess(profiles, ref syncIndices);
			MemoryStream memoryStream = new MemoryStream(134217728);
			using (SectionBlock sectionBlock = SectionBlock.New(Section.Info, memoryStream))
			{
				string text = $"World Size: {0}, Seed: {0}, Players: {0}, Entities: {0}";
				sectionBlock.Write(text);
			}
			foreach (ServerProfiler.Profile profile in profiles)
			{
				using SectionBlock sectionBlock2 = SectionBlock.New(Section.Thread, memoryStream);
				sectionBlock2.Write((uint)profile.ThreadId);
				long num = 0L;
				using SectionBlock sectionBlock3 = SectionBlock.New(Section.Marks, memoryStream);
				for (uint num2 = 0u; num2 < profile.MarksCreated; num2++)
				{
					ServerProfiler.Mark mark = profile.Marks[num2];
					sectionBlock3.Write((byte)mark.Event);
					sectionBlock3.Write((ulong)mark.Timestamp);
					if (mark.Event == ServerProfiler.Mark.Type.Enter)
					{
						ServerProfiler.SerializeNameTo(profile.Methods[num++], memoryStream);
					}
				}
			}
			byte[] array = new byte[memoryStream.Position];
			Buffer.BlockCopy(memoryStream.GetBuffer(), 0, array, 0, (int)memoryStream.Position);
			File.WriteAllBytes("Perf.bin.gz", Compression.Compress(array));
		}
	}

	private const string OutputDir = "profiler";

	private unsafe static byte Preprocess(IList<ServerProfiler.Profile> profiles, ref uint[] syncIndices)
	{
		byte b = 0;
		uint num = 0u;
		uint num2 = 0u;
		foreach (ServerProfiler.Profile profile in profiles)
		{
			ServerProfiler.Profile threadProfile = profile;
			if (threadProfile.ThreadId == ServerProfiler.GetMainThreadId())
			{
				uint num3 = 0u;
				while ((num3 = FindSyncpoint(in threadProfile, num3 + 1)) != threadProfile.MarksCreated)
				{
					syncIndices[b++] = num3;
				}
				uint num4 = 0u;
				long num5 = threadProfile.Timestamp;
				for (byte b2 = 0; b2 < b; b2++)
				{
					uint num6 = syncIndices[b2];
					long timestamp = threadProfile.Marks[num6].Timestamp;
					Debug.Log(string.Format(arg2: ServerProfiler.TimestampToTimespan(timestamp - num5).TotalMilliseconds, format: "Frame {0}: {1}, time: {2}ms\n", arg0: b2, arg1: num6 - num4));
					num5 = timestamp;
					num = Math.Max(threadProfile.MarksCreated, num6 - num4);
					num4 = num6;
				}
			}
			else
			{
				num2 = Math.Max(threadProfile.MarksCreated, num2);
			}
		}
		Debug.Log($"Frame count: {b}, max marks on main thread: {num}, worker thread: {num2}");
		return b;
	}

	private unsafe static uint FindSyncpoint(in ServerProfiler.Profile threadProfile, uint start)
	{
		for (uint num = start; num < threadProfile.MarksCreated; num++)
		{
			if (threadProfile.Marks[num].Event == ServerProfiler.Mark.Type.Sync)
			{
				return num;
			}
		}
		return threadProfile.MarksCreated;
	}
}
