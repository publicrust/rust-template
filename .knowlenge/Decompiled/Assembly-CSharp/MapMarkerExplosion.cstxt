using UnityEngine;

public class MapMarkerExplosion : MapMarker
{
	private float duration = 10f;

	public void SetDuration(float newDuration)
	{
		duration = newDuration;
		if (IsInvoking(DelayedDestroy))
		{
			CancelInvoke(DelayedDestroy);
		}
		Invoke(DelayedDestroy, duration * 60f);
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.fromDisk)
		{
			Debug.LogWarning("Loaded explosion marker from disk, cleaning up");
			Invoke(DelayedDestroy, 3f);
		}
	}

	public void DelayedDestroy()
	{
		Kill();
	}
}
