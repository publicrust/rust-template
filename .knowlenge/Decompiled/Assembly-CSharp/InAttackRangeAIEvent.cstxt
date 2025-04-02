public class InAttackRangeAIEvent : BaseAIEvent
{
	public InAttackRangeAIEvent()
		: base(AIEventType.InAttackRange)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		BaseEntity baseEntity = memory.Entity.Get(base.InputEntityMemorySlot);
		base.Result = false;
		if (!(baseEntity == null) && base.Owner is IAIAttack iAIAttack)
		{
			float dist;
			bool flag = iAIAttack.IsTargetInRange(baseEntity, out dist);
			base.Result = (base.Inverted ? (!flag) : flag);
		}
	}
}
