using System.Collections.Generic;
using UnityEngine;

public class TerrainCollision : TerrainExtension
{
	private ListDictionary<Collider, List<Collider>> ignoredColliders;

	private TerrainCollider terrainCollider;

	public override void Setup()
	{
		ignoredColliders = new ListDictionary<Collider, List<Collider>>();
		terrainCollider = terrain.GetComponent<TerrainCollider>();
	}

	public void Clear()
	{
		if (!terrainCollider)
		{
			return;
		}
		foreach (Collider key in ignoredColliders.Keys)
		{
			Physics.IgnoreCollision(key, terrainCollider, ignore: false);
		}
		ignoredColliders.Clear();
	}

	public void Reset(Collider collider)
	{
		if ((bool)terrainCollider && (bool)collider)
		{
			Physics.IgnoreCollision(collider, terrainCollider, ignore: false);
			ignoredColliders.Remove(collider);
		}
	}

	public bool GetIgnore(Vector3 pos, float radius = 0.01f)
	{
		return GamePhysics.CheckSphere<TerrainCollisionTrigger>(pos, radius, 262144, QueryTriggerInteraction.Collide);
	}

	public bool GetIgnore(RaycastHit hit)
	{
		if (hit.collider is TerrainCollider)
		{
			return GetIgnore(hit.point);
		}
		return false;
	}

	public bool GetIgnore(Collider collider)
	{
		if (!terrainCollider || !collider)
		{
			return false;
		}
		return ignoredColliders.Contains(collider);
	}

	public void SetIgnore(Collider collider, Collider trigger, bool ignore = true)
	{
		if (!terrainCollider || !collider)
		{
			return;
		}
		if (!GetIgnore(collider))
		{
			if (ignore)
			{
				List<Collider> val = new List<Collider> { trigger };
				Physics.IgnoreCollision(collider, terrainCollider, ignore: true);
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
		if (ignoredColliders == null)
		{
			return;
		}
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
				Physics.IgnoreCollision(key, terrainCollider, ignore: false);
				ignoredColliders.RemoveAt(i--);
			}
		}
	}
}
