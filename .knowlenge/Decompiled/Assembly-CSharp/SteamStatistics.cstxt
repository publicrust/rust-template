using System.Collections.Generic;
using System.Threading.Tasks;
using ConVar;
using UnityEngine;

public class SteamStatistics
{
	private BasePlayer player;

	public Dictionary<string, int> intStats = new Dictionary<string, int>();

	private Task refresh;

	public SteamStatistics(BasePlayer p)
	{
		player = p;
	}

	public void Init()
	{
		if (PlatformService.Instance.IsValid)
		{
			refresh = PlatformService.Instance.LoadPlayerStats(player.userID);
			intStats.Clear();
		}
	}

	public void Save()
	{
		if (PlatformService.Instance.IsValid)
		{
			PlatformService.Instance.SavePlayerStats(player.userID);
		}
	}

	public void Add(string name, int var)
	{
		if (!PlatformService.Instance.IsValid || refresh == null || !refresh.IsCompleted)
		{
			return;
		}
		using (TimeWarning.New("PlayerStats.Add"))
		{
			int value = 0;
			if (intStats.TryGetValue(name, out value))
			{
				intStats[name] += var;
				PlatformService.Instance.SetPlayerStatInt(player.userID, name, intStats[name]);
				return;
			}
			value = (int)PlatformService.Instance.GetPlayerStatInt(player.userID, name, 0L);
			if (!PlatformService.Instance.SetPlayerStatInt(player.userID, name, value + var))
			{
				if (Global.developer > 0)
				{
					Debug.LogWarning("[STEAMWORKS] Couldn't SetUserStat: " + name);
				}
			}
			else
			{
				intStats.Add(name, value + var);
			}
		}
	}
}
