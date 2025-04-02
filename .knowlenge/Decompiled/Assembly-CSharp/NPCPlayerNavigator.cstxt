using UnityEngine;
using UnityEngine.AI;

public class NPCPlayerNavigator : BaseNavigator
{
	public NPCPlayer NPCPlayerEntity { get; private set; }

	public override void Init(BaseCombatEntity entity, NavMeshAgent agent)
	{
		base.Init(entity, agent);
		NPCPlayerEntity = entity as NPCPlayer;
	}

	protected override bool CanEnableNavMeshNavigation()
	{
		if (!base.CanEnableNavMeshNavigation())
		{
			return false;
		}
		if (NPCPlayerEntity.isMounted && !CanNavigateMounted)
		{
			return false;
		}
		return true;
	}

	protected override bool CanUpdateMovement()
	{
		if (!base.CanUpdateMovement())
		{
			return false;
		}
		if (NPCPlayerEntity.IsWounded())
		{
			return false;
		}
		if (base.CurrentNavigationType == NavigationType.NavMesh && (NPCPlayerEntity.IsDormant || !NPCPlayerEntity.syncPosition) && base.Agent.enabled)
		{
			SetDestination(NPCPlayerEntity.ServerPosition);
			return false;
		}
		return true;
	}

	protected override void UpdatePositionAndRotation(Vector3 moveToPosition, float delta)
	{
		base.UpdatePositionAndRotation(moveToPosition, delta);
		if (overrideFacingDirectionMode == OverrideFacingDirectionMode.None)
		{
			if (base.CurrentNavigationType == NavigationType.NavMesh)
			{
				NPCPlayerEntity.SetAimDirection(base.Agent.desiredVelocity.normalized);
			}
			else if (base.CurrentNavigationType == NavigationType.AStar || base.CurrentNavigationType == NavigationType.Base)
			{
				NPCPlayerEntity.SetAimDirection(Vector3Ex.Direction2D(moveToPosition, base.transform.position));
			}
		}
	}

	public override void ApplyFacingDirectionOverride()
	{
		base.ApplyFacingDirectionOverride();
		if (overrideFacingDirectionMode != 0)
		{
			if (overrideFacingDirectionMode == OverrideFacingDirectionMode.Direction)
			{
				NPCPlayerEntity.SetAimDirection(facingDirectionOverride);
			}
			else if (facingDirectionEntity != null)
			{
				Vector3 aimDirection = GetAimDirection(NPCPlayerEntity, facingDirectionEntity);
				facingDirectionOverride = aimDirection;
				NPCPlayerEntity.SetAimDirection(facingDirectionOverride);
			}
		}
	}

	private static Vector3 GetAimDirection(BasePlayer aimingPlayer, BaseEntity target)
	{
		if (target == null)
		{
			return Vector3Ex.Direction2D(aimingPlayer.transform.position + aimingPlayer.eyes.BodyForward() * 1000f, aimingPlayer.transform.position);
		}
		if (Vector3Ex.Distance2D(aimingPlayer.transform.position, target.transform.position) <= 0.75f)
		{
			return Vector3Ex.Direction2D(target.transform.position, aimingPlayer.transform.position);
		}
		return (TargetAimPositionOffset(target) - aimingPlayer.eyes.position).normalized;
	}

	private static Vector3 TargetAimPositionOffset(BaseEntity target)
	{
		BasePlayer basePlayer = target as BasePlayer;
		if (basePlayer != null)
		{
			if (basePlayer.IsSleeping() || basePlayer.IsWounded())
			{
				return basePlayer.transform.position + Vector3.up * 0.1f;
			}
			return basePlayer.eyes.position - Vector3.up * 0.15f;
		}
		return target.CenterPoint();
	}
}
