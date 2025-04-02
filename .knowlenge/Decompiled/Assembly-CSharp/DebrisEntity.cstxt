using System;
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
		TimeWarning val = TimeWarning.New("ResetRemovalTime", 0);
		try
		{
			if (((FacepunchBehaviour)this).IsInvoking((Action)RemoveCorpse))
			{
				((FacepunchBehaviour)this).CancelInvoke((Action)RemoveCorpse);
			}
			((FacepunchBehaviour)this).Invoke((Action)RemoveCorpse, dur);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
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
