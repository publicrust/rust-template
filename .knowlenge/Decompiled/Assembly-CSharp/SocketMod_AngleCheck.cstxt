using UnityEngine;

public class SocketMod_AngleCheck : SocketMod
{
	public bool wantsAngle = true;

	public Vector3 worldNormal = Vector3.up;

	public float withinDegrees = 45f;

	protected override Translate.Phrase ErrorPhrase => ConstructionErrors.InvalidAngle;

	public override bool DoCheck(Construction.Placement place)
	{
		if (worldNormal.DotDegrees(place.rotation * Vector3.up) < withinDegrees)
		{
			return true;
		}
		return false;
	}
}
