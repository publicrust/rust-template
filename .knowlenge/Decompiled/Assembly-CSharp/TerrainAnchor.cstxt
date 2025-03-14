using System;
using UnityEngine;

public class TerrainAnchor : PrefabAttribute
{
	public float Extents = 1f;

	public float Offset;

	protected void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 1f);
		Gizmos.DrawLine(base.transform.position + Vector3.up * Offset - Vector3.up * Extents, base.transform.position + Vector3.up * Offset + Vector3.up * Extents);
	}

	public void Apply(out float height, out float min, out float max, Vector3 pos)
	{
		float extents = Extents;
		float offset = Offset;
		height = TerrainMeta.HeightMap.GetHeight(pos);
		min = height - offset - extents;
		max = height - offset + extents;
	}

	protected override Type GetIndexedType()
	{
		return typeof(TerrainAnchor);
	}
}
