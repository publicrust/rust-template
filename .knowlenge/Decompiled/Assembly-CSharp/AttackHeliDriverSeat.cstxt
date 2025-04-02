using UnityEngine;

public class AttackHeliDriverSeat : BaseVehicleSeat
{
	[SerializeField]
	private Sprite rocketCrosshair;

	[SerializeField]
	private Sprite incendRocketCrosshair;

	[SerializeField]
	private Sprite hvRocketCrosshair;

	[SerializeField]
	private Sprite reloadingCrosshair;

	[SerializeField]
	private GameObjectRef rocketHVItem;

	[SerializeField]
	private GameObjectRef rocketIncenItem;

	private AttackHelicopter _owner;

	private AttackHelicopter Owner
	{
		get
		{
			if ((Object)(object)_owner == (Object)null)
			{
				_owner = ((Component)this).GetComponentInParent<AttackHelicopter>();
			}
			return _owner;
		}
	}
}
