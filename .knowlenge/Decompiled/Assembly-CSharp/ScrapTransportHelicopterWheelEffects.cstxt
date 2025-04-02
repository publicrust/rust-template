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
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		if (impactEffect.isValid && !(Time.time < lastEffectPlayed + minTimeBetweenEffects) && (!(Vector3.Distance(((Component)this).transform.position, lastCollisionPos) < minDistBetweenEffects) || lastEffectPlayed == 0f))
		{
			Effect.server.Run(impactEffect.resourcePath, ((Component)this).transform.position, ((Component)this).transform.up);
			lastEffectPlayed = Time.time;
			lastCollisionPos = ((Component)this).transform.position;
		}
	}
}
