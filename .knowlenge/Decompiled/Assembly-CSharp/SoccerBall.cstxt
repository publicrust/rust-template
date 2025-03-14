using UnityEngine;

public class SoccerBall : BaseCombatEntity
{
	[Header("Soccer Ball")]
	[SerializeField]
	private Rigidbody rigidBody;

	[SerializeField]
	private float additionalForceMultiplier = 0.2f;

	[SerializeField]
	private float upForceMultiplier = 0.15f;

	[SerializeField]
	private DamageRenderer damageRenderer;

	[SerializeField]
	private float explosionForceMultiplier = 40f;

	[SerializeField]
	private float otherForceMultiplier = 10f;

	protected void OnCollisionEnter(Collision collision)
	{
		if (!base.isClient && collision.impulse.magnitude > 0f && collision.collider.attachedRigidbody != null && !ComponentEx.HasComponent<SoccerBall>(collision.collider.attachedRigidbody))
		{
			Vector3 vector = rigidBody.position - collision.collider.attachedRigidbody.position;
			float magnitude = collision.impulse.magnitude;
			rigidBody.AddForce(vector * magnitude * additionalForceMultiplier + Vector3.up * magnitude * upForceMultiplier, ForceMode.Impulse);
		}
	}

	public override void Hurt(HitInfo info)
	{
		if (!base.isClient)
		{
			float num = 0f;
			float[] types = info.damageTypes.types;
			foreach (float num2 in types)
			{
				num = (((int)num2 != 16 && (int)num2 != 22) ? (num + num2 * otherForceMultiplier) : (num + num2 * explosionForceMultiplier));
			}
			if (num > 3f)
			{
				rigidBody.AddExplosionForce(num, info.HitPositionWorld, 0.25f, 0.5f);
			}
			base.Hurt(info);
		}
	}
}
