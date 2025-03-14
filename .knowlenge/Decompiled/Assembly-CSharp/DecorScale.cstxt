using UnityEngine;

public class DecorScale : DecorComponent
{
	public Vector3 MinScale = new Vector3(1f, 1f, 1f);

	public Vector3 MaxScale = new Vector3(2f, 2f, 2f);

	public override void Apply(ref Vector3 pos, ref Quaternion rot, ref Vector3 scale)
	{
		uint seed = pos.Seed(World.Seed) + 3;
		float t = SeedRandom.Value(ref seed);
		scale.x *= Mathf.Lerp(MinScale.x, MaxScale.x, t);
		scale.y *= Mathf.Lerp(MinScale.y, MaxScale.y, t);
		scale.z *= Mathf.Lerp(MinScale.z, MaxScale.z, t);
	}
}
