using UnityEngine;

public class TerrainHeightRaise : TerrainModifier
{
	protected override void Apply(Vector3 position, float opacity, float radius, float fade)
	{
		if ((bool)TerrainMeta.HeightMap)
		{
			TerrainMeta.HeightMap.RaiseHeight(position, opacity, radius, fade);
		}
	}
}
