using System;
using UnityEngine;

[ExecuteInEditMode]
public class WaterBody : MonoBehaviour
{
	[Flags]
	public enum FishingTag
	{
		MoonPool = 1,
		River = 2,
		Ocean = 4,
		Swamp = 8
	}

	public WaterBodyType Type = WaterBodyType.Lake;

	public Renderer Renderer;

	public Collider[] Triggers;

	public bool IsOcean;

	public FishingTag FishingType;

	public Transform Transform { get; private set; }

	private void Awake()
	{
		Transform = base.transform;
	}

	private void OnEnable()
	{
		WaterSystem.RegisterBody(this);
	}

	private void OnDisable()
	{
		WaterSystem.UnregisterBody(this);
	}

	public void OnOceanLevelChanged(float newLevel)
	{
		if (!IsOcean || Triggers == null || Triggers.Length == 0)
		{
			return;
		}
		Collider[] triggers = Triggers;
		foreach (Collider collider in triggers)
		{
			if (!(collider == null))
			{
				Vector3 position = collider.transform.position;
				position.y = newLevel;
				collider.transform.position = position;
			}
		}
	}

	public float MinWaterLevel()
	{
		float num = base.transform.position.y;
		if (Triggers == null || Triggers.Length == 0)
		{
			return num;
		}
		Collider[] triggers = Triggers;
		foreach (Collider collider in triggers)
		{
			if (!(collider == null))
			{
				num = Mathf.Min(num, collider.bounds.max.y);
			}
		}
		return num;
	}

	public float SqrDistance(Vector3 point)
	{
		float num = float.MaxValue;
		if (Triggers == null || Triggers.Length == 0)
		{
			return num;
		}
		Collider[] triggers = Triggers;
		foreach (Collider collider in triggers)
		{
			if (!(collider == null))
			{
				MeshCollider meshCollider = collider as MeshCollider;
				num = ((!(meshCollider == null) && !meshCollider.convex) ? Mathf.Min(num, (collider.ClosestPointOnBounds(point) - point).sqrMagnitude) : Mathf.Min(num, (collider.ClosestPoint(point) - point).sqrMagnitude));
			}
		}
		return num;
	}

	public int GetTopologyMask()
	{
		return Type switch
		{
			WaterBodyType.Lake => 65536, 
			WaterBodyType.Ocean => 128, 
			WaterBodyType.River => 16384, 
			WaterBodyType.Moonpool => 128, 
			WaterBodyType.Pool => 65536, 
			_ => 65536, 
		};
	}
}
