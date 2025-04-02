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
		if ((bool)TerrainMeta.HeightMap)
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
