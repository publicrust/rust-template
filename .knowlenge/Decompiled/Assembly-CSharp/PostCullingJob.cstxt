using Instancing;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

[BurstCompile]
public struct PostCullingJob : IJob
{
	[ReadOnly]
	public NativeArray<int> CountPerMesh;

	[ReadOnly]
	public int RendererCount;

	[ReadOnly]
	public NativeArray<InstancedRendererJobData> Renderers;

	[WriteOnly]
	public JobInt PostCullMeshCount;

	[WriteOnly]
	public JobInt PostCullShadowCount;

	public void Execute()
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < RendererCount; i++)
		{
			InstancedRendererJobData instancedRendererJobData = Renderers[i];
			int num3 = CountPerMesh[i];
			if (instancedRendererJobData.HasShadow)
			{
				num2 += num3;
			}
			if (instancedRendererJobData.HasMesh)
			{
				num += num3;
			}
		}
		PostCullMeshCount.Value = num;
		PostCullShadowCount.Value = num2;
	}
}
