public interface IAIAttack
{
	void AttackTick(float delta, BaseEntity target, bool targetIsLOS);

	BaseEntity GetBestTarget();

	bool CanAttack(BaseEntity entity);

	float EngagementRange();

	bool IsTargetInRange(BaseEntity entity, out float dist);

	bool CanSeeTarget(BaseEntity entity);

	float GetAmmoFraction();

	bool NeedsToReload();

	bool Reload();

	float CooldownDuration();

	bool IsOnCooldown();

	bool StartAttacking(BaseEntity entity);

	void StopAttacking();
}
