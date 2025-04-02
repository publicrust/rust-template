using UnityEngine;

public class TriggerWetness : TriggerBase
{
	public float Wetness = 0.25f;

	public SphereCollider TargetCollider;

	public Transform OriginTransform;

	public bool ApplyLocalHeightCheck;

	public float MinLocalHeight;

	public float WorkoutWetness(Vector3 position)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (ApplyLocalHeightCheck && ((Component)this).transform.InverseTransformPoint(position).y < MinLocalHeight)
		{
			return 0f;
		}
		float num = Vector3Ex.Distance2D(OriginTransform.position, position) / TargetCollider.radius;
		num = Mathf.Clamp01(num);
		num = 1f - num;
		return Mathf.Lerp(0f, Wetness, num);
	}

	internal override GameObject InterestedInObject(GameObject obj)
	{
		obj = base.InterestedInObject(obj);
		if ((Object)(object)obj == (Object)null)
		{
			return null;
		}
		BaseEntity baseEntity = obj.ToBaseEntity();
		if ((Object)(object)baseEntity == (Object)null)
		{
			return null;
		}
		if (baseEntity.isClient)
		{
			return null;
		}
		return ((Component)baseEntity).gameObject;
	}
}
