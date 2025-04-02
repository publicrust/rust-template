using UnityEngine;

public class DecorSwim : DecorComponent
{
	public override void Apply(ref Vector3 pos, ref Quaternion rot, ref Vector3 scale)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		pos.y = WaterLevel.GetWaterSurface(pos, waves: false, volumes: false);
		if (pos.y <= TerrainMeta.Position.y + 1f)
		{
			pos.y = 0f;
		}
	}
}
