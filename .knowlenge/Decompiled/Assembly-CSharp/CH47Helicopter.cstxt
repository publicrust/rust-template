using Oxide.Core;
using UnityEngine;

public class CH47Helicopter : BaseHelicopter
{
	public GameObjectRef mapMarkerEntityPrefab;

	[Header("Sounds")]
	public SoundDefinition flightEngineSoundDef;

	public SoundDefinition flightThwopsSoundDef;

	public float rotorGainModSmoothing = 0.25f;

	public float engineGainMin = 0.5f;

	public float engineGainMax = 1f;

	public float thwopGainMin = 0.5f;

	public float thwopGainMax = 1f;

	public BaseEntity mapMarkerInstance;

	public override void ServerInit()
	{
		rigidBody.isKinematic = false;
		base.ServerInit();
		CreateMapMarker();
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

	public override bool IsValidHomingTarget()
	{
		object obj = Interface.CallHook("CanBeHomingTargeted", this);
		if (obj is bool)
		{
			return (bool)obj;
		}
		return false;
	}

	protected override void ApplyHandbrake()
	{
	}

	protected override bool CanPushNow(BasePlayer pusher)
	{
		return false;
	}
}
