public class StateFinishedAIEvent : BaseAIEvent
{
	public StateFinishedAIEvent()
		: base(AIEventType.StateFinished)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		if (stateStatus == StateStatus.Finished)
		{
			base.Result = !base.Inverted;
		}
	}
}
