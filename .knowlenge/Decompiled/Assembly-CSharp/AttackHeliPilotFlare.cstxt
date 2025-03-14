using Oxide.Core;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AttackHeliPilotFlare : MonoBehaviour, SeekerTarget.ISeekerTargetOwner
{
	protected void Start()
	{
		SeekerTarget.SetSeekerTarget(this, SeekerTarget.SeekerStrength.HIGH);
	}

	protected void OnDestroy()
	{
		SeekerTarget.SetSeekerTarget(this, SeekerTarget.SeekerStrength.OFF);
	}

	public void Init(Vector3 initialVelocity)
	{
		GetComponent<Rigidbody>().velocity = initialVelocity;
	}

	public Vector3 CenterPoint()
	{
		return base.transform.position;
	}

	public bool IsVisible(Vector3 from, float maxDistance = float.PositiveInfinity)
	{
		return GamePhysics.LineOfSight(from, CenterPoint(), 1218519041);
	}

	public bool InSafeZone()
	{
		return GamePhysics.CheckSphere<TriggerSafeZone>(CenterPoint(), 0.1f, 262144, QueryTriggerInteraction.Collide);
	}

	public bool IsValidHomingTarget()
	{
		object obj = Interface.CallHook("CanBeHomingTargeted", this);
		if (obj is bool)
		{
			return (bool)obj;
		}
		return true;
	}

	public void OnEntityMessage(BaseEntity from, string msg)
	{
	}
}
