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
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		base.Result = base.Inverted;
		BaseEntity baseEntity = memory.Entity.Get(base.InputEntityMemorySlot);
		if ((Object)(object)baseEntity == (Object)null)
		{
			base.Result = !base.Inverted;
			return;
		}
		if (Vector3.Distance(((Component)baseEntity).transform.position, ((Component)base.Owner).transform.position) > senses.TargetLostRange)
		{
			base.Result = !base.Inverted;
			return;
		}
		BasePlayer basePlayer = baseEntity as BasePlayer;
		if (baseEntity.Health() <= 0f || ((Object)(object)basePlayer != (Object)null && basePlayer.IsDead()))
		{
			base.Result = !base.Inverted;
		}
		else if (senses.ignoreSafeZonePlayers && (Object)(object)basePlayer != (Object)null && basePlayer.InSafeZone())
		{
			base.Result = !base.Inverted;
		}
	}
}
