using UnityEngine;
using UnityEngine.AI;

public class FishNavigator : BaseNavigator
{
	public BaseNpc NPC { get; private set; }

	public override void Init(BaseCombatEntity entity, NavMeshAgent agent)
	{
		base.Init(entity, agent);
		NPC = entity as BaseNpc;
	}

	protected override bool SetCustomDestination(Vector3 pos, float speedFraction = 1f, float updateInterval = 0f)
	{
		if (!base.SetCustomDestination(pos, speedFraction, updateInterval))
		{
			return false;
		}
		base.Destination = pos;
		return true;
	}

	protected override void UpdatePositionAndRotation(Vector3 moveToPosition, float delta)
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, moveToPosition, GetTargetSpeed() * delta);
		base.BaseEntity.ServerPosition = base.transform.localPosition;
		if (ReachedPosition(moveToPosition))
		{
			Stop();
		}
		else
		{
			UpdateRotation(moveToPosition, delta);
		}
	}

	private void UpdateRotation(Vector3 moveToPosition, float delta)
	{
		base.BaseEntity.ServerRotation = Quaternion.LookRotation(Vector3Ex.Direction(moveToPosition, base.transform.position));
	}
}
