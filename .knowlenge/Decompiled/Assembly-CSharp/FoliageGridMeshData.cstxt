using System.Collections.Generic;
using Facepunch;
using UnityEngine;
using UnityEngine.Rendering;

public class FoliageGridMeshData
{
	public struct FoliageVertex
	{
		public Vector3 position;

		public Vector3 normal;

		public Vector4 tangent;

		public Color32 color;

		public Vector2 uv;

		public Vector4 uv2;

		public static readonly VertexAttributeDescriptor[] VertexLayout = new VertexAttributeDescriptor[6]
		{
			new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0),
			new VertexAttributeDescriptor(VertexAttribute.Normal),
			new VertexAttributeDescriptor(VertexAttribute.Tangent, VertexAttributeFormat.Float32, 4),
			new VertexAttributeDescriptor(VertexAttribute.Color, VertexAttributeFormat.UNorm8, 4),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord2, VertexAttributeFormat.Float32, 4)
		};
	}

	public List<FoliageVertex> vertices;

	public List<int> triangles;

	public Bounds bounds;

	public void Alloc()
	{
		if (triangles == null)
		{
			triangles = Pool.Get<List<int>>();
		}
		if (vertices == null)
		{
			vertices = Pool.Get<List<FoliageVertex>>();
		}
	}

	public void Free()
	{
		if (triangles != null)
		{
			Pool.FreeUnmanaged(ref triangles);
		}
		if (vertices != null)
		{
			Pool.FreeUnmanaged(ref vertices);
		}
	}

	public void Clear()
	{
		triangles?.Clear();
		vertices?.Clear();
	}

	public void Combine(MeshGroup meshGroup)
	{
		if (meshGroup.Count == 0)
		{
			return;
		}
		bounds = new Bounds(meshGroup[0].position, Vector3.zero);
		for (int i = 0; i < meshGroup.Count; i++)
		{
			MeshInstance meshInstance = meshGroup[i];
			Matrix4x4 matrix4x = Matrix4x4.TRS(meshInstance.position, meshInstance.rotation, meshInstance.scale);
			int count = vertices.Count;
			for (int j = 0; j < meshInstance.data.triangles.Length; j++)
			{
				triangles.Add(count + meshInstance.data.triangles[j]);
			}
			for (int k = 0; k < meshInstance.data.vertices.Length; k++)
			{
				Vector4 vector = meshInstance.data.tangents[k];
				Vector3 vector2 = new Vector3(vector.x, vector.y, vector.z);
				Vector3 vector3 = matrix4x.MultiplyVector(vector2);
				FoliageVertex item = default(FoliageVertex);
				item.position = matrix4x.MultiplyPoint3x4(meshInstance.data.vertices[k]);
				item.normal = matrix4x.MultiplyVector(meshInstance.data.normals[k]);
				item.uv = meshInstance.data.uv[k];
				item.uv2 = meshInstance.position;
				item.tangent = new Vector4(vector3.x, vector3.y, vector3.z, vector.w);
				if (meshInstance.data.colors32.Length != 0)
				{
					item.color = meshInstance.data.colors32[k];
				}
				vertices.Add(item);
			}
			bounds.Encapsulate(new Bounds(meshInstance.position + meshInstance.data.bounds.center, meshInstance.data.bounds.size));
		}
		bounds.size += Vector3.one;
	}

	public void Apply(Mesh mesh)
	{
		mesh.SetVertexBufferParams(vertices.Count, FoliageVertex.VertexLayout);
		mesh.SetVertexBufferData(vertices, 0, 0, vertices.Count, 0, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontRecalculateBounds);
		mesh.SetIndices(triangles, MeshTopology.Triangles, 0, calculateBounds: false);
		mesh.bounds = bounds;
	}
}
