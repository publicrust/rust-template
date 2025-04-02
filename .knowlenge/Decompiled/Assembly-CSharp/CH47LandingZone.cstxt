using System.Collections.Generic;
using UnityEngine;

public class CH47LandingZone : MonoBehaviour
{
	public float lastDropTime;

	public static List<CH47LandingZone> landingZones = new List<CH47LandingZone>();

	public float dropoffScale = 1f;

	public static bool HasAnyLandingZones => !CollectionEx.IsNullOrEmpty(landingZones);

	public void Awake()
	{
		if (!landingZones.Contains(this))
		{
			landingZones.Add(this);
		}
	}

	public static CH47LandingZone GetClosest(Vector3 pos)
	{
		float num = float.PositiveInfinity;
		CH47LandingZone result = null;
		foreach (CH47LandingZone landingZone in landingZones)
		{
			float num2 = Vector3Ex.Distance2D(pos, landingZone.transform.position);
			if (num2 < num)
			{
				num = num2;
				result = landingZone;
			}
		}
		return result;
	}

	public void OnDestroy()
	{
		if (landingZones.Contains(this))
		{
			landingZones.Remove(this);
		}
	}

	public float TimeSinceLastDrop()
	{
		return Time.time - lastDropTime;
	}

	public void Used()
	{
		lastDropTime = Time.time;
	}

	public void OnDrawGizmos()
	{
		Color magenta = Color.magenta;
		magenta.a = 0.25f;
		Gizmos.color = magenta;
		GizmosUtil.DrawCircleY(base.transform.position, 6f);
		magenta.a = 1f;
		Gizmos.color = magenta;
		GizmosUtil.DrawWireCircleY(base.transform.position, 6f);
	}
}
