using UnityEngine;

public class DecorAlign : DecorComponent
{
	public float NormalAlignment = 1f;

	public float GradientAlignment = 1f;

	public Vector3 SlopeOffset = Vector3.zero;

	public Vector3 SlopeScale = Vector3.one;

	public override void Apply(ref Vector3 pos, ref Quaternion rot, ref Vector3 scale)
	{
		Vector3 normal = TerrainMeta.HeightMap.GetNormal(pos);
		Vector3 vector = ((normal == Vector3.up) ? Vector3.forward : Vector3.Cross(normal, Vector3.up));
		Vector3 vector2 = Vector3.Cross(normal, vector);
		if (SlopeOffset != Vector3.zero || SlopeScale != Vector3.one)
		{
			float slope = TerrainMeta.HeightMap.GetSlope01(pos);
			if (SlopeOffset != Vector3.zero)
			{
				Vector3 vector3 = SlopeOffset * slope;
				pos += vector3.x * vector;
				pos += vector3.y * normal;
				pos -= vector3.z * vector2;
			}
			if (SlopeScale != Vector3.one)
			{
				Vector3 vector4 = Vector3.Lerp(Vector3.one, Vector3.one + Quaternion.Inverse(rot) * (SlopeScale - Vector3.one), slope);
				scale.x *= vector4.x;
				scale.y *= vector4.y;
				scale.z *= vector4.z;
			}
		}
		Vector3 up = Vector3.Lerp(rot * Vector3.up, normal, NormalAlignment);
		Vector3 forward = Vector3.Lerp(rot * Vector3.forward, vector2, GradientAlignment);
		rot = QuaternionEx.LookRotationForcedUp(forward, up);
	}
}
