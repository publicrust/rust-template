using UnityEngine;

public class TerrainTopologyAdd : TerrainModifier
{
	[InspectorFlags]
	public TerrainTopology.Enum TopologyType = TerrainTopology.Enum.Decor;

	protected override void Apply(Vector3 position, float opacity, float radius, float fade)
	{
		if ((bool)TerrainMeta.TopologyMap)
		{
			TerrainMeta.TopologyMap.AddTopology(position, (int)TopologyType, radius, fade);
		}
	}
}
