using System;

public struct PerformanceSamplePoint
{
	public int UpdateCount;

	public int FixedUpdateCount;

	public int RenderCount;

	public TimeSpan PreCull;

	public TimeSpan Update;

	public TimeSpan LateUpdate;

	public TimeSpan PhysicsUpdate;

	public TimeSpan Render;

	public TimeSpan FixedUpdate;

	public TimeSpan TotalCPU;

	public int CpuUpdateCount;

	public PerformanceSamplePoint Add(PerformanceSamplePoint other)
	{
		PerformanceSamplePoint result = default(PerformanceSamplePoint);
		result.UpdateCount = UpdateCount + other.UpdateCount;
		result.FixedUpdateCount = FixedUpdateCount + other.FixedUpdateCount;
		result.RenderCount = RenderCount + other.RenderCount;
		result.PreCull = PreCull + other.PreCull;
		result.Update = Update + other.Update;
		result.LateUpdate = LateUpdate + other.LateUpdate;
		result.PhysicsUpdate = PhysicsUpdate + other.PhysicsUpdate;
		result.Render = Render + other.Render;
		result.FixedUpdate = FixedUpdate + other.FixedUpdate;
		result.TotalCPU = TotalCPU + other.TotalCPU;
		result.CpuUpdateCount = CpuUpdateCount + other.CpuUpdateCount;
		return result;
	}
}
