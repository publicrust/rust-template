using System;
using UnityEngine;

public class AlignedLineDrawer : MonoBehaviour, IClientComponent
{
	[Serializable]
	public struct LinePoint
	{
		public Vector3 LocalPosition;

		public Vector3 WorldNormal;
	}

	public MeshFilter Filter;

	public MeshRenderer Renderer;

	public float LineWidth = 1f;

	public float SurfaceOffset = 0.001f;

	public float SprayThickness = 0.4f;

	public float uvTilingFactor = 1f;

	public bool DrawEndCaps;

	public bool DrawSideMesh;

	public bool DrawBackMesh;

	public SprayCanSpray_Freehand Spray;
}
