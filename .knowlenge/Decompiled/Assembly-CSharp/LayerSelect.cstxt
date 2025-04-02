using System;
using UnityEngine;

[Serializable]
public struct LayerSelect
{
	[SerializeField]
	private int layer;

	public int Mask => 1 << layer;

	public string Name => LayerMask.LayerToName(layer);

	public LayerSelect(int layer)
	{
		this.layer = layer;
	}

	public static implicit operator int(LayerSelect layer)
	{
		return layer.layer;
	}

	public static implicit operator LayerSelect(int layer)
	{
		return new LayerSelect(layer);
	}
}
