using System.Collections.Generic;

public class ServerStatistics
{
	public class Storage
	{
		private Dictionary<string, int> dict = new Dictionary<string, int>();

		public int Get(string name)
		{
			dict.TryGetValue(name, out var value);
			return value;
		}

		public void Add(string name, int val)
		{
			if (dict.ContainsKey(name))
			{
				dict[name] += val;
			}
			else
			{
				dict.Add(name, val);
			}
		}
	}

	private BasePlayer player;

	private Storage storage;

	private static Dictionary<ulong, Storage> players = new Dictionary<ulong, Storage>();

	public ServerStatistics(BasePlayer player)
	{
		this.player = player;
	}

	public void Init()
	{
		storage = Get(player.userID);
	}

	public void Save()
	{
	}

	public void Add(string name, int val)
	{
		if (storage != null)
		{
			storage.Add(name, val);
		}
	}

	public static Storage Get(ulong id)
	{
		if (players.TryGetValue(id, out var value))
		{
			return value;
		}
		value = new Storage();
		players.Add(id, value);
		return value;
	}
}
