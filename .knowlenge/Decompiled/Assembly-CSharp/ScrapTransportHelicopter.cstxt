using Rust;
using UnityEngine;

public class ScrapTransportHelicopter : MiniCopter, TriggerHurtNotChild.IHurtTriggerUser
{
	public Transform searchlightEye;

	public BoxCollider parentTriggerCollider;

	[Header("Damage Effects")]
	public ParticleSystemContainer tailDamageLight;

	public ParticleSystemContainer tailDamageHeavy;

	public ParticleSystemContainer mainEngineDamageLight;

	public ParticleSystemContainer mainEngineDamageHeavy;

	public ParticleSystemContainer cockpitSparks;

	public Transform tailDamageLightEffects;

	public Transform mainEngineDamageLightEffects;

	public SoundDefinition damagedFireSoundDef;

	public SoundDefinition damagedFireTailSoundDef;

	public SoundDefinition damagedSparksSoundDef;

	private Sound damagedFireSound;

	private Sound damagedFireTailSound;

	private Sound damagedSparksSound;

	public float pilotRotorScale = 1.5f;

	public float compassOffset;

	[ServerVar(Help = "Population active on the server", ShowInAdminUI = true)]
	public new static float population;

	public const string PASSENGER_ACHIEVEMENT = "RUST_AIR";

	public const int PASSENGER_ACHIEVEMENT_REQ_COUNT = 5;

	public override void OnHealthChanged(float oldvalue, float newvalue)
	{
		if (base.isServer)
		{
			Invoke(DelayedNetworking, 0.15f);
		}
	}

	public void DelayedNetworking()
	{
		SendNetworkUpdate();
	}

	public override void OnAttacked(HitInfo info)
	{
		base.OnAttacked(info);
	}

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
		if (!Rust.GameInfo.HasAchievements || !base.isServer || old.HasFlag(Flags.On) || !next.HasFlag(Flags.On) || !(GetDriver() != null))
		{
			return;
		}
		int num = 0;
		foreach (BaseEntity child in children)
		{
			if (child.ToPlayer() != null)
			{
				num++;
			}
			if (child is BaseVehicleSeat baseVehicleSeat && baseVehicleSeat.GetMounted() != null && baseVehicleSeat.GetMounted() != GetDriver())
			{
				num++;
			}
		}
		if (num >= 5)
		{
			GetDriver().GiveAchievement("RUST_AIR");
		}
	}

	public override int StartingFuelUnits()
	{
		return 100;
	}

	public float GetDamageMultiplier(BaseEntity ent)
	{
		return 1f;
	}

	public void OnHurtTriggerOccupant(BaseEntity hurtEntity, DamageType damageType, float damageTotal)
	{
	}

	protected override bool CanPushNow(BasePlayer pusher)
	{
		return false;
	}
}
