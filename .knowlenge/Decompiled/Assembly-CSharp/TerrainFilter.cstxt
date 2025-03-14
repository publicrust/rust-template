using System;
using UnityEngine;

public class TerrainFilter : PrefabAttribute
{
	public SpawnFilter Filter;

	protected void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 1f);
		Gizmos.DrawCube(base.transform.position + Vector3.up * 50f * 0.5f, new Vector3(0.5f, 50f, 0.5f));
		Gizmos.DrawSphere(base.transform.position + Vector3.up * 50f, 2f);
	}

	public bool Check(Vector3 pos)
	{
		return Filter.GetFactor(pos) > 0f;
	}

	protected override Type GetIndexedType()
	{
		return typeof(TerrainFilter);
	}
}
