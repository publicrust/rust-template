using System.Collections.Generic;
using UnityEngine;

public static class TutorialIslandSpawner
{
	public static List<Vector3> GetEdgeSpawnPoints(Vector3 start, Vector3 bounds, Vector3 cellSize, int loopCount, out Bounds worldBoundsMinusTutorialIslands)
	{
		List<Vector3> list = new List<Vector3>();
		for (int i = 0; i < loopCount; i++)
		{
			list.AddRange(GetEdgeSpawnPoints(start, bounds, cellSize, i));
		}
		worldBoundsMinusTutorialIslands = new Bounds(start + bounds / 2f, bounds - cellSize * 2f * loopCount);
		worldBoundsMinusTutorialIslands.size = new Vector3(worldBoundsMinusTutorialIslands.size.x, 1000f, worldBoundsMinusTutorialIslands.size.z);
		return list;
	}

	public static List<Vector3> GetEdgeSpawnPoints(Vector3 start, Vector3 bounds, Vector3 cellSize, int curLoop)
	{
		List<Vector3> list = new List<Vector3>();
		bounds -= cellSize * 2f * curLoop;
		start += cellSize * curLoop;
		Vector3 vector = start + bounds - cellSize / 2f;
		int num = (int)(bounds.x / cellSize.x);
		int num2 = (int)(bounds.z / cellSize.z);
		Vector3 item = start + cellSize / 2f;
		for (int i = 0; i < num; i++)
		{
			list.Add(item);
			list.Add(new Vector3(item.x, 0f, vector.z));
			item += new Vector3(cellSize.x, 0f, 0f);
		}
		item = start + cellSize / 2f + new Vector3(0f, 0f, cellSize.z);
		for (int j = 1; j < num2 - 1; j++)
		{
			list.Add(item);
			list.Add(new Vector3(vector.x, 0f, item.z));
			item += new Vector3(0f, 0f, cellSize.z);
		}
		return list;
	}
}
