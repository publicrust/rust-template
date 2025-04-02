using System;
using UnityEngine;

public class EnvironmentVolumeCheck : PrefabAttribute
{
	[InspectorFlags]
	public EnvironmentType Type = EnvironmentType.Underground | EnvironmentType.TrainTunnels;

	public Vector3 Center = Vector3.zero;

	public Vector3 Size = Vector3.one;

	protected void OnDrawGizmosSelected()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = new Color(0f, 0f, 0.5f, 1f);
		Gizmos.DrawWireCube(Center, Size);
	}

	public bool Check(OBB obb)
	{
		return !EnvironmentManager.Check(obb, Type);
	}

	protected override Type GetIndexedType()
	{
		return typeof(EnvironmentVolumeCheck);
	}
}
