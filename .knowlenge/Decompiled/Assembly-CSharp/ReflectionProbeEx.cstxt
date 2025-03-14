using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class ReflectionProbeEx : MonoBehaviour
{
	[Serializable]
	public enum ConvolutionQuality
	{
		Lowest,
		Low,
		Medium,
		High,
		VeryHigh
	}

	[Serializable]
	public struct RenderListEntry
	{
		public Renderer renderer;

		public bool alwaysEnabled;

		public RenderListEntry(Renderer renderer, bool alwaysEnabled)
		{
			this.renderer = renderer;
			this.alwaysEnabled = alwaysEnabled;
		}
	}

	private struct CubemapSkyboxVertex
	{
		public float x;

		public float y;

		public float z;

		public Color color;

		public float tu;

		public float tv;

		public float tw;
	}

	private struct CubemapFaceMatrices
	{
		public Matrix4x4 worldToView;

		public Matrix4x4 viewToWorld;

		public CubemapFaceMatrices(Vector3 x, Vector3 y, Vector3 z)
		{
			worldToView = Matrix4x4.identity;
			worldToView[0, 0] = x[0];
			worldToView[0, 1] = x[1];
			worldToView[0, 2] = x[2];
			worldToView[1, 0] = y[0];
			worldToView[1, 1] = y[1];
			worldToView[1, 2] = y[2];
			worldToView[2, 0] = z[0];
			worldToView[2, 1] = z[1];
			worldToView[2, 2] = z[2];
			viewToWorld = worldToView.inverse;
		}
	}

	public ReflectionProbeRefreshMode refreshMode = ReflectionProbeRefreshMode.EveryFrame;

	public bool timeSlicing;

	public int resolution = 128;

	[InspectorName("HDR")]
	public bool hdr = true;

	public float shadowDistance;

	public ReflectionProbeClearFlags clearFlags = ReflectionProbeClearFlags.Skybox;

	public Color background = new Color(0.192f, 0.301f, 0.474f);

	public float nearClip = 0.3f;

	public float farClip = 1000f;

	public Transform attachToTarget;

	public Light directionalLight;

	public float textureMipBias = 2f;

	public bool highPrecision;

	public bool enableShadows;

	public ConvolutionQuality convolutionQuality;

	public List<RenderListEntry> staticRenderList = new List<RenderListEntry>();

	public Cubemap reflectionCubemap;

	public float reflectionIntensity = 1f;

	private Mesh blitMesh;

	private Mesh skyboxMesh;

	private static float[] octaVerts = new float[72]
	{
		0f, 1f, 0f, 0f, 0f, -1f, 1f, 0f, 0f, 0f,
		1f, 0f, 1f, 0f, 0f, 0f, 0f, 1f, 0f, 1f,
		0f, 0f, 0f, 1f, -1f, 0f, 0f, 0f, 1f, 0f,
		-1f, 0f, 0f, 0f, 0f, -1f, 0f, -1f, 0f, 1f,
		0f, 0f, 0f, 0f, -1f, 0f, -1f, 0f, 0f, 0f,
		1f, 1f, 0f, 0f, 0f, -1f, 0f, -1f, 0f, 0f,
		0f, 0f, 1f, 0f, -1f, 0f, 0f, 0f, -1f, -1f,
		0f, 0f
	};

	private static readonly CubemapFaceMatrices[] cubemapFaceMatrices = new CubemapFaceMatrices[6]
	{
		new CubemapFaceMatrices(new Vector3(0f, 0f, -1f), new Vector3(0f, -1f, 0f), new Vector3(-1f, 0f, 0f)),
		new CubemapFaceMatrices(new Vector3(0f, 0f, 1f), new Vector3(0f, -1f, 0f), new Vector3(1f, 0f, 0f)),
		new CubemapFaceMatrices(new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, 1f), new Vector3(0f, -1f, 0f)),
		new CubemapFaceMatrices(new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, -1f), new Vector3(0f, 1f, 0f)),
		new CubemapFaceMatrices(new Vector3(1f, 0f, 0f), new Vector3(0f, -1f, 0f), new Vector3(0f, 0f, -1f)),
		new CubemapFaceMatrices(new Vector3(-1f, 0f, 0f), new Vector3(0f, -1f, 0f), new Vector3(0f, 0f, 1f))
	};

	private static readonly CubemapFaceMatrices[] cubemapFaceMatricesD3D11 = new CubemapFaceMatrices[6]
	{
		new CubemapFaceMatrices(new Vector3(0f, 0f, -1f), new Vector3(0f, 1f, 0f), new Vector3(-1f, 0f, 0f)),
		new CubemapFaceMatrices(new Vector3(0f, 0f, 1f), new Vector3(0f, 1f, 0f), new Vector3(1f, 0f, 0f)),
		new CubemapFaceMatrices(new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, -1f), new Vector3(0f, -1f, 0f)),
		new CubemapFaceMatrices(new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, 1f), new Vector3(0f, 1f, 0f)),
		new CubemapFaceMatrices(new Vector3(1f, 0f, 0f), new Vector3(0f, 1f, 0f), new Vector3(0f, 0f, -1f)),
		new CubemapFaceMatrices(new Vector3(-1f, 0f, 0f), new Vector3(0f, 1f, 0f), new Vector3(0f, 0f, 1f))
	};

	private static readonly CubemapFaceMatrices[] shadowCubemapFaceMatrices = new CubemapFaceMatrices[6]
	{
		new CubemapFaceMatrices(new Vector3(0f, 0f, 1f), new Vector3(0f, -1f, 0f), new Vector3(-1f, 0f, 0f)),
		new CubemapFaceMatrices(new Vector3(0f, 0f, -1f), new Vector3(0f, -1f, 0f), new Vector3(1f, 0f, 0f)),
		new CubemapFaceMatrices(new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, 1f), new Vector3(0f, 1f, 0f)),
		new CubemapFaceMatrices(new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, -1f), new Vector3(0f, -1f, 0f)),
		new CubemapFaceMatrices(new Vector3(1f, 0f, 0f), new Vector3(0f, -1f, 0f), new Vector3(0f, 0f, 1f)),
		new CubemapFaceMatrices(new Vector3(-1f, 0f, 0f), new Vector3(0f, -1f, 0f), new Vector3(0f, 0f, -1f))
	};

	private CubemapFaceMatrices[] platformCubemapFaceMatrices;

	private static readonly int[] tab32 = new int[32]
	{
		0, 9, 1, 10, 13, 21, 2, 29, 11, 14,
		16, 18, 22, 25, 3, 30, 8, 12, 20, 28,
		15, 17, 24, 7, 19, 27, 23, 6, 26, 5,
		4, 31
	};

	private void CreateMeshes()
	{
		if (blitMesh == null)
		{
			blitMesh = CreateBlitMesh();
		}
		if (skyboxMesh == null)
		{
			skyboxMesh = CreateSkyboxMesh();
		}
	}

	private void DestroyMeshes()
	{
		if (blitMesh != null)
		{
			UnityEngine.Object.DestroyImmediate(blitMesh);
			blitMesh = null;
		}
		if (skyboxMesh != null)
		{
			UnityEngine.Object.DestroyImmediate(skyboxMesh);
			skyboxMesh = null;
		}
	}

	private static Mesh CreateBlitMesh()
	{
		Mesh mesh = new Mesh();
		mesh.vertices = new Vector3[4]
		{
			new Vector3(-1f, -1f, 0f),
			new Vector3(-1f, 1f, 0f),
			new Vector3(1f, 1f, 0f),
			new Vector3(1f, -1f, 0f)
		};
		mesh.uv = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0f, 1f),
			new Vector2(1f, 1f),
			new Vector2(1f, 0f)
		};
		mesh.triangles = new int[6] { 0, 1, 2, 0, 2, 3 };
		return mesh;
	}

	private static CubemapSkyboxVertex SubDivVert(CubemapSkyboxVertex v1, CubemapSkyboxVertex v2)
	{
		Vector3 a = new Vector3(v1.x, v1.y, v1.z);
		Vector3 b = new Vector3(v2.x, v2.y, v2.z);
		Vector3 vector = Vector3.Normalize(Vector3.Lerp(a, b, 0.5f));
		CubemapSkyboxVertex result = default(CubemapSkyboxVertex);
		result.x = (result.tu = vector.x);
		result.y = (result.tv = vector.y);
		result.z = (result.tw = vector.z);
		result.color = Color.white;
		return result;
	}

	private static void Subdivide(List<CubemapSkyboxVertex> destArray, CubemapSkyboxVertex v1, CubemapSkyboxVertex v2, CubemapSkyboxVertex v3)
	{
		CubemapSkyboxVertex item = SubDivVert(v1, v2);
		CubemapSkyboxVertex item2 = SubDivVert(v2, v3);
		CubemapSkyboxVertex item3 = SubDivVert(v1, v3);
		destArray.Add(v1);
		destArray.Add(item);
		destArray.Add(item3);
		destArray.Add(item);
		destArray.Add(v2);
		destArray.Add(item2);
		destArray.Add(item2);
		destArray.Add(item3);
		destArray.Add(item);
		destArray.Add(v3);
		destArray.Add(item3);
		destArray.Add(item2);
	}

	private static void SubdivideYOnly(List<CubemapSkyboxVertex> destArray, CubemapSkyboxVertex v1, CubemapSkyboxVertex v2, CubemapSkyboxVertex v3)
	{
		float num = Mathf.Abs(v2.y - v1.y);
		float num2 = Mathf.Abs(v2.y - v3.y);
		float num3 = Mathf.Abs(v3.y - v1.y);
		CubemapSkyboxVertex cubemapSkyboxVertex;
		CubemapSkyboxVertex cubemapSkyboxVertex2;
		CubemapSkyboxVertex cubemapSkyboxVertex3;
		if (num < num2 && num < num3)
		{
			cubemapSkyboxVertex = v3;
			cubemapSkyboxVertex2 = v1;
			cubemapSkyboxVertex3 = v2;
		}
		else if (num2 < num && num2 < num3)
		{
			cubemapSkyboxVertex = v1;
			cubemapSkyboxVertex2 = v2;
			cubemapSkyboxVertex3 = v3;
		}
		else
		{
			cubemapSkyboxVertex = v2;
			cubemapSkyboxVertex2 = v3;
			cubemapSkyboxVertex3 = v1;
		}
		CubemapSkyboxVertex item = SubDivVert(cubemapSkyboxVertex, cubemapSkyboxVertex2);
		CubemapSkyboxVertex item2 = SubDivVert(cubemapSkyboxVertex, cubemapSkyboxVertex3);
		destArray.Add(cubemapSkyboxVertex);
		destArray.Add(item);
		destArray.Add(item2);
		Vector3 vector = new Vector3(item2.x - cubemapSkyboxVertex2.x, item2.y - cubemapSkyboxVertex2.y, item2.z - cubemapSkyboxVertex2.z);
		Vector3 vector2 = new Vector3(item.x - cubemapSkyboxVertex3.x, item.y - cubemapSkyboxVertex3.y, item.z - cubemapSkyboxVertex3.z);
		if (vector.x * vector.x + vector.y * vector.y + vector.z * vector.z > vector2.x * vector2.x + vector2.y * vector2.y + vector2.z * vector2.z)
		{
			destArray.Add(item);
			destArray.Add(cubemapSkyboxVertex2);
			destArray.Add(cubemapSkyboxVertex3);
			destArray.Add(item2);
			destArray.Add(item);
			destArray.Add(cubemapSkyboxVertex3);
		}
		else
		{
			destArray.Add(item2);
			destArray.Add(item);
			destArray.Add(cubemapSkyboxVertex2);
			destArray.Add(item2);
			destArray.Add(cubemapSkyboxVertex2);
			destArray.Add(cubemapSkyboxVertex3);
		}
	}

	private static Mesh CreateSkyboxMesh()
	{
		List<CubemapSkyboxVertex> list = new List<CubemapSkyboxVertex>();
		for (int i = 0; i < 24; i++)
		{
			CubemapSkyboxVertex item = default(CubemapSkyboxVertex);
			Vector3 vector = Vector3.Normalize(new Vector3(octaVerts[i * 3], octaVerts[i * 3 + 1], octaVerts[i * 3 + 2]));
			item.x = (item.tu = vector.x);
			item.y = (item.tv = vector.y);
			item.z = (item.tw = vector.z);
			item.color = Color.white;
			list.Add(item);
		}
		for (int j = 0; j < 3; j++)
		{
			List<CubemapSkyboxVertex> list2 = new List<CubemapSkyboxVertex>(list.Count);
			list2.AddRange(list);
			int count = list2.Count;
			list.Clear();
			list.Capacity = count * 4;
			for (int k = 0; k < count; k += 3)
			{
				Subdivide(list, list2[k], list2[k + 1], list2[k + 2]);
			}
		}
		for (int l = 0; l < 2; l++)
		{
			List<CubemapSkyboxVertex> list3 = new List<CubemapSkyboxVertex>(list.Count);
			list3.AddRange(list);
			int count2 = list3.Count;
			float num = Mathf.Pow(0.5f, (float)l + 1f);
			list.Clear();
			list.Capacity = count2 * 4;
			for (int m = 0; m < count2; m += 3)
			{
				if (Mathf.Max(Mathf.Max(Mathf.Abs(list3[m].y), Mathf.Abs(list3[m + 1].y)), Mathf.Abs(list3[m + 2].y)) > num)
				{
					list.Add(list3[m]);
					list.Add(list3[m + 1]);
					list.Add(list3[m + 2]);
				}
				else
				{
					SubdivideYOnly(list, list3[m], list3[m + 1], list3[m + 2]);
				}
			}
		}
		Mesh mesh = new Mesh();
		Vector3[] array = new Vector3[list.Count];
		Vector2[] array2 = new Vector2[list.Count];
		int[] array3 = new int[list.Count];
		for (int n = 0; n < list.Count; n++)
		{
			array[n] = new Vector3(list[n].x, list[n].y, list[n].z);
			array2[n] = new Vector3(list[n].tu, list[n].tv);
			array3[n] = n;
		}
		mesh.vertices = array;
		mesh.uv = array2;
		mesh.triangles = array3;
		return mesh;
	}

	private bool InitializeCubemapFaceMatrices()
	{
		switch (SystemInfo.graphicsDeviceType)
		{
		case GraphicsDeviceType.OpenGLCore:
			platformCubemapFaceMatrices = cubemapFaceMatrices;
			break;
		case GraphicsDeviceType.Direct3D11:
			platformCubemapFaceMatrices = cubemapFaceMatricesD3D11;
			break;
		case GraphicsDeviceType.Direct3D12:
			platformCubemapFaceMatrices = cubemapFaceMatricesD3D11;
			break;
		case GraphicsDeviceType.Vulkan:
			platformCubemapFaceMatrices = cubemapFaceMatricesD3D11;
			break;
		case GraphicsDeviceType.Metal:
			platformCubemapFaceMatrices = cubemapFaceMatricesD3D11;
			break;
		default:
			platformCubemapFaceMatrices = null;
			break;
		}
		if (platformCubemapFaceMatrices == null)
		{
			Debug.LogError("[ReflectionProbeEx] Initialization failed. No cubemap ortho basis defined for " + SystemInfo.graphicsDeviceType);
			return false;
		}
		return true;
	}

	private int FastLog2(int value)
	{
		value |= value >> 1;
		value |= value >> 2;
		value |= value >> 4;
		value |= value >> 8;
		value |= value >> 16;
		return tab32[(uint)((long)value * 130329821L) >> 27];
	}

	private uint ReverseBits(uint bits)
	{
		bits = (bits << 16) | (bits >> 16);
		bits = ((bits & 0xFF00FF) << 8) | ((bits & 0xFF00FF00u) >> 8);
		bits = ((bits & 0xF0F0F0F) << 4) | ((bits & 0xF0F0F0F0u) >> 4);
		bits = ((bits & 0x33333333) << 2) | ((bits & 0xCCCCCCCCu) >> 2);
		bits = ((bits & 0x55555555) << 1) | ((bits & 0xAAAAAAAAu) >> 1);
		return bits;
	}

	private void SafeCreateMaterial(ref Material mat, Shader shader)
	{
		if (mat == null)
		{
			mat = new Material(shader);
		}
	}

	private void SafeCreateMaterial(ref Material mat, string shaderName)
	{
		if (mat == null)
		{
			SafeCreateMaterial(ref mat, Shader.Find(shaderName));
		}
	}

	private void SafeCreateCubeRT(ref RenderTexture rt, string name, int size, int depth, bool mips, TextureDimension dim, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite = RenderTextureReadWrite.Linear)
	{
		if (rt == null || !rt.IsCreated())
		{
			SafeDestroy(ref rt);
			rt = new RenderTexture(size, size, depth, format, readWrite)
			{
				hideFlags = HideFlags.DontSave
			};
			rt.name = name;
			rt.dimension = dim;
			if (dim == TextureDimension.Tex2DArray)
			{
				rt.volumeDepth = 6;
			}
			rt.useMipMap = mips;
			rt.autoGenerateMips = false;
			rt.filterMode = filter;
			rt.anisoLevel = 0;
			rt.Create();
		}
	}

	private void SafeCreateCB(ref CommandBuffer cb, string name)
	{
		if (cb == null)
		{
			cb = new CommandBuffer();
			cb.name = name;
		}
	}

	private void SafeDestroy<T>(ref T obj) where T : UnityEngine.Object
	{
		if (obj != null)
		{
			UnityEngine.Object.DestroyImmediate(obj);
			obj = null;
		}
	}

	private void SafeDispose<T>(ref T obj) where T : IDisposable
	{
		if (obj != null)
		{
			obj.Dispose();
			obj = default(T);
		}
	}
}
