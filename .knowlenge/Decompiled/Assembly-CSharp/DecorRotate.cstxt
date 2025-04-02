using UnityEngine;

public class DecorRotate : DecorComponent
{
	public Vector3 MinRotation = new Vector3(0f, -180f, 0f);

	public Vector3 MaxRotation = new Vector3(0f, 180f, 0f);

	public override void Apply(ref Vector3 pos, ref Quaternion rot, ref Vector3 scale)
	{
		uint seed = pos.Seed(World.Seed) + 2;
		float x = SeedRandom.Range(ref seed, MinRotation.x, MaxRotation.x);
		float y = SeedRandom.Range(ref seed, MinRotation.y, MaxRotation.y);
		float z = SeedRandom.Range(ref seed, MinRotation.z, MaxRotation.z);
		rot = Quaternion.Euler(x, y, z) * rot;
	}
}
