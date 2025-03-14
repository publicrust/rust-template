using UnityEngine;

public class SpaceCheckingSpawnPoint : GenericSpawnPoint
{
	public bool useCustomBoundsCheckMask;

	public LayerMask customBoundsCheckMask;

	public float customBoundsCheckScale = 1f;

	public override bool IsAvailableTo(GameObjectRef prefabRef)
	{
		if (!base.IsAvailableTo(prefabRef))
		{
			return false;
		}
		if (useCustomBoundsCheckMask)
		{
			return SpawnHandler.CheckBounds(prefabRef.Get(), base.transform.position, base.transform.rotation, Vector3.one * customBoundsCheckScale, customBoundsCheckMask);
		}
		return SingletonComponent<SpawnHandler>.Instance.CheckBounds(prefabRef.Get(), base.transform.position, base.transform.rotation, Vector3.one * customBoundsCheckScale);
	}
}
