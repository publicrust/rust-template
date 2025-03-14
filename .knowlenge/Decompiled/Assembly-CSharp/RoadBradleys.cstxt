using System.Collections.Generic;
using UnityEngine;

public class RoadBradleys : TriggeredEvent
{
	public List<BradleyAPC> spawnedAPCs = new List<BradleyAPC>();

	public int GetNumBradleys()
	{
		CleanList();
		return spawnedAPCs.Count;
	}

	public int GetDesiredNumber()
	{
		return Mathf.CeilToInt((float)World.Size / 1000f) * 2;
	}

	private void CleanList()
	{
		for (int num = spawnedAPCs.Count - 1; num >= 0; num--)
		{
			if (spawnedAPCs[num] == null)
			{
				spawnedAPCs.RemoveAt(num);
			}
		}
	}

	private void RunEvent()
	{
		int numBradleys = GetNumBradleys();
		int num = GetDesiredNumber() - numBradleys;
		if (num <= 0 || TerrainMeta.Path == null || TerrainMeta.Path.Roads.Count == 0)
		{
			return;
		}
		Debug.Log("Spawning :" + num + "Bradleys");
		for (int i = 0; i < num; i++)
		{
			Vector3 zero = Vector3.zero;
			PathList pathList = TerrainMeta.Path.Roads[Random.Range(0, TerrainMeta.Path.Roads.Count)];
			zero = pathList.Path.Points[Random.Range(0, pathList.Path.Points.Length)];
			BradleyAPC bradleyAPC = BradleyAPC.SpawnRoadDrivingBradley(zero, Quaternion.identity);
			if ((bool)bradleyAPC)
			{
				spawnedAPCs.Add(bradleyAPC);
			}
			else
			{
				Debug.Log("Failed to spawn bradley at: " + zero);
			}
		}
	}
}
