using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileWeaponMod : BaseEntity
{
	[Serializable]
	public struct Modifier
	{
		public bool enabled;

		[Tooltip("1 means no change. 0.5 is half.")]
		public float scalar;

		[Tooltip("Added after the scalar is applied.")]
		public float offset;
	}

	[Header("Silencer")]
	public GameObjectRef defaultSilencerEffect;

	public bool isSilencer;

	[Header("Weapon Basics")]
	public Modifier repeatDelay;

	public Modifier projectileVelocity;

	public Modifier projectileDamage;

	public Modifier projectileDistance;

	[Header("Recoil")]
	public Modifier aimsway;

	public Modifier aimswaySpeed;

	public Modifier recoil;

	[Header("Aim Cone")]
	public Modifier sightAimCone;

	public Modifier hipAimCone;

	[Header("Light Effects")]
	public bool isLight;

	[Header("MuzzleBrake")]
	public bool isMuzzleBrake;

	[Header("MuzzleBoost")]
	public bool isMuzzleBoost;

	[Header("Scope")]
	public bool isScope;

	public float zoomAmountDisplayOnly;

	[Header("Magazine")]
	public Modifier magazineCapacity;

	public bool needsOnForEffects;

	[Header("Burst")]
	public int burstCount = -1;

	public float timeBetweenBursts;

	public override void ServerInit()
	{
		SetFlag(Flags.Disabled, b: true);
		base.ServerInit();
	}

	public override void PostServerLoad()
	{
		base.limitNetworking = HasFlag(Flags.Disabled);
	}

	public static float Mult(BaseEntity parentEnt, Func<ProjectileWeaponMod, Modifier> selector_modifier, Func<Modifier, float> selector_value, float def)
	{
		if (parentEnt.children == null)
		{
			return def;
		}
		IEnumerable<float> mods = GetMods(parentEnt, selector_modifier, selector_value);
		float num = 1f;
		foreach (float item in mods)
		{
			num *= item;
		}
		return num;
	}

	public static float Sum(BaseEntity parentEnt, Func<ProjectileWeaponMod, Modifier> selector_modifier, Func<Modifier, float> selector_value, float def)
	{
		if (parentEnt.children == null)
		{
			return def;
		}
		IEnumerable<float> mods = GetMods(parentEnt, selector_modifier, selector_value);
		if (mods.Count() != 0)
		{
			return mods.Sum();
		}
		return def;
	}

	public static float Average(BaseEntity parentEnt, Func<ProjectileWeaponMod, Modifier> selector_modifier, Func<Modifier, float> selector_value, float def)
	{
		if (parentEnt.children == null)
		{
			return def;
		}
		IEnumerable<float> mods = GetMods(parentEnt, selector_modifier, selector_value);
		if (mods.Count() != 0)
		{
			return mods.Average();
		}
		return def;
	}

	public static float Max(BaseEntity parentEnt, Func<ProjectileWeaponMod, Modifier> selector_modifier, Func<Modifier, float> selector_value, float def)
	{
		if (parentEnt.children == null)
		{
			return def;
		}
		IEnumerable<float> mods = GetMods(parentEnt, selector_modifier, selector_value);
		if (mods.Count() != 0)
		{
			return mods.Max();
		}
		return def;
	}

	public static float Min(BaseEntity parentEnt, Func<ProjectileWeaponMod, Modifier> selector_modifier, Func<Modifier, float> selector_value, float def)
	{
		if (parentEnt.children == null)
		{
			return def;
		}
		IEnumerable<float> mods = GetMods(parentEnt, selector_modifier, selector_value);
		if (mods.Count() != 0)
		{
			return mods.Min();
		}
		return def;
	}

	public static IEnumerable<float> GetMods(BaseEntity parentEnt, Func<ProjectileWeaponMod, Modifier> selector_modifier, Func<Modifier, float> selector_value)
	{
		return (from x in (from ProjectileWeaponMod x in parentEnt.children
				where x != null && (!x.needsOnForEffects || x.HasFlag(Flags.On))
				select x).Select(selector_modifier)
			where x.enabled
			select x).Select(selector_value);
	}

	public static bool HasBrokenWeaponMod(BaseEntity parentEnt)
	{
		if (parentEnt.children == null)
		{
			return false;
		}
		if (parentEnt.children.Cast<ProjectileWeaponMod>().Any((ProjectileWeaponMod x) => x != null && x.IsBroken()))
		{
			return true;
		}
		return false;
	}
}
