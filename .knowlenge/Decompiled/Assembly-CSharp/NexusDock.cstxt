using System;
using Facepunch.Extend;
using UnityEngine;

public class NexusDock : SingletonComponent<NexusDock>
{
	[Header("Targets")]
	public Transform FerryWaypoint;

	public Transform[] QueuePoints;

	public Transform Arrival;

	public Transform Docking;

	public Transform Docked;

	public Transform CastingOff;

	public Transform Departure;

	[Header("Ferry")]
	public float WaitTime = 30f;

	[Header("Ejection")]
	public BoxCollider EjectionZone;

	public float TraceHeight = 100f;

	public LayerMask TraceLayerMask = 1503731969;

	[NonSerialized]
	public NexusFerry[] QueuedFerries;

	[NonSerialized]
	public NexusFerry CurrentFerry;

	public Transform GetEntryPoint(NexusFerry ferry, out bool entered)
	{
		if (ferry == null)
		{
			throw new ArgumentNullException("ferry");
		}
		CleanupQueuedFerries();
		if (ferry == CurrentFerry)
		{
			entered = true;
			return Arrival;
		}
		int num = QueuedFerries.FindIndex(ferry);
		if (num < 0)
		{
			if (QueuedFerries[0] == null)
			{
				QueuedFerries[0] = ferry;
				entered = false;
				return QueuePoints[0];
			}
			entered = false;
			return FerryWaypoint;
		}
		int num2 = QueuedFerries.Length - 1;
		if (num == num2)
		{
			if (CurrentFerry == null)
			{
				QueuedFerries[num] = null;
				CurrentFerry = ferry;
				entered = true;
				return Arrival;
			}
			entered = false;
			return QueuePoints[num];
		}
		if (num < num2)
		{
			if (QueuedFerries[num + 1] == null)
			{
				QueuedFerries[num] = null;
				QueuedFerries[num + 1] = ferry;
				entered = false;
				return QueuePoints[num + 1];
			}
			entered = false;
			return QueuePoints[num];
		}
		entered = false;
		return QueuePoints[num];
	}

	public bool Depart(NexusFerry ferry)
	{
		if (ferry != CurrentFerry)
		{
			return false;
		}
		CurrentFerry = null;
		return true;
	}

	public bool TryFindEjectionPosition(out Vector3 position, float radius = 5f)
	{
		if (EjectionZone == null)
		{
			Debug.LogError("EjectionZone is null, cannot find an eject position", this);
			position = Vector3.zero;
			return false;
		}
		Transform transform = EjectionZone.transform;
		Vector3 size = EjectionZone.size;
		float num = transform.position.y - size.y / 2f;
		for (int i = 0; i < 10; i++)
		{
			Vector3 position2 = size.Scale(UnityEngine.Random.value - 0.5f, 0f, UnityEngine.Random.value - 0.5f);
			Vector3 vector = transform.TransformPoint(position2);
			if (Physics.SphereCast(vector.WithY(num + TraceHeight), radius, Vector3.down, out var hitInfo, TraceHeight + radius, TraceLayerMask, QueryTriggerInteraction.Ignore) && !(hitInfo.point.y < vector.y - size.y) && !(hitInfo.point.y > vector.y + size.y))
			{
				float waterSurface = WaterLevel.GetWaterSurface(vector, waves: false, volumes: false);
				if (!(hitInfo.point.y < waterSurface))
				{
					position = hitInfo.point;
					return true;
				}
			}
		}
		position = Vector3.zero;
		return false;
	}

	public void CleanupQueuedFerries()
	{
		Array.Resize(ref QueuedFerries, QueuePoints.Length);
		for (int i = 0; i < QueuedFerries.Length; i++)
		{
			if (!QueuedFerries[i])
			{
				QueuedFerries[i] = null;
			}
		}
		if (!CurrentFerry)
		{
			CurrentFerry = null;
		}
	}
}
