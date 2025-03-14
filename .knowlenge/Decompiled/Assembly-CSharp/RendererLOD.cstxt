using System;
using UnityEngine;
using UnityEngine.Rendering;

public class RendererLOD : LODComponent, IBatchingHandler
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
	}

	public State[] States;
}
