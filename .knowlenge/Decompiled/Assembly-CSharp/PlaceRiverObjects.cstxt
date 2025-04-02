using System.Collections.Generic;
using UnityEngine.Serialization;

public class PlaceRiverObjects : ProceduralComponent
{
	public PathList.BasicObject[] Start;

	public PathList.BasicObject[] End;

	[FormerlySerializedAs("RiversideObjects")]
	public PathList.SideObject[] Side;

	[FormerlySerializedAs("RiverObjects")]
	public PathList.PathObject[] Path;

	public override void Process(uint seed)
	{
		List<PathList> rivers = TerrainMeta.Path.Rivers;
		if (World.Networked)
		{
			foreach (PathList item in rivers)
			{
				World.Spawn(item.Name, "assets/bundled/prefabs/autospawn/");
			}
			return;
		}
		foreach (PathList item2 in rivers)
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
			PathList.PathObject[] path = Path;
			foreach (PathList.PathObject obj4 in path)
			{
				item2.SpawnAlong(ref seed, obj4);
			}
			PathList.SideObject[] side = Side;
			foreach (PathList.SideObject obj5 in side)
			{
				item2.SpawnSide(ref seed, obj5);
			}
			start = End;
			foreach (PathList.BasicObject obj6 in start)
			{
				item2.SpawnEnd(ref seed, obj6);
			}
			item2.ResetTrims();
		}
	}
}
