using System;
using UnityEngine;

public abstract class DecorComponent : PrefabAttribute
{
	public abstract void Apply(ref Vector3 pos, ref Quaternion rot, ref Vector3 scale);

	protected override Type GetIndexedType()
	{
		return typeof(DecorComponent);
	}
}
