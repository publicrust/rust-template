using System.Collections.Generic;
using UnityEngine;

public class AIInformationCell
{
	public Bounds BoundingBox;

	public List<AIInformationCell> NeighbourCells = new List<AIInformationCell>();

	public AIInformationCellContents<AIMovePoint> MovePoints = new AIInformationCellContents<AIMovePoint>();

	public AIInformationCellContents<AICoverPoint> CoverPoints = new AIInformationCellContents<AICoverPoint>();

	public int X { get; }

	public int Z { get; }

	public AIInformationCell(Bounds bounds, GameObject root, int x, int z)
	{
		BoundingBox = bounds;
		X = x;
		Z = z;
		MovePoints.Init(bounds, root);
		CoverPoints.Init(bounds, root);
	}

	public void DebugDraw(Color color, bool points, float scale = 1f)
	{
		Color color2 = Gizmos.color;
		Gizmos.color = color;
		Gizmos.DrawWireCube(BoundingBox.center, BoundingBox.size * scale);
		Gizmos.color = color2;
		if (!points)
		{
			return;
		}
		foreach (AIMovePoint item in MovePoints.Items)
		{
			Gizmos.DrawLine(BoundingBox.center, item.transform.position);
		}
		foreach (AICoverPoint item2 in CoverPoints.Items)
		{
			Gizmos.DrawLine(BoundingBox.center, item2.transform.position);
		}
	}
}
