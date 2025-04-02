using ConVar;
using UnityEngine;

public class TriggerParentEnclosed : TriggerParent
{
	public enum TriggerMode
	{
		TriggerPoint,
		PivotPoint
	}

	public float Padding;

	[Tooltip("AnyIntersect: Look for any intersection with the trigger. OriginIntersect: Only consider objects in the trigger if their origin is inside")]
	public TriggerMode intersectionMode;

	public bool CheckBoundsOnUnparent;

	public BoxCollider boxCollider;

	protected void OnEnable()
	{
		boxCollider = GetComponent<BoxCollider>();
	}

	public override bool ShouldParent(BaseEntity ent, bool bypassOtherTriggerCheck = false)
	{
		if (!base.ShouldParent(ent, bypassOtherTriggerCheck))
		{
			return false;
		}
		return IsInside(ent, Padding);
	}

	internal override bool SkipOnTriggerExit(Collider collider)
	{
		if (!CheckBoundsOnUnparent)
		{
			return false;
		}
		if (!Debugging.checkparentingtriggers)
		{
			return false;
		}
		BaseEntity baseEntity = GameObjectEx.ToBaseEntity(collider);
		if (baseEntity == null)
		{
			return false;
		}
		return IsInside(baseEntity, 0f);
	}

	public bool IsInside(BaseEntity ent, float padding)
	{
		Bounds bounds = new Bounds(boxCollider.center, boxCollider.size);
		if (padding > 0f)
		{
			bounds.Expand(padding);
		}
		OBB oBB = new OBB(boxCollider.transform, bounds);
		Vector3 target = ((intersectionMode == TriggerMode.TriggerPoint) ? ent.TriggerPoint() : ent.PivotPoint());
		return oBB.Contains(target);
	}
}
