using UnityEngine;

public class Socket_Specific_Female : Socket_Base
{
	public int rotationDegrees;

	public int rotationOffset;

	public string[] allowedMaleSockets;

	public bool parentToBone;

	public string boneName;

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

	private void OnDrawGizmosSelected()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.DrawWireCube(selectCenter, selectSize);
	}

	public bool CanAccept(Socket_Specific socket)
	{
		string[] array = allowedMaleSockets;
		foreach (string text in array)
		{
			if (socket.targetSocketName == text)
			{
				return true;
			}
		}
		return false;
	}

	public override Construction.Placement DoPlacement(Construction.Target target)
	{
		return base.DoPlacement(target);
	}
}
