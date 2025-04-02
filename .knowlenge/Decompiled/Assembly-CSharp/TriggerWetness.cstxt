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
		if (ApplyLocalHeightCheck && base.transform.InverseTransformPoint(position).y < MinLocalHeight)
		{
			return 0f;
		}
		float value = Vector3Ex.Distance2D(OriginTransform.position, position) / TargetCollider.radius;
		value = Mathf.Clamp01(value);
		value = 1f - value;
		return Mathf.Lerp(0f, Wetness, value);
	}

	internal override GameObject InterestedInObject(GameObject obj)
	{
		obj = base.InterestedInObject(obj);
		if (obj == null)
		{
			return null;
		}
		BaseEntity baseEntity = GameObjectEx.ToBaseEntity(obj);
		if (baseEntity == null)
		{
			return null;
		}
		if (baseEntity.isClient)
		{
			return null;
		}
		return baseEntity.gameObject;
	}
}
