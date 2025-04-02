using UnityEngine.Rendering;

public struct InstancedRendererJobData
{
	public int Id;

	public int DrawCallCount;

	public float MinDistance;

	public float MaxDistance;

	public ShadowCastingMode ShadowMode;

	public bool HasMesh => ShadowMode != ShadowCastingMode.ShadowsOnly;

	public bool HasShadow => ShadowMode != ShadowCastingMode.Off;
}
