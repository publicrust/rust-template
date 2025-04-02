using System;
using UnityEngine;

public class RigidbodyInfo : PrefabAttribute, IClientComponent
{
	[NonSerialized]
	public float mass;

	[NonSerialized]
	public float drag;

	[NonSerialized]
	public float angularDrag;

	protected override Type GetIndexedType()
	{
		return typeof(RigidbodyInfo);
	}

	protected override void AttributeSetup(GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		base.AttributeSetup(rootObj, name, serverside, clientside, bundling);
		Rigidbody component = rootObj.GetComponent<Rigidbody>();
		if (component == null)
		{
			Debug.LogError(GetType().Name + ": RigidbodyInfo couldn't find a rigidbody on " + name + "! If a RealmedRemove is removing it, make sure this script is above the RealmedRemove script so that this gets processed first.");
			return;
		}
		mass = component.mass;
		drag = component.drag;
		angularDrag = component.angularDrag;
	}
}
