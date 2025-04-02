using System.Collections.Generic;
using Facepunch;

public class EntityLink : Pool.IPooled
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
		return socket.CanConnect(owner.transform.position, owner.transform.rotation, link.socket, link.owner.transform.position, link.owner.transform.rotation);
	}
}
