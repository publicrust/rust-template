using System;
using UnityEngine;

public class DeployShell : PrefabAttribute
{
	public Bounds bounds = new Bounds(Vector3.zero, Vector3.one);

	public OBB WorldSpaceBounds(Transform transform)
	{
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
