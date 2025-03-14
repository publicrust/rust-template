using System;
using UnityEngine;
using UnityEngine.Rendering;

public class TreeLOD : LODComponent
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

	[Horizontal(1, 0)]
	public State[] States;
}
