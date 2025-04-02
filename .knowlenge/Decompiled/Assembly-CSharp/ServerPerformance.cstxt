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
			((FacepunchBehaviour)this).InvokeRepeating((Action)WriteLine, 1f, 60f);
		}
	}

	private void WriteLine()
	{
		Rust.GC.Collect();
		uint monoUsedSize = Profiler.GetMonoUsedSize();
		uint usedHeapSize = Profiler.usedHeapSize;
		int count = BasePlayer.activePlayerList.Count;
		int count2 = BasePlayer.sleepingPlayerList.Count;
		int num = Object.FindObjectsOfType<GameObject>().Length;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = Time.frameCount - lastFrame;
		File.AppendAllText(fileName, monoUsedSize + "," + usedHeapSize + "," + num7 + "," + count + "," + count2 + "," + NetworkSleep.totalCollidersDisabled + "," + NetworkSleep.totalBehavioursDisabled + "," + num + "," + Object.FindObjectsOfType<Collider>().Length + "," + Object.FindObjectsOfType<Rigidbody>().Length + "," + Object.FindObjectsOfType<BuildingBlock>().Length + "," + num2 + "," + num3 + "," + num4 + "," + num5 + "," + num6 + "," + deaths + "," + spawns + "," + position_changes + "\r\n");
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
		Object[] objects = (Object[])(object)Object.FindObjectsOfType<Transform>();
		ComponentReport(filename, "All Objects", objects);
		string filename2 = text;
		objects = (Object[])(object)Object.FindObjectsOfType<BaseEntity>();
		ComponentReport(filename2, "Entities", objects);
		string filename3 = text;
		objects = (Object[])(object)Object.FindObjectsOfType<Rigidbody>();
		ComponentReport(filename3, "Rigidbodies", objects);
		string filename4 = text;
		objects = (Object[])(object)(from x in Object.FindObjectsOfType<Collider>()
			where !x.enabled
			select x).ToArray();
		ComponentReport(filename4, "Disabled Colliders", objects);
		string filename5 = text;
		objects = (Object[])(object)(from x in Object.FindObjectsOfType<Collider>()
			where x.enabled
			select x).ToArray();
		ComponentReport(filename5, "Enabled Colliders", objects);
		if (Object.op_Implicit((Object)(object)SingletonComponent<SpawnHandler>.Instance))
		{
			SingletonComponent<SpawnHandler>.Instance.DumpReport(text);
		}
	}

	public static string WorkoutPrefabName(GameObject obj)
	{
		if ((Object)(object)obj == (Object)null)
		{
			return "null";
		}
		string text = (obj.activeSelf ? "" : " (inactive)");
		BaseEntity baseEntity = obj.ToBaseEntity();
		if (Object.op_Implicit((Object)(object)baseEntity))
		{
			return baseEntity.PrefabName + text;
		}
		return ((Object)obj).name + text;
	}

	public static void ComponentReport(string filename, string Title, Object[] objects)
	{
		File.AppendAllText(filename, "\r\n\r\n" + Title + ":\r\n\r\n");
		foreach (IGrouping<string, Object> item in from x in objects
			group x by WorkoutPrefabName(((Component)((x is Component) ? x : null)).gameObject) into x
			orderby x.Count() descending
			select x)
		{
			File.AppendAllText(filename, "\t" + WorkoutPrefabName(((Component)/*isinst with value type is only supported in some contexts*/).gameObject) + " - " + item.Count() + "\r\n");
		}
		File.AppendAllText(filename, "\r\nTotal: " + objects.Count() + "\r\n\r\n\r\n");
	}
}
