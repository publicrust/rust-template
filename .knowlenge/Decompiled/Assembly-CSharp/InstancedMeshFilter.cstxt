using System;
using Instancing;
using UnityEngine;

public class InstancedMeshFilter : PrefabAttribute, IClientComponent
{
	public MeshRenderer MeshRenderer;

	public RendererLOD RendererLOD;

	public MeshLOD MeshLOD;

	[NonSerialized]
	public InstancedMeshConfig Config;

	protected override Type GetIndexedType()
	{
		return typeof(InstancedMeshFilter);
	}
}
