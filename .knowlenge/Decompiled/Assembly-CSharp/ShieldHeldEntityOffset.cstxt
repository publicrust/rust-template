using System;
using UnityEngine;

public class ShieldHeldEntityOffset : PrefabAttribute, IClientComponent
{
	public enum BoneType
	{
		r_prop,
		l_prop
	}

	public BoneType Type;

	public Vector3 LocalSpaceHoldOffsetPos;

	public Quaternion LocalSpaceHoldOffsetRot;

	protected override Type GetIndexedType()
	{
		return typeof(ShieldHeldEntityOffset);
	}
}
