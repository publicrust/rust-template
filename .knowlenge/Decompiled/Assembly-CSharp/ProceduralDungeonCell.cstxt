using UnityEngine;

public class ProceduralDungeonCell : BaseMonoBehaviour
{
	public bool north;

	public bool east;

	public bool south;

	public bool west;

	public bool entrance;

	public bool hasSpawn;

	public Transform exitPointHack;

	public SpawnGroup[] spawnGroups;

	public RendererLOD[] mapRendererLods;

	public void Awake()
	{
		spawnGroups = GetComponentsInChildren<SpawnGroup>();
	}
}
