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
		if ((Object)(object)combatEntity == (Object)null)
		{
			return;
		}
		if (combatEntity.lastDealtDamageTime >= num)
		{
			if ((Object)(object)combatEntity.lastDealtDamageTo == (Object)null || (Object)(object)combatEntity.lastDealtDamageTo == (Object)(object)combatEntity)
			{
				return;
			}
			BasePlayer basePlayer = combatEntity as BasePlayer;
			if (!((Object)(object)basePlayer != (Object)null) || ((!((Object)(object)basePlayer == (Object)(object)memory.Entity.Get(5)) || !((Object)(object)basePlayer.lastDealtDamageTo == (Object)(object)base.Owner)) && (!((Object)(object)basePlayer == (Object)(object)memory.Entity.Get(5)) || (((Component)basePlayer.lastDealtDamageTo).gameObject.layer != 21 && ((Component)basePlayer.lastDealtDamageTo).gameObject.layer != 8))))
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
