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
		if (IsClient || collision == null || collision.gameObject == null || collision.gameObject == null)
		{
			return;
		}
		Rigidbody rigidbody = collision.rigidbody;
		float num = ((rigidbody == null) ? 100f : rigidbody.mass);
		float value = collision.relativeVelocity.magnitude * (entity.RealisticMass + num) / Time.fixedDeltaTime;
		float num2 = Mathf.InverseLerp(forceForAnyDamage, forceForMaxDamage, value);
		if (num2 > 0f)
		{
			pendingDamage = Mathf.Max(pendingDamage, Mathf.Lerp(minDamage, maxDamage, num2));
			if (pendingDamage > entity.Health() && GameObjectEx.ToBaseEntity(collision.gameObject) is ICanRestoreVelocity canRestoreVelocity)
			{
				canRestoreVelocity.RestoreVelocity(collision.relativeVelocity * velocityRestorePercent);
			}
			Invoke(DoDamage, 0f);
		}
	}

	protected void OnDestroy()
	{
		CancelInvoke(DoDamage);
	}

	private void DoDamage()
	{
		if (!(entity == null) && !entity.IsDead() && !entity.IsDestroyed && pendingDamage > 0f)
		{
			entity.Hurt(pendingDamage, DamageType.Collision, null, useProtection: false);
			pendingDamage = 0f;
		}
	}
}
