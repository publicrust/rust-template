using UnityEngine;

public class WaterResource
{
	public static ItemDefinition GetAtPoint(Vector3 pos)
	{
		return ItemManager.FindItemDefinition(IsFreshWater(pos) ? "water" : "water.salt");
	}

	public static bool IsFreshWater(Vector3 pos)
	{
		if (TerrainMeta.TopologyMap == null)
		{
			return false;
		}
		return TerrainMeta.TopologyMap.GetTopology(pos, 245760);
	}

	public static ItemDefinition Merge(ItemDefinition first, ItemDefinition second)
	{
		if (first == second)
		{
			return first;
		}
		if (first.shortname == "water.salt" || second.shortname == "water.salt")
		{
			return ItemManager.FindItemDefinition("water.salt");
		}
		return ItemManager.FindItemDefinition("water");
	}
}
