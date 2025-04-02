using UnityEngine;

public class SpaceCheckingSpawnPoint : GenericSpawnPoint
{
	public bool useCustomBoundsCheckMask;

	public LayerMask customBoundsCheckMask;

	public float customBoundsCheckScale = 1f;

	public override bool IsAvailableTo(GameObject prefab)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		if (!base.IsAvailableTo(prefab))
		{
			return false;
		}
		if (useCustomBoundsCheckMask)
		{
			return SpawnHandler.CheckBounds(prefab, ((Component)this).transform.position, ((Component)this).transform.rotation, Vector3.one * customBoundsCheckScale, customBoundsCheckMask);
		}
		return SingletonComponent<SpawnHandler>.Instance.CheckBounds(prefab, ((Component)this).transform.position, ((Component)this).transform.rotation, Vector3.one * customBoundsCheckScale);
	}
}
