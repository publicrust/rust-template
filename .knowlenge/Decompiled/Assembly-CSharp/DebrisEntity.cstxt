using ConVar;

public class DebrisEntity : BaseCombatEntity
{
	public float DebrisDespawnOverride;

	public override void ServerInit()
	{
		ResetRemovalTime();
		base.ServerInit();
	}

	public void RemoveCorpse()
	{
		Kill();
	}

	public void ResetRemovalTime(float dur)
	{
		using (TimeWarning.New("ResetRemovalTime"))
		{
			if (IsInvoking(RemoveCorpse))
			{
				CancelInvoke(RemoveCorpse);
			}
			Invoke(RemoveCorpse, dur);
		}
	}

	public float GetRemovalTime()
	{
		if (!(DebrisDespawnOverride > 0f))
		{
			return Server.debrisdespawn;
		}
		return DebrisDespawnOverride;
	}

	public void ResetRemovalTime()
	{
		ResetRemovalTime(GetRemovalTime());
	}

	public override string Categorize()
	{
		return "debris";
	}
}
