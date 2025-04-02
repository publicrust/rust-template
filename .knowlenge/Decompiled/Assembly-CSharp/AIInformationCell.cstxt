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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		BoundingBox = bounds;
		X = x;
		Z = z;
		MovePoints.Init(bounds, root);
		CoverPoints.Init(bounds, root);
	}

	public void DebugDraw(Color color, bool points, float scale = 1f)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		Color color2 = Gizmos.color;
		Gizmos.color = color;
		Gizmos.DrawWireCube(((Bounds)(ref BoundingBox)).center, ((Bounds)(ref BoundingBox)).size * scale);
		Gizmos.color = color2;
		if (!points)
		{
			return;
		}
		foreach (AIMovePoint item in MovePoints.Items)
		{
			Gizmos.DrawLine(((Bounds)(ref BoundingBox)).center, ((Component)item).transform.position);
		}
		foreach (AICoverPoint item2 in CoverPoints.Items)
		{
			Gizmos.DrawLine(((Bounds)(ref BoundingBox)).center, ((Component)item2).transform.position);
		}
	}
}
