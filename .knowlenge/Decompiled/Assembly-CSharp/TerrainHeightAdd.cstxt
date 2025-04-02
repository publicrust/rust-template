using UnityEngine;

public class TerrainHeightAdd : TerrainModifier
{
	public float Delta = 1f;

	protected override void Apply(Vector3 position, float opacity, float radius, float fade)
	{
		if ((bool)TerrainMeta.HeightMap)
		{
			TerrainMeta.HeightMap.AddHeight(position, opacity * Delta * TerrainMeta.OneOverSize.y, radius, fade);
		}
	}
}
