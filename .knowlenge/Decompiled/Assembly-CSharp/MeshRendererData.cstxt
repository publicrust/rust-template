using System.Collections.Generic;
using ConVar;
using Facepunch;
using UnityEngine;

public class MeshRendererData
{
	public List<int> triangles;

	public List<Vector3> vertices;

	public List<Vector3> normals;

	public List<Vector4> tangents;

	public List<Color32> colors32;

	public List<Vector2> uv;

	public List<Vector2> uv2;

	public List<Vector4> positions;

	public void Alloc()
	{
		if (triangles == null)
		{
			triangles = Facepunch.Pool.Get<List<int>>();
		}
		if (vertices == null)
		{
			vertices = Facepunch.Pool.Get<List<Vector3>>();
		}
		if (normals == null)
		{
			normals = Facepunch.Pool.Get<List<Vector3>>();
		}
		if (tangents == null)
		{
			tangents = Facepunch.Pool.Get<List<Vector4>>();
		}
		if (colors32 == null)
		{
			colors32 = Facepunch.Pool.Get<List<Color32>>();
		}
		if (uv == null)
		{
			uv = Facepunch.Pool.Get<List<Vector2>>();
		}
		if (uv2 == null)
		{
			uv2 = Facepunch.Pool.Get<List<Vector2>>();
		}
		if (positions == null)
		{
			positions = Facepunch.Pool.Get<List<Vector4>>();
		}
	}

	public void Free()
	{
		if (triangles != null)
		{
			Facepunch.Pool.FreeUnmanaged(ref triangles);
		}
		if (vertices != null)
		{
			Facepunch.Pool.FreeUnmanaged(ref vertices);
		}
		if (normals != null)
		{
			Facepunch.Pool.FreeUnmanaged(ref normals);
		}
		if (tangents != null)
		{
			Facepunch.Pool.FreeUnmanaged(ref tangents);
		}
		if (colors32 != null)
		{
			Facepunch.Pool.FreeUnmanaged(ref colors32);
		}
		if (uv != null)
		{
			Facepunch.Pool.FreeUnmanaged(ref uv);
		}
		if (uv2 != null)
		{
			Facepunch.Pool.FreeUnmanaged(ref uv2);
		}
		if (positions != null)
		{
			Facepunch.Pool.FreeUnmanaged(ref positions);
		}
	}

	public void Clear()
	{
		if (triangles != null)
		{
			triangles.Clear();
		}
		if (vertices != null)
		{
			vertices.Clear();
		}
		if (normals != null)
		{
			normals.Clear();
		}
		if (tangents != null)
		{
			tangents.Clear();
		}
		if (colors32 != null)
		{
			colors32.Clear();
		}
		if (uv != null)
		{
			uv.Clear();
		}
		if (uv2 != null)
		{
			uv2.Clear();
		}
		if (positions != null)
		{
			positions.Clear();
		}
	}

	public void Apply(UnityEngine.Mesh mesh)
	{
		mesh.Clear();
		if (vertices != null)
		{
			mesh.SetVertices(vertices);
		}
		if (triangles != null)
		{
			mesh.SetTriangles(triangles, 0);
		}
		if (normals != null)
		{
			if (normals.Count == vertices.Count)
			{
				mesh.SetNormals(normals);
			}
			else if (normals.Count > 0 && Batching.verbose > 0)
			{
				Debug.LogWarning("Skipping renderer normals because some meshes were missing them.");
			}
		}
		if (tangents != null)
		{
			if (tangents.Count == vertices.Count)
			{
				mesh.SetTangents(tangents);
			}
			else if (tangents.Count > 0 && Batching.verbose > 0)
			{
				Debug.LogWarning("Skipping renderer tangents because some meshes were missing them.");
			}
		}
		if (colors32 != null)
		{
			if (colors32.Count == vertices.Count)
			{
				mesh.SetColors(colors32);
			}
			else if (colors32.Count > 0 && Batching.verbose > 0)
			{
				Debug.LogWarning("Skipping renderer colors because some meshes were missing them.");
			}
		}
		if (uv != null)
		{
			if (uv.Count == vertices.Count)
			{
				mesh.SetUVs(0, uv);
			}
			else if (uv.Count > 0 && Batching.verbose > 0)
			{
				Debug.LogWarning("Skipping renderer uvs because some meshes were missing them.");
			}
		}
		if (uv2 != null)
		{
			if (uv2.Count == vertices.Count)
			{
				mesh.SetUVs(1, uv2);
			}
			else if (uv2.Count > 0 && Batching.verbose > 0)
			{
				Debug.LogWarning("Skipping renderer uv2s because some meshes were missing them.");
			}
		}
		if (positions != null)
		{
			mesh.SetUVs(2, positions);
		}
	}

	public void Combine(MeshRendererGroup meshGroup)
	{
		for (int i = 0; i < meshGroup.Count; i++)
		{
			MeshRendererInstance meshRendererInstance = meshGroup[i];
			Matrix4x4 matrix4x = Matrix4x4.TRS(meshRendererInstance.position, meshRendererInstance.rotation, meshRendererInstance.scale);
			int count = vertices.Count;
			for (int j = 0; j < meshRendererInstance.data.triangles.Length; j++)
			{
				triangles.Add(count + meshRendererInstance.data.triangles[j]);
			}
			for (int k = 0; k < meshRendererInstance.data.vertices.Length; k++)
			{
				vertices.Add(matrix4x.MultiplyPoint3x4(meshRendererInstance.data.vertices[k]));
				positions.Add(meshRendererInstance.position);
			}
			for (int l = 0; l < meshRendererInstance.data.normals.Length; l++)
			{
				normals.Add(matrix4x.MultiplyVector(meshRendererInstance.data.normals[l]));
			}
			for (int m = 0; m < meshRendererInstance.data.tangents.Length; m++)
			{
				Vector4 vector = meshRendererInstance.data.tangents[m];
				Vector3 vector2 = new Vector3(vector.x, vector.y, vector.z);
				Vector3 vector3 = matrix4x.MultiplyVector(vector2);
				tangents.Add(new Vector4(vector3.x, vector3.y, vector3.z, vector.w));
			}
			for (int n = 0; n < meshRendererInstance.data.colors32.Length; n++)
			{
				colors32.Add(meshRendererInstance.data.colors32[n]);
			}
			for (int num = 0; num < meshRendererInstance.data.uv.Length; num++)
			{
				uv.Add(meshRendererInstance.data.uv[num]);
			}
			for (int num2 = 0; num2 < meshRendererInstance.data.uv2.Length; num2++)
			{
				uv2.Add(meshRendererInstance.data.uv2[num2]);
			}
		}
	}

	public void Combine(MeshRendererGroup meshGroup, MeshRendererLookup rendererLookup)
	{
		for (int i = 0; i < meshGroup.Count; i++)
		{
			MeshRendererInstance instance = meshGroup[i];
			Matrix4x4 matrix4x = Matrix4x4.TRS(instance.position, instance.rotation, instance.scale);
			int count = vertices.Count;
			for (int j = 0; j < instance.data.triangles.Length; j++)
			{
				triangles.Add(count + instance.data.triangles[j]);
			}
			for (int k = 0; k < instance.data.vertices.Length; k++)
			{
				vertices.Add(matrix4x.MultiplyPoint3x4(instance.data.vertices[k]));
				positions.Add(instance.position);
			}
			for (int l = 0; l < instance.data.normals.Length; l++)
			{
				normals.Add(matrix4x.MultiplyVector(instance.data.normals[l]));
			}
			for (int m = 0; m < instance.data.tangents.Length; m++)
			{
				Vector4 vector = instance.data.tangents[m];
				Vector3 vector2 = new Vector3(vector.x, vector.y, vector.z);
				Vector3 vector3 = matrix4x.MultiplyVector(vector2);
				tangents.Add(new Vector4(vector3.x, vector3.y, vector3.z, vector.w));
			}
			for (int n = 0; n < instance.data.colors32.Length; n++)
			{
				colors32.Add(instance.data.colors32[n]);
			}
			for (int num = 0; num < instance.data.uv.Length; num++)
			{
				uv.Add(instance.data.uv[num]);
			}
			for (int num2 = 0; num2 < instance.data.uv2.Length; num2++)
			{
				uv2.Add(instance.data.uv2[num2]);
			}
			rendererLookup.Add(instance);
		}
	}
}
