using UnityEngine;

public class ApplyTerrainAnchors : MonoBehaviour
{
	protected void Awake()
	{
		BaseEntity component = ((Component)this).GetComponent<BaseEntity>();
		TerrainAnchor[] anchors = null;
		if (component.isServer)
		{
			anchors = PrefabAttribute.server.FindAll<TerrainAnchor>(component.prefabID);
		}
		((Component)this).transform.ApplyTerrainAnchors(anchors);
		GameManager.Destroy((Component)(object)this);
	}
}
