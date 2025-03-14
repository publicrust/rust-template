using System.IO;
using System.Text;
using UnityEngine;

public static class ObjWriter
{
	public static string MeshToString(Mesh mesh)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("g ").Append(mesh.name).Append("\n");
		Vector3[] vertices = mesh.vertices;
		for (int i = 0; i < vertices.Length; i++)
		{
			Vector3 vector = vertices[i];
			stringBuilder.Append($"v {0f - vector.x} {vector.y} {vector.z}\n");
		}
		stringBuilder.Append("\n");
		vertices = mesh.normals;
		for (int i = 0; i < vertices.Length; i++)
		{
			Vector3 vector2 = vertices[i];
			stringBuilder.Append($"vn {0f - vector2.x} {vector2.y} {vector2.z}\n");
		}
		stringBuilder.Append("\n");
		Vector2[] uv = mesh.uv;
		for (int i = 0; i < uv.Length; i++)
		{
			Vector3 vector3 = uv[i];
			stringBuilder.Append($"vt {vector3.x} {vector3.y}\n");
		}
		stringBuilder.Append("\n");
		int[] triangles = mesh.triangles;
		for (int j = 0; j < triangles.Length; j += 3)
		{
			int num = triangles[j] + 1;
			int num2 = triangles[j + 1] + 1;
			int num3 = triangles[j + 2] + 1;
			stringBuilder.Append(string.Format("f {1}/{1}/{1} {0}/{0}/{0} {2}/{2}/{2}\n", num, num2, num3));
		}
		return stringBuilder.ToString();
	}

	public static void Write(Mesh mesh, string path)
	{
		using StreamWriter streamWriter = new StreamWriter(path);
		streamWriter.Write(MeshToString(mesh));
	}
}
