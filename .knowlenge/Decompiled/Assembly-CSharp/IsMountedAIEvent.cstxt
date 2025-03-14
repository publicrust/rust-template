public class IsMountedAIEvent : BaseAIEvent
{
	public IsMountedAIEvent()
		: base(AIEventType.IsMounted)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		IAIMounted iAIMounted = memory.Entity.Get(base.InputEntityMemorySlot) as IAIMounted;
		base.Result = false;
		if (iAIMounted != null)
		{
			if (base.Inverted && !iAIMounted.IsMounted())
			{
				base.Result = true;
			}
			if (!base.Inverted && iAIMounted.IsMounted())
			{
				base.Result = true;
			}
			if (base.Result && base.ShouldSetOutputEntityMemory)
			{
				memory.Entity.Set(memory.Entity.Get(base.InputEntityMemorySlot), base.OutputEntityMemorySlot);
			}
		}
	}
}
