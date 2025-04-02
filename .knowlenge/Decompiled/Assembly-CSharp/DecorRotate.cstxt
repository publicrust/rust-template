using UnityEngine;

public class DecorRotate : DecorComponent
{
	public Vector3 MinRotation = new Vector3(0f, -180f, 0f);

	public Vector3 MaxRotation = new Vector3(0f, 180f, 0f);

	public override void Apply(ref Vector3 pos, ref Quaternion rot, ref Vector3 scale)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		uint num = SeedEx.Seed(pos, World.Seed) + 2;
		float num2 = SeedRandom.Range(ref num, MinRotation.x, MaxRotation.x);
		float num3 = SeedRandom.Range(ref num, MinRotation.y, MaxRotation.y);
		float num4 = SeedRandom.Range(ref num, MinRotation.z, MaxRotation.z);
		rot = Quaternion.Euler(num2, num3, num4) * rot;
	}
}
