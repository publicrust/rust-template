using Facepunch;
using ProtoBuf;
using UnityEngine;

public class LockOnLauncher : BaseLauncher
{
	[SerializeField]
	public float lockRange = 250f;

	[SerializeField]
	public float lockConeDot = 0.8f;

	[SerializeField]
	public float timeToLock = 2f;

	[SerializeField]
	private float currentLockTime;

	[SerializeField]
	public float timeToLoseLock = 1f;

	[SerializeField]
	private GameObjectRef camUIDialogPrefab;

	private SeekerTarget currentLockTarget;

	private SeekingServerProjectile projectile;

	private float lockTickRate = 0.1f;

	private float lastSentLockTime;

	private bool HasProjectile => projectile != null;

	public override void OnHeldChanged()
	{
		base.OnHeldChanged();
		currentLockTarget = null;
		currentLockTime = 0f;
		if (IsDisabled())
		{
			CancelInvoke(UpdateLockedEntity);
			SetFlag(Flags.Reserved9, b: false);
			SetFlag(Flags.Reserved10, b: false);
			LetExistingProjectileGo();
		}
		else
		{
			InvokeRepeating(UpdateLockedEntity, 0f, lockTickRate);
		}
	}

	public virtual bool CanLock()
	{
		if (!GetOwnerPlayer())
		{
			return false;
		}
		if (!HasProjectile)
		{
			if (CanAttack())
			{
				return primaryMagazine.contents > 0;
			}
			return false;
		}
		return true;
	}

	public void UpdateLockedEntity()
	{
		BasePlayer ownerPlayer = GetOwnerPlayer();
		if (ownerPlayer != null && (ownerPlayer.IsSleeping() || ownerPlayer.IsDead()))
		{
			CancelInvoke(UpdateLockedEntity);
			SetFlag(Flags.Reserved9, b: false);
			SetFlag(Flags.Reserved10, b: false);
		}
		else
		{
			if (ownerPlayer == null || ownerPlayer.IsSleeping() || ownerPlayer.IsDead() || ownerPlayer.IsWounded())
			{
				return;
			}
			SeekerTarget seekerTarget = null;
			if (CanLock())
			{
				seekerTarget = SeekerTarget.GetBestForPoint(ownerPlayer.eyes.position, ownerPlayer.eyes.BodyForward(), lockConeDot, lockRange);
			}
			else
			{
				currentLockTime = 0f;
			}
			if (seekerTarget == null)
			{
				float num = timeToLock / timeToLoseLock;
				currentLockTime -= lockTickRate * num;
				if (currentLockTime == 0f)
				{
					currentLockTarget = null;
				}
			}
			if (seekerTarget != null && currentLockTarget != null && seekerTarget != currentLockTarget)
			{
				currentLockTime = 0f;
			}
			currentLockTarget = seekerTarget;
			if (currentLockTarget != null)
			{
				currentLockTime += lockTickRate;
				currentLockTarget.SendOwnerMessage(this, "RadarWarning");
			}
			currentLockTime = Mathf.Clamp(currentLockTime, 0f, timeToLock);
			if (currentLockTime != lastSentLockTime)
			{
				SendNetworkUpdate();
			}
			SetFlag(Flags.Reserved9, currentLockTarget != null);
			SetFlag(Flags.Reserved10, currentLockTime >= timeToLock);
			if (HasProjectile)
			{
				projectile.lockedTarget = ((currentLockTarget != null && HasLock()) ? currentLockTarget : null);
			}
			SetFlag(Flags.Busy, HasProjectile);
		}
	}

	public bool HasTarget()
	{
		return HasFlag(Flags.Reserved9);
	}

	protected override void OnReloadStarted()
	{
		LetExistingProjectileGo();
	}

	public override void ProjectileLaunched_Server(ServerProjectile justLaunched)
	{
		base.ProjectileLaunched_Server(justLaunched);
		SeekingServerProjectile component = justLaunched.GetComponent<SeekingServerProjectile>();
		component.lockedTarget = currentLockTarget;
		LetExistingProjectileGo();
		projectile = component;
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (!info.forDisk)
		{
			info.msg.ioEntity = Pool.Get<ProtoBuf.IOEntity>();
			info.msg.ioEntity.genericFloat1 = currentLockTime;
			lastSentLockTime = currentLockTime;
		}
	}

	private void LetExistingProjectileGo()
	{
		if (HasProjectile)
		{
			projectile.NotifyOrphaned();
			projectile = null;
		}
	}

	public bool HasLock()
	{
		return HasFlag(Flags.Reserved10);
	}
}
