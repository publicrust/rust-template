using System.Collections.Generic;
using UnityEngine;

public class DungeonBaseLink : MonoBehaviour
{
	public DungeonBaseLinkType Type;

	public int Cost = 1;

	public int MaxFloor = -1;

	public int MaxCountLocal = -1;

	public int MaxCountGlobal = -1;

	[Tooltip("If set to a positive number, all segments with the same MaxCountIdentifier are counted towards MaxCountLocal and MaxCountGlobal")]
	public int MaxCountIdentifier = -1;

	public DungeonBaseInfo Dungeon;

	public RendererLOD[] MapRendererLods = new RendererLOD[0];

	private List<DungeonBaseSocket> sockets;

	private List<DungeonVolume> volumes;

	internal List<DungeonBaseSocket> Sockets
	{
		get
		{
			if (sockets == null)
			{
				sockets = new List<DungeonBaseSocket>();
				GetComponentsInChildren(includeInactive: true, sockets);
			}
			return sockets;
		}
	}

	internal List<DungeonVolume> Volumes
	{
		get
		{
			if (volumes == null)
			{
				volumes = new List<DungeonVolume>();
				GetComponentsInChildren(includeInactive: true, volumes);
			}
			return volumes;
		}
	}

	protected void Awake()
	{
		if ((bool)TerrainMeta.Path)
		{
			TerrainMeta.Path.DungeonBaseLinks.Add(this);
		}
	}

	internal void Initialize()
	{
		if (!(TerrainMeta.Path == null))
		{
			Dungeon = TerrainMeta.Path.FindClosest(TerrainMeta.Path.DungeonBaseEntrances, base.transform.position);
			if (!(Dungeon == null))
			{
				Dungeon.Add(this);
			}
		}
	}
}
