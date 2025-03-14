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
		uint seed = pos.Seed(World.Seed) + 4;
		if (!(SeedRandom.Value(ref seed) > 0.5f))
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
