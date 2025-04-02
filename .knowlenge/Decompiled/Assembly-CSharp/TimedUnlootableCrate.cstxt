public class TimedUnlootableCrate : LootContainer
{
	public bool unlootableOnSpawn = true;

	public float unlootableDuration = 300f;

	public override void ServerInit()
	{
		base.ServerInit();
		if (unlootableOnSpawn)
		{
			SetUnlootableFor(unlootableDuration);
		}
	}

	public void SetUnlootableFor(float duration)
	{
		SetFlag(Flags.OnFire, b: true);
		SetFlag(Flags.Locked, b: true);
		unlootableDuration = duration;
		Invoke(MakeLootable, duration);
	}

	public void MakeLootable()
	{
		SetFlag(Flags.OnFire, b: false);
		SetFlag(Flags.Locked, b: false);
	}
}
