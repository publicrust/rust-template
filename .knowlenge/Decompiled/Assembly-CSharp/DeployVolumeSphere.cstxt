using System;
using System.Collections.Generic;
using UnityEngine;

public class DeployVolumeSphere : DeployVolume
{
	public Vector3 center = Vector3.zero;

	public float radius = 0.5f;

	protected override bool Check(Vector3 position, Quaternion rotation, int mask = -1)
	{
		position += rotation * (worldRotation * center + worldPosition);
		if (DeployVolume.CheckSphere(position, radius, (int)layers & mask, this))
		{
			return true;
		}
		return false;
	}

	protected override bool Check(Vector3 position, Quaternion rotation, List<Type> allowedTypes, int mask = -1)
	{
		return Check(position, rotation, mask);
	}

	protected override bool Check(Vector3 position, Quaternion rotation, OBB obb, int mask = -1)
	{
		position += rotation * (worldRotation * center + worldPosition);
		if (((int)layers & mask) != 0 && Vector3.Distance(position, obb.ClosestPoint(position)) <= radius)
		{
			return true;
		}
		return false;
	}
}
