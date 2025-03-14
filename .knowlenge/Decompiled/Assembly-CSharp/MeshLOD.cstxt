using System;
using UnityEngine;

public class MeshLOD : LODComponent, IBatchingHandler, IHLODMeshSource
{
	[Serializable]
	public class State
	{
		[Range(1f, 1000f)]
		public float distance;

		public Mesh mesh;
	}

	[Horizontal(1, 0)]
	public State[] States;

	public Mesh GetHighestDetailMesh()
	{
		if (States != null && States.Length != 0)
		{
			return States[0].mesh;
		}
		return null;
	}
}
