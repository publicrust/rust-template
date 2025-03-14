using UnityEngine;

public class SocketMod_AngleCheck : SocketMod
{
	public bool wantsAngle = true;

	public Vector3 worldNormal = Vector3.up;

	public float withinDegrees = 45f;

	public bool usePlacementNormal;

	protected override Translate.Phrase ErrorPhrase => ConstructionErrors.InvalidAngle;

	public override bool DoCheck(Construction.Placement place)
	{
		Vector3 vector = (usePlacementNormal ? Vector3.forward : Vector3.up);
		float num = worldNormal.DotDegrees(place.rotation * vector);
		if (!usePlacementNormal)
		{
			return num < withinDegrees;
		}
		return num >= withinDegrees;
	}
}
