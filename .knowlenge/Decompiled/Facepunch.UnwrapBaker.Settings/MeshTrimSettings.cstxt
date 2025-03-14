using System;
using UnityEngine;

[Serializable]
public struct MeshTrimSettings
{
	public bool TrimBasedOnVisibility;

	[Range(1f, 100f)]
	public int IterationsPerLoop;

	public float StartHeight;

	public float EndHeight;

	[Range(1f, 100f)]
	public int HeightIterations;

	public float Radius;

	public float MinimumTriangleArea;

	public float MinimumTriangleEdgeLength;

	public Vector3 OriginOffset;

	public static MeshTrimSettings Default = new MeshTrimSettings
	{
		TrimBasedOnVisibility = true,
		IterationsPerLoop = 16,
		StartHeight = 1f,
		EndHeight = 16f,
		HeightIterations = 16,
		Radius = 50f,
		MinimumTriangleArea = 0.1f,
		MinimumTriangleEdgeLength = 0.02f,
		OriginOffset = Vector3.zero
	};
}
