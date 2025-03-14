using UnityEngine;

public class TerrainSplatSet : TerrainModifier
{
	public TerrainSplat.Enum SplatType;

	protected override void Apply(Vector3 position, float opacity, float radius, float fade)
	{
		if ((bool)TerrainMeta.SplatMap)
		{
			TerrainMeta.SplatMap.SetSplat(position, (int)SplatType, opacity, radius, fade);
		}
	}
}
