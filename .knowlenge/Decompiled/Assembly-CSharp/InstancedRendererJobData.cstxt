using UnityEngine.Rendering;

public struct InstancedRendererJobData
{
	public int Id;

	public int DrawCallCount;

	public float MinDistance;

	public float MaxDistance;

	public ShadowCastingMode ShadowMode;

	public bool HasMesh => (int)ShadowMode != 3;

	public bool HasShadow => (int)ShadowMode > 0;
}
