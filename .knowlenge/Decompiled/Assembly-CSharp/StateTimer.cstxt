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
			bool num = ReleaseTime > Time.time;
			if (!num && OnFinished != null)
			{
				OnFinished();
				OnFinished = null;
			}
			return num;
		}
	}

	public void Activate(float seconds, Action onFinished = null)
	{
		ReleaseTime = Time.time + seconds;
		OnFinished = onFinished;
	}
}
