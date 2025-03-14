using UnityEngine;
using UnityEngine.Events;

public class EntityFlag_Toggle : EntityComponent<BaseEntity>, IOnPostNetworkUpdate, IOnSendNetworkUpdate, IPrefabPreProcess
{
	public bool runClientside = true;

	public bool runServerside = true;

	public BaseEntity.Flags flag;

	[SerializeField]
	private UnityEvent onFlagEnabled = new UnityEvent();

	[SerializeField]
	private UnityEvent onFlagDisabled = new UnityEvent();

	internal bool hasRunOnce;

	internal bool lastHasFlag;

	protected void OnDisable()
	{
		hasRunOnce = false;
		lastHasFlag = false;
	}

	public void DoUpdate(BaseEntity entity)
	{
		bool flag = entity.HasFlag(this.flag);
		if (!hasRunOnce || flag != lastHasFlag)
		{
			hasRunOnce = true;
			lastHasFlag = flag;
			if (flag)
			{
				onFlagEnabled.Invoke();
			}
			else
			{
				onFlagDisabled.Invoke();
			}
			OnStateToggled(flag);
		}
	}

	protected virtual void OnStateToggled(bool state)
	{
	}

	public void OnPostNetworkUpdate(BaseEntity entity)
	{
		if (!(base.baseEntity != entity) && runClientside)
		{
			DoUpdate(entity);
		}
	}

	public void OnSendNetworkUpdate(BaseEntity entity)
	{
		if (runServerside)
		{
			DoUpdate(entity);
		}
	}

	public void PreProcess(IPrefabProcessor process, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		if ((!clientside || !runClientside) && (!serverside || !runServerside))
		{
			process.RemoveComponent(this);
		}
	}
}
