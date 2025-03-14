using System.Collections.Generic;
using Facepunch;
using Network;

public struct RpcTarget
{
	public string Function;

	public SendInfo Connections;

	public bool ToNetworkGroup;

	public bool UsingPooledConnections;

	public static RpcTarget NetworkGroup(string funcName)
	{
		RpcTarget result = default(RpcTarget);
		result.Function = funcName;
		result.ToNetworkGroup = true;
		return result;
	}

	public static RpcTarget NetworkGroup(string funcName, BaseNetworkable entity)
	{
		RpcTarget result = default(RpcTarget);
		result.Function = funcName;
		result.Connections = new SendInfo(entity.net.group.subscribers);
		return result;
	}

	public static RpcTarget NetworkGroup(string funcName, BaseNetworkable entity, SendMethod method, Priority priority)
	{
		RpcTarget result = default(RpcTarget);
		result.Function = funcName;
		result.Connections = new SendInfo(entity.net.group.subscribers)
		{
			method = method,
			priority = priority
		};
		return result;
	}

	public static RpcTarget Player(string funcName, BasePlayer target)
	{
		return Player(funcName, target.IsValid() ? target.net.connection : null);
	}

	public static RpcTarget Player(string funcName, Connection connection)
	{
		RpcTarget result = default(RpcTarget);
		result.Function = funcName;
		result.Connections = new SendInfo(connection);
		return result;
	}

	public static RpcTarget Players(string funcName, List<Connection> connections)
	{
		RpcTarget result = default(RpcTarget);
		result.Function = funcName;
		result.Connections = new SendInfo(connections);
		return result;
	}

	public static RpcTarget Players(string funcName, List<Connection> connections, SendMethod method, Priority priority)
	{
		RpcTarget result = default(RpcTarget);
		result.Function = funcName;
		result.Connections = new SendInfo(connections)
		{
			method = method,
			priority = priority
		};
		return result;
	}

	public static RpcTarget SendInfo(string funcName, SendInfo sendInfo)
	{
		RpcTarget result = default(RpcTarget);
		result.Function = funcName;
		result.Connections = sendInfo;
		return result;
	}

	public static RpcTarget PlayerAndSpectators(string funcName, BasePlayer player)
	{
		List<Connection> list = Pool.Get<List<Connection>>();
		if (player.IsValid())
		{
			if (player.net.connection != null)
			{
				list.Add(player.net.connection);
			}
			if (player.IsBeingSpectated && player.children != null)
			{
				foreach (BaseEntity child in player.children)
				{
					if (child is BasePlayer basePlayer)
					{
						list.Add(basePlayer.net.connection);
					}
				}
			}
		}
		RpcTarget result = default(RpcTarget);
		result.Function = funcName;
		result.Connections = new SendInfo(list);
		result.UsingPooledConnections = true;
		return result;
	}
}
