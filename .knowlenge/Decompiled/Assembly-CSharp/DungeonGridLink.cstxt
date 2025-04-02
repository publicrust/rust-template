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
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)TerrainMeta.Path == (Object)null))
		{
			DungeonGridInfo dungeonGridInfo = TerrainMeta.Path.FindClosest(TerrainMeta.Path.DungeonGridEntrances, ((Component)this).transform.position);
			if (!((Object)(object)dungeonGridInfo == (Object)null))
			{
				dungeonGridInfo.Links.Add(((Component)this).gameObject);
			}
		}
	}
}
