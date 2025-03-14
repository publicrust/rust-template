using System;
using System.Collections.Generic;
using Facepunch;
using UnityEngine;
using UnityEngine.AI;

public class AsyncTerrainNavMeshBake : CustomYieldInstruction
{
	private List<int> indices;

	private List<Vector3> vertices;

	private List<Vector3> normals;

	private List<int> triangles;

	private Vector3 pivot;

	private int width;

	private int height;

	private bool normal;

	private bool alpha;

	private Action worker;

	public override bool keepWaiting => worker != null;

	public bool isDone => worker == null;

	public Mesh mesh
	{
		get
		{
			Mesh mesh = new Mesh();
			if (vertices != null)
			{
				mesh.SetVertices(vertices);
				Pool.FreeUnmanaged(ref vertices);
			}
			if (normals != null)
			{
				mesh.SetNormals(normals);
				Pool.FreeUnmanaged(ref normals);
			}
			if (triangles != null)
			{
				mesh.SetTriangles(triangles, 0);
				Pool.FreeUnmanaged(ref triangles);
			}
			if (indices != null)
			{
				Pool.FreeUnmanaged(ref indices);
			}
			return mesh;
		}
	}

	public NavMeshBuildSource CreateNavMeshBuildSource()
	{
		NavMeshBuildSource result = default(NavMeshBuildSource);
		result.transform = Matrix4x4.TRS(pivot, Quaternion.identity, Vector3.one);
		result.shape = NavMeshBuildSourceShape.Mesh;
		result.sourceObject = mesh;
		return result;
	}

	public NavMeshBuildSource CreateNavMeshBuildSource(int area)
	{
		NavMeshBuildSource result = CreateNavMeshBuildSource();
		result.area = area;
		return result;
	}

	public AsyncTerrainNavMeshBake(Vector3 pivot, int width, int height, bool normal, bool alpha)
	{
		this.pivot = pivot;
		this.width = width;
		this.height = height;
		this.normal = normal;
		this.alpha = alpha;
		indices = Pool.Get<List<int>>();
		vertices = Pool.Get<List<Vector3>>();
		normals = (normal ? Pool.Get<List<Vector3>>() : null);
		triangles = Pool.Get<List<int>>();
		Invoke();
	}

	private void DoWork()
	{
		Vector3 vector = new Vector3(width / 2, 0f, height / 2);
		Vector3 vector2 = new Vector3(pivot.x - vector.x, 0f, pivot.z - vector.z);
		TerrainHeightMap heightMap = TerrainMeta.HeightMap;
		TerrainAlphaMap alphaMap = TerrainMeta.AlphaMap;
		int num = 0;
		for (int i = 0; i <= height; i++)
		{
			int num2 = 0;
			while (num2 <= width)
			{
				Vector3 worldPos = new Vector3(num2, 0f, i) + vector2;
				Vector3 item = new Vector3(num2, 0f, i) - vector;
				float num3 = heightMap.GetHeight(worldPos);
				if (num3 < -1f)
				{
					indices.Add(-1);
				}
				else if (alpha && alphaMap.GetAlpha(worldPos) < 0.1f)
				{
					indices.Add(-1);
				}
				else
				{
					if (normal)
					{
						Vector3 item2 = heightMap.GetNormal(worldPos);
						normals.Add(item2);
					}
					worldPos.y = (item.y = num3 - pivot.y);
					indices.Add(vertices.Count);
					vertices.Add(item);
				}
				num2++;
				num++;
			}
		}
		int num4 = 0;
		int num5 = 0;
		while (num5 < height)
		{
			int num6 = 0;
			while (num6 < width)
			{
				int num7 = indices[num4];
				int num8 = indices[num4 + width + 1];
				int num9 = indices[num4 + 1];
				int num10 = indices[num4 + 1];
				int num11 = indices[num4 + width + 1];
				int num12 = indices[num4 + width + 2];
				if (num7 != -1 && num8 != -1 && num9 != -1)
				{
					triangles.Add(num7);
					triangles.Add(num8);
					triangles.Add(num9);
				}
				if (num10 != -1 && num11 != -1 && num12 != -1)
				{
					triangles.Add(num10);
					triangles.Add(num11);
					triangles.Add(num12);
				}
				num6++;
				num4++;
			}
			num5++;
			num4++;
		}
	}

	private void Invoke()
	{
		worker = DoWork;
		worker.BeginInvoke(Callback, null);
	}

	private void Callback(IAsyncResult result)
	{
		worker.EndInvoke(result);
		worker = null;
	}
}
