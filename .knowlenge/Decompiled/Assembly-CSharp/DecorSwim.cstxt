using UnityEngine;

public class DecorSwim : DecorComponent
{
	public override void Apply(ref Vector3 pos, ref Quaternion rot, ref Vector3 scale)
	{
		pos.y = TerrainMeta.WaterMap.GetHeight(pos);
	}
}
