using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class SpawnableBoundsBlocker : MonoBehaviour
{
	public BoundsCheck.BlockType BlockType;

	public BoxCollider BoxCollider;

	[Button("Clear Trees")]
	public void ClearTrees()
	{
		List<TreeEntity> obj = Pool.Get<List<TreeEntity>>();
		if (BoxCollider != null)
		{
			GamePhysics.OverlapOBB(new OBB(base.transform.TransformPoint(BoxCollider.center), BoxCollider.size + Vector3.one, base.transform.rotation), obj, 1073741824, QueryTriggerInteraction.Collide);
		}
		foreach (TreeEntity item in obj)
		{
			BoundsCheck boundsCheck = PrefabAttribute.server.Find<BoundsCheck>(item.prefabID);
			if (boundsCheck != null && boundsCheck.IsType == BlockType)
			{
				item.Kill();
			}
		}
		Pool.FreeUnmanaged(ref obj);
	}
}
