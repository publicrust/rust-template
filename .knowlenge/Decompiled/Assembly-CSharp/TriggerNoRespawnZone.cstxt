using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TriggerNoRespawnZone : TriggerBase
{
	public static List<TriggerNoRespawnZone> allNRZones = new List<TriggerNoRespawnZone>();

	public float maxDepth = 20f;

	public float maxAltitude = -1f;

	private SphereCollider sphereCollider;

	private float radiusSqr;

	protected override void Awake()
	{
		base.Awake();
		sphereCollider = GetComponent<SphereCollider>();
		radiusSqr = sphereCollider.radius * sphereCollider.radius;
	}

	protected void OnEnable()
	{
		allNRZones.Add(this);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		allNRZones.Remove(this);
	}

	internal override GameObject InterestedInObject(GameObject obj)
	{
		obj = base.InterestedInObject(obj);
		if (obj == null)
		{
			return null;
		}
		BasePlayer basePlayer = GameObjectEx.ToBaseEntity(obj) as BasePlayer;
		if (basePlayer == null)
		{
			return null;
		}
		if (basePlayer.isClient)
		{
			return null;
		}
		return basePlayer.gameObject;
	}

	public static bool InAnyNoRespawnZone(Vector3 theirPos)
	{
		for (int i = 0; i < allNRZones.Count; i++)
		{
			if (allNRZones[i].InNoRespawnZone(theirPos, checkRadius: true))
			{
				return true;
			}
		}
		return false;
	}

	public bool InNoRespawnZone(Vector3 theirPos, bool checkRadius)
	{
		Vector3 vector = base.transform.position + sphereCollider.center;
		if (checkRadius && Vector3.SqrMagnitude(vector - theirPos) > radiusSqr)
		{
			return false;
		}
		float num = Mathf.Abs(vector.y - theirPos.y);
		if (maxDepth != -1f && theirPos.y < vector.y && num > maxDepth)
		{
			return false;
		}
		if (maxAltitude != -1f && theirPos.y > vector.y && num > maxAltitude)
		{
			return false;
		}
		return true;
	}
}
