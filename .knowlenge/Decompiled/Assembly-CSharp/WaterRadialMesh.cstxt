using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaterRadialMesh
{
	private const float AlignmentGranularity = 1f;

	private const float MaxHorizontalDisplacement = 1f;

	private Mesh[] meshes;

	private bool initialized;

	public Mesh[] Meshes => meshes;

	public bool IsInitialized => initialized;

	public void Initialize(int vertexCount)
	{
		meshes = GenerateMeshes(vertexCount);
		initialized = true;
	}

	public void Destroy()
	{
		if (initialized)
		{
			Mesh[] array = meshes;
			for (int i = 0; i < array.Length; i++)
			{
				UnityEngine.Object.DestroyImmediate(array[i]);
			}
			meshes = null;
			initialized = false;
		}
	}

	private Mesh CreateMesh(string name, Vector3[] vertices, int[] indices)
	{
		Mesh mesh = new Mesh();
		mesh.hideFlags = HideFlags.DontSave;
		mesh.name = name;
		mesh.vertices = vertices;
		mesh.SetIndices(indices, MeshTopology.Quads, 0);
		mesh.RecalculateBounds();
		mesh.UploadMeshData(markNoLongerReadable: true);
		return mesh;
	}

	private Mesh[] GenerateMeshes(int vertexCount, bool volume = false)
	{
		int num = Mathf.RoundToInt((float)Mathf.RoundToInt(Mathf.Sqrt(vertexCount)) * 0.4f);
		int num2 = Mathf.RoundToInt((float)vertexCount / (float)num);
		int num3 = (volume ? (num2 / 2) : num2);
		List<Mesh> list = new List<Mesh>();
		List<Vector3> list2 = new List<Vector3>();
		List<int> list3 = new List<int>();
		Vector2[] array = new Vector2[num];
		int num4 = 0;
		int num5 = 0;
		for (int i = 0; i < num; i++)
		{
			float f = ((float)i / (float)(num - 1) * 2f - 1f) * (float)Math.PI * 0.25f;
			array[i] = new Vector2(Mathf.Sin(f), Mathf.Cos(f)).normalized;
		}
		for (int j = 0; j < num3; j++)
		{
			float num6 = (float)j / (float)(num2 - 1);
			num6 = 1f - Mathf.Cos(num6 * (float)Math.PI * 0.5f);
			for (int k = 0; k < num; k++)
			{
				Vector2 vector = array[k] * num6;
				if (j < num3 - 2 || !volume)
				{
					list2.Add(new Vector3(vector.x, 0f, vector.y));
				}
				else if (j == num3 - 2)
				{
					list2.Add(new Vector3(vector.x * 10f, -0.9f, vector.y) * 0.5f);
				}
				else
				{
					list2.Add(new Vector3(vector.x * 10f, -0.9f, vector.y * -10f) * 0.5f);
				}
				if (k != 0 && j != 0 && num4 > num)
				{
					list3.Add(num4);
					list3.Add(num4 - num);
					list3.Add(num4 - num - 1);
					list3.Add(num4 - 1);
				}
				num4++;
				if (num4 >= 65000)
				{
					list.Add(CreateMesh("WaterMesh_" + num + "x" + num2 + "_" + num5, list2.ToArray(), list3.ToArray()));
					k--;
					j--;
					num6 = 1f - Mathf.Cos((float)j / (float)(num2 - 1) * (float)Math.PI * 0.5f);
					num4 = 0;
					list2.Clear();
					list3.Clear();
					num5++;
				}
			}
		}
		if (num4 != 0)
		{
			list.Add(CreateMesh("WaterMesh_" + num + "x" + num2 + "_" + num5, list2.ToArray(), list3.ToArray()));
		}
		return list.ToArray();
	}

	private Vector3 RaycastPlane(Camera camera, float planeHeight, Vector3 pos)
	{
		Ray ray = camera.ViewportPointToRay(pos);
		if (camera.transform.position.y > planeHeight)
		{
			if (ray.direction.y > -0.01f)
			{
				ray.direction = new Vector3(ray.direction.x, 0f - ray.direction.y - 0.02f, ray.direction.z);
			}
		}
		else if (ray.direction.y < 0.01f)
		{
			ray.direction = new Vector3(ray.direction.x, 0f - ray.direction.y + 0.02f, ray.direction.z);
		}
		float num = (0f - (ray.origin.y - planeHeight)) / ray.direction.y;
		return Quaternion.AngleAxis(0f - camera.transform.eulerAngles.y, Vector3.up) * (ray.direction * num);
	}

	public Matrix4x4 ComputeLocalToWorldMatrix(Camera camera, float oceanWaterLevel)
	{
		if (camera == null)
		{
			return Matrix4x4.identity;
		}
		Vector3 vector = camera.worldToCameraMatrix.MultiplyVector(Vector3.up);
		Vector3 vector2 = camera.worldToCameraMatrix.MultiplyVector(Vector3.Cross(camera.transform.forward, Vector3.up));
		vector = new Vector3(vector.x, vector.y, 0f).normalized * 0.5f + new Vector3(0.5f, 0f, 0.5f);
		vector2 = new Vector3(vector2.x, vector2.y, 0f).normalized * 0.5f;
		Vector3 vector3 = RaycastPlane(camera, oceanWaterLevel, vector - vector2);
		Vector3 vector4 = RaycastPlane(camera, oceanWaterLevel, vector + vector2);
		float num = Mathf.Min(camera.farClipPlane, 5000f);
		Vector3 position = camera.transform.position;
		Vector3 s = default(Vector3);
		s.x = num * Mathf.Tan(camera.fieldOfView * 0.5f * ((float)Math.PI / 180f)) * camera.aspect + 2f;
		s.y = num;
		s.z = num;
		float num2 = Mathf.Abs(vector4.x - vector3.x);
		float a = Mathf.Min(vector3.z, vector4.z) - (num2 + 2f) * s.z / s.x;
		a = Mathf.Min(a, -15f);
		Vector3 forward = camera.transform.forward;
		forward.y = 0f;
		forward.Normalize();
		s.z -= a;
		position = new Vector3(position.x, oceanWaterLevel, position.z) + forward * a;
		Quaternion q = Quaternion.AngleAxis(Mathf.Atan2(forward.x, forward.z) * 57.29578f, Vector3.up);
		return Matrix4x4.TRS(position, q, s);
	}
}
