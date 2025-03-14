using UnityEngine;

public class AttackHeliGunnerSeat : BaseVehicleSeat
{
	private AttackHelicopter _owner;

	private AttackHelicopter Owner
	{
		get
		{
			if (_owner == null)
			{
				_owner = GetComponentInParent<AttackHelicopter>();
			}
			return _owner;
		}
	}

	public override bool CanHoldItems()
	{
		if (Owner != null)
		{
			return !Owner.GunnerIsInGunnerView;
		}
		return false;
	}

	public override Transform GetEyeOverride()
	{
		if (Owner != null && Owner.GunnerIsInGunnerView)
		{
			return Owner.gunnerEyePos;
		}
		return base.GetEyeOverride();
	}

	public override Vector3 EyePositionForPlayer(BasePlayer player, Quaternion lookRot)
	{
		if (player.GetMounted() != this)
		{
			return Vector3.zero;
		}
		return GetEyeOverride().position;
	}

	public override Vector3 EyeCenterForPlayer(BasePlayer player, Quaternion lookRot)
	{
		if (player.GetMounted() != this)
		{
			return Vector3.zero;
		}
		return GetEyeOverride().position;
	}

	public override Vector2 GetPitchClamp()
	{
		if (Owner != null && Owner.GunnerIsInGunnerView)
		{
			return Owner.turretPitchClamp;
		}
		return pitchClamp;
	}

	public override Vector2 GetYawClamp()
	{
		if (Owner != null && Owner.GunnerIsInGunnerView)
		{
			return Owner.turretYawClamp;
		}
		return yawClamp;
	}
}
