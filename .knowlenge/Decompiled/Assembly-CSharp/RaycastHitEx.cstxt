using Rust;
using UnityEngine;

public static class RaycastHitEx
{
	public static Transform GetTransform(this RaycastHit hit)
	{
		return hit.transform;
	}

	public static Rigidbody GetRigidbody(this RaycastHit hit)
	{
		return hit.rigidbody;
	}

	public static Collider GetCollider(this RaycastHit hit)
	{
		return hit.collider;
	}

	public static BaseEntity GetEntity(this RaycastHit hit)
	{
		if (!(hit.collider != null))
		{
			return null;
		}
		return GameObjectEx.ToBaseEntity(hit.collider);
	}

	public static bool IsOnLayer(this RaycastHit hit, Layer rustLayer)
	{
		if (hit.collider != null)
		{
			return GameObjectEx.IsOnLayer(hit.collider.gameObject, rustLayer);
		}
		return false;
	}

	public static bool IsOnLayer(this RaycastHit hit, int layer)
	{
		if (hit.collider != null)
		{
			return GameObjectEx.IsOnLayer(hit.collider.gameObject, layer);
		}
		return false;
	}

	public static bool IsWaterHit(this RaycastHit hit)
	{
		if (!(hit.collider == null))
		{
			return GameObjectEx.IsOnLayer(hit.collider.gameObject, Layer.Water);
		}
		return true;
	}

	public static WaterBody GetWaterBody(this RaycastHit hit)
	{
		if (hit.collider == null)
		{
			return WaterSystem.Ocean;
		}
		Transform transform = hit.collider.transform;
		if (transform.TryGetComponent<WaterBody>(out var component))
		{
			return component;
		}
		return transform.parent.GetComponentInChildren<WaterBody>();
	}
}
