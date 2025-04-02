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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		component.shadowCastingMode = shadows;
		if (Object.op_Implicit((Object)(object)material))
		{
			component.sharedMaterial = material;
		}
		Renderer obj = component;
		SkinnedMeshRenderer val = (SkinnedMeshRenderer)(object)((obj is SkinnedMeshRenderer) ? obj : null);
		if (val != null)
		{
			val.sharedMesh = mesh;
		}
		else if (component is MeshRenderer)
		{
			meshFilter.sharedMesh = mesh;
		}
	}

	public override void Setup()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		shadows = component.shadowCastingMode;
		material = component.sharedMaterial;
		Renderer obj = component;
		SkinnedMeshRenderer val = (SkinnedMeshRenderer)(object)((obj is SkinnedMeshRenderer) ? obj : null);
		if (val != null)
		{
			mesh = val.sharedMesh;
		}
		else if (component is MeshRenderer)
		{
			meshFilter = ((Component)this).GetComponent<MeshFilter>();
			mesh = meshFilter.sharedMesh;
		}
	}
}
