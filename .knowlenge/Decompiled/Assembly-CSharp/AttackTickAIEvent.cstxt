public class AttackTickAIEvent : BaseAIEvent
{
	public AttackTickAIEvent()
		: base(AIEventType.AttackTick)
	{
		base.Rate = ExecuteRate.VeryFast;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		if (base.Owner is IAIAttack iAIAttack)
		{
			BaseEntity baseEntity = memory.Entity.Get(base.InputEntityMemorySlot);
			iAIAttack.AttackTick(deltaTime, baseEntity, senses.Memory.IsLOS(baseEntity));
			base.Result = !base.Inverted;
		}
	}
}
