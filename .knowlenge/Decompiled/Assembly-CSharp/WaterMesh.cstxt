using System;
using UnityEngine;

[Serializable]
public class WaterMesh
{
	private Mesh borderMesh;

	private Mesh centerPatch;

	private int borderRingCount;

	private float borderRingSpacingFalloff;

	private int resolution;

	private Vector3[] borderVerticesLocal;

	private Vector3[] borderVerticesWorld;

	private bool initialized;

	public Mesh BorderMesh => borderMesh;

	public Mesh CenterPatch => centerPatch;

	public bool IsInitialized => initialized;

	public void Initialize(int patchResolution, float patchSizeInWorld, int borderRingCount, float borderRingSpacingFalloff)
	{
		if (!Mathf.IsPowerOfTwo(patchResolution))
		{
			Debug.LogError("[Water] Patch resolution must be a power-of-two number.");
			return;
		}
		this.borderRingCount = borderRingCount;
		this.borderRingSpacingFalloff = borderRingSpacingFalloff;
		borderMesh = CreateSortedBorderPatch(patchResolution, borderRingCount, patchSizeInWorld);
		centerPatch = CreateSortedCenterPatch(patchResolution, patchSizeInWorld, borderOnly: false);
		resolution = patchResolution;
		borderVerticesLocal = new Vector3[borderMesh.vertexCount];
		borderVerticesWorld = new Vector3[borderMesh.vertexCount];
		Array.Copy(borderMesh.vertices, borderVerticesLocal, borderMesh.vertexCount);
		initialized = true;
	}

	public void Destroy()
	{
		if (initialized)
		{
			UnityEngine.Object.DestroyImmediate(borderMesh);
			UnityEngine.Object.DestroyImmediate(centerPatch);
			initialized = false;
		}
	}

	public void UpdateBorderMesh(Matrix4x4 centerLocalToWorld, Matrix4x4 borderLocalToWorld, bool collapseCenter)
	{
		int num = resolution * 4;
		int num2 = 0;
		int num3 = num;
		int num4 = borderMesh.vertexCount - num;
		int vertexCount = borderMesh.vertexCount;
		Vector3 vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
		Vector3 vector2 = new Vector3(float.MinValue, float.MinValue, float.MinValue);
		Bounds bounds = default(Bounds);
		for (int i = num2; i < num3; i++)
		{
			Vector3 vector3 = borderLocalToWorld.MultiplyPoint3x4(borderVerticesLocal[i]);
			vector = Vector3.Min(vector, vector3);
			vector2 = Vector3.Max(vector2, vector3);
			borderVerticesWorld[i] = vector3;
		}
		bounds.SetMinMax(vector, vector2);
		if (!collapseCenter)
		{
			for (int j = num4; j < vertexCount; j++)
			{
				borderVerticesWorld[j] = centerLocalToWorld.MultiplyPoint3x4(borderVerticesLocal[j]);
			}
		}
		else
		{
			for (int k = num4; k < vertexCount; k++)
			{
				borderVerticesWorld[k] = centerLocalToWorld.MultiplyPoint3x4(Vector3.zero);
			}
		}
		int l = 1;
		int num5 = num3;
		for (; l < borderRingCount; l++)
		{
			float f = (float)l / (float)borderRingCount;
			f = Mathf.Clamp01(Mathf.Pow(f, borderRingSpacingFalloff));
			int num6 = 0;
			while (num6 < num)
			{
				Vector3 vector4 = borderVerticesWorld[num2 + num6];
				Vector3 vector5 = borderVerticesWorld[num4 + num6];
				borderVerticesWorld[num5].x = vector4.x + (vector5.x - vector4.x) * f;
				borderVerticesWorld[num5].y = vector4.y + (vector5.y - vector4.y) * f;
				borderVerticesWorld[num5].z = vector4.z + (vector5.z - vector4.z) * f;
				num6++;
				num5++;
			}
		}
		borderMesh.vertices = borderVerticesWorld;
		borderMesh.bounds = bounds;
	}

	private Mesh CreateSortedBorderPatch(int resolution, int ringCount, float sizeInWorld)
	{
		float num = sizeInWorld / (float)resolution;
		int num2 = resolution * 4 * (ringCount + 1);
		int num3 = resolution * 4 * ringCount * 6;
		Vector3[] array = new Vector3[num2];
		Vector3[] array2 = new Vector3[num2];
		Color[] array3 = new Color[num2];
		int[] array4 = new int[num3];
		for (int i = 0; i < num2; i++)
		{
			array2[i] = Vector3.up;
		}
		for (int j = 0; j < num2; j++)
		{
			array3[j] = Color.clear;
		}
		int num4 = resolution * 4;
		float num5 = (float)resolution * num;
		Vector3 vector = new Vector3(sizeInWorld, 0f, sizeInWorld) * 0.5f;
		int k = 0;
		int num6 = 0;
		for (; k < ringCount + 1; k++)
		{
			Vector3 vector2 = -vector;
			for (int l = 0; l < resolution; l++)
			{
				array[num6++] = vector2 + new Vector3((float)l * num, 0f, 0f);
			}
			for (int m = 0; m < resolution; m++)
			{
				array[num6++] = vector2 + new Vector3(num5, 0f, (float)m * num);
			}
			for (int num7 = resolution; num7 > 0; num7--)
			{
				array[num6++] = vector2 + new Vector3((float)num7 * num, 0f, num5);
			}
			for (int num8 = resolution; num8 > 0; num8--)
			{
				array[num6++] = vector2 + new Vector3(0f, 0f, (float)num8 * num);
			}
		}
		int n = 0;
		int num9 = 0;
		for (; n < ringCount; n++)
		{
			int num10 = n * num4;
			int num11 = num10 + num4;
			int num12 = num11;
			int num13 = num10 + num4 * 2;
			int num14 = num10;
			int num15 = num10 + num4 + 1;
			int num16 = num10 + num4;
			int num17 = num10 + 1;
			int num18 = num10 + num4 + 1;
			int num19 = num10;
			for (int num20 = 0; num20 < num4; num20++)
			{
				bool num21 = num20 % resolution == 0;
				int num22 = num14;
				int num23 = (num21 ? (num15 - num4) : num15);
				int num24 = num16;
				int num25 = num17;
				int num26 = num18;
				int num27 = (num21 ? (num19 + num4) : num19);
				if (num23 >= num13)
				{
					num23 = num12;
				}
				if (num25 >= num11)
				{
					num25 = num10;
				}
				if (num26 >= num13)
				{
					num26 = num12;
				}
				array4[num9++] = num24;
				array4[num9++] = num23;
				array4[num9++] = num22;
				array4[num9++] = num27;
				array4[num9++] = num26;
				array4[num9++] = num25;
				num14++;
				num15++;
				num16++;
				num17++;
				num18++;
				num19++;
			}
		}
		Mesh mesh = new Mesh();
		mesh.hideFlags = HideFlags.DontSave;
		mesh.vertices = array;
		mesh.normals = array2;
		mesh.colors = array3;
		mesh.triangles = array4;
		mesh.RecalculateBounds();
		return mesh;
	}

	private Mesh CreateSortedCenterPatch(int resolution, float sizeInWorld, bool borderOnly)
	{
		float num = sizeInWorld / (float)resolution;
		int num2 = resolution + 1;
		int num3;
		int num4;
		if (borderOnly)
		{
			num3 = resolution * 8 - 8;
			num4 = (resolution - 1) * 24;
		}
		else
		{
			num3 = num2 * num2;
			num4 = resolution * resolution * 6;
		}
		Vector3[] array = new Vector3[num3];
		Vector3[] array2 = new Vector3[num3];
		Color[] array3 = new Color[num3];
		int[] array4 = new int[num4];
		for (int i = 0; i < num3; i++)
		{
			array2[i] = Vector3.up;
		}
		int num5 = resolution / 2;
		int num6 = num5 - 1;
		int num7 = resolution;
		int num8 = resolution * 4;
		Vector3 vector = new Vector3(sizeInWorld, 0f, sizeInWorld) * 0.5f;
		if (borderOnly)
		{
			for (int j = 0; j < num3; j++)
			{
				array3[j] = Color.clear;
			}
		}
		else
		{
			for (int k = 0; k < num3; k++)
			{
				if (k >= num8)
				{
					array3[k] = Color.white;
				}
				else
				{
					array3[k] = Color.clear;
				}
			}
		}
		int l = 0;
		int num9 = 0;
		Vector3 vector2 = default(Vector3);
		for (; l < num5 + 1; l++)
		{
			vector2.x = (float)l * num;
			vector2.y = 0f;
			vector2.z = vector2.x;
			vector2 -= vector;
			float num10 = (float)num7 * num;
			if (l <= num6)
			{
				for (int m = 0; m < num7; m++)
				{
					array[num9++] = vector2 + new Vector3((float)m * num, 0f, 0f);
				}
				for (int n = 0; n < num7; n++)
				{
					array[num9++] = vector2 + new Vector3(num10, 0f, (float)n * num);
				}
				for (int num11 = num7; num11 > 0; num11--)
				{
					array[num9++] = vector2 + new Vector3((float)num11 * num, 0f, num10);
				}
				for (int num12 = num7; num12 > 0; num12--)
				{
					array[num9++] = vector2 + new Vector3(0f, 0f, (float)num12 * num);
				}
			}
			else
			{
				array[num9++] = vector2;
			}
			num7 -= 2;
			if (borderOnly && l >= 1)
			{
				break;
			}
		}
		int num13 = resolution;
		int num14 = resolution - 2;
		int num15 = resolution * 4;
		int num16 = num15 - 8;
		int num17 = (resolution - 1) * 4;
		int num18 = num17 - 8;
		int num19 = 0;
		int num20 = num15;
		int num21 = 0;
		int num22 = 0;
		for (; num21 < num5; num21++)
		{
			if (num21 < num6)
			{
				int num23 = num20;
				int num24 = num20 - 1;
				int num25 = num19;
				int num26 = 0;
				bool flag = true;
				for (int num27 = 0; num27 < num17; num27++)
				{
					int num28 = num23;
					int num29 = num24;
					int num30 = num25;
					num24 = num25;
					num25++;
					int num31 = num23;
					int num32 = num24;
					int num33 = num25;
					bool flag2 = (num26 & 1) == 0;
					if (flag2 || (borderOnly && flag && !flag2))
					{
						array4[num22++] = num33;
						array4[num22++] = num32;
						array4[num22++] = num31;
						array4[num22++] = num30;
						array4[num22++] = num29;
						array4[num22++] = num28;
					}
					else
					{
						array4[num22++] = num30;
						array4[num22++] = num29;
						array4[num22++] = num33;
						array4[num22++] = num33;
						array4[num22++] = num29;
						array4[num22++] = num28;
					}
					flag = (num27 + 1) % (num13 - 1) == 0;
					if (flag)
					{
						num24++;
						num25++;
						num26++;
					}
					else
					{
						num24 = num23;
						num23 = ((num23 + 1 < num20 + num16) ? (num23 + 1) : num20);
					}
				}
				num17 -= 8;
				num18 -= 8;
				num15 -= 8;
				num16 -= 8;
				num13 -= 2;
				num14 -= 2;
				num19 = num20;
				num20 += num15;
			}
			else
			{
				int num34 = num20;
				int num35 = num20 - 1;
				int num36 = num19;
				int num37 = 0;
				for (int num38 = 0; num38 < num17; num38++)
				{
					int num39 = num34;
					int num40 = num35;
					int num41 = num36;
					num35 = num36;
					num36++;
					int num42 = num34;
					int num43 = num35;
					int num44 = num36;
					num35++;
					num36++;
					if ((num37 & 1) == 0)
					{
						array4[num22++] = num44;
						array4[num22++] = num43;
						array4[num22++] = num42;
						array4[num22++] = num41;
						array4[num22++] = num40;
						array4[num22++] = num39;
					}
					else
					{
						array4[num22++] = num41;
						array4[num22++] = num40;
						array4[num22++] = num44;
						array4[num22++] = num44;
						array4[num22++] = num40;
						array4[num22++] = num39;
					}
					num37++;
				}
			}
			if (borderOnly)
			{
				break;
			}
		}
		Mesh mesh = new Mesh();
		mesh.hideFlags = HideFlags.DontSave;
		mesh.vertices = array;
		mesh.normals = array2;
		mesh.colors = array3;
		mesh.triangles = array4;
		mesh.RecalculateBounds();
		return mesh;
	}
}
