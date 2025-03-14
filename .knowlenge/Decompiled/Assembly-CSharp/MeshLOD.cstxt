using System;
using UnityEngine;

public class MeshLOD : LODComponent, IBatchingHandler
{
	[Serializable]
	public class State
	{
		public float distance;

		public Mesh mesh;
	}

	[Horizontal(1, 0)]
	public State[] States;
}
