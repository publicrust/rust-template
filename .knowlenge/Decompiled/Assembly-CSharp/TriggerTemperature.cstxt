using ConVar;
using UnityEngine;

public class TriggerTemperature : TriggerBase
{
	public float Temperature = 50f;

	public float triggerSize;

	public float minSize;

	public bool sunlightBlocker;

	public float sunlightBlockAmount;

	[Range(0f, 24f)]
	public float blockMinHour = 8.5f;

	[Range(0f, 24f)]
	public float blockMaxHour = 18.5f;

	private void OnValidate()
	{
		triggerSize = GetComponent<SphereCollider>().radius * base.transform.localScale.y;
	}

	public float WorkoutTemperature(Vector3 position, float oldTemperature)
	{
		if (sunlightBlocker)
		{
			float time = Env.time;
			if (time >= blockMinHour && time <= blockMaxHour)
			{
				Vector3 position2 = TOD_Sky.Instance.Components.SunTransform.position;
				if (!GamePhysics.LineOfSight(position, position2, 256))
				{
					return oldTemperature - sunlightBlockAmount;
				}
			}
			return oldTemperature;
		}
		float value = Vector3.Distance(base.gameObject.transform.position, position);
		float t = Mathf.InverseLerp(triggerSize, minSize, value);
		return Mathf.Lerp(oldTemperature, Temperature, t);
	}

	public override GameObject InterestedInObject(GameObject obj)
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
