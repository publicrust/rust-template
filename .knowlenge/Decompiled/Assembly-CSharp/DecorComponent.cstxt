using System;
using UnityEngine;

public abstract class DecorComponent : PrefabAttribute
{
	internal bool isRoot;

	public abstract void Apply(ref Vector3 pos, ref Quaternion rot, ref Vector3 scale);

	protected override void AttributeSetup(GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		base.AttributeSetup(rootObj, name, serverside, clientside, bundling);
		isRoot = rootObj == base.gameObject;
	}

	protected override Type GetIndexedType()
	{
		return typeof(DecorComponent);
	}
}
