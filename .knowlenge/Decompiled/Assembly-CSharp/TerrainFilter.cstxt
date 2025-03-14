using System;
using UnityEngine;

public class TerrainFilter : PrefabAttribute
{
	public SpawnFilter Filter;

	public bool CheckPlacementMap = true;

	public bool CheckTerrainBounds;

	public float CheckTopologyRadius;

	public bool Check(Vector3 pos)
	{
		if (CheckTerrainBounds && TerrainMeta.OutOfBounds(pos))
		{
			return false;
		}
		return Filter.GetFactor(pos, CheckPlacementMap, CheckTopologyRadius) > 0f;
	}

	protected override Type GetIndexedType()
	{
		return typeof(TerrainFilter);
	}
}
