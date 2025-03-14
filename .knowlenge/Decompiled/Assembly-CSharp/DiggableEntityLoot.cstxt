using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/DiggableLoot Spawn")]
public class DiggableEntityLoot : ScriptableObject
{
	[Serializable]
	public struct ItemEntry
	{
		public ItemDefinition Item;

		public int Weight;

		public int Min;

		public int Max;
	}

	public List<ItemEntry> Items = new List<ItemEntry>();

	[InspectorFlags]
	public TerrainBiome.Enum Biomes = (TerrainBiome.Enum)(-1);

	[InspectorFlags]
	public TerrainTopology.Enum Topology = (TerrainTopology.Enum)(-1);

	public bool VerifyLootListForWorldPosition(Vector3 worldPos)
	{
		int num = (TerrainMeta.BiomeMap ? TerrainMeta.BiomeMap.GetBiomeMaxType(worldPos) : 2);
		int num2 = ((!TerrainMeta.TopologyMap) ? 1 : TerrainMeta.TopologyMap.GetTopology(worldPos));
		if (((uint)num & (uint)Biomes) == 0)
		{
			return false;
		}
		if (((uint)num2 & (uint)Topology) == 0)
		{
			return false;
		}
		return true;
	}
}
