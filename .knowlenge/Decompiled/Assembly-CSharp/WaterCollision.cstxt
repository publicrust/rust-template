using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
	private ListDictionary<Collider, List<Collider>> ignoredColliders;

	private HashSet<Collider> waterColliders;

	private void Awake()
	{
		ignoredColliders = new ListDictionary<Collider, List<Collider>>();
		waterColliders = new HashSet<Collider>();
	}

	public void Clear()
	{
		if (waterColliders.Count == 0)
		{
			return;
		}
		HashSet<Collider>.Enumerator enumerator = waterColliders.GetEnumerator();
		while (enumerator.MoveNext())
		{
			foreach (Collider key in ignoredColliders.Keys)
			{
				Physics.IgnoreCollision(key, enumerator.Current, ignore: false);
			}
		}
		ignoredColliders.Clear();
	}

	public void Reset(Collider collider)
	{
		if (waterColliders.Count != 0 && (bool)collider)
		{
			HashSet<Collider>.Enumerator enumerator = waterColliders.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Physics.IgnoreCollision(collider, enumerator.Current, ignore: false);
			}
			ignoredColliders.Remove(collider);
		}
	}

	public bool GetIgnore(Vector3 pos, float radius = 0.01f)
	{
		return GamePhysics.CheckSphere<WaterVisibilityTrigger>(pos, radius, 262144, QueryTriggerInteraction.Collide);
	}

	public bool GetIgnore(Bounds bounds)
	{
		return GamePhysics.CheckBounds<WaterVisibilityTrigger>(bounds, 262144, QueryTriggerInteraction.Collide);
	}

	public bool GetIgnore(Vector3 start, Vector3 end, float radius)
	{
		return GamePhysics.CheckCapsule<WaterVisibilityTrigger>(start, end, radius, 262144, QueryTriggerInteraction.Collide);
	}

	public bool GetIgnore(RaycastHit hit)
	{
		if (waterColliders.Contains(hit.collider))
		{
			return GetIgnore(hit.point);
		}
		return false;
	}

	public bool GetIgnore(Collider collider)
	{
		if (waterColliders.Count == 0 || !collider)
		{
			return false;
		}
		return ignoredColliders.Contains(collider);
	}

	public void SetIgnore(Collider collider, Collider trigger, bool ignore = true)
	{
		if (waterColliders.Count == 0 || !collider)
		{
			return;
		}
		if (!GetIgnore(collider))
		{
			if (ignore)
			{
				List<Collider> val = new List<Collider> { trigger };
				HashSet<Collider>.Enumerator enumerator = waterColliders.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Physics.IgnoreCollision(collider, enumerator.Current, ignore: true);
				}
				ignoredColliders.Add(collider, val);
			}
			return;
		}
		List<Collider> list = ignoredColliders[collider];
		if (ignore)
		{
			if (!list.Contains(trigger))
			{
				list.Add(trigger);
			}
		}
		else if (list.Contains(trigger))
		{
			list.Remove(trigger);
		}
	}

	protected void LateUpdate()
	{
		for (int i = 0; i < ignoredColliders.Count; i++)
		{
			KeyValuePair<Collider, List<Collider>> byIndex = ignoredColliders.GetByIndex(i);
			Collider key = byIndex.Key;
			List<Collider> value = byIndex.Value;
			if (key == null)
			{
				ignoredColliders.RemoveAt(i--);
			}
			else if (value.Count == 0)
			{
				HashSet<Collider>.Enumerator enumerator = waterColliders.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Physics.IgnoreCollision(key, enumerator.Current, ignore: false);
				}
				ignoredColliders.RemoveAt(i--);
			}
		}
	}
}
