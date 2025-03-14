using System;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class ConstructionPlaceholder : PrefabAttribute, IPrefabPreProcess
{
	public Mesh mesh;

	public Material material;

	public bool renderer;

	public bool collider;

	protected override void AttributeSetup(GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		base.AttributeSetup(rootObj, name, serverside, clientside, bundling);
		if (!clientside)
		{
			return;
		}
		if (renderer)
		{
			MeshFilter component = rootObj.GetComponent<MeshFilter>();
			MeshRenderer component2 = rootObj.GetComponent<MeshRenderer>();
			if (!component)
			{
				rootObj.AddComponent<MeshFilter>().sharedMesh = mesh;
			}
			if (!component2)
			{
				component2 = rootObj.AddComponent<MeshRenderer>();
				component2.sharedMaterial = material;
				component2.shadowCastingMode = ShadowCastingMode.Off;
			}
		}
		if (collider && !rootObj.GetComponent<MeshCollider>())
		{
			rootObj.AddComponent<MeshCollider>().sharedMesh = mesh;
		}
	}

	protected override Type GetIndexedType()
	{
		return typeof(ConstructionPlaceholder);
	}
}
