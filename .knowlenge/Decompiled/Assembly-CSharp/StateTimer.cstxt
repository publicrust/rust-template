using System;
using UnityEngine;

[Serializable]
public struct StateTimer
{
	public float ReleaseTime;

	public Action OnFinished;

	public bool IsActive
	{
		get
		{
			bool flag = ReleaseTime > Time.time;
			if (!flag && OnFinished != null)
			{
				OnFinished();
				OnFinished = null;
			}
			return flag;
		}
	}

	public void Activate(float seconds, Action onFinished = null)
	{
		ReleaseTime = Time.time + seconds;
		OnFinished = onFinished;
	}
}
