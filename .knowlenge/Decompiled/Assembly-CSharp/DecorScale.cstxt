using UnityEngine;

public class DecorScale : DecorComponent
{
	public Vector3 MinScale = new Vector3(1f, 1f, 1f);

	public Vector3 MaxScale = new Vector3(2f, 2f, 2f);

	public override void Apply(ref Vector3 pos, ref Quaternion rot, ref Vector3 scale)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		uint num = SeedEx.Seed(pos, World.Seed) + 3;
		float num2 = SeedRandom.Value(ref num);
		scale.x *= Mathf.Lerp(MinScale.x, MaxScale.x, num2);
		scale.y *= Mathf.Lerp(MinScale.y, MaxScale.y, num2);
		scale.z *= Mathf.Lerp(MinScale.z, MaxScale.z, num2);
	}
}
