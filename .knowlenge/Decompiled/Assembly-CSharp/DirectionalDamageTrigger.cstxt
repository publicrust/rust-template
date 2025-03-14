using System.Collections.Generic;
using System.Linq;
using Rust;
using UnityEngine;

public class DirectionalDamageTrigger : TriggerBase
{
	public float repeatRate = 1f;

	public List<DamageTypeEntry> damageType;

	public GameObjectRef attackEffect;

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
		if (!(baseEntity is BaseCombatEntity))
		{
			return null;
		}
		if (baseEntity.isClient)
		{
			return null;
		}
		return baseEntity.gameObject;
	}

	public override void OnObjects()
	{
		InvokeRepeating(OnTick, repeatRate, repeatRate);
	}

	public override void OnEmpty()
	{
		CancelInvoke(OnTick);
	}

	private void OnTick()
	{
		if (attackEffect.isValid)
		{
			Effect.server.Run(attackEffect.resourcePath, base.transform.position, Vector3.up);
		}
		if (entityContents == null)
		{
			return;
		}
		BaseEntity[] array = entityContents.ToArray();
		foreach (BaseEntity baseEntity in array)
		{
			if (baseEntity.IsValid())
			{
				BaseCombatEntity baseCombatEntity = baseEntity as BaseCombatEntity;
				if (!(baseCombatEntity == null))
				{
					HitInfo hitInfo = new HitInfo();
					hitInfo.damageTypes.Add(damageType);
					hitInfo.DoHitEffects = true;
					hitInfo.DidHit = true;
					hitInfo.PointStart = base.transform.position;
					hitInfo.PointEnd = baseCombatEntity.transform.position;
					baseCombatEntity.Hurt(hitInfo);
				}
			}
		}
	}
}
