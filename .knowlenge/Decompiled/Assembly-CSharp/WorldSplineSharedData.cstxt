using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Vehicles/WorldSpline Shared Data", fileName = "WorldSpline Prefab Shared Data")]
public class WorldSplineSharedData : ScriptableObject
{
	[SerializeField]
	private List<WorldSplineData> dataList;

	public static WorldSplineSharedData instance;

	private static string[] worldSplineFolders = new string[2] { "Assets/Content/Structures", "Assets/bundled/Prefabs/autospawn" };

	[RuntimeInitializeOnLoadMethod]
	private static void Init()
	{
		instance = Resources.Load<WorldSplineSharedData>("WorldSpline Prefab Shared Data");
	}

	public static bool TryGetDataFor(WorldSpline worldSpline, out WorldSplineData data)
	{
		if (instance == null)
		{
			Debug.LogError("No instance of WorldSplineSharedData found.");
			data = null;
			return false;
		}
		if (worldSpline.dataIndex < 0 || worldSpline.dataIndex >= instance.dataList.Count)
		{
			data = null;
			return false;
		}
		data = instance.dataList[worldSpline.dataIndex];
		return true;
	}
}
