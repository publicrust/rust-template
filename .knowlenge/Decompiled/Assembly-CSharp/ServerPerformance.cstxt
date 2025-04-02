using System;
using System.IO;
using System.Linq;
using Facepunch;
using Rust;
using UnityEngine;
using UnityEngine.Profiling;

public class ServerPerformance : BaseMonoBehaviour
{
	public static ulong deaths;

	public static ulong spawns;

	public static ulong position_changes;

	private string fileName;

	private int lastFrame;

	private void Start()
	{
		if (Profiler.supported && CommandLine.HasSwitch("-perf"))
		{
			fileName = "perfdata." + DateTime.Now.ToString() + ".txt";
			fileName = fileName.Replace('\\', '-');
			fileName = fileName.Replace('/', '-');
			fileName = fileName.Replace(' ', '_');
			fileName = fileName.Replace(':', '.');
			lastFrame = Time.frameCount;
			File.WriteAllText(fileName, "MemMono,MemUnity,Frame,PlayerCount,Sleepers,CollidersDisabled,BehavioursDisabled,GameObjects,Colliders,RigidBodies,BuildingBlocks,nwSend,nwRcv,cnInit,cnApp,cnRej,deaths,spawns,poschange\r\n");
			InvokeRepeating(WriteLine, 1f, 60f);
		}
	}

	private void WriteLine()
	{
		Rust.GC.Collect();
		uint monoUsedSize = Profiler.GetMonoUsedSize();
		uint usedHeapSize = Profiler.usedHeapSize;
		int count = BasePlayer.activePlayerList.Count;
		int count2 = BasePlayer.sleepingPlayerList.Count;
		int num = UnityEngine.Object.FindObjectsOfType<GameObject>().Length;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = Time.frameCount - lastFrame;
		File.AppendAllText(fileName, monoUsedSize + "," + usedHeapSize + "," + num7 + "," + count + "," + count2 + "," + NetworkSleep.totalCollidersDisabled + "," + NetworkSleep.totalBehavioursDisabled + "," + num + "," + UnityEngine.Object.FindObjectsOfType<Collider>().Length + "," + UnityEngine.Object.FindObjectsOfType<Rigidbody>().Length + "," + UnityEngine.Object.FindObjectsOfType<BuildingBlock>().Length + "," + num2 + "," + num3 + "," + num4 + "," + num5 + "," + num6 + "," + deaths + "," + spawns + "," + position_changes + "\r\n");
		lastFrame = Time.frameCount;
		deaths = 0uL;
		spawns = 0uL;
		position_changes = 0uL;
	}

	public static void DoReport()
	{
		string text = "report." + DateTime.Now.ToString() + ".txt";
		text = text.Replace('\\', '-');
		text = text.Replace('/', '-');
		text = text.Replace(' ', '_');
		text = text.Replace(':', '.');
		File.WriteAllText(text, "Report Generated " + DateTime.Now.ToString() + "\r\n");
		string filename = text;
		UnityEngine.Object[] objects = UnityEngine.Object.FindObjectsOfType<Transform>();
		ComponentReport(filename, "All Objects", objects);
		string filename2 = text;
		objects = UnityEngine.Object.FindObjectsOfType<BaseEntity>();
		ComponentReport(filename2, "Entities", objects);
		string filename3 = text;
		objects = UnityEngine.Object.FindObjectsOfType<Rigidbody>();
		ComponentReport(filename3, "Rigidbodies", objects);
		string filename4 = text;
		objects = (from x in UnityEngine.Object.FindObjectsOfType<Collider>()
			where !x.enabled
			select x).ToArray();
		ComponentReport(filename4, "Disabled Colliders", objects);
		string filename5 = text;
		objects = (from x in UnityEngine.Object.FindObjectsOfType<Collider>()
			where x.enabled
			select x).ToArray();
		ComponentReport(filename5, "Enabled Colliders", objects);
		if ((bool)SingletonComponent<SpawnHandler>.Instance)
		{
			SingletonComponent<SpawnHandler>.Instance.DumpReport(text);
		}
	}

	public static string WorkoutPrefabName(GameObject obj)
	{
		if (obj == null)
		{
			return "null";
		}
		string text = (obj.activeSelf ? "" : " (inactive)");
		BaseEntity baseEntity = GameObjectEx.ToBaseEntity(obj);
		if ((bool)baseEntity)
		{
			return baseEntity.PrefabName + text;
		}
		return obj.name + text;
	}

	public static void ComponentReport(string filename, string Title, UnityEngine.Object[] objects)
	{
		File.AppendAllText(filename, "\r\n\r\n" + Title + ":\r\n\r\n");
		foreach (IGrouping<string, UnityEngine.Object> item in from x in objects
			group x by WorkoutPrefabName((x as Component).gameObject) into x
			orderby x.Count() descending
			select x)
		{
			File.AppendAllText(filename, "\t" + WorkoutPrefabName((item.ElementAt(0) as Component).gameObject) + " - " + item.Count() + "\r\n");
		}
		File.AppendAllText(filename, "\r\nTotal: " + objects.Count() + "\r\n\r\n\r\n");
	}
}
