using UnityEngine;

public class ApplyTerrainModifiers : MonoBehaviour
{
	protected void Awake()
	{
		BaseEntity component = GetComponent<BaseEntity>();
		TerrainModifier[] modifiers = null;
		if (component.isServer)
		{
			modifiers = PrefabAttribute.server.FindAll<TerrainModifier>(component.prefabID);
		}
		base.transform.ApplyTerrainModifiers(modifiers);
		GameManager.Destroy(this);
	}
}
