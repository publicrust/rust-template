using Facepunch.BurstCloth;
using UnityEngine;

public class BurstClothCollider : MonoBehaviour, IClientComponent
{
	public float Height;

	public float Radius;

	public CapsuleParams GetParams()
	{
		Vector3 position = base.transform.position;
		float num = Height / 2f;
		Vector3 vector = base.transform.rotation * Vector3.up;
		Vector3 position2 = position + vector * num;
		Vector3 position3 = position - vector * num;
		CapsuleParams result = default(CapsuleParams);
		result.Transform = base.transform;
		result.PointA = base.transform.InverseTransformPoint(position2);
		result.PointB = base.transform.InverseTransformPoint(position3);
		result.Radius = Radius;
		return result;
	}
}
