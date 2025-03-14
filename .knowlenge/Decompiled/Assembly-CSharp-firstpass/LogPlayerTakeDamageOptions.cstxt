using System;
using Epic.OnlineServices.AntiCheatCommon;

public struct LogPlayerTakeDamageOptions
{
	public IntPtr VictimPlayerHandle { get; set; }

	public Vec3f? VictimPlayerPosition { get; set; }

	public Quat? VictimPlayerViewRotation { get; set; }

	public IntPtr AttackerPlayerHandle { get; set; }

	public Vec3f? AttackerPlayerPosition { get; set; }

	public Quat? AttackerPlayerViewRotation { get; set; }

	public bool IsHitscanAttack { get; set; }

	public bool HasLineOfSight { get; set; }

	public bool IsCriticalHit { get; set; }

	public uint HitBoneId_DEPRECATED { get; set; }

	public float DamageTaken { get; set; }

	public float HealthRemaining { get; set; }

	public AntiCheatCommonPlayerTakeDamageSource DamageSource { get; set; }

	public AntiCheatCommonPlayerTakeDamageType DamageType { get; set; }

	public AntiCheatCommonPlayerTakeDamageResult DamageResult { get; set; }

	public LogPlayerUseWeaponData? PlayerUseWeaponData { get; set; }

	public uint TimeSincePlayerUseWeaponMs { get; set; }

	public Vec3f? DamagePosition { get; set; }
}
