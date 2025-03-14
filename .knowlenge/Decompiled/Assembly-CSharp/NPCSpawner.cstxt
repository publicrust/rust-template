using UnityEngine;

public class NPCSpawner : SpawnGroup
{
	public MonumentNavMesh monumentNavMesh;

	public bool shouldFillOnSpawn;

	public override void SpawnInitial()
	{
		fillOnSpawn = shouldFillOnSpawn;
		if (WaitingForNavMesh())
		{
			Invoke(LateSpawn, 10f);
		}
		else
		{
			base.SpawnInitial();
		}
	}

	public bool WaitingForNavMesh()
	{
		if (monumentNavMesh != null)
		{
			return monumentNavMesh.IsBuilding;
		}
		return false;
	}

	public void LateSpawn()
	{
		if (!WaitingForNavMesh())
		{
			SpawnInitial();
			Debug.Log("Navmesh complete, spawning");
		}
		else
		{
			Invoke(LateSpawn, 5f);
		}
	}
}
