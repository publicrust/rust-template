using System;
using System.Collections.Generic;
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

	public LayerMask TraceLayerMask = LayerMask.op_Implicit(1503731969);

	[NonSerialized]
	public NexusFerry[] QueuedFerries;

	[NonSerialized]
	public NexusFerry CurrentFerry;

	public Transform GetEntryPoint(NexusFerry ferry, out bool entered)
	{
		if ((Object)(object)ferry == (Object)null)
		{
			throw new ArgumentNullException("ferry");
		}
		CleanupQueuedFerries();
		if ((Object)(object)ferry == (Object)(object)CurrentFerry)
		{
			entered = true;
			return Arrival;
		}
		int num = List.FindIndex<NexusFerry>((IReadOnlyList<NexusFerry>)QueuedFerries, ferry, (IEqualityComparer<NexusFerry>)null);
		if (num < 0)
		{
			if ((Object)(object)QueuedFerries[0] == (Object)null)
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
			if ((Object)(object)CurrentFerry == (Object)null)
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
			if ((Object)(object)QueuedFerries[num + 1] == (Object)null)
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
		if ((Object)(object)ferry != (Object)(object)CurrentFerry)
		{
			return false;
		}
		CurrentFerry = null;
		return true;
	}

	public bool TryFindEjectionPosition(out Vector3 position, float radius = 5f)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)EjectionZone == (Object)null)
		{
			Debug.LogError((object)"EjectionZone is null, cannot find an eject position", (Object)(object)this);
			position = Vector3.zero;
			return false;
		}
		Transform transform = ((Component)EjectionZone).transform;
		Vector3 size = EjectionZone.size;
		float num = transform.position.y - size.y / 2f;
		RaycastHit val3 = default(RaycastHit);
		for (int i = 0; i < 10; i++)
		{
			Vector3 val = Vector3Ex.Scale(size, Random.value - 0.5f, 0f, Random.value - 0.5f);
			Vector3 val2 = transform.TransformPoint(val);
			if (Physics.SphereCast(Vector3Ex.WithY(val2, num + TraceHeight), radius, Vector3.down, ref val3, TraceHeight + radius, LayerMask.op_Implicit(TraceLayerMask), (QueryTriggerInteraction)1) && !(((RaycastHit)(ref val3)).point.y < val2.y - size.y) && !(((RaycastHit)(ref val3)).point.y > val2.y + size.y))
			{
				float waterSurface = WaterLevel.GetWaterSurface(val2, waves: false, volumes: false);
				if (!(((RaycastHit)(ref val3)).point.y < waterSurface))
				{
					position = ((RaycastHit)(ref val3)).point;
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
			if (!Object.op_Implicit((Object)(object)QueuedFerries[i]))
			{
				QueuedFerries[i] = null;
			}
		}
		if (!Object.op_Implicit((Object)(object)CurrentFerry))
		{
			CurrentFerry = null;
		}
	}
}
