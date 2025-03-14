using UnityEngine;

public class SeekingServerProjectile : ServerProjectile
{
	public float courseAdjustRate = 1f;

	public float maxTrackDistance = 500f;

	public float minLockDot;

	public float flareLockDot = 0.6f;

	public bool autoSeek;

	public float swimAfter = 6f;

	public float launchingDuration = 0.15f;

	public float armingDuration = 0.75f;

	public float velocityRampUpTime = 6f;

	public Vector3 armingFinalDir;

	public AnimationCurve airmingDirCurve;

	public AnimationCurve armingVelocityCurve;

	public float armingVelocity;

	public AnimationCurve velocityCurve;

	public float orphanedVectorChangeRate = 30f;

	public SeekerTarget lockedTarget;

	private float nextTargetUpdateTime = float.NegativeInfinity;

	private Vector3 seekingDestination;

	private float launchTime;

	private Vector3 initialDir = Vector3.forward;

	private bool orphanedProjectile;

	private Vector3 orphanedTargetVector;

	private Vector3 orphanedRotationAxis;

	public float totalArmingPhaseDuration => launchingDuration + armingDuration;

	public void NotifyOrphaned()
	{
		orphanedProjectile = true;
		orphanedTargetVector = Random.onUnitSphere;
	}

	public virtual void UpdateTarget()
	{
		if (orphanedProjectile)
		{
			lockedTarget = null;
			return;
		}
		if (Time.realtimeSinceStartup >= nextTargetUpdateTime)
		{
			if (autoSeek)
			{
				lockedTarget = SeekerTarget.GetBestForPoint(base.transform.position, base.transform.forward, minLockDot, maxTrackDistance);
			}
			else
			{
				SeekerTarget bestForPoint = SeekerTarget.GetBestForPoint(base.transform.position, base.transform.forward, flareLockDot, maxTrackDistance, SeekerTarget.SeekerStrength.HIGH);
				if (bestForPoint != null)
				{
					lockedTarget = bestForPoint;
				}
			}
			nextTargetUpdateTime = Time.realtimeSinceStartup + 0.1f;
		}
		if (lockedTarget != null && lockedTarget.TryGetPosition(out var result))
		{
			seekingDestination = result;
		}
		else
		{
			seekingDestination = base.transform.position + base.transform.forward * 1000f;
		}
		if (lockedTarget != null)
		{
			lockedTarget.SendOwnerMessage(base.baseEntity, "RadarLock");
		}
	}

	public Vector3 GetSeekingDestination()
	{
		return seekingDestination;
	}

	public override bool DoMovement()
	{
		float num = TimeSinceLaunch();
		if (!(num < launchingDuration))
		{
			if (num < totalArmingPhaseDuration)
			{
				float num2 = num - launchingDuration;
				Vector3 vector = Vector3.Lerp(initialDir, armingFinalDir, Mathf.Clamp01(num2 / armingDuration));
				base.CurrentVelocity = vector * armingVelocity * armingVelocityCurve.Evaluate(num);
			}
			else
			{
				UpdateTarget();
				Vector3 normalized = base.CurrentVelocity.normalized;
				Vector3 normalized2;
				if (orphanedProjectile)
				{
					normalized2 = orphanedTargetVector;
					orphanedTargetVector = Quaternion.AngleAxis(orphanedVectorChangeRate * Time.deltaTime, orphanedRotationAxis) * orphanedTargetVector;
					if (Random.value < 0.02f)
					{
						PickNewRotationAxis();
					}
				}
				else
				{
					normalized2 = (GetSeekingDestination() - base.transform.position).normalized;
				}
				Vector3 vector2 = Vector3.MoveTowards(normalized, normalized2, Time.fixedDeltaTime * courseAdjustRate);
				vector2.Normalize();
				float num3 = armingVelocity + velocityCurve.Evaluate(TimeSinceArmed() / velocityRampUpTime) * speed;
				base.CurrentVelocity = vector2 * num3;
			}
		}
		return base.DoMovement();
	}

	public float TimeSinceArmed()
	{
		return TimeSinceLaunch() - totalArmingPhaseDuration;
	}

	public float TimeSinceLaunch()
	{
		return Mathf.Max(Time.time - launchTime, 0f);
	}

	public void EnableBoosters()
	{
		base.baseEntity.SetFlag(BaseEntity.Flags.On, b: true);
		Invoke(DisableBoosters, 1f);
	}

	public void DisableBoosters()
	{
		base.baseEntity.SetFlag(BaseEntity.Flags.On, b: false);
	}

	public override void InitializeVelocity(Vector3 overrideVel)
	{
		Vector3 normalized = overrideVel.normalized;
		launchTime = Time.time;
		initialDir = normalized;
		Invoke(EnableBoosters, 0.5f);
		base.InitializeVelocity(overrideVel);
	}

	private void PickNewRotationAxis()
	{
		orphanedRotationAxis = Vector3.Cross(orphanedTargetVector, Random.onUnitSphere).normalized;
	}
}
