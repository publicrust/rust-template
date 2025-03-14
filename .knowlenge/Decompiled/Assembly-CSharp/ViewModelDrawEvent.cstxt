using System;
using UnityEngine;

[Serializable]
public struct ViewModelDrawEvent : IEquatable<ViewModelDrawEvent>
{
	public ViewModelRenderer viewModelRenderer;

	public Renderer renderer;

	public bool skipDepthPrePass;

	public Material material;

	public int subMesh;

	public int pass;

	public bool Equals(ViewModelDrawEvent other)
	{
		if (object.Equals(viewModelRenderer, other.viewModelRenderer) && object.Equals(renderer, other.renderer) && skipDepthPrePass == other.skipDepthPrePass && object.Equals(material, other.material) && subMesh == other.subMesh)
		{
			return pass == other.pass;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is ViewModelDrawEvent other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((((((((((viewModelRenderer != null) ? viewModelRenderer.GetHashCode() : 0) * 397) ^ ((renderer != null) ? renderer.GetHashCode() : 0)) * 397) ^ skipDepthPrePass.GetHashCode()) * 397) ^ ((material != null) ? material.GetHashCode() : 0)) * 397) ^ subMesh) * 397) ^ pass;
	}
}
