using UnityEngine;

public class TriggerRagdollRelocate : TriggerBase
{
	public Transform targetLocation;

	internal override void OnObjectAdded(GameObject obj, Collider col)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		base.OnObjectAdded(obj, col);
		BaseEntity baseEntity = obj.transform.ToBaseEntity();
		if ((Object)(object)baseEntity != (Object)null && baseEntity.isServer)
		{
			RepositionTransform(((Component)baseEntity).transform);
		}
		Ragdoll componentInParent = obj.GetComponentInParent<Ragdoll>();
		if (!((Object)(object)componentInParent != (Object)null))
		{
			return;
		}
		RepositionTransform(((Component)componentInParent).transform);
		foreach (Rigidbody rigidbody in componentInParent.rigidbodies)
		{
			if (((Component)rigidbody).transform.position.y < ((Component)this).transform.position.y)
			{
				RepositionTransform(((Component)rigidbody).transform);
			}
		}
	}

	private void RepositionTransform(Transform t)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = targetLocation.InverseTransformPoint(t.position);
		val.y = 0f;
		val = targetLocation.TransformPoint(val);
		t.position = val;
	}
}
