public class IsVisibleAIEvent : BaseAIEvent
{
	public IsVisibleAIEvent()
		: base(AIEventType.IsVisible)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = false;
		BaseEntity baseEntity = memory.Entity.Get(base.InputEntityMemorySlot);
		if (!(baseEntity == null) && base.Owner is IAIAttack)
		{
			bool flag = senses.Memory.IsLOS(baseEntity);
			base.Result = (base.Inverted ? (!flag) : flag);
		}
	}
}
