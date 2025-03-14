using Rust.Ai.HTN;
using UnityEngine;

public class HTNPlayerSpawnGroup : SpawnGroup
{
	[Header("HTN Player Spawn Group")]
	public HTNDomain.MovementRule Movement = HTNDomain.MovementRule.FreeMove;

	public float MovementRadius = -1f;

	protected override void PostSpawnProcess(BaseEntity entity, BaseSpawnPoint spawnPoint)
	{
		HTNPlayer hTNPlayer = entity as HTNPlayer;
		if (hTNPlayer != null && hTNPlayer.AiDomain != null)
		{
			hTNPlayer.AiDomain.Movement = Movement;
			hTNPlayer.AiDomain.MovementRadius = MovementRadius;
		}
	}
}
