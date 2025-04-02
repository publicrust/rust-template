using UnityEngine;

public class TerrainHeightAdd : TerrainModifier
{
	public float Delta = 1f;

	protected override void Apply(Vector3 position, float opacity, float radius, float fade)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)TerrainMeta.HeightMap))
		{
			TerrainMeta.HeightMap.AddHeight(position, opacity * Delta * TerrainMeta.OneOverSize.y, radius, fade);
		}
	}
}
