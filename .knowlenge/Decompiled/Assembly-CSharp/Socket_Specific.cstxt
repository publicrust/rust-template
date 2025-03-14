using UnityEngine;

public class Socket_Specific : Socket_Base
{
	public bool useFemaleRotation = true;

	public string targetSocketName;

	private void OnDrawGizmos()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = Color.red;
		Gizmos.DrawLine(Vector3.zero, Vector3.forward * 0.2f);
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(Vector3.zero, Vector3.right * 0.1f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(Vector3.zero, Vector3.up * 0.1f);
		Gizmos.DrawIcon(base.transform.position, "light_circle_green.png", allowScaling: false);
	}

	public override bool TestTarget(Construction.Target target)
	{
		if (!base.TestTarget(target))
		{
			return false;
		}
		Socket_Specific_Female socket_Specific_Female = target.socket as Socket_Specific_Female;
		if (socket_Specific_Female == null)
		{
			return false;
		}
		return socket_Specific_Female.CanAccept(this);
	}

	public override Construction.Placement DoPlacement(Construction.Target target)
	{
		Quaternion quaternion = target.socket.rotation;
		if (target.socket.male && target.socket.female)
		{
			quaternion = target.socket.rotation * Quaternion.Euler(180f, 0f, 180f);
		}
		Transform transform = target.entity.transform;
		Vector3 vector = transform.localToWorldMatrix.MultiplyPoint3x4(target.socket.position);
		Quaternion quaternion2;
		if (useFemaleRotation)
		{
			quaternion2 = transform.rotation * quaternion;
		}
		else
		{
			Vector3 vector2 = new Vector3(vector.x, 0f, vector.z);
			Vector3 vector3 = new Vector3(target.player.eyes.position.x, 0f, target.player.eyes.position.z);
			quaternion2 = Quaternion.LookRotation((vector2 - vector3).normalized) * quaternion;
		}
		Construction.Placement placement = new Construction.Placement();
		Quaternion quaternion3 = quaternion2 * Quaternion.Inverse(rotation);
		Vector3 vector4 = quaternion3 * position;
		placement.position = vector - vector4;
		placement.rotation = quaternion3;
		return placement;
	}
}
