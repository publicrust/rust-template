using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WaterBaseNavGenTest : MonoBehaviour
{
	private IEnumerator co;

	[ContextMenu("Nav Gen")]
	public void NavGen()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		DungeonNavmesh dungeonNavmesh = ((Component)this).gameObject.AddComponent<DungeonNavmesh>();
		dungeonNavmesh.NavmeshResolutionModifier = 0.3f;
		dungeonNavmesh.NavMeshCollectGeometry = (NavMeshCollectGeometry)1;
		dungeonNavmesh.LayerMask = LayerMask.op_Implicit(65537);
		co = dungeonNavmesh.UpdateNavMeshAndWait();
		((MonoBehaviour)this).StartCoroutine(co);
	}
}
