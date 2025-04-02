using System;
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
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		orphanedProjectile = true;
		orphanedTargetVector = Random.onUnitSphere;
	}

	public virtual void UpdateTarget()
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		if (orphanedProjectile)
		{
			lockedTarget = null;
			return;
		}
		if (Time.realtimeSinceStartup >= nextTargetUpdateTime)
		{
			if (autoSeek)
			{
				lockedTarget = SeekerTarget.GetBestForPoint(((Component)this).transform.position, ((Component)this).transform.forward, minLockDot, maxTrackDistance);
			}
			else
			{
				SeekerTarget bestForPoint = SeekerTarget.GetBestForPoint(((Component)this).transform.position, ((Component)this).transform.forward, flareLockDot, maxTrackDistance, SeekerTarget.SeekerStrength.HIGH);
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
			seekingDestination = ((Component)this).transform.position + ((Component)this).transform.forward * 1000f;
		}
		if (lockedTarget != null)
		{
			lockedTarget.SendOwnerMessage(base.baseEntity, "RadarLock");
		}
	}

	public Vector3 GetSeekingDestination()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return seekingDestination;
	}

	public override bool DoMovement()
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		float num = TimeSinceLaunch();
		if (!(num < launchingDuration))
		{
			if (num < totalArmingPhaseDuration)
			{
				float num2 = num - launchingDuration;
				Vector3 val = Vector3.Lerp(initialDir, armingFinalDir, Mathf.Clamp01(num2 / armingDuration));
				base.CurrentVelocity = val * armingVelocity * armingVelocityCurve.Evaluate(num);
			}
			else
			{
				UpdateTarget();
				Vector3 val2 = base.CurrentVelocity;
				Vector3 normalized = ((Vector3)(ref val2)).normalized;
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
					val2 = GetSeekingDestination() - ((Component)this).transform.position;
					normalized2 = ((Vector3)(ref val2)).normalized;
				}
				Vector3 val3 = Vector3.MoveTowards(normalized, normalized2, Time.fixedDeltaTime * courseAdjustRate);
				((Vector3)(ref val3)).Normalize();
				float num3 = armingVelocity + velocityCurve.Evaluate(TimeSinceArmed() / velocityRampUpTime) * speed;
				base.CurrentVelocity = val3 * num3;
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
		((FacepunchBehaviour)this).Invoke((Action)DisableBoosters, 1f);
	}

	public void DisableBoosters()
	{
		base.baseEntity.SetFlag(BaseEntity.Flags.On, b: false);
	}

	public override void InitializeVelocity(Vector3 overrideVel)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		Vector3 normalized = ((Vector3)(ref overrideVel)).normalized;
		launchTime = Time.time;
		initialDir = normalized;
		((FacepunchBehaviour)this).Invoke((Action)EnableBoosters, 0.5f);
		base.InitializeVelocity(overrideVel);
	}

	private void PickNewRotationAxis()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = Vector3.Cross(orphanedTargetVector, Random.onUnitSphere);
		orphanedRotationAxis = ((Vector3)(ref val)).normalized;
	}
}
