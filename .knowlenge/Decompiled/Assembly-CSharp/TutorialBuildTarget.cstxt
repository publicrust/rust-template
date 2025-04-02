using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class TutorialBuildTarget : MonoBehaviour
{
	public BaseEntityRef TargetPrefab;

	public ItemDefinition TargetItemDef;

	public GameObject VisualObject;

	public Vector3 PhysCheckOffset = Vector3.zero;

	public bool Snap = true;

	public float MaxDistance = 0.5f;

	public BaseMission RequiredMission;

	public int RequiredMissionStage = -1;

	public float MaxValidAngle = 180f;

	public bool IsValid(Construction toConstruct, Construction.Target target, ref Construction.Placement placement)
	{
		UpdateActive(target.player);
		if (!base.gameObject.activeInHierarchy)
		{
			return false;
		}
		if (!TargetPrefab.isValid || toConstruct.prefabID != TargetPrefab.Get().prefabID)
		{
			bool flag = false;
			if (TargetItemDef != null && target.player != null && target.player.GetHeldEntity() != null && target.player.GetHeldEntity().GetItem() != null)
			{
				Item item = target.player.GetHeldEntity().GetItem();
				if (item.info != null && item.info.isRedirectOf == TargetItemDef)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		if (Vector3.Distance(placement.position, base.transform.position) < MaxDistance)
		{
			if (target.socket != null && MaxValidAngle < 180f && Vector3.Angle(base.transform.forward, placement.rotation * Vector3.forward) > MaxValidAngle)
			{
				return false;
			}
			if (Snap)
			{
				placement.position = base.transform.position;
				placement.rotation = base.transform.rotation;
			}
			return true;
		}
		return false;
	}

	public bool IsValid(BasePlayer player, Deployable deployable, Vector3 worldPosition, Quaternion worldRotation)
	{
		UpdateActive(player);
		if (!base.gameObject.activeInHierarchy)
		{
			return false;
		}
		if (!TargetPrefab.isValid || deployable.prefabID != TargetPrefab.Get().prefabID)
		{
			bool flag = false;
			if (TargetItemDef != null && player != null && player.GetHeldEntity() != null && player.GetHeldEntity().GetItem() != null)
			{
				Item item = player.GetHeldEntity().GetItem();
				if (item.info != null && item.info.isRedirectOf == TargetItemDef)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		if (Vector3.Distance(worldPosition, base.transform.position) < MaxDistance)
		{
			return true;
		}
		return false;
	}

	public void UpdateActive(BasePlayer p)
	{
		if (p == null || !p.HasActiveMission())
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		BaseMission.MissionInstance activeMissionInstance = p.GetActiveMissionInstance();
		bool flag = activeMissionInstance != null && activeMissionInstance.GetMission() == RequiredMission;
		if (flag && RequiredMissionStage >= 0 && !activeMissionInstance.objectiveStatuses[RequiredMissionStage].started)
		{
			flag = false;
		}
		base.gameObject.SetActive(flag && !HasTargetBeenBuilt());
	}

	private bool HasTargetBeenBuilt()
	{
		if (!TargetPrefab.isValid)
		{
			return false;
		}
		List<BaseEntity> obj = Pool.Get<List<BaseEntity>>();
		Vis.Entities(base.transform.position + PhysCheckOffset, 0.5f + MaxDistance, obj, 1218652417);
		bool flag = false;
		uint prefabID = TargetPrefab.Get().prefabID;
		foreach (BaseEntity item in obj)
		{
			if (item.prefabID == prefabID)
			{
				flag = true;
				break;
			}
			if (item is Door)
			{
				foreach (BaseEntity child in item.children)
				{
					if (child.prefabID == prefabID)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				break;
			}
		}
		Pool.FreeUnmanaged(ref obj);
		return flag;
	}
}
