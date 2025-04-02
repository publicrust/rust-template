using UnityEngine;

public class MissionEntity : BaseMonoBehaviour, IOnParentDestroying
{
	public string identifier;

	public bool cleanupOnMissionSuccess = true;

	public bool cleanupOnMissionFailed = true;

	public void OnParentDestroying()
	{
		Object.Destroy((Object)(object)this);
	}

	public virtual void Setup(BasePlayer assignee, BaseMission.MissionInstance instance, string identifier, bool wantsSuccessCleanup, bool wantsFailedCleanup)
	{
		this.identifier = identifier;
		cleanupOnMissionFailed = wantsFailedCleanup;
		cleanupOnMissionSuccess = wantsSuccessCleanup;
		BaseEntity entity = GetEntity();
		if (Object.op_Implicit((Object)(object)entity))
		{
			((Component)entity).SendMessage("MissionSetupPlayer", (object)assignee, (SendMessageOptions)1);
		}
	}

	public virtual void MissionStarted(BasePlayer assignee, BaseMission.MissionInstance instance)
	{
		IMissionEntityListener[] componentsInChildren = ((Component)this).GetComponentsInChildren<IMissionEntityListener>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].MissionStarted(assignee, instance);
		}
	}

	public virtual void MissionEnded(BasePlayer assignee, BaseMission.MissionInstance instance)
	{
		IMissionEntityListener[] componentsInChildren = ((Component)this).GetComponentsInChildren<IMissionEntityListener>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].MissionEnded(assignee, instance);
		}
		instance.missionEntities.Remove(identifier);
		if ((cleanupOnMissionSuccess && (instance.status == BaseMission.MissionStatus.Completed || instance.status == BaseMission.MissionStatus.Accomplished)) || (cleanupOnMissionFailed && instance.status == BaseMission.MissionStatus.Failed))
		{
			BaseEntity entity = GetEntity();
			if (Object.op_Implicit((Object)(object)entity))
			{
				entity.Kill();
			}
		}
	}

	public BaseEntity GetEntity()
	{
		return ((Component)this).GetComponent<BaseEntity>();
	}
}
