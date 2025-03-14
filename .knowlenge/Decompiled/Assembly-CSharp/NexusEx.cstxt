using System.Collections.Generic;
using Facepunch;
using Facepunch.Nexus.Models;

public class NexusEx : Nexus
{
	public static HashSet<StringView> Empty = new HashSet<StringView>();

	public string Key { get; }

	public HashSet<StringView> TagsSet { get; }

	public NexusEx(string endpoint, Nexus nexus)
	{
		base.NexusId = nexus.NexusId;
		base.Name = nexus.Name;
		base.LastReset = nexus.LastReset;
		base.ZoneCount = nexus.ZoneCount;
		base.MaxPlayers = nexus.MaxPlayers;
		base.OnlinePlayers = nexus.OnlinePlayers;
		base.QueuedPlayers = nexus.QueuedPlayers;
		base.Build = nexus.Build;
		base.Protocol = nexus.Protocol;
		base.Tags = nexus.Tags;
		Key = $"{endpoint}#{nexus.NexusId}";
		if (!string.IsNullOrEmpty(base.Tags))
		{
			List<StringView> collection = Pool.Get<List<StringView>>();
			((StringView)base.Tags).Split(',', collection);
			TagsSet = new HashSet<StringView>(collection, StringView.ComparerIgnoreCase.Instance);
		}
		else
		{
			TagsSet = Empty;
		}
	}
}
