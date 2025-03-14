using System.Diagnostics;
using UnityEngine;

public class Profile
{
	public Stopwatch watch = new Stopwatch();

	public string category;

	public string name;

	public float warnTime;

	public Profile(string cat, string nam, float WarnTime = 1f)
	{
		category = cat;
		name = nam;
		warnTime = WarnTime;
	}

	public void Start()
	{
		watch.Reset();
		watch.Start();
	}

	public void Stop()
	{
		watch.Stop();
		if ((float)watch.Elapsed.Seconds > warnTime)
		{
			UnityEngine.Debug.Log(category + "." + name + ": Took " + watch.Elapsed.Seconds + " seconds");
		}
	}
}
