using UnityEngine;

public class AttackHeliGunnerSeat : BaseVehicleSeat
{
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

	public override bool CanHoldItems()
	{
		if ((Object)(object)Owner != (Object)null)
		{
			return !Owner.GunnerIsInGunnerView;
		}
		return false;
	}

	public override Transform GetEyeOverride()
	{
		if ((Object)(object)Owner != (Object)null && Owner.GunnerIsInGunnerView)
		{
			return Owner.gunnerEyePos;
		}
		return base.GetEyeOverride();
	}

	public override Vector3 EyePositionForPlayer(BasePlayer player, Quaternion lookRot)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)player.GetMounted() != (Object)(object)this)
		{
			return Vector3.zero;
		}
		return GetEyeOverride().position;
	}

	public override Vector3 EyeCenterForPlayer(BasePlayer player, Quaternion lookRot)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)player.GetMounted() != (Object)(object)this)
		{
			return Vector3.zero;
		}
		return GetEyeOverride().position;
	}

	public override Vector2 GetPitchClamp()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)Owner != (Object)null && Owner.GunnerIsInGunnerView)
		{
			return Owner.turretPitchClamp;
		}
		return pitchClamp;
	}

	public override Vector2 GetYawClamp()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)Owner != (Object)null && Owner.GunnerIsInGunnerView)
		{
			return Owner.turretYawClamp;
		}
		return yawClamp;
	}
}
