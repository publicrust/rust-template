using UnityEngine;

public class TriggerWorkbench : TriggerBase
{
	public Workbench parentBench;

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

	public float WorkbenchLevel()
	{
		return parentBench.Workbenchlevel;
	}

	internal override void OnEntityEnter(BaseEntity ent)
	{
		base.OnEntityEnter(ent);
		if (ent is BasePlayer basePlayer)
		{
			basePlayer.metabolism.ForceUpdateWorkbenchFlags();
		}
	}

	internal override void OnEntityLeave(BaseEntity ent)
	{
		base.OnEntityLeave(ent);
		if (ent is BasePlayer basePlayer)
		{
			basePlayer.metabolism.ForceUpdateWorkbenchFlags();
		}
	}
}
