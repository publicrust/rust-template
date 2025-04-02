using System;
using Rust;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TakeCollisionDamage : FacepunchBehaviour
{
	public interface ICanRestoreVelocity
	{
		void RestoreVelocity(Vector3 amount);
	}

	[SerializeField]
	private BaseCombatEntity entity;

	[SerializeField]
	private float minDamage = 1f;

	[SerializeField]
	private float maxDamage = 250f;

	[SerializeField]
	private float forceForAnyDamage = 20000f;

	[SerializeField]
	private float forceForMaxDamage = 1000000f;

	[SerializeField]
	private float velocityRestorePercent = 0.75f;

	private float pendingDamage;

	private bool IsServer => entity.isServer;

	private bool IsClient => entity.isClient;

	protected void OnCollisionEnter(Collision collision)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		if (IsClient || collision == null || (Object)(object)collision.gameObject == (Object)null || (Object)(object)collision.gameObject == (Object)null)
		{
			return;
		}
		Rigidbody rigidbody = collision.rigidbody;
		float num = (((Object)(object)rigidbody == (Object)null) ? 100f : rigidbody.mass);
		Vector3 relativeVelocity = collision.relativeVelocity;
		float num2 = ((Vector3)(ref relativeVelocity)).magnitude * (entity.RealisticMass + num) / Time.fixedDeltaTime;
		float num3 = Mathf.InverseLerp(forceForAnyDamage, forceForMaxDamage, num2);
		if (num3 > 0f)
		{
			pendingDamage = Mathf.Max(pendingDamage, Mathf.Lerp(minDamage, maxDamage, num3));
			if (pendingDamage > entity.Health() && collision.gameObject.ToBaseEntity() is ICanRestoreVelocity canRestoreVelocity)
			{
				canRestoreVelocity.RestoreVelocity(collision.relativeVelocity * velocityRestorePercent);
			}
			((FacepunchBehaviour)this).Invoke((Action)DoDamage, 0f);
		}
	}

	protected void OnDestroy()
	{
		((FacepunchBehaviour)this).CancelInvoke((Action)DoDamage);
	}

	private void DoDamage()
	{
		if (!((Object)(object)entity == (Object)null) && !entity.IsDead() && !entity.IsDestroyed && pendingDamage > 0f)
		{
			entity.Hurt(pendingDamage, DamageType.Collision, null, useProtection: false);
			pendingDamage = 0f;
		}
	}
}
