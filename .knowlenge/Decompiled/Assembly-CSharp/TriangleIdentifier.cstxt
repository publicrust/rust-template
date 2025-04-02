using UnityEngine;

public class TriangleIdentifier : MonoBehaviour
{
	public int TriangleID;

	public int SubmeshID;

	public float LineLength = 1.5f;

	private void OnDrawGizmosSelected()
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		MeshFilter component = ((Component)this).GetComponent<MeshFilter>();
		if (!((Object)(object)component == (Object)null) && !((Object)(object)component.sharedMesh == (Object)null))
		{
			int[] triangles = component.sharedMesh.GetTriangles(SubmeshID);
			if (TriangleID >= 0 && TriangleID * 3 <= triangles.Length)
			{
				Gizmos.matrix = ((Component)this).transform.localToWorldMatrix;
				Vector3 val = component.sharedMesh.vertices[TriangleID * 3];
				Vector3 val2 = component.sharedMesh.vertices[TriangleID * 3 + 1];
				Vector3 val3 = component.sharedMesh.vertices[TriangleID * 3 + 2];
				Vector3 val4 = component.sharedMesh.normals[TriangleID * 3];
				Vector3 val5 = component.sharedMesh.normals[TriangleID * 3 + 1];
				Vector3 val6 = component.sharedMesh.normals[TriangleID * 3 + 2];
				Vector3 val7 = (val + val2 + val3) / 3f;
				Vector3 val8 = (val4 + val5 + val6) / 3f;
				Gizmos.DrawLine(val7, val7 + val8 * LineLength);
			}
		}
	}
}
