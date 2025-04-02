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
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		Gizmos.matrix = ((Component)this).transform.localToWorldMatrix;
		Gizmos.color = new Color(0f, 0f, 0.5f, 1f);
		Gizmos.DrawWireCube(Center, Size);
	}

	public bool Check(OBB obb)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return !EnvironmentManager.Check(obb, Type);
	}

	protected override Type GetIndexedType()
	{
		return typeof(EnvironmentVolumeCheck);
	}
}
