using UnityEngine;

public class Ballista : BaseSiegeWeapon
{
	[Header("Ballista")]
	public GameObjectRef ballistaGunPrefab;

	public EntityRef<BallistaGun> ballistaGunRef;

	public Transform dismountPositionsParent;

	[Header("Effects")]
	[SerializeField]
	private GameObjectRef fireEffectPrefab;

	public override float DriveWheelVelocity { get; }

	protected override void OnChildAdded(BaseEntity child)
	{
		base.OnChildAdded(child);
		if (child.prefabID == ballistaGunPrefab.GetEntity().prefabID)
		{
			BallistaGun ballistaGun = (BallistaGun)child;
			ballistaGunRef.Set(ballistaGun);
			ballistaGun.ballistaOwner = this;
		}
	}

	private BallistaGun GetBallistaGun()
	{
		BallistaGun ballistaGun = ballistaGunRef.Get(base.isServer);
		if (ballistaGun.IsValid())
		{
			return ballistaGun;
		}
		return null;
	}

	protected override bool CanPullNow(BasePlayer puller)
	{
		if (base.CanPullNow(puller))
		{
			return !IsGunMounted();
		}
		return false;
	}

	protected override bool CanPushNow(BasePlayer pusher)
	{
		if (base.CanPushNow(pusher))
		{
			return !IsGunMounted();
		}
		return false;
	}

	public bool IsGunMounted()
	{
		BallistaGun ballistaGun = GetBallistaGun();
		if (ballistaGun != null)
		{
			return ballistaGun.IsMounted();
		}
		return false;
	}

	protected override void CreateEngineController()
	{
	}

	private void RotateDismountPositions()
	{
		if (ballistaGunRef.Get(base.isServer) != null)
		{
			dismountPositionsParent.rotation = ballistaGunRef.Get(base.isServer).transform.rotation;
		}
	}

	public override void ServerInit()
	{
		base.ServerInit();
		mountPose = PlayerModel.MountPoses.StandDrive;
		DisablePhysics();
		Invoke(base.EnablePhysics, 1f);
	}

	public override BasePlayer GetMounted()
	{
		return GetDriver();
	}

	public override void OnTowAttach()
	{
		base.OnTowAttach();
		DismountAllPlayers();
	}

	public void OnFired()
	{
		if (fireEffectPrefab != null && fireEffectPrefab.isValid)
		{
			Effect.server.Run(fireEffectPrefab.resourcePath, this, 0u, Vector3.zero, Vector3.up, null, broadcast: true);
		}
	}

	public override void VehicleFixedUpdate()
	{
		base.VehicleFixedUpdate();
		if (GetWorldVelocity().magnitude > 5f || IsFlipping())
		{
			DismountAllPlayers();
		}
		RotateDismountPositions();
	}

	protected override void DoPushAction(BasePlayer player)
	{
		if (!(rigidBody == null))
		{
			Vector3 normalized = Vector3.ProjectOnPlane(base.transform.position - player.eyes.position, base.transform.up).normalized;
			float num = rigidBody.mass * 2.4f;
			rigidBody.AddForce(normalized * num, ForceMode.Impulse);
		}
	}

	public override void OnEngineStartFailed()
	{
	}

	public override bool MeetsEngineRequirements()
	{
		return false;
	}

	public override void LightToggle(BasePlayer player)
	{
	}
}
