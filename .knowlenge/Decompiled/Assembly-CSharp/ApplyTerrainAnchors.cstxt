using UnityEngine;

public class ApplyTerrainAnchors : MonoBehaviour
{
	protected void Awake()
	{
		BaseEntity component = GetComponent<BaseEntity>();
		TerrainAnchor[] anchors = null;
		if (component.isServer)
		{
			anchors = PrefabAttribute.server.FindAll<TerrainAnchor>(component.prefabID);
		}
		base.transform.ApplyTerrainAnchors(anchors);
		GameManager.Destroy(this);
	}
}
