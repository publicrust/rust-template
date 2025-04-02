using System;
using UnityEngine;
using UnityEngine.Rendering;

public class FoliageGridBaked : FoliageGrid
{
	[Serializable]
	public struct BakedFoliagePlacement
	{
		public Mesh FoliageMesh;

		public Material FoliageMaterial;

		public ShadowCastingMode Shadows;

		public int Layer;

		public Mesh DataMesh;

		private bool hasCached;

		private Vector3[] position;

		private Quaternion[] rotation;

		private Vector3[] scale;

		private int totalPoints;
	}

	public BakedFoliagePlacement[] BakedData = new BakedFoliagePlacement[0];
}
