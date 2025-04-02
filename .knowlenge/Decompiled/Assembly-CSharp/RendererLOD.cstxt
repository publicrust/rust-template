using System;
using UnityEngine;
using UnityEngine.Rendering;

public class RendererLOD : LODComponent, IBatchingHandler, IPrefabPreProcess, ICustomMaterialReplacer, IHLODMeshSource
{
	[Serializable]
	public class State
	{
		public float distance;

		public Renderer renderer;

		[NonSerialized]
		public MeshFilter filter;

		[NonSerialized]
		public ShadowCastingMode shadowMode;

		[NonSerialized]
		public bool isImpostor;

		[ReadOnly]
		public bool hasCached;

		[ReadOnly]
		public Mesh stateMesh;

		[ReadOnly]
		public Material[] stateMaterials;

		[ReadOnly]
		public ShadowCastingMode cachedShadowMode;
	}

	public float minDistanceMultiplier;

	public State[] States;

	[ReadOnly]
	public MeshRenderer collapsedRenderer;

	[ReadOnly]
	public MeshFilter collapsedFilter;

	public Mesh GetFinalLodMesh(out Matrix4x4 localToWorldMatrix)
	{
		localToWorldMatrix = base.transform.localToWorldMatrix;
		for (int num = States.Length - 1; num >= 0; num--)
		{
			Mesh mesh = null;
			if (States[num].renderer != null && States[num].renderer.TryGetComponent<MeshFilter>(out var component))
			{
				mesh = component.sharedMesh;
			}
			if (mesh != null)
			{
				localToWorldMatrix = States[num].renderer.transform.localToWorldMatrix;
				return mesh;
			}
		}
		return null;
	}

	public void PreProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
	}
}
