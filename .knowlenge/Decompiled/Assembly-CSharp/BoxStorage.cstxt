using UnityEngine;

public class BoxStorage : StorageContainer
{
	public override Vector3 GetDropPosition()
	{
		return ClosestPoint(base.GetDropPosition() + base.LastAttackedDir * 10f);
	}
}
