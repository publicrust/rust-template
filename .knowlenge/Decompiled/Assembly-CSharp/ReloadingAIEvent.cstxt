public class ReloadingAIEvent : BaseAIEvent
{
	public ReloadingAIEvent()
		: base(AIEventType.Reloading)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		BaseEntity baseEntity = memory.Entity.Get(base.InputEntityMemorySlot);
		base.Result = false;
		NPCPlayer nPCPlayer = baseEntity as NPCPlayer;
		if (!(nPCPlayer == null))
		{
			bool flag = nPCPlayer.IsReloading();
			base.Result = (base.Inverted ? (!flag) : flag);
		}
	}
}
