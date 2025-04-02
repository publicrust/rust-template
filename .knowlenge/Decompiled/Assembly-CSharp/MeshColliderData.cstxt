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
			triangles = Pool.Get<List<int>>();
		}
		if (vertices == null)
		{
			vertices = Pool.Get<List<Vector3>>();
		}
		if (normals == null)
		{
			normals = Pool.Get<List<Vector3>>();
		}
	}

	public void Free()
	{
		if (triangles != null)
		{
			Pool.FreeUnmanaged<int>(ref triangles);
		}
		if (vertices != null)
		{
			Pool.FreeUnmanaged<Vector3>(ref vertices);
		}
		if (normals != null)
		{
			Pool.FreeUnmanaged<Vector3>(ref normals);
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

	public void Apply(Mesh mesh)
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
				Debug.LogWarning((object)"Skipping collider normals because some meshes were missing them.");
			}
		}
	}

	public void Combine(MeshColliderGroup meshGroup)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < ((List<MeshColliderInstance>)(object)meshGroup).Count; i++)
		{
			MeshColliderInstance meshColliderInstance = ((List<MeshColliderInstance>)(object)meshGroup)[i];
			Matrix4x4 val = Matrix4x4.TRS(meshColliderInstance.position, meshColliderInstance.rotation, meshColliderInstance.scale);
			int count = vertices.Count;
			for (int j = 0; j < meshColliderInstance.data.triangles.Length; j++)
			{
				triangles.Add(count + meshColliderInstance.data.triangles[j]);
			}
			for (int k = 0; k < meshColliderInstance.data.vertices.Length; k++)
			{
				vertices.Add(((Matrix4x4)(ref val)).MultiplyPoint3x4(meshColliderInstance.data.vertices[k]));
			}
			for (int l = 0; l < meshColliderInstance.data.normals.Length; l++)
			{
				normals.Add(((Matrix4x4)(ref val)).MultiplyVector(meshColliderInstance.data.normals[l]));
			}
		}
	}

	public void Combine(MeshColliderGroup meshGroup, MeshColliderLookup colliderLookup)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < ((List<MeshColliderInstance>)(object)meshGroup).Count; i++)
		{
			MeshColliderInstance instance = ((List<MeshColliderInstance>)(object)meshGroup)[i];
			Matrix4x4 val = Matrix4x4.TRS(instance.position, instance.rotation, instance.scale);
			int count = vertices.Count;
			for (int j = 0; j < instance.data.triangles.Length; j++)
			{
				triangles.Add(count + instance.data.triangles[j]);
			}
			for (int k = 0; k < instance.data.vertices.Length; k++)
			{
				vertices.Add(((Matrix4x4)(ref val)).MultiplyPoint3x4(instance.data.vertices[k]));
			}
			for (int l = 0; l < instance.data.normals.Length; l++)
			{
				normals.Add(((Matrix4x4)(ref val)).MultiplyVector(instance.data.normals[l]));
			}
			colliderLookup.Add(instance);
		}
	}
}
