using UnityEngine;

public class AttackedAIEvent : BaseAIEvent
{
	protected float lastExecuteTime = float.NegativeInfinity;

	private BaseCombatEntity combatEntity;

	public AttackedAIEvent()
		: base(AIEventType.Attacked)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Reset()
	{
		base.Reset();
		lastExecuteTime = Time.time;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		combatEntity = memory.Entity.Get(base.InputEntityMemorySlot) as BaseCombatEntity;
		float num = lastExecuteTime;
		lastExecuteTime = Time.time;
		if (combatEntity == null || !(combatEntity.lastAttackedTime >= num) || combatEntity.lastAttacker == null || combatEntity.lastAttacker == combatEntity)
		{
			return;
		}
		BasePlayer basePlayer = combatEntity.lastAttacker as BasePlayer;
		if (!(basePlayer != null) || !(basePlayer == memory.Entity.Get(5)) || !(basePlayer.lastDealtDamageTo == base.Owner))
		{
			if (base.ShouldSetOutputEntityMemory)
			{
				memory.Entity.Set(combatEntity.lastAttacker, base.OutputEntityMemorySlot);
			}
			base.Result = !base.Inverted;
		}
	}
}
