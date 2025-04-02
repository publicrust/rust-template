using System;
using UnityEngine;

public static class Ballistics
{
	private struct TheoreticalProjectile
	{
		public Vector3 pos;

		public Vector3 forward;

		public float gravity;

		public TheoreticalProjectile(Vector3 pos, Vector3 forward, float gravity)
		{
			this.pos = pos;
			this.forward = forward;
			this.gravity = gravity;
		}
	}

	public static Vector3 GetAimToTarget(Vector3 origin, Vector3 target, float speed, float maxAngle, float idealGravity, out float requiredGravity)
	{
		return GetAimToTarget(origin, target, speed, maxAngle, idealGravity, 0f, out requiredGravity);
	}

	public static Vector3 GetAimToTarget(Vector3 origin, Vector3 target, float speed, float maxAngle, float idealGravity, float minRange, out float requiredGravity)
	{
		requiredGravity = idealGravity;
		Vector3 vector = target - origin;
		float num = vector.Magnitude2D();
		float y = vector.y;
		float num2 = Mathf.Sqrt(speed * speed * speed * speed - requiredGravity * (requiredGravity * (num * num) + 2f * y * speed * speed));
		float num3 = Mathf.Atan((speed * speed + num2) / (requiredGravity * num)) * 57.29578f;
		float num4 = Mathf.Clamp(num3, 0f, 90f);
		if (float.IsNaN(num3))
		{
			num4 = 45f;
			requiredGravity = ProjectileDistToGravity(num, y, num4, speed);
		}
		else if (num3 > maxAngle)
		{
			num4 = maxAngle;
			requiredGravity = ProjectileDistToGravity(Mathf.Max(num, minRange), y, num4, speed);
		}
		vector.Normalize();
		vector.y = 0f;
		Vector3 axis = Vector3.Cross(vector, Vector3.up);
		return Quaternion.AngleAxis(num4, axis) * vector;
	}

	public static bool TryGetPhysicsProjectileHitPos(Vector3 origin, Vector3 direction, float speed, float gravity, out Vector3 result, float flightTimePerUpwardCheck = 2f, float flightTimePerDownwardCheck = 0.66f, float maxRays = 128f, BaseNetworkable owner = null)
	{
		TheoreticalProjectile projectile = new TheoreticalProjectile(origin, direction * speed, gravity);
		int num = 0;
		float dt = ((projectile.forward.y > 0f) ? flightTimePerUpwardCheck : flightTimePerDownwardCheck);
		while (!NextRayHitSomething(ref projectile, dt, owner) && (float)num < maxRays)
		{
			num++;
		}
		result = projectile.pos;
		return (float)num < maxRays;
	}

	public static Vector3 GetBulletHitPoint(Vector3 origin, Vector3 direction)
	{
		return GetBulletHitPoint(new Ray(origin, direction));
	}

	public static Vector3 GetBulletHitPoint(Ray aimRay)
	{
		if (GamePhysics.Trace(aimRay, 0f, out var hitInfo, 300f, 1220225809))
		{
			return hitInfo.point;
		}
		return aimRay.origin + aimRay.direction * 300f;
	}

	private static bool NextRayHitSomething(ref TheoreticalProjectile projectile, float dt, BaseNetworkable owner)
	{
		float gravity = projectile.gravity;
		Vector3 pos = projectile.pos;
		float num = projectile.forward.MagnitudeXZ() * dt;
		float y = projectile.forward.y * dt + gravity * dt * dt * 0.5f;
		Vector2 vector = projectile.forward.XZ2D().normalized * num;
		Vector3 vector2 = new Vector3(vector.x, y, vector.y);
		projectile.pos += vector2;
		float y2 = projectile.forward.y + gravity * dt;
		projectile.forward.y = y2;
		if (Physics.Linecast(pos, projectile.pos, out var hitInfo, 1084293393, QueryTriggerInteraction.Ignore))
		{
			projectile.pos = hitInfo.point;
			BaseEntity entity = RaycastHitEx.GetEntity(hitInfo);
			int num2;
			if (entity != null)
			{
				num2 = (entity.EqualNetID(owner) ? 1 : 0);
				if (num2 != 0)
				{
					projectile.pos += projectile.forward * 1f;
				}
			}
			else
			{
				num2 = 0;
			}
			return num2 == 0;
		}
		return false;
	}

	private static float ProjectileDistToGravity(float x, float y, float θ, float v)
	{
		float num = θ * (MathF.PI / 180f);
		float num2 = (v * v * x * Mathf.Sin(2f * num) - 2f * v * v * y * Mathf.Cos(num) * Mathf.Cos(num)) / (x * x);
		if (float.IsNaN(num2) || num2 < 0.01f)
		{
			num2 = 0f - Physics.gravity.y;
		}
		return num2;
	}
}
