using System.Collections.Generic;
using UnityEngine;

public class WaypointRaceTarget : MonoBehaviour
{
	private static Dictionary<string, Transform> allPoints = new Dictionary<string, Transform>();

	private void Start()
	{
		string text = base.gameObject.name.ToLower();
		if (!allPoints.TryAdd(text, base.transform))
		{
			Debug.Log("Unable to add waypoint marker " + text + ", needs a unique name");
		}
	}

	public static void GetWaypoints(string filter, List<Transform> found, int max = 20)
	{
		string empty = string.Empty;
		for (int i = 0; i < max; i++)
		{
			empty = $"{filter.ToLower()}{i}";
			if (allPoints.TryGetValue(empty, out var value))
			{
				found.Add(value);
			}
		}
	}
}
