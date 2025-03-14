using System.Collections.Generic;
using ConVar;
using Oxide.Core;
using UnityEngine;

public class HelicopterTurret : MonoBehaviour
{
	public PatrolHelicopterAI _heliAI;

	public float fireRate = 0.125f;

	public float burstLength = 3f;

	public float timeBetweenBursts = 3f;

	public float maxTargetRange = 300f;

	public float loseTargetAfter = 5f;

	public Transform gun_yaw;

	public Transform gun_pitch;

	public Transform muzzleTransform;

	public bool left;

	public BaseCombatEntity _target;

	private float lastBurstTime = float.NegativeInfinity;

	private float lastFireTime = float.NegativeInfinity;

	private float lastSeenTargetTime = float.NegativeInfinity;

	private bool targetVisible;

	public void SetTarget(BaseCombatEntity newTarget)
	{
		if (Interface.CallHook("OnHelicopterTarget", this, newTarget) == null)
		{
			_target = newTarget;
			UpdateTargetVisibility();
		}
	}

	public bool NeedsNewTarget()
	{
		if (HasTarget())
		{
			if (!targetVisible)
			{
				return TimeSinceTargetLastSeen() > loseTargetAfter;
			}
			return false;
		}
		return true;
	}

	public bool UpdateTargetFromList(List<PatrolHelicopterAI.targetinfo> newTargetList)
	{
		int num = UnityEngine.Random.Range(0, newTargetList.Count);
		int num2 = newTargetList.Count;
		while (num2 >= 0)
		{
			num2--;
			PatrolHelicopterAI.targetinfo targetinfo = newTargetList[num];
			if (targetinfo != null && targetinfo.ent != null && targetinfo.IsVisible() && InFiringArc(targetinfo.ply))
			{
				SetTarget(targetinfo.ply);
				return true;
			}
			num++;
			if (num >= newTargetList.Count)
			{
				num = 0;
			}
		}
		return false;
	}

	public bool TargetVisible()
	{
		UpdateTargetVisibility();
		return targetVisible;
	}

	public float TimeSinceTargetLastSeen()
	{
		return UnityEngine.Time.realtimeSinceStartup - lastSeenTargetTime;
	}

	public bool HasTarget()
	{
		return _target != null;
	}

	public void ClearTarget()
	{
		_target = null;
		targetVisible = false;
	}

	public void TurretThink()
	{
		if (HasTarget() && TimeSinceTargetLastSeen() > loseTargetAfter * 2f)
		{
			ClearTarget();
		}
		if (HasTarget())
		{
			if (UnityEngine.Time.time - lastBurstTime > burstLength + timeBetweenBursts && TargetVisible())
			{
				lastBurstTime = UnityEngine.Time.time;
			}
			if (UnityEngine.Time.time < lastBurstTime + burstLength && UnityEngine.Time.time - lastFireTime >= fireRate && InFiringArc(_target))
			{
				lastFireTime = UnityEngine.Time.time;
				FireGun();
			}
		}
	}

	public void FireGun()
	{
		_heliAI.FireGun(_target.transform.position + new Vector3(0f, 0.25f, 0f), ConVar.PatrolHelicopter.bulletAccuracy, left);
	}

	public Vector3 GetPositionForEntity(BaseCombatEntity potentialtarget)
	{
		return potentialtarget.transform.position;
	}

	public float AngleToTarget(BaseCombatEntity potentialtarget)
	{
		Vector3 positionForEntity = GetPositionForEntity(potentialtarget);
		Vector3 position = muzzleTransform.position;
		Vector3 normalized = (positionForEntity - position).normalized;
		return Vector3.Angle(left ? (-_heliAI.transform.right) : _heliAI.transform.right, normalized);
	}

	public bool InFiringArc(BaseCombatEntity potentialtarget)
	{
		object obj = Interface.CallHook("CanBeTargeted", potentialtarget, this);
		if (obj is bool)
		{
			return (bool)obj;
		}
		return AngleToTarget(potentialtarget) < 80f;
	}

	public void UpdateTargetVisibility()
	{
		if (HasTarget())
		{
			Vector3 position = _target.transform.position;
			BasePlayer basePlayer = _target as BasePlayer;
			if ((bool)basePlayer)
			{
				position = basePlayer.eyes.position;
			}
			bool flag = false;
			float num = Vector3.Distance(position, muzzleTransform.position);
			Vector3 normalized = (position - muzzleTransform.position).normalized;
			if (num < maxTargetRange && InFiringArc(_target) && GamePhysics.Trace(new Ray(muzzleTransform.position + normalized * 6f, normalized), 0f, out var hitInfo, num * 1.1f, 1218652417) && GameObjectEx.ToBaseEntity(hitInfo.collider.gameObject) == _target)
			{
				flag = true;
			}
			if (flag)
			{
				lastSeenTargetTime = UnityEngine.Time.realtimeSinceStartup;
			}
			targetVisible = flag;
		}
	}
}
