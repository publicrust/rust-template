using Rust;
using UnityEngine;

public class VehicleLiftOccupantTrigger : TriggerBase
{
	public ModularCar carOccupant { get; private set; }

	protected override void OnDisable()
	{
		if (!Rust.Application.isQuitting)
		{
			base.OnDisable();
			if (carOccupant != null)
			{
				carOccupant = null;
			}
		}
	}

	internal override GameObject InterestedInObject(GameObject obj)
	{
		if (base.InterestedInObject(obj) == null)
		{
			return null;
		}
		BaseEntity baseEntity = GameObjectEx.ToBaseEntity(obj);
		if (baseEntity == null || baseEntity.isClient)
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
		if (carOccupant == null && ent.isServer)
		{
			carOccupant = (ModularCar)ent;
		}
	}

	internal override void OnEntityLeave(BaseEntity ent)
	{
		base.OnEntityLeave(ent);
		if (!(carOccupant == ent))
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
			if (entityContent != null)
			{
				carOccupant = (ModularCar)entityContent;
				break;
			}
		}
	}
}
