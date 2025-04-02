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
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		List<TreeEntity> list = Pool.Get<List<TreeEntity>>();
		if ((Object)(object)BoxCollider != (Object)null)
		{
			GamePhysics.OverlapOBB<TreeEntity>(new OBB(((Component)this).transform.TransformPoint(BoxCollider.center), BoxCollider.size + Vector3.one, ((Component)this).transform.rotation), list, 1073741824, (QueryTriggerInteraction)2);
		}
		foreach (TreeEntity item in list)
		{
			BoundsCheck boundsCheck = PrefabAttribute.server.Find<BoundsCheck>(item.prefabID);
			if (boundsCheck != null && boundsCheck.IsType == BlockType)
			{
				item.Kill();
			}
		}
		Pool.FreeUnmanaged<TreeEntity>(ref list);
	}
}
