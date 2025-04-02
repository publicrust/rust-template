using UnityEngine;

public class ScrapTransportHelicopterWheelEffects : MonoBehaviour, IServerComponent
{
	public WheelCollider wheelCollider;

	public GameObjectRef impactEffect;

	public float minTimeBetweenEffects = 0.25f;

	public float minDistBetweenEffects = 0.1f;

	private bool wasGrounded;

	private float lastEffectPlayed;

	private Vector3 lastCollisionPos;

	public void Update()
	{
		bool isGrounded = wheelCollider.isGrounded;
		if (isGrounded && !wasGrounded)
		{
			DoImpactEffect();
		}
		wasGrounded = isGrounded;
	}

	private void DoImpactEffect()
	{
		if (impactEffect.isValid && !(Time.time < lastEffectPlayed + minTimeBetweenEffects) && (!(Vector3.Distance(base.transform.position, lastCollisionPos) < minDistBetweenEffects) || lastEffectPlayed == 0f))
		{
			Effect.server.Run(impactEffect.resourcePath, base.transform.position, base.transform.up);
			lastEffectPlayed = Time.time;
			lastCollisionPos = base.transform.position;
		}
	}
}
