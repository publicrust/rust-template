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

	private BoxCollider boxCollider;

	protected void OnEnable()
	{
		boxCollider = GetComponent<BoxCollider>();
	}

	protected override bool ShouldParent(BaseEntity ent)
	{
		if (!base.ShouldParent(ent))
		{
			return false;
		}
		Bounds bounds = new Bounds(boxCollider.center, boxCollider.size);
		bounds.Expand(Padding);
		OBB oBB = new OBB(boxCollider.transform, bounds);
		Vector3 target = ((intersectionMode == TriggerMode.TriggerPoint) ? ent.TriggerPoint() : ent.PivotPoint());
		return oBB.Contains(target);
	}
}
