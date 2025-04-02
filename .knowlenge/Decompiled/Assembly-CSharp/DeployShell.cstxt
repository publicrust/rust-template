using System;
using UnityEngine;

public class DeployShell : PrefabAttribute
{
	public Bounds bounds = new Bounds(Vector3.zero, Vector3.one);

	public OBB WorldSpaceBounds(Transform transform)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		return new OBB(transform.position, transform.lossyScale, transform.rotation, bounds);
	}

	public float LineOfSightPadding()
	{
		return 0.025f;
	}

	protected override Type GetIndexedType()
	{
		return typeof(DeployShell);
	}
}
