using System;
using UnityEngine;

public class WaterCheck : PrefabAttribute
{
	public bool Rotate = true;

	protected void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(0f, 0f, 0.5f, 1f);
		Gizmos.DrawSphere(base.transform.position, 1f);
	}

	public bool Check(Vector3 pos)
	{
		return pos.y <= WaterLevel.GetWaterSurface(pos, waves: false, volumes: false);
	}

	protected override Type GetIndexedType()
	{
		return typeof(WaterCheck);
	}
}
