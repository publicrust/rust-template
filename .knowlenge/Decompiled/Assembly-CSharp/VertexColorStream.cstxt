using UnityEngine;

[ExecuteInEditMode]
public class VertexColorStream : MonoBehaviour
{
	[HideInInspector]
	public Mesh originalMesh;

	[HideInInspector]
	public Mesh paintedMesh;

	[HideInInspector]
	public MeshHolder meshHold;

	[HideInInspector]
	public Vector3[] _vertices;

	[HideInInspector]
	public Vector3[] _normals;

	[HideInInspector]
	public int[] _triangles;

	[HideInInspector]
	public int[][] _Subtriangles;

	[HideInInspector]
	public Matrix4x4[] _bindPoses;

	[HideInInspector]
	public BoneWeight[] _boneWeights;

	[HideInInspector]
	public Bounds _bounds;

	[HideInInspector]
	public int _subMeshCount;

	[HideInInspector]
	public Vector4[] _tangents;

	[HideInInspector]
	public Vector2[] _uv;

	[HideInInspector]
	public Vector2[] _uv2;

	[HideInInspector]
	public Vector2[] _uv3;

	[HideInInspector]
	public Color[] _colors;

	[HideInInspector]
	public Vector2[] _uv4;

	private void OnDidApplyAnimationProperties()
	{
	}

	public void init(Mesh origMesh, bool destroyOld)
	{
		originalMesh = origMesh;
		paintedMesh = Object.Instantiate(origMesh);
		if (destroyOld)
		{
			Object.DestroyImmediate(origMesh);
		}
		paintedMesh.hideFlags = HideFlags.None;
		paintedMesh.name = "vpp_" + base.gameObject.name;
		meshHold = new MeshHolder();
		meshHold._vertices = paintedMesh.vertices;
		meshHold._normals = paintedMesh.normals;
		meshHold._triangles = paintedMesh.triangles;
		meshHold._TrianglesOfSubs = new trisPerSubmesh[paintedMesh.subMeshCount];
		for (int i = 0; i < paintedMesh.subMeshCount; i++)
		{
			meshHold._TrianglesOfSubs[i] = new trisPerSubmesh();
			meshHold._TrianglesOfSubs[i].triangles = paintedMesh.GetTriangles(i);
		}
		meshHold._bindPoses = paintedMesh.bindposes;
		meshHold._boneWeights = paintedMesh.boneWeights;
		meshHold._bounds = paintedMesh.bounds;
		meshHold._subMeshCount = paintedMesh.subMeshCount;
		meshHold._tangents = paintedMesh.tangents;
		meshHold._uv = paintedMesh.uv;
		meshHold._uv2 = paintedMesh.uv2;
		meshHold._uv3 = paintedMesh.uv3;
		meshHold._colors = paintedMesh.colors;
		meshHold._uv4 = paintedMesh.uv4;
		GetComponent<MeshFilter>().sharedMesh = paintedMesh;
		if ((bool)GetComponent<MeshCollider>())
		{
			GetComponent<MeshCollider>().sharedMesh = paintedMesh;
		}
	}

	public void setWholeMesh(Mesh tmpMesh)
	{
		paintedMesh.vertices = tmpMesh.vertices;
		paintedMesh.triangles = tmpMesh.triangles;
		paintedMesh.normals = tmpMesh.normals;
		paintedMesh.colors = tmpMesh.colors;
		paintedMesh.uv = tmpMesh.uv;
		paintedMesh.uv2 = tmpMesh.uv2;
		paintedMesh.uv3 = tmpMesh.uv3;
		meshHold._vertices = tmpMesh.vertices;
		meshHold._triangles = tmpMesh.triangles;
		meshHold._normals = tmpMesh.normals;
		meshHold._colors = tmpMesh.colors;
		meshHold._uv = tmpMesh.uv;
		meshHold._uv2 = tmpMesh.uv2;
		meshHold._uv3 = tmpMesh.uv3;
	}

	public Vector3[] setVertices(Vector3[] _deformedVertices)
	{
		paintedMesh.vertices = _deformedVertices;
		meshHold._vertices = _deformedVertices;
		paintedMesh.RecalculateNormals();
		paintedMesh.RecalculateBounds();
		meshHold._normals = paintedMesh.normals;
		meshHold._bounds = paintedMesh.bounds;
		GetComponent<MeshCollider>().sharedMesh = null;
		if ((bool)GetComponent<MeshCollider>())
		{
			GetComponent<MeshCollider>().sharedMesh = paintedMesh;
		}
		return meshHold._normals;
	}

	public Vector3[] getVertices()
	{
		return paintedMesh.vertices;
	}

	public Vector3[] getNormals()
	{
		return paintedMesh.normals;
	}

	public int[] getTriangles()
	{
		return paintedMesh.triangles;
	}

	public void setTangents(Vector4[] _meshTangents)
	{
		paintedMesh.tangents = _meshTangents;
		meshHold._tangents = _meshTangents;
	}

	public Vector4[] getTangents()
	{
		return paintedMesh.tangents;
	}

	public void setColors(Color[] _vertexColors)
	{
		paintedMesh.colors = _vertexColors;
		meshHold._colors = _vertexColors;
	}

	public Color[] getColors()
	{
		return paintedMesh.colors;
	}

	public Vector2[] getUVs()
	{
		return paintedMesh.uv;
	}

	public void setUV4s(Vector2[] _uv4s)
	{
		paintedMesh.uv4 = _uv4s;
		meshHold._uv4 = _uv4s;
	}

	public Vector2[] getUV4s()
	{
		return paintedMesh.uv4;
	}

	public void unlink()
	{
		init(paintedMesh, destroyOld: false);
	}

	public void rebuild()
	{
		if (!GetComponent<MeshFilter>())
		{
			return;
		}
		paintedMesh = new Mesh();
		paintedMesh.hideFlags = HideFlags.HideAndDontSave;
		paintedMesh.name = "vpp_" + base.gameObject.name;
		if (meshHold == null || meshHold._vertices.Length == 0 || meshHold._TrianglesOfSubs.Length == 0)
		{
			paintedMesh.subMeshCount = _subMeshCount;
			paintedMesh.vertices = _vertices;
			paintedMesh.normals = _normals;
			paintedMesh.triangles = _triangles;
			meshHold._TrianglesOfSubs = new trisPerSubmesh[paintedMesh.subMeshCount];
			for (int i = 0; i < paintedMesh.subMeshCount; i++)
			{
				meshHold._TrianglesOfSubs[i] = new trisPerSubmesh();
				meshHold._TrianglesOfSubs[i].triangles = paintedMesh.GetTriangles(i);
			}
			paintedMesh.bindposes = _bindPoses;
			paintedMesh.boneWeights = _boneWeights;
			paintedMesh.bounds = _bounds;
			paintedMesh.tangents = _tangents;
			paintedMesh.uv = _uv;
			paintedMesh.uv2 = _uv2;
			paintedMesh.uv3 = _uv3;
			paintedMesh.colors = _colors;
			paintedMesh.uv4 = _uv4;
			init(paintedMesh, destroyOld: true);
		}
		else
		{
			paintedMesh.subMeshCount = meshHold._subMeshCount;
			paintedMesh.vertices = meshHold._vertices;
			paintedMesh.normals = meshHold._normals;
			for (int j = 0; j < meshHold._subMeshCount; j++)
			{
				paintedMesh.SetTriangles(meshHold._TrianglesOfSubs[j].triangles, j);
			}
			paintedMesh.bindposes = meshHold._bindPoses;
			paintedMesh.boneWeights = meshHold._boneWeights;
			paintedMesh.bounds = meshHold._bounds;
			paintedMesh.tangents = meshHold._tangents;
			paintedMesh.uv = meshHold._uv;
			paintedMesh.uv2 = meshHold._uv2;
			paintedMesh.uv3 = meshHold._uv3;
			paintedMesh.colors = meshHold._colors;
			paintedMesh.uv4 = meshHold._uv4;
			init(paintedMesh, destroyOld: true);
		}
	}

	private void Start()
	{
		if (!paintedMesh || meshHold == null)
		{
			rebuild();
		}
	}
}
