using System.Collections.Generic;
using UnityEngine.Serialization;

public class PlaceRoadObjects : ProceduralComponent
{
	public PathList.BasicObject[] Start;

	public PathList.BasicObject[] End;

	[FormerlySerializedAs("RoadsideObjects")]
	public PathList.SideObject[] Side;

	[FormerlySerializedAs("RoadObjects")]
	public PathList.PathObject[] Path;

	public override void Process(uint seed)
	{
		List<PathList> roads = TerrainMeta.Path.Roads;
		if (World.Networked)
		{
			foreach (PathList item in roads)
			{
				World.Spawn(item.Name, "assets/bundled/prefabs/autospawn/");
			}
			return;
		}
		foreach (PathList item2 in roads)
		{
			if (item2.Hierarchy < 2)
			{
				PathList.BasicObject[] start = Start;
				foreach (PathList.BasicObject obj in start)
				{
					item2.TrimStart(obj);
				}
				start = End;
				foreach (PathList.BasicObject obj2 in start)
				{
					item2.TrimEnd(obj2);
				}
				start = Start;
				foreach (PathList.BasicObject obj3 in start)
				{
					item2.SpawnStart(ref seed, obj3);
				}
				start = End;
				foreach (PathList.BasicObject obj4 in start)
				{
					item2.SpawnEnd(ref seed, obj4);
				}
				PathList.PathObject[] path = Path;
				foreach (PathList.PathObject obj5 in path)
				{
					item2.SpawnAlong(ref seed, obj5);
				}
				PathList.SideObject[] side = Side;
				foreach (PathList.SideObject obj6 in side)
				{
					item2.SpawnSide(ref seed, obj6);
				}
				item2.ResetTrims();
			}
		}
	}
}
