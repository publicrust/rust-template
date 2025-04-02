using System;
using UnityEngine;

public class EntityFlag_TOD : EntityComponent<BaseEntity>
{
	public BaseEntity.Flags desiredFlag;

	public bool onAtNight = true;

	public void Start()
	{
		((FacepunchBehaviour)this).Invoke((Action)Initialize, 1f);
	}

	public void Initialize()
	{
		if (!((Object)(object)base.baseEntity == (Object)null) && !base.baseEntity.isClient)
		{
			((FacepunchBehaviour)this).InvokeRandomized((Action)DoTimeCheck, 0f, 5f, 1f);
		}
	}

	public bool WantsOn()
	{
		if ((Object)(object)TOD_Sky.Instance == (Object)null)
		{
			return false;
		}
		bool isNight = TOD_Sky.Instance.IsNight;
		if (onAtNight == isNight)
		{
			return true;
		}
		return false;
	}

	private void DoTimeCheck()
	{
		bool num = base.baseEntity.HasFlag(desiredFlag);
		bool flag = WantsOn();
		if (num != flag)
		{
			base.baseEntity.SetFlag(desiredFlag, flag);
		}
	}
}
