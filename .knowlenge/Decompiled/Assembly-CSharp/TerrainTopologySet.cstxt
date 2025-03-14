using UnityEngine;

public class TerrainTopologySet : TerrainModifier
{
	[InspectorFlags]
	public TerrainTopology.Enum TopologyType = TerrainTopology.Enum.Decor;

	protected override void Apply(Vector3 position, float opacity, float radius, float fade)
	{
		if ((bool)TerrainMeta.TopologyMap)
		{
			TerrainMeta.TopologyMap.SetTopology(position, (int)TopologyType, radius, fade);
		}
	}
}
