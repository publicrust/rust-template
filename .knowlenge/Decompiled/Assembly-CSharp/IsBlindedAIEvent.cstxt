public class IsBlindedAIEvent : BaseAIEvent
{
	public IsBlindedAIEvent()
		: base(AIEventType.IsBlinded)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		bool flag = senses.brain.Blinded();
		if (base.Inverted)
		{
			base.Result = !flag;
		}
		else
		{
			base.Result = flag;
		}
	}
}
