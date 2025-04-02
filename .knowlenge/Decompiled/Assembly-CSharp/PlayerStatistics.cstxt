using ConVar;

public class PlayerStatistics
{
	public SteamStatistics steam;

	public ServerStatistics server;

	public CombatLog combat;

	public BasePlayer forPlayer;

	private TimeSince lastSteamSave;

	public PlayerStatistics(BasePlayer player)
	{
		steam = new SteamStatistics(player);
		server = new ServerStatistics(player);
		combat = new CombatLog(player);
		forPlayer = player;
	}

	public void Init()
	{
		steam.Init();
		server.Init();
		combat.Init();
	}

	public void Save(bool forceSteamSave = false)
	{
		if (Server.official && (forceSteamSave || (float)lastSteamSave > 60f))
		{
			lastSteamSave = 0f;
			steam.Save();
		}
		server.Save();
		combat.Save();
	}

	public void Add(string name, int val, Stats stats = Stats.Steam)
	{
		if ((stats & Stats.Steam) != 0)
		{
			steam.Add(name, val);
		}
		if ((stats & Stats.Server) != 0)
		{
			server.Add(name, val);
		}
		if ((stats & Stats.Life) != 0)
		{
			forPlayer.LifeStoryGenericStat(name, val);
		}
	}
}
