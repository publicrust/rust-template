using System;
using UnityEngine;

[Serializable]
public class MeshHolder
{
	[HideInInspector]
	public Vector3[] _vertices;

	[HideInInspector]
	public Vector3[] _normals;

	[HideInInspector]
	public int[] _triangles;

	[HideInInspector]
	public trisPerSubmesh[] _TrianglesOfSubs;

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

	public void setAnimationData(Mesh mesh)
	{
		_colors = mesh.colors;
	}
}
