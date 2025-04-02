using UnityEngine;

public class PowerlineNode : MonoBehaviour
{
	public GameObjectRef WirePrefab;

	public float MaxDistance = 50f;

	protected void Awake()
	{
		if (Object.op_Implicit((Object)(object)TerrainMeta.Path))
		{
			TerrainMeta.Path.AddWire(this);
		}
	}
}
