using ConVar;
using UnityEngine;

public class PhysicsEffects : MonoBehaviour
{
	public BaseEntity entity;

	public SoundDefinition physImpactSoundDef;

	public float minTimeBetweenEffects = 0.25f;

	public float minDistBetweenEffects = 0.1f;

	public float hardnessScale = 1f;

	public float lowMedThreshold = 0.4f;

	public float medHardThreshold = 0.7f;

	public float enableDelay = 0.1f;

	public LayerMask ignoreLayers;

	public bool useCollisionPositionInsteadOfTransform;

	public float minimumRigidbodyImpactWeight;

	private float lastEffectPlayed;

	private float enabledAt = float.PositiveInfinity;

	private float ignoreImpactThreshold = 0.02f;

	private Vector3 lastCollisionPos;

	public void OnEnable()
	{
		enabledAt = UnityEngine.Time.time;
	}

	public void OnCollisionEnter(Collision collision)
	{
		if (!ConVar.Physics.sendeffects || UnityEngine.Time.time < enabledAt + enableDelay || UnityEngine.Time.time < lastEffectPlayed + minTimeBetweenEffects || ((1 << collision.gameObject.layer) & (int)ignoreLayers) != 0)
		{
			return;
		}
		float magnitude = collision.relativeVelocity.magnitude;
		magnitude = magnitude * 0.055f * hardnessScale;
		if (!(magnitude <= ignoreImpactThreshold) && (!((useCollisionPositionInsteadOfTransform ? Vector3.Distance(collision.contacts[0].point, lastCollisionPos) : Vector3.Distance(base.transform.position, lastCollisionPos)) < minDistBetweenEffects) || lastEffectPlayed == 0f) && (!(minimumRigidbodyImpactWeight > 0f) || !collision.gameObject.TryGetComponent<Rigidbody>(out var component) || !(component.mass < minimumRigidbodyImpactWeight)))
		{
			if (entity != null)
			{
				entity.SignalBroadcast(BaseEntity.Signal.PhysImpact, magnitude.ToString());
			}
			lastEffectPlayed = UnityEngine.Time.time;
			if (useCollisionPositionInsteadOfTransform)
			{
				lastCollisionPos = base.transform.InverseTransformPoint(collision.contacts[0].point);
			}
			else
			{
				lastCollisionPos = base.transform.position;
			}
		}
	}
}
