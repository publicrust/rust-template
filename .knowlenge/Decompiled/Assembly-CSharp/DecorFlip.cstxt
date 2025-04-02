using UnityEngine;

public class DecorFlip : DecorComponent
{
	public enum AxisType
	{
		X,
		Y,
		Z
	}

	public AxisType FlipAxis = AxisType.Y;

	public override void Apply(ref Vector3 pos, ref Quaternion rot, ref Vector3 scale)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		uint num = SeedEx.Seed(pos, World.Seed) + 4;
		if (!(SeedRandom.Value(ref num) > 0.5f))
		{
			switch (FlipAxis)
			{
			case AxisType.X:
			case AxisType.Z:
				rot = Quaternion.AngleAxis(180f, rot * Vector3.up) * rot;
				break;
			case AxisType.Y:
				rot = Quaternion.AngleAxis(180f, rot * Vector3.forward) * rot;
				break;
			}
		}
	}
}
