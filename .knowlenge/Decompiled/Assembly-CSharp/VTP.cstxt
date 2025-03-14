using UnityEngine;

public class VTP : MonoBehaviour
{
	public static Color getSingleVertexColorAtHit(Transform transform, RaycastHit hit)
	{
		Vector3[] vertices = transform.GetComponent<MeshFilter>().sharedMesh.vertices;
		int[] triangles = transform.GetComponent<MeshFilter>().sharedMesh.triangles;
		Color[] colors = transform.GetComponent<MeshFilter>().sharedMesh.colors;
		int triangleIndex = hit.triangleIndex;
		float num = float.PositiveInfinity;
		int num2 = 0;
		for (int i = 0; i < 3; i++)
		{
			float num3 = Vector3.Distance(transform.TransformPoint(vertices[triangles[triangleIndex * 3 + i]]), hit.point);
			if (num3 < num)
			{
				num2 = triangles[triangleIndex * 3 + i];
				num = num3;
			}
		}
		return colors[num2];
	}

	public static Color getFaceVerticesColorAtHit(Transform transform, RaycastHit hit)
	{
		int[] triangles = transform.GetComponent<MeshFilter>().sharedMesh.triangles;
		Color[] colors = transform.GetComponent<MeshFilter>().sharedMesh.colors;
		int triangleIndex = hit.triangleIndex;
		int num = triangles[triangleIndex * 3];
		return (colors[num] + colors[num + 1] + colors[num + 2]) / 3f;
	}

	public static void paintSingleVertexOnHit(Transform transform, RaycastHit hit, Color color, float strength)
	{
		Vector3[] vertices = transform.GetComponent<MeshFilter>().sharedMesh.vertices;
		int[] triangles = transform.GetComponent<MeshFilter>().sharedMesh.triangles;
		Color[] colors = transform.GetComponent<MeshFilter>().sharedMesh.colors;
		int triangleIndex = hit.triangleIndex;
		float num = float.PositiveInfinity;
		int num2 = 0;
		for (int i = 0; i < 3; i += 3)
		{
			float num3 = Vector3.Distance(transform.TransformPoint(vertices[triangles[triangleIndex * 3 + i]]), hit.point);
			if (num3 < num)
			{
				num2 = triangles[triangleIndex * 3 + i];
				num = num3;
			}
		}
		Color color2 = VertexColorLerp(colors[num2], color, strength);
		colors[num2] = color2;
		transform.GetComponent<MeshFilter>().sharedMesh.colors = colors;
	}

	public static void paintFaceVerticesOnHit(Transform transform, RaycastHit hit, Color color, float strength)
	{
		int[] triangles = transform.GetComponent<MeshFilter>().sharedMesh.triangles;
		Color[] colors = transform.GetComponent<MeshFilter>().sharedMesh.colors;
		int triangleIndex = hit.triangleIndex;
		int num = 0;
		for (int i = 0; i < 3; i++)
		{
			num = triangles[triangleIndex * 3 + i];
			Color color2 = VertexColorLerp(colors[num], color, strength);
			colors[num] = color2;
		}
		transform.GetComponent<MeshFilter>().sharedMesh.colors = colors;
	}

	public static void deformSingleVertexOnHit(Transform transform, RaycastHit hit, bool up, float strength, bool recalculateNormals, bool recalculateCollider, bool recalculateFlow)
	{
		Vector3[] vertices = transform.GetComponent<MeshFilter>().sharedMesh.vertices;
		int[] triangles = transform.GetComponent<MeshFilter>().sharedMesh.triangles;
		Vector3[] normals = transform.GetComponent<MeshFilter>().sharedMesh.normals;
		int triangleIndex = hit.triangleIndex;
		float num = float.PositiveInfinity;
		int num2 = 0;
		for (int i = 0; i < 3; i++)
		{
			float num3 = Vector3.Distance(transform.TransformPoint(vertices[triangles[triangleIndex * 3 + i]]), hit.point);
			if (num3 < num)
			{
				num2 = triangles[triangleIndex * 3 + i];
				num = num3;
			}
		}
		int num4 = 1;
		if (!up)
		{
			num4 = -1;
		}
		vertices[num2] += (float)num4 * 0.1f * strength * normals[num2];
		transform.GetComponent<MeshFilter>().sharedMesh.vertices = vertices;
		if (recalculateNormals)
		{
			transform.GetComponent<MeshFilter>().sharedMesh.RecalculateNormals();
		}
		if (recalculateCollider)
		{
			transform.GetComponent<MeshCollider>().sharedMesh = transform.GetComponent<MeshFilter>().sharedMesh;
		}
		if (recalculateFlow)
		{
			Vector4[] array = calculateMeshTangents(triangles, vertices, transform.GetComponent<MeshCollider>().sharedMesh.uv, normals);
			transform.GetComponent<MeshCollider>().sharedMesh.tangents = array;
			recalculateMeshForFlow(transform, vertices, normals, array);
		}
	}

	public static void deformFaceVerticesOnHit(Transform transform, RaycastHit hit, bool up, float strength, bool recalculateNormals, bool recalculateCollider, bool recalculateFlow)
	{
		Vector3[] vertices = transform.GetComponent<MeshFilter>().sharedMesh.vertices;
		int[] triangles = transform.GetComponent<MeshFilter>().sharedMesh.triangles;
		Vector3[] normals = transform.GetComponent<MeshFilter>().sharedMesh.normals;
		int triangleIndex = hit.triangleIndex;
		int num = 0;
		int num2 = 1;
		if (!up)
		{
			num2 = -1;
		}
		for (int i = 0; i < 3; i++)
		{
			num = triangles[triangleIndex * 3 + i];
			vertices[num] += (float)num2 * 0.1f * strength * normals[num];
		}
		transform.GetComponent<MeshFilter>().sharedMesh.vertices = vertices;
		if (recalculateNormals)
		{
			transform.GetComponent<MeshFilter>().sharedMesh.RecalculateNormals();
		}
		if (recalculateCollider)
		{
			transform.GetComponent<MeshCollider>().sharedMesh = transform.GetComponent<MeshFilter>().sharedMesh;
		}
		if (recalculateFlow)
		{
			Vector4[] array = calculateMeshTangents(triangles, vertices, transform.GetComponent<MeshCollider>().sharedMesh.uv, normals);
			transform.GetComponent<MeshCollider>().sharedMesh.tangents = array;
			recalculateMeshForFlow(transform, vertices, normals, array);
		}
	}

	private static void recalculateMeshForFlow(Transform transform, Vector3[] currentVertices, Vector3[] currentNormals, Vector4[] currentTangents)
	{
		Vector2[] uv = transform.GetComponent<MeshFilter>().sharedMesh.uv4;
		for (int i = 0; i < currentVertices.Length; i++)
		{
			Vector3 vector = transform.TransformDirection(Vector3.Cross(currentNormals[i], new Vector3(currentTangents[i].x, currentTangents[i].y, currentTangents[i].z)).normalized * currentTangents[i].w);
			float x = 0.5f + 0.5f * transform.TransformDirection(currentTangents[i].normalized).y;
			float y = 0.5f + 0.5f * vector.y;
			uv[i] = new Vector2(x, y);
		}
		transform.GetComponent<MeshFilter>().sharedMesh.uv4 = uv;
	}

	private static Vector4[] calculateMeshTangents(int[] triangles, Vector3[] vertices, Vector2[] uv, Vector3[] normals)
	{
		int num = triangles.Length;
		int num2 = vertices.Length;
		Vector3[] array = new Vector3[num2];
		Vector3[] array2 = new Vector3[num2];
		Vector4[] array3 = new Vector4[num2];
		for (long num3 = 0L; num3 < num; num3 += 3)
		{
			long num4 = triangles[num3];
			long num5 = triangles[num3 + 1];
			long num6 = triangles[num3 + 2];
			Vector3 vector = vertices[num4];
			Vector3 vector2 = vertices[num5];
			Vector3 vector3 = vertices[num6];
			Vector2 vector4 = uv[num4];
			Vector2 vector5 = uv[num5];
			Vector2 vector6 = uv[num6];
			float num7 = vector2.x - vector.x;
			float num8 = vector3.x - vector.x;
			float num9 = vector2.y - vector.y;
			float num10 = vector3.y - vector.y;
			float num11 = vector2.z - vector.z;
			float num12 = vector3.z - vector.z;
			float num13 = vector5.x - vector4.x;
			float num14 = vector6.x - vector4.x;
			float num15 = vector5.y - vector4.y;
			float num16 = vector6.y - vector4.y;
			float num17 = num13 * num16 - num14 * num15;
			float num18 = ((num17 == 0f) ? 0f : (1f / num17));
			Vector3 vector7 = new Vector3((num16 * num7 - num15 * num8) * num18, (num16 * num9 - num15 * num10) * num18, (num16 * num11 - num15 * num12) * num18);
			Vector3 vector8 = new Vector3((num13 * num8 - num14 * num7) * num18, (num13 * num10 - num14 * num9) * num18, (num13 * num12 - num14 * num11) * num18);
			array[num4] += vector7;
			array[num5] += vector7;
			array[num6] += vector7;
			array2[num4] += vector8;
			array2[num5] += vector8;
			array2[num6] += vector8;
		}
		for (long num19 = 0L; num19 < num2; num19++)
		{
			Vector3 normal = normals[num19];
			Vector3 tangent = array[num19];
			Vector3.OrthoNormalize(ref normal, ref tangent);
			array3[num19].x = tangent.x;
			array3[num19].y = tangent.y;
			array3[num19].z = tangent.z;
			array3[num19].w = ((Vector3.Dot(Vector3.Cross(normal, tangent), array2[num19]) < 0f) ? (-1f) : 1f);
		}
		return array3;
	}

	public static Color VertexColorLerp(Color colorA, Color colorB, float value)
	{
		if (value >= 1f)
		{
			return colorB;
		}
		if (value <= 0f)
		{
			return colorA;
		}
		return new Color(colorA.r + (colorB.r - colorA.r) * value, colorA.g + (colorB.g - colorA.g) * value, colorA.b + (colorB.b - colorA.b) * value, colorA.a + (colorB.a - colorA.a) * value);
	}
}
