using UnityEngine;

public class TriggerNotifyEntity : TriggerBase, IPrefabPreProcess
{
	public GameObject notifyTarget;

	private INotifyEntityTrigger toNotify;

	public bool runClientside = true;

	public bool runServerside = true;

	public bool HasContents
	{
		get
		{
			if (contents != null)
			{
				return contents.Count > 0;
			}
			return false;
		}
	}

	internal override void OnEntityEnter(BaseEntity ent)
	{
		base.OnEntityEnter(ent);
		if (toNotify != null || (notifyTarget != null && notifyTarget.TryGetComponent<INotifyEntityTrigger>(out toNotify)))
		{
			toNotify.OnEntityEnter(ent);
		}
	}

	internal override void OnEntityLeave(BaseEntity ent)
	{
		base.OnEntityLeave(ent);
		if (toNotify != null || (notifyTarget != null && notifyTarget.TryGetComponent<INotifyEntityTrigger>(out toNotify)))
		{
			toNotify.OnEntityLeave(ent);
		}
	}

	public void PreProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		if ((!clientside || !runClientside) && (!serverside || !runServerside))
		{
			preProcess.RemoveComponent(this);
		}
	}
}
