using UnityEngine;

public class DungeonGridCell : MonoBehaviour
{
	public DungeonGridConnectionType North;

	public DungeonGridConnectionType South;

	public DungeonGridConnectionType West;

	public DungeonGridConnectionType East;

	public DungeonGridConnectionVariant NorthVariant;

	public DungeonGridConnectionVariant SouthVariant;

	public DungeonGridConnectionVariant WestVariant;

	public DungeonGridConnectionVariant EastVariant;

	public GameObjectRef[] AvoidNeighbours;

	public RendererLOD[] MapRendererLods;

	public bool Replaceable;

	public bool ShouldAvoid(uint id)
	{
		GameObjectRef[] avoidNeighbours = AvoidNeighbours;
		for (int i = 0; i < avoidNeighbours.Length; i++)
		{
			if (avoidNeighbours[i].resourceID == id)
			{
				return true;
			}
		}
		return false;
	}

	protected void Awake()
	{
		if ((bool)TerrainMeta.Path)
		{
			TerrainMeta.Path.DungeonGridCells.Add(this);
		}
	}
}
