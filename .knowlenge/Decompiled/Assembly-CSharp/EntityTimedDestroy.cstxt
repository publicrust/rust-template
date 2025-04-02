using System;
using UnityEngine;

public class EntityTimedDestroy : EntityComponent<BaseEntity>
{
	public float secondsTillDestroy = 1f;

	private void OnEnable()
	{
		((FacepunchBehaviour)this).Invoke((Action)TimedDestroy, secondsTillDestroy);
	}

	private void TimedDestroy()
	{
		if ((Object)(object)base.baseEntity != (Object)null)
		{
			base.baseEntity.Kill();
		}
		else
		{
			Debug.LogWarning((object)"EntityTimedDestroy failed, baseEntity was already null!");
		}
	}
}
