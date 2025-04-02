using System.Collections.Generic;
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
			SingletonComponent<SmokeGrenadeManager>.Instance.Add(this);
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
		SingletonComponent<SmokeGrenadeManager>.Instance.Remove(this);
		activeGrenades.Remove(this);
		base.DestroyShared();
	}
}
