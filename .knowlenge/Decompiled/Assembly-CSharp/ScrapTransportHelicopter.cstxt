using System;
using Rust;
using UnityEngine;

public class ScrapTransportHelicopter : PlayerHelicopter, TriggerHurtNotChild.IHurtTriggerUser
{
	[SerializeField]
	private Transform searchlightEye;

	[SerializeField]
	private BoxCollider parentTriggerCollider;

	[Header("Damage Effects")]
	[SerializeField]
	private ParticleSystemContainer tailDamageLight;

	[SerializeField]
	private ParticleSystemContainer tailDamageHeavy;

	[SerializeField]
	private ParticleSystemContainer mainEngineDamageLight;

	[SerializeField]
	private ParticleSystemContainer mainEngineDamageHeavy;

	[SerializeField]
	private ParticleSystemContainer cockpitSparks;

	[SerializeField]
	private Transform tailDamageLightEffects;

	[SerializeField]
	private Transform mainEngineDamageLightEffects;

	[SerializeField]
	private SoundDefinition damagedFireSoundDef;

	[SerializeField]
	private SoundDefinition damagedFireTailSoundDef;

	[SerializeField]
	private SoundDefinition damagedSparksSoundDef;

	[SerializeField]
	private float pilotRotorScale = 1.5f;

	[SerializeField]
	private float compassOffset;

	[ServerVar(Help = "Population active on the server", ShowInAdminUI = true)]
	public static float population;

	public const string PASSENGER_ACHIEVEMENT = "RUST_AIR";

	public const int PASSENGER_ACHIEVEMENT_REQ_COUNT = 5;

	public override void ServerInit()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		base.ServerInit();
		rigidBody.inertiaTensor = new Vector3(19082f, 14356f, 7940f);
	}

	public override void OnHealthChanged(float oldvalue, float newvalue)
	{
		if (base.isServer)
		{
			((FacepunchBehaviour)this).Invoke((Action)DelayedNetworking, 0.15f);
		}
	}

	public void DelayedNetworking()
	{
		SendNetworkUpdate();
	}

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
		if (!GameInfo.HasAchievements || !base.isServer || old.HasFlag(Flags.On) || !next.HasFlag(Flags.On) || !((Object)(object)GetDriver() != (Object)null))
		{
			return;
		}
		int num = 0;
		foreach (BaseEntity child in children)
		{
			if ((Object)(object)child.ToPlayer() != (Object)null)
			{
				num++;
			}
			if (child is BaseVehicleSeat baseVehicleSeat && (Object)(object)baseVehicleSeat.GetMounted() != (Object)null && (Object)(object)baseVehicleSeat.GetMounted() != (Object)(object)GetDriver())
			{
				num++;
			}
		}
		if (num >= 5)
		{
			GetDriver().GiveAchievement("RUST_AIR");
		}
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
