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
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		Gizmos.matrix = ((Component)this).transform.localToWorldMatrix;
		Gizmos.color = Color.red;
		Gizmos.DrawLine(Vector3.zero, Vector3.forward * 0.2f);
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(Vector3.zero, Vector3.right * 0.1f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(Vector3.zero, Vector3.up * 0.1f);
		Gizmos.DrawIcon(((Component)this).transform.position, "light_circle_green.png", false);
	}

	private void OnDrawGizmosSelected()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		Gizmos.matrix = ((Component)this).transform.localToWorldMatrix;
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
