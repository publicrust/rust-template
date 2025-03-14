using System.Diagnostics;
using UnityEngine;

public struct Timing
{
	private Stopwatch sw;

	private string name;

	public static Timing Start(string name)
	{
		return new Timing(name);
	}

	public void End()
	{
		if (sw.Elapsed.TotalSeconds > 0.30000001192092896)
		{
			UnityEngine.Debug.Log("[" + sw.Elapsed.TotalSeconds.ToString("0.0") + "s] " + name);
		}
	}

	public Timing(string name)
	{
		sw = Stopwatch.StartNew();
		this.name = name;
	}
}
