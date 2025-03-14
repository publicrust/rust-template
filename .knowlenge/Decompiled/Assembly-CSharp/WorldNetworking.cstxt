using System.Collections.Generic;
using Facepunch;
using Network;
using ProtoBuf;
using UnityEngine;

public class WorldNetworking
{
	private const int prefabsPerPacket = 100;

	private const int pathsPerPacket = 10;

	public static void OnMessageReceived(Message message)
	{
		WorldSerialization serialization = World.Serialization;
		using WorldMessage worldMessage = WorldMessage.Deserialize(message.read);
		switch (worldMessage.status)
		{
		case WorldMessage.MessageType.Request:
			SendWorldData(message.connection);
			return;
		}
		if (worldMessage.prefabs != null)
		{
			serialization.world.prefabs.AddRange(worldMessage.prefabs);
			worldMessage.prefabs.Clear();
		}
		if (worldMessage.paths != null)
		{
			serialization.world.paths.AddRange(worldMessage.paths);
			worldMessage.paths.Clear();
		}
	}

	private static void SendWorldData(Connection connection)
	{
		if (connection.hasRequestedWorld)
		{
			DebugEx.LogWarning($"{connection} requested world data more than once");
			return;
		}
		connection.hasRequestedWorld = true;
		WorldSerialization serialization = World.Serialization;
		WorldMessage data = Pool.Get<WorldMessage>();
		for (int i = 0; i < serialization.world.prefabs.Count; i++)
		{
			if (data.prefabs != null && data.prefabs.Count >= 100)
			{
				data.status = WorldMessage.MessageType.Receive;
				SendWorldData(connection, ref data);
				data = Pool.Get<WorldMessage>();
			}
			if (data.prefabs == null)
			{
				data.prefabs = Pool.Get<List<PrefabData>>();
			}
			data.prefabs.Add(serialization.world.prefabs[i]);
		}
		for (int j = 0; j < serialization.world.paths.Count; j++)
		{
			if (data.paths != null && data.paths.Count >= 10)
			{
				data.status = WorldMessage.MessageType.Receive;
				SendWorldData(connection, ref data);
				data = Pool.Get<WorldMessage>();
			}
			if (data.paths == null)
			{
				data.paths = Pool.Get<List<PathData>>();
			}
			data.paths.Add(serialization.world.paths[j]);
		}
		if (data != null)
		{
			data.status = WorldMessage.MessageType.Done;
			SendWorldData(connection, ref data);
		}
	}

	private static void SendWorldData(Connection connection, ref WorldMessage data)
	{
		NetWrite netWrite = Net.sv.StartWrite();
		netWrite.PacketID(Message.Type.World);
		data.ToProto(netWrite);
		netWrite.Send(new SendInfo(connection));
		if (data.prefabs != null)
		{
			data.prefabs.Clear();
		}
		if (data.paths != null)
		{
			data.paths.Clear();
		}
		data.Dispose();
		data = null;
	}
}
