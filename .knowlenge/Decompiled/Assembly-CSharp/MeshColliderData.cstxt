using System.Collections.Generic;
using ConVar;
using Facepunch;
using UnityEngine;

public class MeshColliderData
{
	public List<int> triangles;

	public List<Vector3> vertices;

	public List<Vector3> normals;

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
				Debug.LogWarning("Skipping collider normals because some meshes were missing them.");
			}
		}
	}

	public void Combine(MeshColliderGroup meshGroup)
	{
		for (int i = 0; i < meshGroup.Count; i++)
		{
			MeshColliderInstance meshColliderInstance = meshGroup[i];
			Matrix4x4 matrix4x = Matrix4x4.TRS(meshColliderInstance.position, meshColliderInstance.rotation, meshColliderInstance.scale);
			int count = vertices.Count;
			for (int j = 0; j < meshColliderInstance.data.triangles.Length; j++)
			{
				triangles.Add(count + meshColliderInstance.data.triangles[j]);
			}
			for (int k = 0; k < meshColliderInstance.data.vertices.Length; k++)
			{
				vertices.Add(matrix4x.MultiplyPoint3x4(meshColliderInstance.data.vertices[k]));
			}
			for (int l = 0; l < meshColliderInstance.data.normals.Length; l++)
			{
				normals.Add(matrix4x.MultiplyVector(meshColliderInstance.data.normals[l]));
			}
		}
	}

	public void Combine(MeshColliderGroup meshGroup, MeshColliderLookup colliderLookup)
	{
		for (int i = 0; i < meshGroup.Count; i++)
		{
			MeshColliderInstance instance = meshGroup[i];
			Matrix4x4 matrix4x = Matrix4x4.TRS(instance.position, instance.rotation, instance.scale);
			int count = vertices.Count;
			for (int j = 0; j < instance.data.triangles.Length; j++)
			{
				triangles.Add(count + instance.data.triangles[j]);
			}
			for (int k = 0; k < instance.data.vertices.Length; k++)
			{
				vertices.Add(matrix4x.MultiplyPoint3x4(instance.data.vertices[k]));
			}
			for (int l = 0; l < instance.data.normals.Length; l++)
			{
				normals.Add(matrix4x.MultiplyVector(instance.data.normals[l]));
			}
			colliderLookup.Add(instance);
		}
	}
}
