using System.Collections.Generic;
using Rust.Ai;
using UnityEngine;

public class SmokeGrenade : TimedExplosive
{
	public float smokeDuration = 45f;

	public GameObjectRef smokeEffectPrefab;

	public GameObjectRef igniteSound;

	public SoundPlayer soundLoop;

	private GameObject smokeEffectInstance;

	public static List<SmokeGrenade> activeGrenades = new List<SmokeGrenade>();

	public float fieldMin = 5f;

	public float fieldMax = 8f;

	protected bool killing;

	public override void ServerInit()
	{
		base.ServerInit();
		InvokeRepeating(CheckForWater, 1f, 1f);
	}

	public override void Explode()
	{
		if (WaterFactor() >= 0.5f)
		{
			FinishUp();
		}
		else if (!IsOn())
		{
			Invoke(FinishUp, smokeDuration);
			SetFlag(Flags.On, b: true);
			SetFlag(Flags.Open, b: true);
			InvalidateNetworkCache();
			SendNetworkUpdateImmediate();
			activeGrenades.Add(this);
			if ((bool)creatorEntity)
			{
				Sensation sensation = default(Sensation);
				sensation.Type = SensationType.Explosion;
				sensation.Position = creatorEntity.transform.position;
				sensation.Radius = explosionRadius * 17f;
				sensation.DamagePotential = 0f;
				sensation.InitiatorPlayer = creatorEntity as BasePlayer;
				sensation.Initiator = creatorEntity;
				Sense.Stimulate(sensation);
			}
		}
	}

	public void CheckForWater()
	{
		if (WaterFactor() >= 0.5f)
		{
			FinishUp();
		}
	}

	public void FinishUp()
	{
		if (!killing)
		{
			Kill();
			killing = true;
		}
	}

	public override void DestroyShared()
	{
		activeGrenades.Remove(this);
		base.DestroyShared();
	}
}
