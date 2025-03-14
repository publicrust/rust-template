using System.Collections.Generic;
using UnityEngine;

public class DungeonBaseInfo : LandmarkInfo
{
	public List<GameObject> Links = new List<GameObject>();

	public List<DungeonBaseFloor> Floors = new List<DungeonBaseFloor>();

	public float Distance(Vector3 position)
	{
		return (base.transform.position - position).magnitude;
	}

	public float SqrDistance(Vector3 position)
	{
		return (base.transform.position - position).sqrMagnitude;
	}

	public void Add(DungeonBaseLink link)
	{
		Links.Add(link.gameObject);
		if (link.Type == DungeonBaseLinkType.End)
		{
			return;
		}
		DungeonBaseFloor dungeonBaseFloor = null;
		float num = float.MaxValue;
		for (int i = 0; i < Floors.Count; i++)
		{
			DungeonBaseFloor dungeonBaseFloor2 = Floors[i];
			float num2 = dungeonBaseFloor2.Distance(link.transform.position);
			if (!(num2 >= 1f) && !(num2 >= num))
			{
				dungeonBaseFloor = dungeonBaseFloor2;
				num = num2;
			}
		}
		if (dungeonBaseFloor == null)
		{
			dungeonBaseFloor = new DungeonBaseFloor();
			dungeonBaseFloor.Links.Add(link);
			Floors.Add(dungeonBaseFloor);
			Floors.Sort((DungeonBaseFloor l, DungeonBaseFloor r) => l.SignedDistance(base.transform.position).CompareTo(r.SignedDistance(base.transform.position)));
		}
		else
		{
			dungeonBaseFloor.Links.Add(link);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if ((bool)TerrainMeta.Path)
		{
			TerrainMeta.Path.DungeonBaseEntrances.Add(this);
		}
	}

	protected void Start()
	{
		TransformEx.SetHierarchyGroup(base.transform, "DungeonBase");
	}
}
