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
		enabledAt = Time.time;
	}

	public void OnCollisionEnter(Collision collision)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		if (!Physics.sendeffects || Time.time < enabledAt + enableDelay || Time.time < lastEffectPlayed + minTimeBetweenEffects || ((1 << collision.gameObject.layer) & LayerMask.op_Implicit(ignoreLayers)) != 0)
		{
			return;
		}
		Vector3 relativeVelocity = collision.relativeVelocity;
		float magnitude = ((Vector3)(ref relativeVelocity)).magnitude;
		magnitude = magnitude * 0.055f * hardnessScale;
		Rigidbody val = default(Rigidbody);
		if (!(magnitude <= ignoreImpactThreshold) && (!((useCollisionPositionInsteadOfTransform ? Vector3.Distance(((ContactPoint)(ref collision.contacts[0])).point, lastCollisionPos) : Vector3.Distance(((Component)this).transform.position, lastCollisionPos)) < minDistBetweenEffects) || lastEffectPlayed == 0f) && (!(minimumRigidbodyImpactWeight > 0f) || !collision.gameObject.TryGetComponent<Rigidbody>(ref val) || !(val.mass < minimumRigidbodyImpactWeight)))
		{
			if ((Object)(object)entity != (Object)null)
			{
				entity.SignalBroadcast(BaseEntity.Signal.PhysImpact, magnitude.ToString());
			}
			lastEffectPlayed = Time.time;
			if (useCollisionPositionInsteadOfTransform)
			{
				lastCollisionPos = ((Component)this).transform.InverseTransformPoint(((ContactPoint)(ref collision.contacts[0])).point);
			}
			else
			{
				lastCollisionPos = ((Component)this).transform.position;
			}
		}
	}
}
