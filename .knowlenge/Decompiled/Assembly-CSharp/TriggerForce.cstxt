using UnityEngine;

public class TriggerForce : TriggerBase, IServerComponent
{
	public const float GravityMultiplier = 0.1f;

	public const float VelocityLerp = 10f;

	public const float AngularDrag = 10f;

	public Vector3 velocity = Vector3.forward;

	public override GameObject InterestedInObject(GameObject obj)
	{
		obj = base.InterestedInObject(obj);
		if (obj == null)
		{
			return null;
		}
		BaseEntity baseEntity = GameObjectEx.ToBaseEntity(obj);
		if (baseEntity == null)
		{
			return null;
		}
		if (baseEntity.isClient)
		{
			return null;
		}
		return baseEntity.gameObject;
	}

	public override void OnEntityEnter(BaseEntity ent)
	{
		base.OnEntityEnter(ent);
		Vector3 vector = base.transform.TransformDirection(velocity);
		ent.ApplyInheritedVelocity(vector);
	}

	public override void OnEntityLeave(BaseEntity ent)
	{
		base.OnEntityLeave(ent);
		ent.ApplyInheritedVelocity(Vector3.zero);
	}

	protected void FixedUpdate()
	{
		if (entityContents == null)
		{
			return;
		}
		Vector3 vector = base.transform.TransformDirection(velocity);
		foreach (BaseEntity entityContent in entityContents)
		{
			if (entityContent != null)
			{
				entityContent.ApplyInheritedVelocity(vector);
			}
		}
	}
}
