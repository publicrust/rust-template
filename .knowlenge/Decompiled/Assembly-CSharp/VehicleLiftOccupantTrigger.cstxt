using Rust;
using UnityEngine;

public class VehicleLiftOccupantTrigger : TriggerBase
{
	public ModularCar carOccupant { get; private set; }

	protected override void OnDisable()
	{
		if (!Application.isQuitting)
		{
			base.OnDisable();
			if ((Object)(object)carOccupant != (Object)null)
			{
				carOccupant = null;
			}
		}
	}

	internal override GameObject InterestedInObject(GameObject obj)
	{
		if ((Object)(object)base.InterestedInObject(obj) == (Object)null)
		{
			return null;
		}
		BaseEntity baseEntity = obj.ToBaseEntity();
		if ((Object)(object)baseEntity == (Object)null || baseEntity.isClient)
		{
			return null;
		}
		if (!(baseEntity is ModularCar))
		{
			return null;
		}
		return obj;
	}

	internal override void OnEntityEnter(BaseEntity ent)
	{
		base.OnEntityEnter(ent);
		if ((Object)(object)carOccupant == (Object)null && ent.isServer)
		{
			carOccupant = (ModularCar)ent;
		}
	}

	internal override void OnEntityLeave(BaseEntity ent)
	{
		base.OnEntityLeave(ent);
		if (!((Object)(object)carOccupant == (Object)(object)ent))
		{
			return;
		}
		carOccupant = null;
		if (entityContents == null || entityContents.Count <= 0)
		{
			return;
		}
		foreach (BaseEntity entityContent in entityContents)
		{
			if ((Object)(object)entityContent != (Object)null)
			{
				carOccupant = (ModularCar)entityContent;
				break;
			}
		}
	}
}
