using ConVar;
using UnityEngine;
using UnityEngine.AI;

public class NPCNavigator : BaseNavigator
{
	public int DestroyOnFailedSampleCount = 5;

	private int sampleFailCount;

	public BaseNpc NPC { get; private set; }

	public override void Init(BaseCombatEntity entity, NavMeshAgent agent)
	{
		base.Init(entity, agent);
		NPC = entity as BaseNpc;
		sampleFailCount = 0;
	}

	public override void OnFailedToPlaceOnNavmesh()
	{
		base.OnFailedToPlaceOnNavmesh();
		if (SingletonComponent<DynamicNavMesh>.Instance == null || SingletonComponent<DynamicNavMesh>.Instance.IsBuilding)
		{
			return;
		}
		sampleFailCount++;
		if (DestroyOnFailedSampleCount > 0 && sampleFailCount >= DestroyOnFailedSampleCount)
		{
			Debug.LogWarning("Failed to sample navmesh " + sampleFailCount + " times in a row at: " + base.transform.position.ToString() + ". Destroying: " + base.gameObject.name);
			if (NPC != null && !NPC.IsDestroyed)
			{
				NPC.Kill();
			}
		}
	}

	public override void OnPlacedOnNavmesh()
	{
		base.OnPlacedOnNavmesh();
		sampleFailCount = 0;
	}

	protected override bool CanEnableNavMeshNavigation()
	{
		if (!base.CanEnableNavMeshNavigation())
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
		if (NPC != null && (NPC.IsDormant || !NPC.syncPosition) && base.Agent.enabled)
		{
			SetDestination(NPC.ServerPosition);
			return false;
		}
		return true;
	}

	protected override void UpdatePositionAndRotation(Vector3 moveToPosition, float delta)
	{
		base.UpdatePositionAndRotation(moveToPosition, delta);
		UpdateRotation(moveToPosition, delta);
	}

	private void UpdateRotation(Vector3 moveToPosition, float delta)
	{
		if (overrideFacingDirectionMode != 0)
		{
			return;
		}
		if (traversingNavMeshLink)
		{
			Vector3 vector = base.Agent.destination - base.BaseEntity.ServerPosition;
			if (vector.sqrMagnitude > 1f)
			{
				vector = currentNavMeshLinkEndPos - base.BaseEntity.ServerPosition;
			}
			_ = vector.sqrMagnitude;
			_ = 0.001f;
		}
		else if ((base.Agent.destination - base.BaseEntity.ServerPosition).sqrMagnitude > 1f)
		{
			Vector3 normalized = base.Agent.desiredVelocity.normalized;
			if (normalized.sqrMagnitude > 0.001f)
			{
				base.BaseEntity.ServerRotation = Quaternion.LookRotation(normalized);
			}
		}
	}

	public override void ApplyFacingDirectionOverride()
	{
		base.ApplyFacingDirectionOverride();
		base.BaseEntity.ServerRotation = Quaternion.LookRotation(base.FacingDirectionOverride);
	}

	public override bool IsSwimming()
	{
		if (!AI.npcswimming)
		{
			return false;
		}
		if (NPC != null)
		{
			return NPC.swimming;
		}
		return false;
	}
}
