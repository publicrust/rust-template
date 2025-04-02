using UnityEngine;

public class Socket_Terrain : Socket_Base
{
	public float placementHeight;

	public bool alignToNormal;

	private void OnDrawGizmos()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = Color.red;
		Gizmos.DrawLine(Vector3.zero, Vector3.forward * 0.2f);
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(Vector3.zero, Vector3.right * 0.1f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(Vector3.zero, Vector3.up * 0.1f);
		Gizmos.color = new Color(0f, 1f, 0f, 0.2f);
		Gizmos.DrawCube(Vector3.zero, new Vector3(0.1f, 0.1f, placementHeight));
		Gizmos.color = new Color(0f, 1f, 0f, 0.5f);
		Gizmos.DrawWireCube(Vector3.zero, new Vector3(0.1f, 0.1f, placementHeight));
		Gizmos.DrawIcon(base.transform.position, "light_circle_green.png", allowScaling: false);
	}

	public override bool TestTarget(Construction.Target target)
	{
		return target.onTerrain;
	}

	public override Construction.Placement DoPlacement(Construction.Target target)
	{
		Vector3 eulerAngles = rotation.eulerAngles;
		eulerAngles.x = 0f;
		eulerAngles.z = 0f;
		Vector3 direction = target.ray.direction;
		direction.y = 0f;
		direction.Normalize();
		Vector3 upwards = Vector3.up;
		if (alignToNormal)
		{
			upwards = target.normal;
		}
		Quaternion quaternion = Quaternion.LookRotation(direction, upwards) * Quaternion.Euler(0f, eulerAngles.y, 0f) * Quaternion.Euler(target.rotation);
		Vector3 vector = target.position;
		vector -= quaternion * position;
		Construction.Placement result = new Construction.Placement(target);
		result.rotation = quaternion;
		result.position = vector;
		return result;
	}
}
