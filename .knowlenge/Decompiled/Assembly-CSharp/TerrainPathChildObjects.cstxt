using System.Collections.Generic;
using UnityEngine;

public class TerrainPathChildObjects : MonoBehaviour
{
	public bool Spline = true;

	public float Width;

	public float Offset;

	public float Fade;

	[InspectorFlags]
	public TerrainSplat.Enum Splat = TerrainSplat.Enum.Dirt;

	[InspectorFlags]
	public TerrainTopology.Enum Topology = TerrainTopology.Enum.Road;

	public InfrastructureType Type;

	protected void Awake()
	{
		if (!World.Cached && !World.Networked)
		{
			List<Vector3> list = new List<Vector3>();
			foreach (Transform item in base.transform)
			{
				list.Add(item.position);
			}
			if (list.Count >= 2)
			{
				switch (Type)
				{
				case InfrastructureType.Road:
				{
					PathList pathList2 = new PathList("Road " + TerrainMeta.Path.Roads.Count, list.ToArray());
					pathList2.Width = Width;
					pathList2.InnerFade = Fade * 0.5f;
					pathList2.OuterFade = Fade * 0.5f;
					pathList2.MeshOffset = Offset * 0.3f;
					pathList2.TerrainOffset = Offset;
					pathList2.Topology = (int)Topology;
					pathList2.Splat = (int)Splat;
					pathList2.Spline = Spline;
					pathList2.Path.RecalculateTangents();
					TerrainMeta.Path.Roads.Add(pathList2);
					break;
				}
				case InfrastructureType.Power:
				{
					PathList pathList = new PathList("Powerline " + TerrainMeta.Path.Powerlines.Count, list.ToArray());
					pathList.Width = Width;
					pathList.InnerFade = Fade * 0.5f;
					pathList.OuterFade = Fade * 0.5f;
					pathList.MeshOffset = Offset * 0.3f;
					pathList.TerrainOffset = Offset;
					pathList.Topology = (int)Topology;
					pathList.Splat = (int)Splat;
					pathList.Spline = Spline;
					pathList.Path.RecalculateTangents();
					TerrainMeta.Path.Powerlines.Add(pathList);
					break;
				}
				}
			}
		}
		GameManager.Destroy(base.gameObject);
	}

	protected void OnDrawGizmos()
	{
		bool flag = false;
		Vector3 a = Vector3.zero;
		foreach (Transform item in base.transform)
		{
			Vector3 position = item.position;
			if (flag)
			{
				Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 1f);
				GizmosUtil.DrawWirePath(a, position, 0.5f * Width);
			}
			a = position;
			flag = true;
		}
	}
}
