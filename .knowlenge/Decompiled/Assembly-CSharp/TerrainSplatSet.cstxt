using UnityEngine;

public class TerrainSplatSet : TerrainModifier
{
	public Enum SplatType;

	protected override void Apply(Vector3 position, float opacity, float radius, float fade)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected I4, but got Unknown
		if (Object.op_Implicit((Object)(object)TerrainMeta.SplatMap))
		{
			TerrainMeta.SplatMap.SetSplat(position, (int)SplatType, opacity, radius, fade);
		}
	}
}
