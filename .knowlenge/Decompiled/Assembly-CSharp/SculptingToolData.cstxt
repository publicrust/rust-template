using System;
using UnityEngine;

public class SculptingToolData : PrefabAttribute
{
	public enum CarvingShapeType
	{
		Cylinder,
		Sphere,
		Rectangle
	}

	[Flags]
	public enum CarvingMode
	{
		Carve = 1,
		Smooth = 2,
		Additive = 4
	}

	public CarvingShapeType CarvingShape;

	public CarvingMode CarvingModes = CarvingMode.Carve | CarvingMode.Smooth | CarvingMode.Additive;

	public Vector2Int CarvingSizeLimits = new Vector2Int(2, 5);

	public bool AllowCarve => (CarvingModes & CarvingMode.Carve) != 0;

	public bool AllowSmooth => (CarvingModes & CarvingMode.Smooth) != 0;

	public bool AllowAdditive => (CarvingModes & CarvingMode.Additive) != 0;

	public int MinCarvingSize => CarvingSizeLimits.x;

	public int MaxCarvingSize => CarvingSizeLimits.y;

	protected override Type GetIndexedType()
	{
		return typeof(SculptingToolData);
	}
}
