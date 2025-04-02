using UnityEngine;

public class TargetLostAIEvent : BaseAIEvent
{
	public float Range { get; set; }

	public TargetLostAIEvent()
		: base(AIEventType.TargetLost)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		BaseEntity baseEntity = memory.Entity.Get(base.InputEntityMemorySlot);
		if (baseEntity == null)
		{
			base.Result = !base.Inverted;
			return;
		}
		if (Vector3.Distance(baseEntity.transform.position, base.Owner.transform.position) > senses.TargetLostRange)
		{
			base.Result = !base.Inverted;
			return;
		}
		BasePlayer basePlayer = baseEntity as BasePlayer;
		if (baseEntity.Health() <= 0f || (basePlayer != null && basePlayer.IsDead()))
		{
			base.Result = !base.Inverted;
		}
		else if (senses.ignoreSafeZonePlayers && basePlayer != null && basePlayer.InSafeZone())
		{
			base.Result = !base.Inverted;
		}
	}
}
