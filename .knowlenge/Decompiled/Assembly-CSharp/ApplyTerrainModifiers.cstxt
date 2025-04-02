using UnityEngine;

public class ApplyTerrainModifiers : MonoBehaviour
{
	protected void Awake()
	{
		BaseEntity component = ((Component)this).GetComponent<BaseEntity>();
		TerrainModifier[] modifiers = null;
		if (component.isServer)
		{
			modifiers = PrefabAttribute.server.FindAll<TerrainModifier>(component.prefabID);
		}
		((Component)this).transform.ApplyTerrainModifiers(modifiers);
		GameManager.Destroy((Component)(object)this);
	}
}
