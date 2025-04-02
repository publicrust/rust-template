using UnityEngine;

public class TerrainSplatRemove : TerrainModifier
{
	public TerrainSplat.Enum SplatType;

	protected override void Apply(Vector3 position, float opacity, float radius, float fade)
	{
		if ((bool)TerrainMeta.SplatMap && (bool)TerrainMeta.TopologyMap && !TerrainMeta.TopologyMap.GetTopology(position, 8388608))
		{
			TerrainMeta.SplatMap.RemoveSplat(position, (int)SplatType, opacity, radius, fade);
		}
	}
}
