using System.IO;
using System.Text;
using UnityEngine;

public static class ObjWriter
{
	public static string MeshToString(Mesh mesh)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("g ").Append(((Object)mesh).name).Append("\n");
		Vector3[] vertices = mesh.vertices;
		foreach (Vector3 val in vertices)
		{
			stringBuilder.Append($"v {0f - val.x} {val.y} {val.z}\n");
		}
		stringBuilder.Append("\n");
		vertices = mesh.normals;
		foreach (Vector3 val2 in vertices)
		{
			stringBuilder.Append($"vn {0f - val2.x} {val2.y} {val2.z}\n");
		}
		stringBuilder.Append("\n");
		Vector2[] uv = mesh.uv;
		for (int i = 0; i < uv.Length; i++)
		{
			Vector3 val3 = Vector2.op_Implicit(uv[i]);
			stringBuilder.Append($"vt {val3.x} {val3.y}\n");
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
