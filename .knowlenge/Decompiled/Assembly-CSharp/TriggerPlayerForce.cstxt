using UnityEngine;

public class TriggerPlayerForce : TriggerBase, IServerComponent
{
	public BoxCollider triggerCollider;

	public float pushVelocity = 5f;

	public bool requireUpAxis;

	private const float HACK_DISABLE_TIME = 4f;

	internal override GameObject InterestedInObject(GameObject obj)
	{
		obj = base.InterestedInObject(obj);
		if (obj == null)
		{
			return null;
		}
		BaseEntity baseEntity = GameObjectEx.ToBaseEntity(obj);
		if (baseEntity != null)
		{
			return baseEntity.gameObject;
		}
		return null;
	}

	internal override void OnObjects()
	{
		InvokeRepeating(HackDisableTick, 0f, 3.75f);
	}

	internal override void OnEmpty()
	{
		base.OnEmpty();
		CancelInvoke(HackDisableTick);
	}

	protected override void OnDisable()
	{
		CancelInvoke(HackDisableTick);
		base.OnDisable();
	}

	internal override void OnEntityLeave(BaseEntity ent)
	{
		base.OnEntityLeave(ent);
		ent.ApplyInheritedVelocity(Vector3.zero);
	}

	private void HackDisableTick()
	{
		if (entityContents == null || !base.enabled)
		{
			return;
		}
		foreach (BaseEntity entityContent in entityContents)
		{
			if (IsInterested(entityContent))
			{
				BasePlayer basePlayer = entityContent.ToPlayer();
				if (basePlayer != null && !basePlayer.IsNpc)
				{
					basePlayer.PauseVehicleNoClipDetection(4f);
					basePlayer.PauseSpeedHackDetection(4f);
				}
			}
		}
	}

	protected void FixedUpdate()
	{
		if (entityContents == null)
		{
			return;
		}
		foreach (BaseEntity entityContent in entityContents)
		{
			if ((!requireUpAxis || !(Vector3.Dot(entityContent.transform.up, base.transform.up) < 0f)) && IsInterested(entityContent))
			{
				Vector3 velocity = GetPushVelocity(entityContent.gameObject);
				entityContent.ApplyInheritedVelocity(velocity);
			}
		}
	}

	private Vector3 GetPushVelocity(GameObject obj)
	{
		Vector3 vector = -(triggerCollider.bounds.center - obj.transform.position);
		vector.Normalize();
		vector.y = 0.2f;
		vector.Normalize();
		return vector * pushVelocity;
	}

	private bool IsInterested(BaseEntity entity)
	{
		if (entity == null || entity.isClient)
		{
			return false;
		}
		BasePlayer basePlayer = entity.ToPlayer();
		if (basePlayer != null)
		{
			if ((basePlayer.IsAdmin || basePlayer.IsDeveloper) && basePlayer.IsFlying)
			{
				return false;
			}
			if (basePlayer != null && basePlayer.IsAlive())
			{
				return !basePlayer.isMounted;
			}
			return false;
		}
		return true;
	}
}
