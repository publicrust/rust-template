using System;
using UnityEngine;

public class MapMarkerExplosion : MapMarker
{
	private float duration = 10f;

	public void SetDuration(float newDuration)
	{
		duration = newDuration;
		if (((FacepunchBehaviour)this).IsInvoking((Action)DelayedDestroy))
		{
			((FacepunchBehaviour)this).CancelInvoke((Action)DelayedDestroy);
		}
		((FacepunchBehaviour)this).Invoke((Action)DelayedDestroy, duration * 60f);
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.fromDisk)
		{
			Debug.LogWarning((object)"Loaded explosion marker from disk, cleaning up");
			((FacepunchBehaviour)this).Invoke((Action)DelayedDestroy, 3f);
		}
	}

	public void DelayedDestroy()
	{
		Kill();
	}
}
