using Rust;
using UnityEngine;

public static class RaycastHitEx
{
	public static Transform GetTransform(this RaycastHit hit)
	{
		return ((RaycastHit)(ref hit)).transform;
	}

	public static Rigidbody GetRigidbody(this RaycastHit hit)
	{
		return ((RaycastHit)(ref hit)).rigidbody;
	}

	public static Collider GetCollider(this RaycastHit hit)
	{
		return ((RaycastHit)(ref hit)).collider;
	}

	public static BaseEntity GetEntity(this RaycastHit hit)
	{
		if (!((Object)(object)((RaycastHit)(ref hit)).collider != (Object)null))
		{
			return null;
		}
		return ((RaycastHit)(ref hit)).collider.ToBaseEntity();
	}

	public static bool IsOnLayer(this RaycastHit hit, Layer rustLayer)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((RaycastHit)(ref hit)).collider != (Object)null)
		{
			return ((Component)((RaycastHit)(ref hit)).collider).gameObject.IsOnLayer(rustLayer);
		}
		return false;
	}

	public static bool IsOnLayer(this RaycastHit hit, int layer)
	{
		if ((Object)(object)((RaycastHit)(ref hit)).collider != (Object)null)
		{
			return ((Component)((RaycastHit)(ref hit)).collider).gameObject.IsOnLayer(layer);
		}
		return false;
	}

	public static bool IsWaterHit(this RaycastHit hit)
	{
		if (!((Object)(object)((RaycastHit)(ref hit)).collider == (Object)null))
		{
			return ((Component)((RaycastHit)(ref hit)).collider).gameObject.IsOnLayer((Layer)4);
		}
		return true;
	}

	public static WaterBody GetWaterBody(this RaycastHit hit)
	{
		if ((Object)(object)((RaycastHit)(ref hit)).collider == (Object)null)
		{
			return WaterSystem.Ocean;
		}
		Transform transform = ((Component)((RaycastHit)(ref hit)).collider).transform;
		WaterBody result = default(WaterBody);
		if (((Component)transform).TryGetComponent<WaterBody>(ref result))
		{
			return result;
		}
		return ((Component)transform.parent).GetComponentInChildren<WaterBody>();
	}
}
