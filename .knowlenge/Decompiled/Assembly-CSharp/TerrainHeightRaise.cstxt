using UnityEngine;

public class TerrainHeightRaise : TerrainModifier
{
	protected override void Apply(Vector3 position, float opacity, float radius, float fade)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)TerrainMeta.HeightMap))
		{
			TerrainMeta.HeightMap.RaiseHeight(position, opacity, radius, fade);
		}
	}
}
