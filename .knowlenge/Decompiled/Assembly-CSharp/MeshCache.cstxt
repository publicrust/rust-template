using System;
using System.Collections.Generic;
using UnityEngine;

public static class MeshCache
{
	[Serializable]
	public class Data
	{
		public Mesh mesh;

		public Vector3[] vertices;

		public Vector3[] normals;

		public Vector4[] tangents;

		public Color32[] colors32;

		public int[] triangles;

		public Vector2[] uv;

		public Vector2[] uv2;

		public Vector2[] uv3;

		public Vector2[] uv4;

		public Bounds bounds;
	}

	public static Dictionary<Mesh, Data> dictionary = new Dictionary<Mesh, Data>();

	public static Data Get(Mesh mesh)
	{
		if (!dictionary.TryGetValue(mesh, out var value))
		{
			value = new Data();
			value.mesh = mesh;
			value.vertices = mesh.vertices;
			value.normals = mesh.normals;
			value.tangents = mesh.tangents;
			value.colors32 = mesh.colors32;
			value.triangles = mesh.triangles;
			value.uv = mesh.uv;
			value.uv2 = mesh.uv2;
			value.uv3 = mesh.uv3;
			value.uv4 = mesh.uv4;
			value.bounds = mesh.bounds;
			dictionary.Add(mesh, value);
		}
		return value;
	}
}
