public class OnPositionMemorySetAIEvent : BaseAIEvent
{
	public OnPositionMemorySetAIEvent()
		: base(AIEventType.OnPositionMemorySet)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = false;
		if (memory.Position.GetTimeSinceSet(5) <= 0.5f)
		{
			base.Result = !base.Inverted;
		}
		else
		{
			base.Result = base.Inverted;
		}
	}
}
