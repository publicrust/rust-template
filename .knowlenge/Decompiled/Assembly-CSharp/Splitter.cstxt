public class Splitter : IOEntity
{
	public override bool BlockFluidDraining => true;

	public override bool IsRootEntity()
	{
		return true;
	}

	public override void OnCircuitChanged(bool forceUpdate)
	{
		MarkDirtyForceUpdateOutputs();
	}
}
