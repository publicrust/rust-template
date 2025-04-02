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
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		((Nexus)this).NexusId = nexus.NexusId;
		((Nexus)this).Name = nexus.Name;
		((Nexus)this).LastReset = nexus.LastReset;
		((Nexus)this).ZoneCount = nexus.ZoneCount;
		((Nexus)this).MaxPlayers = nexus.MaxPlayers;
		((Nexus)this).OnlinePlayers = nexus.OnlinePlayers;
		((Nexus)this).QueuedPlayers = nexus.QueuedPlayers;
		((Nexus)this).Build = nexus.Build;
		((Nexus)this).Protocol = nexus.Protocol;
		((Nexus)this).Tags = nexus.Tags;
		Key = $"{endpoint}#{nexus.NexusId}";
		if (!string.IsNullOrEmpty(((Nexus)this).Tags))
		{
			List<StringView> list = Pool.Get<List<StringView>>();
			StringView val = StringView.op_Implicit(((Nexus)this).Tags);
			((StringView)(ref val)).Split(',', (ICollection<StringView>)list);
			TagsSet = new HashSet<StringView>(list, (IEqualityComparer<StringView>?)ComparerIgnoreCase.Instance);
		}
		else
		{
			TagsSet = Empty;
		}
	}
}
