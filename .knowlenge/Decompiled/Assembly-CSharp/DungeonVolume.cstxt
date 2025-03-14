using UnityEngine;

public class DungeonVolume : MonoBehaviour
{
	public Bounds bounds = new Bounds(Vector3.zero, Vector3.one);

	public OBB GetBounds(Vector3 position, Quaternion rotation)
	{
		position += rotation * (base.transform.localRotation * bounds.center + base.transform.localPosition);
		return new OBB(position, bounds.size, rotation * base.transform.localRotation);
	}

	public OBB GetBounds(Vector3 position, Quaternion rotation, Vector3 extrude)
	{
		position += rotation * (base.transform.localRotation * bounds.center + base.transform.localPosition);
		return new OBB(position, bounds.size + extrude, rotation * base.transform.localRotation);
	}
}
