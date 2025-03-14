using Rust.Ai;
using UnityEngine;
using UnityEngine.AI;

public class RealmedNavMeshObstacle : BasePrefab
{
	public NavMeshObstacle Obstacle;

	public override void PreProcess(IPrefabProcessor process, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		if (bundling)
		{
			return;
		}
		base.PreProcess(process, rootObj, name, serverside, clientside, bundling: false);
		if (base.isServer && (bool)Obstacle)
		{
			if (AiManager.nav_disable)
			{
				process.RemoveComponent(Obstacle);
				Obstacle = null;
			}
			else if (AiManager.nav_obstacles_carve_state >= 2)
			{
				Obstacle.carving = true;
			}
			else if (AiManager.nav_obstacles_carve_state == 1)
			{
				Obstacle.carving = Obstacle.gameObject.layer == 21;
			}
			else
			{
				Obstacle.carving = false;
			}
		}
		process.RemoveComponent(this);
	}
}
