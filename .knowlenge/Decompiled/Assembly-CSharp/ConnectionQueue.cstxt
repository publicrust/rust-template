using System.Collections.Generic;
using ConVar;
using Facepunch;
using Network;
using Oxide.Core;
using UnityEngine;

public class ConnectionQueue
{
	private class ReservedServerSlot : Facepunch.Pool.IPooled
	{
		public ulong UserId;

		public float Expiry;

		public void EnterPool()
		{
		}

		public void LeavePool()
		{
			UserId = 0uL;
			Expiry = 0f;
		}
	}

	public List<Connection> queue = new List<Connection>();

	public List<Connection> joining = new List<Connection>();

	private List<ReservedServerSlot> reservedSlots = new List<ReservedServerSlot>();

	private float nextCleanupReservedSlots;

	public float nextMessageTime;

	public int ReservedCount => reservedSlots.Count;

	public int Queued => queue.Count;

	public int Joining => joining.Count;

	public bool IsServerFull => SingletonComponent<ServerMgr>.Instance.AvailableSlots - Joining <= 0;

	public void SkipQueue(ulong userid)
	{
		for (int i = 0; i < queue.Count; i++)
		{
			Connection connection = queue[i];
			if (connection.userid == userid)
			{
				JoinGame(connection);
				break;
			}
		}
	}

	internal void Join(Connection connection)
	{
		if (Interface.CallHook("OnConnectionQueue", connection) == null)
		{
			nextMessageTime = 0f;
			if ((Queued == 0 && !IsServerFull) || CanJumpQueue(connection))
			{
				JoinGame(connection);
				return;
			}
			connection.state = Connection.State.InQueue;
			queue.Add(connection);
		}
	}

	public void Cycle(int availableSlots)
	{
		if (Interface.CallHook("OnQueueCycle", availableSlots) != null)
		{
			return;
		}
		if (UnityEngine.Time.realtimeSinceStartup > nextCleanupReservedSlots)
		{
			nextCleanupReservedSlots = UnityEngine.Time.realtimeSinceStartup + 1f;
			CleanupExpiredReservedSlots();
		}
		if (queue.Count != 0)
		{
			SendQueueUpdates();
			if (!IsServerFull)
			{
				JoinGame(queue[0]);
			}
		}
	}

	public void SendQueueUpdates()
	{
		if (!(nextMessageTime > UnityEngine.Time.realtimeSinceStartup))
		{
			nextMessageTime = UnityEngine.Time.realtimeSinceStartup + 10f;
			for (int i = 0; i < queue.Count; i++)
			{
				SendQueueUpdate(queue[i], i);
			}
		}
	}

	public void SendQueueUpdate(Connection c, int position)
	{
		if (Interface.CallHook("OnQueueUpdate", c, position) == null)
		{
			NetWrite netWrite = Network.Net.sv.StartWrite();
			netWrite.PacketID(Message.Type.QueueUpdate);
			netWrite.UInt16((ushort)Queued);
			netWrite.UInt16((ushort)position);
			netWrite.Send(new SendInfo(c));
		}
	}

	public void RemoveConnection(Connection connection)
	{
		if (Interface.CallHook("OnConnectionDequeue", connection) == null)
		{
			if (queue.Remove(connection))
			{
				nextMessageTime = 0f;
			}
			joining.Remove(connection);
		}
	}

	public void TryAddReservedSlot(Connection connection)
	{
		if (connection.canReserveSlot && (connection.state == Connection.State.Connected || connection.state == Connection.State.Welcoming))
		{
			AddReservation(connection.userid);
		}
	}

	private void JoinGame(Connection connection)
	{
		queue.Remove(connection);
		connection.state = Connection.State.Welcoming;
		RemoveReservedSlot(connection.userid);
		nextMessageTime = 0f;
		joining.Add(connection);
		SingletonComponent<ServerMgr>.Instance.JoinGame(connection);
	}

	public void JoinedGame(Connection connection)
	{
		RemoveConnection(connection);
	}

	private void AddReservation(ulong userId)
	{
		ReservedServerSlot reservedServerSlot = FindQueueSpot(userId);
		if (reservedServerSlot == null)
		{
			reservedServerSlot = Facepunch.Pool.Get<ReservedServerSlot>();
			reservedSlots.Add(reservedServerSlot);
		}
		reservedServerSlot.UserId = userId;
		reservedServerSlot.Expiry = UnityEngine.Time.realtimeSinceStartup + (float)ConVar.Server.rejoin_delay;
	}

	private void CleanupExpiredReservedSlots()
	{
		if (reservedSlots.Count == 0)
		{
			return;
		}
		float realtimeSinceStartup = UnityEngine.Time.realtimeSinceStartup;
		for (int i = 0; i < reservedSlots.Count; i++)
		{
			ReservedServerSlot obj = reservedSlots[i];
			if (realtimeSinceStartup > obj.Expiry)
			{
				reservedSlots.RemoveAt(i);
				i--;
				Facepunch.Pool.Free(ref obj);
			}
		}
	}

	private ReservedServerSlot FindQueueSpot(ulong userId)
	{
		foreach (ReservedServerSlot reservedSlot in reservedSlots)
		{
			if (reservedSlot.UserId == userId)
			{
				return reservedSlot;
			}
		}
		return null;
	}

	private void RemoveReservedSlot(ulong userId)
	{
		for (int i = 0; i < reservedSlots.Count; i++)
		{
			ReservedServerSlot obj = reservedSlots[i];
			if (obj.UserId == userId)
			{
				reservedSlots.RemoveAt(i);
				i--;
				Facepunch.Pool.Free(ref obj);
			}
		}
	}

	private bool CanJumpQueue(Connection connection)
	{
		object obj = Interface.CallHook("CanBypassQueue", connection);
		if (obj is bool)
		{
			return (bool)obj;
		}
		if (DeveloperList.Contains(connection.userid))
		{
			return true;
		}
		ServerUsers.User user = ServerUsers.Get(connection.userid);
		if (user != null && user.group == ServerUsers.UserGroup.Moderator)
		{
			return true;
		}
		if (user != null && user.group == ServerUsers.UserGroup.Owner)
		{
			return true;
		}
		if (user != null && user.group == ServerUsers.UserGroup.SkipQueue)
		{
			return true;
		}
		for (int i = 0; i < reservedSlots.Count; i++)
		{
			if (reservedSlots[i].UserId == connection.userid && reservedSlots[i].Expiry > UnityEngine.Time.realtimeSinceStartup)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsQueued(ulong userid)
	{
		for (int i = 0; i < queue.Count; i++)
		{
			if (queue[i].userid == userid)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsJoining(ulong userid)
	{
		for (int i = 0; i < joining.Count; i++)
		{
			if (joining[i].userid == userid)
			{
				return true;
			}
		}
		return false;
	}
}
