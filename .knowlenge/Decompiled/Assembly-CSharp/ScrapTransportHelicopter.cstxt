using UnityEngine;

public class ScrapTransportHelicopter : MiniCopter
{
	public Transform searchlightEye;

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

	[ServerVar(Help = "Population active on the server")]
	public new static float population;

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

	protected override bool CanPushNow(BasePlayer pusher)
	{
		return false;
	}
}
