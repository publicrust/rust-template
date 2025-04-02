using UnityEngine;

public class BunkerEntrance : BaseEntity, IMissionEntityListener
{
	public GameObjectRef portalPrefab;

	public GameObjectRef doorPrefab;

	public Transform portalSpawnPoint;

	public Transform doorSpawnPoint;

	public Door doorInstance;

	public BasePortal portalInstance;

	public override void ServerInit()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		base.ServerInit();
		if (portalPrefab.isValid)
		{
			portalInstance = ((Component)GameManager.server.CreateEntity(portalPrefab.resourcePath, portalSpawnPoint.position, portalSpawnPoint.rotation)).GetComponent<BasePortal>();
			portalInstance.SetParent(this, worldPositionStays: true);
			portalInstance.Spawn();
		}
		if (doorPrefab.isValid)
		{
			doorInstance = ((Component)GameManager.server.CreateEntity(doorPrefab.resourcePath, doorSpawnPoint.position, doorSpawnPoint.rotation)).GetComponent<Door>();
			doorInstance.SetParent(this, worldPositionStays: true);
			doorInstance.Spawn();
		}
	}

	public void MissionStarted(BasePlayer assignee, BaseMission.MissionInstance instance)
	{
	}

	public void MissionEnded(BasePlayer assignee, BaseMission.MissionInstance instance)
	{
	}
}
