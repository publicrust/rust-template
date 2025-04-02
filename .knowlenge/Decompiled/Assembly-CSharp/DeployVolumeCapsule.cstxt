using System;
using System.Collections.Generic;
using UnityEngine;

public class DeployVolumeCapsule : DeployVolume
{
	public Vector3 center = Vector3.zero;

	public float radius = 0.5f;

	public float height = 1f;

	protected override bool Check(Vector3 position, Quaternion rotation, int mask = -1)
	{
		position += rotation * (worldRotation * center + worldPosition);
		Vector3 start = position + rotation * worldRotation * Vector3.up * height * 0.5f;
		Vector3 end = position + rotation * worldRotation * Vector3.down * height * 0.5f;
		if (DeployVolume.CheckCapsule(start, end, radius, (int)layers & mask, this))
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
		return false;
	}
}
