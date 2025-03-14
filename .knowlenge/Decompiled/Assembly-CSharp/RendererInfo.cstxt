using UnityEngine;
using UnityEngine.Rendering;

public class RendererInfo : ComponentInfo<Renderer>
{
	public ShadowCastingMode shadows;

	public Material material;

	public Mesh mesh;

	public MeshFilter meshFilter;

	public override void Reset()
	{
		component.shadowCastingMode = shadows;
		if ((bool)material)
		{
			component.sharedMaterial = material;
		}
		if (component is SkinnedMeshRenderer skinnedMeshRenderer)
		{
			skinnedMeshRenderer.sharedMesh = mesh;
		}
		else if (component is MeshRenderer)
		{
			meshFilter.sharedMesh = mesh;
		}
	}

	public override void Setup()
	{
		shadows = component.shadowCastingMode;
		material = component.sharedMaterial;
		if (component is SkinnedMeshRenderer skinnedMeshRenderer)
		{
			mesh = skinnedMeshRenderer.sharedMesh;
		}
		else if (component is MeshRenderer)
		{
			meshFilter = GetComponent<MeshFilter>();
			mesh = meshFilter.sharedMesh;
		}
	}
}
