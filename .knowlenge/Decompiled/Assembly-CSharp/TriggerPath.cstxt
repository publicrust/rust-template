using UnityEngine;

public class TriggerPath : TriggerBase, IServerComponent
{
	public int pathTriggerId;

	[Header("Path")]
	public BasePath path;

	[Header("Spline")]
	public WorldSpline spline;

	public int splineDirection = 1;

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
		if (baseEntity.isServer)
		{
			return baseEntity.gameObject;
		}
		return null;
	}

	internal override void OnEntityEnter(BaseEntity ent)
	{
		base.OnEntityEnter(ent);
		if (ent.TryGetComponent<IPathListener>(out var component))
		{
			if ((bool)spline)
			{
				component.OnSplinePathTrigger(pathTriggerId, spline, splineDirection);
			}
			if ((bool)path)
			{
				component.OnBasePathTrigger(pathTriggerId, path);
			}
		}
	}
}
