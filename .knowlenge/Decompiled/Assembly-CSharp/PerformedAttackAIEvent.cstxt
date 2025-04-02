using UnityEngine;

public class PerformedAttackAIEvent : BaseAIEvent
{
	protected float lastExecuteTime = float.NegativeInfinity;

	private BaseCombatEntity combatEntity;

	public PerformedAttackAIEvent()
		: base(AIEventType.PerformedAttack)
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
		base.Result = false;
		combatEntity = memory.Entity.Get(base.InputEntityMemorySlot) as BaseCombatEntity;
		float num = lastExecuteTime;
		lastExecuteTime = Time.time;
		if (combatEntity == null)
		{
			return;
		}
		if (combatEntity.lastDealtDamageTime >= num)
		{
			if (combatEntity.lastDealtDamageTo == null || combatEntity.lastDealtDamageTo == combatEntity)
			{
				return;
			}
			BasePlayer basePlayer = combatEntity as BasePlayer;
			if (!(basePlayer != null) || ((!(basePlayer == memory.Entity.Get(5)) || !(basePlayer.lastDealtDamageTo == base.Owner)) && (!(basePlayer == memory.Entity.Get(5)) || (basePlayer.lastDealtDamageTo.gameObject.layer != 21 && basePlayer.lastDealtDamageTo.gameObject.layer != 8))))
			{
				if (base.ShouldSetOutputEntityMemory)
				{
					memory.Entity.Set(combatEntity.lastDealtDamageTo, base.OutputEntityMemorySlot);
				}
				base.Result = !base.Inverted;
			}
		}
		else
		{
			base.Result = base.Inverted;
		}
	}
}
