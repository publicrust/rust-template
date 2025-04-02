using UnityEngine;

public class DecorTransform : DecorComponent
{
	public Vector3 Position = new Vector3(0f, 0f, 0f);

	public Vector3 Rotation = new Vector3(0f, 0f, 0f);

	public Vector3 Scale = new Vector3(1f, 1f, 1f);

	public override void Apply(ref Vector3 pos, ref Quaternion rot, ref Vector3 scale)
	{
		pos += rot * Vector3.Scale(scale, Position);
		rot = Quaternion.Euler(Rotation) * rot;
		scale = Vector3.Scale(scale, Scale);
	}
}
