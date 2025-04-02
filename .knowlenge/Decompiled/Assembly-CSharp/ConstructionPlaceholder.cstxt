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

	[NonSerialized]
	public MeshRenderer MeshRenderer;

	[NonSerialized]
	public MeshFilter MeshFilter;

	[NonSerialized]
	public MeshCollider MeshCollider;

	protected override void AttributeSetup(GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		base.AttributeSetup(rootObj, name, serverside, clientside, bundling);
		if (!clientside || !base.enabled)
		{
			return;
		}
		if (renderer)
		{
			MeshFilter = rootObj.GetComponent<MeshFilter>();
			MeshRenderer = rootObj.GetComponent<MeshRenderer>();
			if (!MeshFilter)
			{
				MeshFilter = rootObj.AddComponent<MeshFilter>();
				MeshFilter.sharedMesh = mesh;
			}
			if (!MeshRenderer)
			{
				MeshRenderer = rootObj.AddComponent<MeshRenderer>();
				MeshRenderer.sharedMaterial = material;
				MeshRenderer.shadowCastingMode = ShadowCastingMode.Off;
			}
		}
		if (collider)
		{
			MeshCollider = rootObj.GetComponent<MeshCollider>();
			if (!MeshCollider)
			{
				MeshCollider = rootObj.AddComponent<MeshCollider>();
				MeshCollider.sharedMesh = mesh;
			}
		}
	}

	protected override Type GetIndexedType()
	{
		return typeof(ConstructionPlaceholder);
	}
}
