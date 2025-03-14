using UnityEngine;

[RequireComponent(typeof(DungeonBaseLink))]
public class DungeonBaseLandmarkInfo : LandmarkInfo
{
	private DungeonBaseLink baseLink;

	private MapLayer? layer;

	public override MapLayer MapLayer
	{
		get
		{
			if (layer.HasValue)
			{
				return layer.Value;
			}
			DungeonBaseInfo dungeonBaseInfo = TerrainMeta.Path.FindClosest(TerrainMeta.Path.DungeonBaseEntrances, baseLink.transform.position);
			if (dungeonBaseInfo == null)
			{
				Debug.LogWarning("Couldn't determine which underwater lab a DungeonBaseLandmarkInfo belongs to", this);
				shouldDisplayOnMap = false;
				layer = MapLayer.Overworld;
				return layer.Value;
			}
			int num = -1;
			for (int i = 0; i < dungeonBaseInfo.Floors.Count; i++)
			{
				if (dungeonBaseInfo.Floors[i].Links.Contains(baseLink))
				{
					num = i;
				}
			}
			if (num >= 0)
			{
				layer = (MapLayer)(1 + num);
			}
			else
			{
				Debug.LogWarning("Couldn't determine the floor of a DungeonBaseLandmarkInfo", this);
				shouldDisplayOnMap = false;
				layer = MapLayer.Overworld;
			}
			return layer.Value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		baseLink = GetComponent<DungeonBaseLink>();
	}
}
