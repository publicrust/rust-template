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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		localToWorldMatrix = ((Component)this).transform.localToWorldMatrix;
		MeshFilter val2 = default(MeshFilter);
		for (int num = States.Length - 1; num >= 0; num--)
		{
			Mesh val = null;
			if ((Object)(object)States[num].renderer != (Object)null && ((Component)States[num].renderer).TryGetComponent<MeshFilter>(ref val2))
			{
				val = val2.sharedMesh;
			}
			if ((Object)(object)val != (Object)null)
			{
				localToWorldMatrix = ((Component)States[num].renderer).transform.localToWorldMatrix;
				return val;
			}
		}
		return null;
	}

	public void PreProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
	}
}
