using System.Collections.Generic;
using Network;
using Oxide.Core;
using UnityEngine;

public class ConnectionQueue
{
	public List<Connection> queue = new List<Connection>();

	public List<Connection> joining = new List<Connection>();

	public float nextMessageTime;

	public int Queued => queue.Count;

	public int Joining => joining.Count;

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
		connection.state = Connection.State.InQueue;
		queue.Add(connection);
		nextMessageTime = 0f;
		if (CanJumpQueue(connection))
		{
			JoinGame(connection);
		}
	}

	public void Cycle(int availableSlots)
	{
		if (queue.Count != 0)
		{
			if (availableSlots - Joining > 0)
			{
				JoinGame(queue[0]);
			}
			SendMessages();
		}
	}

	private void SendMessages()
	{
		if (!(nextMessageTime > Time.realtimeSinceStartup))
		{
			nextMessageTime = Time.realtimeSinceStartup + 10f;
			for (int i = 0; i < queue.Count; i++)
			{
				SendMessage(queue[i], i);
			}
		}
	}

	private void SendMessage(Connection c, int position)
	{
		string empty = string.Empty;
		empty = ((position <= 0) ? string.Format("YOU'RE NEXT - {1:N0} PLAYERS BEHIND YOU", position, queue.Count - position - 1) : $"{position:N0} PLAYERS AHEAD OF YOU, {queue.Count - position - 1:N0} PLAYERS BEHIND");
		if (Net.sv.write.Start())
		{
			Net.sv.write.PacketID(Message.Type.Message);
			Net.sv.write.String("QUEUE");
			Net.sv.write.String(empty);
			Net.sv.write.Send(new SendInfo(c));
		}
	}

	public void RemoveConnection(Connection connection)
	{
		if (queue.Remove(connection))
		{
			nextMessageTime = 0f;
		}
		joining.Remove(connection);
	}

	private void JoinGame(Connection connection)
	{
		queue.Remove(connection);
		connection.state = Connection.State.Welcoming;
		nextMessageTime = 0f;
		joining.Add(connection);
		SingletonComponent<ServerMgr>.Instance.JoinGame(connection);
	}

	public void JoinedGame(Connection connection)
	{
		RemoveConnection(connection);
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
		return false;
	}
}
