using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class EntityLink : IPooled
{
	public BaseEntity owner;

	public Socket_Base socket;

	public List<EntityLink> connections = new List<EntityLink>(8);

	public int capacity = int.MaxValue;

	public string name => socket.socketName;

	public void Setup(BaseEntity owner, Socket_Base socket)
	{
		this.owner = owner;
		this.socket = socket;
		if (socket.monogamous)
		{
			capacity = 1;
		}
	}

	public void EnterPool()
	{
		owner = null;
		socket = null;
		capacity = int.MaxValue;
	}

	public void LeavePool()
	{
	}

	public bool Contains(EntityLink entity)
	{
		return connections.Contains(entity);
	}

	public void Add(EntityLink entity)
	{
		connections.Add(entity);
	}

	public void Remove(EntityLink entity)
	{
		connections.Remove(entity);
	}

	public void Clear()
	{
		for (int i = 0; i < connections.Count; i++)
		{
			connections[i].Remove(this);
		}
		connections.Clear();
	}

	public bool IsEmpty()
	{
		return connections.Count == 0;
	}

	public bool IsOccupied()
	{
		return connections.Count >= capacity;
	}

	public bool IsMale()
	{
		return socket.male;
	}

	public bool IsFemale()
	{
		return socket.female;
	}

	public bool CanConnect(EntityLink link)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		if (IsOccupied())
		{
			return false;
		}
		if (link == null)
		{
			return false;
		}
		if (link.IsOccupied())
		{
			return false;
		}
		return socket.CanConnect(((Component)owner).transform.position, ((Component)owner).transform.rotation, link.socket, ((Component)link.owner).transform.position, ((Component)link.owner).transform.rotation);
	}
}
