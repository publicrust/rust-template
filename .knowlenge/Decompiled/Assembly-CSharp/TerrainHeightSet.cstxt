using UnityEngine;

public class TerrainHeightSet : TerrainModifier
{
	protected override void Apply(Vector3 position, float opacity, float radius, float fade)
	{
		if ((bool)TerrainMeta.HeightMap)
		{
			TerrainMeta.HeightMap.SetHeight(position, opacity, radius, fade);
		}
	}
}
