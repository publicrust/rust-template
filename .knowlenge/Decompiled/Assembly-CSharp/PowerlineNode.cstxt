using UnityEngine;

public class PowerlineNode : MonoBehaviour
{
	public GameObjectRef WirePrefab;

	public float MaxDistance = 50f;

	protected void Awake()
	{
		if ((bool)TerrainMeta.Path)
		{
			TerrainMeta.Path.AddWire(this);
		}
	}
}
