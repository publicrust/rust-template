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
		if (!clientside || !((Behaviour)this).enabled)
		{
			return;
		}
		if (renderer)
		{
			MeshFilter = rootObj.GetComponent<MeshFilter>();
			MeshRenderer = rootObj.GetComponent<MeshRenderer>();
			if (!Object.op_Implicit((Object)(object)MeshFilter))
			{
				MeshFilter = rootObj.AddComponent<MeshFilter>();
				MeshFilter.sharedMesh = mesh;
			}
			if (!Object.op_Implicit((Object)(object)MeshRenderer))
			{
				MeshRenderer = rootObj.AddComponent<MeshRenderer>();
				((Renderer)MeshRenderer).sharedMaterial = material;
				((Renderer)MeshRenderer).shadowCastingMode = (ShadowCastingMode)0;
			}
		}
		if (collider)
		{
			MeshCollider = rootObj.GetComponent<MeshCollider>();
			if (!Object.op_Implicit((Object)(object)MeshCollider))
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
