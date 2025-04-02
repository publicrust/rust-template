using UnityEngine;

public class DecorSwim : DecorComponent
{
	public override void Apply(ref Vector3 pos, ref Quaternion rot, ref Vector3 scale)
	{
		pos.y = WaterLevel.GetWaterSurface(pos, waves: false, volumes: false);
		if (pos.y <= TerrainMeta.Position.y + 1f)
		{
			pos.y = 0f;
		}
	}
}
