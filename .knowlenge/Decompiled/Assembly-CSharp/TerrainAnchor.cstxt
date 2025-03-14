using System;
using UnityEngine;

public class TerrainAnchor : PrefabAttribute
{
	public float Extents = 1f;

	public float Offset;

	protected void OnDrawGizmosSelected()
	{
		Vector3 position = base.transform.position;
		Vector3 lossyScale = base.transform.lossyScale;
		float num = Extents * lossyScale.y;
		float num2 = Offset * lossyScale.y;
		Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 1f);
		Gizmos.DrawLine(position + Vector3.up * num2 - Vector3.up * num, position + Vector3.up * num2 + Vector3.up * num);
	}

	public void Apply(out float height, out float min, out float max, Vector3 pos, Vector3 scale)
	{
		float num = Extents * scale.y;
		float num2 = Offset * scale.y;
		height = TerrainMeta.HeightMap.GetHeight(pos);
		min = height - num2 - num;
		max = height - num2 + num;
	}

	protected override Type GetIndexedType()
	{
		return typeof(TerrainAnchor);
	}
}
