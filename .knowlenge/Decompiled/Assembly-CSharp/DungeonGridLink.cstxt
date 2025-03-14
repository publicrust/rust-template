using UnityEngine;

public class DungeonGridLink : MonoBehaviour
{
	public Transform UpSocket;

	public Transform DownSocket;

	public DungeonGridLinkType UpType;

	public DungeonGridLinkType DownType;

	public int Priority;

	public int Rotation;

	protected void Start()
	{
		if (!(TerrainMeta.Path == null))
		{
			DungeonGridInfo dungeonGridInfo = TerrainMeta.Path.FindClosest(TerrainMeta.Path.DungeonGridEntrances, base.transform.position);
			if (!(dungeonGridInfo == null))
			{
				dungeonGridInfo.Links.Add(base.gameObject);
			}
		}
	}
}
