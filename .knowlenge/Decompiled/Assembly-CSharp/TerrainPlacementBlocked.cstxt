using UnityEngine;

public class TerrainPlacementBlocked : TerrainModifier
{
	protected override void Apply(Vector3 position, float opacity, float radius, float fade)
	{
		if ((bool)TerrainMeta.PlacementMap)
		{
			TerrainMeta.PlacementMap.SetBlocked(position, radius, fade);
		}
	}
}
