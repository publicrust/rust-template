using UnityEngine;

public class CH47Helicopter : BaseHelicopterVehicle
{
	public GameObjectRef mapMarkerEntityPrefab;

	public BaseEntity mapMarkerInstance;

	public override void ServerInit()
	{
		rigidBody.isKinematic = false;
		base.ServerInit();
		CreateMapMarker();
	}

	public override void PlayerServerInput(InputState inputState, BasePlayer player)
	{
		base.PlayerServerInput(inputState, player);
	}

	public void CreateMapMarker()
	{
		if ((bool)mapMarkerInstance)
		{
			mapMarkerInstance.Kill();
		}
		BaseEntity baseEntity = GameManager.server.CreateEntity(mapMarkerEntityPrefab.resourcePath, Vector3.zero, Quaternion.identity);
		baseEntity.Spawn();
		baseEntity.SetParent(this);
		mapMarkerInstance = baseEntity;
	}

	protected override bool CanPushNow(BasePlayer pusher)
	{
		return false;
	}
}
