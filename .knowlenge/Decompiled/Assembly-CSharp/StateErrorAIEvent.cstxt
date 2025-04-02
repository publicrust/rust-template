public class StateErrorAIEvent : BaseAIEvent
{
	public StateErrorAIEvent()
		: base(AIEventType.StateError)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		switch (stateStatus)
		{
		case StateStatus.Error:
			base.Result = !base.Inverted;
			break;
		case StateStatus.Running:
			base.Result = base.Inverted;
			break;
		}
	}
}
