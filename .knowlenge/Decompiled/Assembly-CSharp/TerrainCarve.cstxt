using UnityEngine;

public class TerrainCarve : TerrainModifier
{
	protected override void Apply(Vector3 position, float opacity, float radius, float fade)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)TerrainMeta.AlphaMap))
		{
			TerrainMeta.AlphaMap.SetAlpha(position, 0f, opacity, radius, fade);
		}
	}
}
