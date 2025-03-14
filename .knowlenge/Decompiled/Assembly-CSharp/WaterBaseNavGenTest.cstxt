using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WaterBaseNavGenTest : MonoBehaviour
{
	private IEnumerator co;

	[ContextMenu("Nav Gen")]
	public void NavGen()
	{
		DungeonNavmesh dungeonNavmesh = base.gameObject.AddComponent<DungeonNavmesh>();
		dungeonNavmesh.NavmeshResolutionModifier = 0.3f;
		dungeonNavmesh.NavMeshCollectGeometry = NavMeshCollectGeometry.PhysicsColliders;
		dungeonNavmesh.LayerMask = 65537;
		co = dungeonNavmesh.UpdateNavMeshAndWait();
		StartCoroutine(co);
	}
}
