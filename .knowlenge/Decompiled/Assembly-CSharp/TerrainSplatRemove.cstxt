using UnityEngine;

public class TerrainSplatRemove : TerrainModifier
{
	public Enum SplatType;

	protected override void Apply(Vector3 position, float opacity, float radius, float fade)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected I4, but got Unknown
		if (Object.op_Implicit((Object)(object)TerrainMeta.SplatMap) && Object.op_Implicit((Object)(object)TerrainMeta.TopologyMap) && !TerrainMeta.TopologyMap.GetTopology(position, 8388608))
		{
			TerrainMeta.SplatMap.RemoveSplat(position, (int)SplatType, opacity, radius, fade);
		}
	}
}
