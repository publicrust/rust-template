using System.Collections.Generic;
using Facepunch;

public static class EntityLinkEx
{
	public static void FreeLinks(this List<EntityLink> links)
	{
		for (int i = 0; i < links.Count; i++)
		{
			EntityLink entityLink = links[i];
			entityLink.Clear();
			Pool.Free<EntityLink>(ref entityLink);
		}
		links.Clear();
	}

	public static void ClearLinks(this List<EntityLink> links)
	{
		for (int i = 0; i < links.Count; i++)
		{
			links[i].Clear();
		}
	}

	public static void AddLinks(this List<EntityLink> links, BaseEntity entity, Socket_Base[] sockets)
	{
		foreach (Socket_Base socket in sockets)
		{
			EntityLink entityLink = Pool.Get<EntityLink>();
			entityLink.Setup(entity, socket);
			links.Add(entityLink);
		}
	}
}
