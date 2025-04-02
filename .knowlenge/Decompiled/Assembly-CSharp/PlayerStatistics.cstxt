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
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		if (Server.official && (forceSteamSave || TimeSince.op_Implicit(lastSteamSave) > 60f))
		{
			lastSteamSave = TimeSince.op_Implicit(0f);
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
