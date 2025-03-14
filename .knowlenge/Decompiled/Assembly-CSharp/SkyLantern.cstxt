using Rust;
using UnityEngine;

public class SkyLantern : StorageContainer, IIgniteable
{
	public float gravityScale = -0.1f;

	public float travelSpeed = 2f;

	public float collisionRadius = 0.5f;

	public float rotationSpeed = 5f;

	public float randOffset = 1f;

	public float lifeTime = 120f;

	public float hoverHeight = 14f;

	public Transform collisionCheckPoint;

	private float idealAltitude;

	private Vector3 travelVec = Vector3.forward;

	private float takeOffY;

	public override float GetNetworkTime()
	{
		return Time.fixedTime;
	}

	public override void ServerInit()
	{
		base.ServerInit();
		randOffset = ((Random.Range(0.5f, 1f) * (float)Random.Range(0, 2) == 1f) ? (-1f) : 1f);
		travelVec = (Vector3.forward + Vector3.right * randOffset).normalized;
		Invoke(StartSinking, lifeTime - 15f);
		Invoke(SelfDestroy, lifeTime);
		travelSpeed = Random.Range(1.75f, 2.25f);
		gravityScale *= Random.Range(1f, 1.25f);
		InvokeRepeating(UpdateIdealAltitude, 0f, 1f);
	}

	public void Ignite(Vector3 fromPos)
	{
		TransformEx.RemoveComponent<GroundWatch>(base.gameObject.transform);
		TransformEx.RemoveComponent<DestroyOnGroundMissing>(base.gameObject.transform);
		base.gameObject.layer = 14;
		takeOffY = base.transform.position.y;
		travelVec = Vector3Ex.Direction2D(base.transform.position, fromPos);
		SetFlag(Flags.On, b: true);
		UpdateIdealAltitude();
	}

	public override void OnAttacked(HitInfo info)
	{
		base.OnAttacked(info);
		if (base.isServer)
		{
			if (info.damageTypes.Has(DamageType.Heat) && CanIgnite())
			{
				Ignite(info.PointStart);
			}
			else if (IsOn() && !IsBroken())
			{
				StartSinking();
			}
		}
	}

	public void SelfDestroy()
	{
		Kill();
	}

	public bool CanIgnite()
	{
		if (!IsOn())
		{
			return !IsBroken();
		}
		return false;
	}

	public void UpdateIdealAltitude()
	{
		if (IsOn())
		{
			idealAltitude = WaterLevel.GetWaterOrTerrainSurface(base.transform.position, waves: false, volumes: false) + hoverHeight;
			if (takeOffY > idealAltitude)
			{
				idealAltitude = takeOffY + hoverHeight;
			}
			if (hoverHeight != 0f)
			{
				idealAltitude -= 2f * Mathf.Abs(randOffset);
			}
		}
	}

	public void StartSinking()
	{
		if (!IsBroken())
		{
			hoverHeight = 0f;
			travelVec = Vector3.zero;
			UpdateIdealAltitude();
			SetFlag(Flags.Broken, b: true);
		}
	}

	public void FixedUpdate()
	{
		if (!base.isClient && IsOn())
		{
			float value = Mathf.Abs(base.transform.position.y - idealAltitude);
			float num = ((base.transform.position.y < idealAltitude) ? (-1f) : 1f);
			float num2 = Mathf.InverseLerp(0f, 10f, value) * num;
			if (IsBroken())
			{
				travelVec = Vector3.Lerp(travelVec, Vector3.zero, Time.fixedDeltaTime * 0.5f);
				num2 = 0.7f;
			}
			Vector3 zero = Vector3.zero;
			zero = Vector3.up * gravityScale * Physics.gravity.y * num2;
			zero += travelVec * travelSpeed;
			Vector3 vector = base.transform.position + zero * Time.fixedDeltaTime;
			Vector3 direction = Vector3Ex.Direction(vector, base.transform.position);
			float maxDistance = Vector3.Distance(vector, base.transform.position);
			if (!Physics.SphereCast(collisionCheckPoint.position, collisionRadius, direction, out var _, maxDistance, 1218519297))
			{
				base.transform.position = vector;
				base.transform.Rotate(Vector3.up, rotationSpeed * randOffset * Time.deltaTime, Space.Self);
			}
			else
			{
				StartSinking();
			}
		}
	}
}
