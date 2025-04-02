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
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if (!base.CanUpdateMovement())
		{
			return false;
		}
		if (NPCPlayerEntity.IsWounded())
		{
			return false;
		}
		if (base.CurrentNavigationType == NavigationType.NavMesh && (NPCPlayerEntity.IsDormant || !NPCPlayerEntity.syncPosition) && ((Behaviour)base.Agent).enabled)
		{
			SetDestination(NPCPlayerEntity.ServerPosition);
			return false;
		}
		return true;
	}

	protected override void UpdatePositionAndRotation(Vector3 moveToPosition, float delta)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		base.UpdatePositionAndRotation(moveToPosition, delta);
		if (overrideFacingDirectionMode == OverrideFacingDirectionMode.None)
		{
			if (base.CurrentNavigationType == NavigationType.NavMesh)
			{
				NPCPlayer nPCPlayerEntity = NPCPlayerEntity;
				Vector3 desiredVelocity = base.Agent.desiredVelocity;
				nPCPlayerEntity.SetAimDirection(((Vector3)(ref desiredVelocity)).normalized);
			}
			else if (base.CurrentNavigationType == NavigationType.AStar || base.CurrentNavigationType == NavigationType.Base)
			{
				NPCPlayerEntity.SetAimDirection(Vector3Ex.Direction2D(moveToPosition, ((Component)this).transform.position));
			}
		}
	}

	public override void ApplyFacingDirectionOverride()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		base.ApplyFacingDirectionOverride();
		if (overrideFacingDirectionMode != 0)
		{
			if (overrideFacingDirectionMode == OverrideFacingDirectionMode.Direction)
			{
				NPCPlayerEntity.SetAimDirection(facingDirectionOverride);
			}
			else if ((Object)(object)facingDirectionEntity != (Object)null)
			{
				Vector3 aimDirection = GetAimDirection(NPCPlayerEntity, facingDirectionEntity);
				facingDirectionOverride = aimDirection;
				NPCPlayerEntity.SetAimDirection(facingDirectionOverride);
			}
		}
	}

	private static Vector3 GetAimDirection(BasePlayer aimingPlayer, BaseEntity target)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)target == (Object)null)
		{
			return Vector3Ex.Direction2D(((Component)aimingPlayer).transform.position + aimingPlayer.eyes.BodyForward() * 1000f, ((Component)aimingPlayer).transform.position);
		}
		if (Vector3Ex.Distance2D(((Component)aimingPlayer).transform.position, ((Component)target).transform.position) <= 0.75f)
		{
			return Vector3Ex.Direction2D(((Component)target).transform.position, ((Component)aimingPlayer).transform.position);
		}
		Vector3 val = TargetAimPositionOffset(target) - aimingPlayer.eyes.position;
		return ((Vector3)(ref val)).normalized;
	}

	private static Vector3 TargetAimPositionOffset(BaseEntity target)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		BasePlayer basePlayer = target as BasePlayer;
		if ((Object)(object)basePlayer != (Object)null)
		{
			if (basePlayer.IsSleeping() || basePlayer.IsWounded())
			{
				return ((Component)basePlayer).transform.position + Vector3.up * 0.1f;
			}
			return basePlayer.eyes.position - Vector3.up * 0.15f;
		}
		return target.CenterPoint();
	}
}
