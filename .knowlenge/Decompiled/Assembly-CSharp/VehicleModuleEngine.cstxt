using System;
using Oxide.Core;
using Rust;
using Rust.Modular;
using UnityEngine;

public class VehicleModuleEngine : VehicleModuleStorage
{
	[Serializable]
	public class Engine
	{
		[Header("Engine Stats")]
		public int engineKW;

		public float idleFuelPerSec = 0.25f;

		public float maxFuelPerSec = 0.25f;

		[Header("Engine Audio")]
		public EngineAudioSet audioSet;

		[Header("Engine FX")]
		public ParticleSystemContainer[] engineParticles;

		public ParticleSystem[] exhaustSmoke;

		public ParticleSystem[] exhaustBackfire;

		public float exhaustSmokeMinOpacity = 0.1f;

		public float exhaustSmokeMaxOpacity = 0.7f;

		public float exhaustSmokeChangeRate = 0.5f;
	}

	[SerializeField]
	public Engine engine;

	private const float FORCE_MULTIPLIER = 12.75f;

	private const float HEALTH_PERFORMANCE_FRACTION = 0.25f;

	private const float LOW_PERFORMANCE_THRESHOLD = 0.5f;

	private Sound badPerformanceLoop;

	private SoundModulation.Modulator badPerformancePitchModulator;

	private float prevSmokePercent;

	private const float MIN_FORCE_BIAS = 0.0002f;

	private const float MAX_FORCE_BIAS = 0.7f;

	public override bool HasAnEngine => true;

	public bool IsUsable { get; set; }

	public float PerformanceFractionAcceleration { get; set; }

	public float PerformanceFractionTopSpeed { get; set; }

	public float PerformanceFractionFuelEconomy { get; set; }

	public float OverallPerformanceFraction { get; set; }

	public bool AtLowPerformance => OverallPerformanceFraction <= 0.5f;

	public bool AtPeakPerformance => Mathf.Approximately(OverallPerformanceFraction, 1f);

	public int KW => engine.engineKW;

	public EngineAudioSet AudioSet => engine.audioSet;

	private bool EngineIsOn
	{
		get
		{
			if (base.Car != null)
			{
				return base.Car.CurEngineState == VehicleEngineController<GroundVehicle>.EngineState.On;
			}
			return false;
		}
	}

	public override void InitShared()
	{
		base.InitShared();
		RefreshPerformanceStats(GetContainer() as EngineStorage);
	}

	public override void OnEngineStateChanged(VehicleEngineController<GroundVehicle>.EngineState oldState, VehicleEngineController<GroundVehicle>.EngineState newState)
	{
		base.OnEngineStateChanged(oldState, newState);
		RefreshPerformanceStats(GetContainer() as EngineStorage);
	}

	public override float GetMaxDriveForce()
	{
		if (!IsUsable)
		{
			return 0f;
		}
		return (float)engine.engineKW * 12.75f * PerformanceFractionTopSpeed;
	}

	public void RefreshPerformanceStats(EngineStorage engineStorage)
	{
		if (Interface.CallHook("OnEngineStatsRefresh", this, engineStorage) == null)
		{
			if (engineStorage == null)
			{
				IsUsable = false;
				PerformanceFractionAcceleration = 0f;
				PerformanceFractionTopSpeed = 0f;
				PerformanceFractionFuelEconomy = 0f;
			}
			else
			{
				IsUsable = engineStorage.isUsable;
				PerformanceFractionAcceleration = GetPerformanceFraction(engineStorage.accelerationBoostPercent);
				PerformanceFractionTopSpeed = GetPerformanceFraction(engineStorage.topSpeedBoostPercent);
				PerformanceFractionFuelEconomy = GetPerformanceFraction(engineStorage.fuelEconomyBoostPercent);
			}
			OverallPerformanceFraction = (PerformanceFractionAcceleration + PerformanceFractionTopSpeed + PerformanceFractionFuelEconomy) / 3f;
			Interface.CallHook("OnEngineStatsRefreshed", this, engineStorage);
		}
	}

	public float GetPerformanceFraction(float statBoostPercent)
	{
		if (!IsUsable)
		{
			return 0f;
		}
		float num = Mathf.Lerp(0f, 0.25f, base.healthFraction);
		float num2 = ((base.healthFraction != 0f) ? (statBoostPercent * 0.75f) : 0f);
		return num + num2;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		RefreshPerformanceStats(GetContainer() as EngineStorage);
	}

	public override bool CanBeLooted(BasePlayer player)
	{
		if (!base.CanBeLooted(player))
		{
			return false;
		}
		return true;
	}

	public override void VehicleFixedUpdate()
	{
		if (!isSpawned || !base.IsOnAVehicle)
		{
			return;
		}
		using (TimeWarning.New("VehicleModuleEngine.VehicleFixedUpdate"))
		{
			base.VehicleFixedUpdate();
			if (base.Vehicle.IsMovingOrOn && !(base.Car == null) && base.Car.CurEngineState == VehicleEngineController<GroundVehicle>.EngineState.On && IsUsable)
			{
				float num = Mathf.Lerp(engine.idleFuelPerSec, engine.maxFuelPerSec, Mathf.Abs(base.Car.GetThrottleInput()));
				num /= PerformanceFractionFuelEconomy;
				base.Car.TickFuel(num);
			}
		}
	}

	public override float GetAdjustedDriveForce(float absSpeed, float topSpeed)
	{
		float maxDriveForce = GetMaxDriveForce();
		float num = MathEx.BiasedLerp(bias: Mathf.Lerp(0.0002f, 0.7f, PerformanceFractionAcceleration), x: 1f - absSpeed / topSpeed);
		return maxDriveForce * num;
	}

	public override void Hurt(HitInfo info)
	{
		base.Hurt(info);
		if (!IsTransferProtected() && info.damageTypes.GetMajorityDamageType() != DamageType.Decay)
		{
			float num = info.damageTypes.Total();
			EngineStorage engineStorage = GetContainer() as EngineStorage;
			if (engineStorage != null && num > 0f)
			{
				engineStorage.OnModuleDamaged(num);
			}
		}
	}

	public override void OnHealthChanged(float oldValue, float newValue)
	{
		base.OnHealthChanged(oldValue, newValue);
		if (base.isServer)
		{
			RefreshPerformanceStats(GetContainer() as EngineStorage);
		}
	}

	public override bool AdminFixUp(int tier)
	{
		if (!base.AdminFixUp(tier))
		{
			return false;
		}
		EngineStorage engineStorage = GetContainer() as EngineStorage;
		engineStorage.AdminAddParts(tier);
		RefreshPerformanceStats(engineStorage);
		return true;
	}
}
