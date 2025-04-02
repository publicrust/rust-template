using UnityEngine;

public class TerrainCarve : TerrainModifier
{
	protected override void Apply(Vector3 position, float opacity, float radius, float fade)
	{
		if ((bool)TerrainMeta.AlphaMap)
		{
			TerrainMeta.AlphaMap.SetAlpha(position, 0f, opacity, radius, fade);
		}
	}
}
