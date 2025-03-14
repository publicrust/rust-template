using System;
using System.Collections.Generic;
using UnityEngine;

public class DamageRenderer : MonoBehaviour, IClientComponent
{
	[Serializable]
	private struct DamageShowingRenderer
	{
		public Renderer renderer;

		public int[] indices;

		public DamageShowingRenderer(Renderer renderer, int[] indices)
		{
			this.renderer = renderer;
			this.indices = indices;
		}
	}

	[SerializeField]
	private List<Material> damageShowingMats;

	[SerializeField]
	[HideInInspector]
	private List<DamageShowingRenderer> damageShowingRenderers;

	[SerializeField]
	[HideInInspector]
	private List<GlassPane> damageShowingGlassRenderers;
}
