using UnityEngine;

public class TriangleIdentifier : MonoBehaviour
{
	public int TriangleID;

	public int SubmeshID;

	public float LineLength = 1.5f;

	private void OnDrawGizmosSelected()
	{
		MeshFilter component = GetComponent<MeshFilter>();
		if (!(component == null) && !(component.sharedMesh == null))
		{
			int[] triangles = component.sharedMesh.GetTriangles(SubmeshID);
			if (TriangleID >= 0 && TriangleID * 3 <= triangles.Length)
			{
				Gizmos.matrix = base.transform.localToWorldMatrix;
				Vector3 vector = component.sharedMesh.vertices[TriangleID * 3];
				Vector3 vector2 = component.sharedMesh.vertices[TriangleID * 3 + 1];
				Vector3 vector3 = component.sharedMesh.vertices[TriangleID * 3 + 2];
				Vector3 vector4 = component.sharedMesh.normals[TriangleID * 3];
				Vector3 vector5 = component.sharedMesh.normals[TriangleID * 3 + 1];
				Vector3 vector6 = component.sharedMesh.normals[TriangleID * 3 + 2];
				Vector3 vector7 = (vector + vector2 + vector3) / 3f;
				Vector3 vector8 = (vector4 + vector5 + vector6) / 3f;
				Gizmos.DrawLine(vector7, vector7 + vector8 * LineLength);
			}
		}
	}
}
