using UnityEngine;

public class TerrainHeightSet : TerrainModifier
{
	public enum Mode
	{
		Set,
		Raise,
		Lower
	}

	public Mode HeightMode;

	protected override void Apply(Vector3 position, float opacity, float radius, float fade)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)TerrainMeta.HeightMap))
		{
			switch (HeightMode)
			{
			case Mode.Set:
				TerrainMeta.HeightMap.SetHeight(position, opacity, radius, fade);
				break;
			case Mode.Raise:
				TerrainMeta.HeightMap.RaiseHeight(position, opacity, radius, fade);
				break;
			case Mode.Lower:
				TerrainMeta.HeightMap.LowerHeight(position, opacity, radius, fade);
				break;
			}
		}
	}
}
