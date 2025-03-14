using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Facepunch;
using Facepunch.Utility;
using ProtoBuf;
using UnityEngine;

public class VDDraw : SingletonComponent<VDDraw>, IServerComponent
{
	private const int maxLogFiles = 10;

	private const string prefix = "VDDraw";

	private const string extension = "vddraw";

	private const string compressionExtension = "gz";

	private const float defaultEntryDuration = 0.2f;

	private const float saveIntervalSeconds = 60f;

	private ConcurrentQueue<VDDrawEntry> logEntries = new ConcurrentQueue<VDDrawEntry>();

	private bool _isRecording;

	private string currentLogPath;

	public static bool isRecording => SingletonComponent<VDDraw>.Instance._isRecording;

	private static string logDirectoryPath => Path.Combine(UnityEngine.Application.persistentDataPath, "Logs");

	[ServerVar]
	public static void SetIsRecording(ConsoleSystem.Arg arg)
	{
		bool flag = (arg.HasArgs() ? arg.GetBool(0) : (!SingletonComponent<VDDraw>.Instance._isRecording));
		if (SingletonComponent<VDDraw>.Instance._isRecording == flag)
		{
			if (SingletonComponent<VDDraw>.Instance._isRecording)
			{
				arg.ReplyWith("Already recording");
			}
			else
			{
				arg.ReplyWith("Not recording");
			}
		}
		else if (flag)
		{
			SingletonComponent<VDDraw>.Instance.StartRecording();
			arg.ReplyWith("Recording started");
		}
		else
		{
			SingletonComponent<VDDraw>.Instance.StopRecording();
			arg.ReplyWith("Recording stopped");
		}
	}

	private void StartRecording()
	{
		if (!_isRecording)
		{
			_isRecording = true;
			if (!Directory.Exists(logDirectoryPath))
			{
				Directory.CreateDirectory(logDirectoryPath);
			}
			ManageLogFiles();
			currentLogPath = GetNewLogFilePath();
			InvokeRepeating(SaveLogs, 0f, 60f);
			UnityEngine.Application.quitting += StopRecording;
		}
	}

	private void StopRecording()
	{
		if (_isRecording)
		{
			_isRecording = false;
			CancelInvoke(SaveLogs);
			SaveLogs();
			CompressCurrentLog();
			currentLogPath = null;
			UnityEngine.Application.quitting -= StopRecording;
		}
	}

	public static void Log(BaseEntity entity, bool display, string label, string message)
	{
		if (entity.IsValid() && SingletonComponent<VDDraw>.Instance._isRecording)
		{
			VDDrawEntry vDDrawEntry = Pool.Get<VDDrawEntry>();
			vDDrawEntry.entityName = GetEntityReadableName(entity);
			vDDrawEntry.label = label;
			vDDrawEntry.frame = Time.frameCount;
			vDDrawEntry.category = VDDrawEntry.Category.Log;
			vDDrawEntry.message = message;
			SingletonComponent<VDDraw>.Instance.logEntries.Enqueue(vDDrawEntry);
		}
	}

	public static void Line(BaseEntity entity, bool display, string label, Vector3 start, Vector3 end, Color color, float duration = 0f)
	{
		if (entity.IsValid() && SingletonComponent<VDDraw>.Instance._isRecording)
		{
			VDDrawEntry vDDrawEntry = Pool.Get<VDDrawEntry>();
			vDDrawEntry.entityName = GetEntityReadableName(entity);
			vDDrawEntry.label = label;
			vDDrawEntry.frame = Time.frameCount;
			vDDrawEntry.category = VDDrawEntry.Category.Line;
			vDDrawEntry.start = start;
			vDDrawEntry.end = end;
			vDDrawEntry.color = color;
			SingletonComponent<VDDraw>.Instance.logEntries.Enqueue(vDDrawEntry);
		}
	}

	public static void Text(BaseEntity entity, bool display, string label, string message, Vector3 position, Color color, float duration = 0f, float scaleMulti = 1f)
	{
		if (entity.IsValid() && SingletonComponent<VDDraw>.Instance._isRecording)
		{
			VDDrawEntry vDDrawEntry = Pool.Get<VDDrawEntry>();
			vDDrawEntry.entityName = GetEntityReadableName(entity);
			vDDrawEntry.label = label;
			vDDrawEntry.frame = Time.frameCount;
			vDDrawEntry.category = VDDrawEntry.Category.Text;
			vDDrawEntry.start = position;
			vDDrawEntry.message = message;
			vDDrawEntry.color = color;
			SingletonComponent<VDDraw>.Instance.logEntries.Enqueue(vDDrawEntry);
		}
	}

	public static void Sphere(BaseEntity entity, bool display, string label, Vector3 position, float size, Color color, float duration = 0f)
	{
		if (entity.IsValid() && SingletonComponent<VDDraw>.Instance._isRecording)
		{
			VDDrawEntry vDDrawEntry = Pool.Get<VDDrawEntry>();
			vDDrawEntry.entityName = GetEntityReadableName(entity);
			vDDrawEntry.label = label;
			vDDrawEntry.frame = Time.frameCount;
			vDDrawEntry.category = VDDrawEntry.Category.Sphere;
			vDDrawEntry.start = position;
			vDDrawEntry.sizeX = size;
			vDDrawEntry.color = color;
			SingletonComponent<VDDraw>.Instance.logEntries.Enqueue(vDDrawEntry);
		}
	}

	public static void Box(BaseEntity entity, bool display, string label, Vector3 center, Quaternion rotation, Vector3 size, Color color, float duration = 0f)
	{
		if (entity.IsValid() && SingletonComponent<VDDraw>.Instance._isRecording)
		{
			VDDrawEntry vDDrawEntry = Pool.Get<VDDrawEntry>();
			vDDrawEntry.entityName = GetEntityReadableName(entity);
			vDDrawEntry.label = label;
			vDDrawEntry.frame = Time.frameCount;
			vDDrawEntry.category = VDDrawEntry.Category.Box;
			vDDrawEntry.start = center;
			vDDrawEntry.end = rotation * Vector3.forward;
			vDDrawEntry.sizeX = size.x;
			vDDrawEntry.sizeY = size.y;
			vDDrawEntry.sizeZ = size.z;
			vDDrawEntry.color = color;
			SingletonComponent<VDDraw>.Instance.logEntries.Enqueue(vDDrawEntry);
		}
	}

	private static string GetNewLogFilePath()
	{
		string text = DateTime.Now.ToString("yyyyMMdd_HHmmss");
		return Path.Combine(logDirectoryPath, "VDDraw_" + text + ".vddraw");
	}

	public static string GetLastLogFilePath()
	{
		List<FileInfo> list = (from f in new DirectoryInfo(logDirectoryPath).GetFiles("VDDraw_*")
			orderby f.CreationTime
			select f).ToList();
		if (list.Count == 0)
		{
			return null;
		}
		return list.Last().FullName;
	}

	private void CompressCurrentLog()
	{
		using (TimeWarning.New("VDDraw:CompressCurrentLog"))
		{
			string lastLogFilePath = GetLastLogFilePath();
			byte[] data = File.ReadAllBytes(lastLogFilePath);
			File.WriteAllBytes(bytes: Compression.Compress(data), path: lastLogFilePath + ".gz");
			File.Delete(lastLogFilePath);
		}
	}

	private void SaveLogs()
	{
		using (TimeWarning.New("VDDraw:SaveLogs"))
		{
			using FileStream stream = new FileStream(currentLogPath, FileMode.Append, FileAccess.Write, FileShare.None, 4096, useAsync: true);
			VDDrawEntry result;
			while (logEntries.TryDequeue(out result))
			{
				VDDrawEntry.SerializeLengthDelimited(stream, result);
				Pool.Free(ref result);
			}
		}
	}

	private static void ManageLogFiles()
	{
		List<FileInfo> list = (from f in new DirectoryInfo(logDirectoryPath).GetFiles("VDDraw_*")
			orderby f.CreationTime
			select f).ToList();
		if (list.Count > 10)
		{
			int num = list.Count - 10;
			for (int i = 0; i < num; i++)
			{
				Debug.Log("Deleting log file: " + list[i].FullName);
				list[i].Delete();
			}
		}
	}

	public static string GetEntityReadableName(BaseEntity entity)
	{
		string text = entity.GetType().Name;
		NetworkableId iD = entity.net.ID;
		return text + "_" + iD.ToString();
	}
}
