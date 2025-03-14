using UnityEngine;

public class DecorOffset : DecorComponent
{
	public Vector3 MinOffset = new Vector3(0f, 0f, 0f);

	public Vector3 MaxOffset = new Vector3(0f, 0f, 0f);

	public override void Apply(ref Vector3 pos, ref Quaternion rot, ref Vector3 scale)
	{
		uint seed = pos.Seed(World.Seed) + 1;
		pos.x += scale.x * SeedRandom.Range(ref seed, MinOffset.x, MaxOffset.x);
		pos.y += scale.y * SeedRandom.Range(ref seed, MinOffset.y, MaxOffset.y);
		pos.z += scale.z * SeedRandom.Range(ref seed, MinOffset.z, MaxOffset.z);
	}
}
