using System.Collections.Generic;
using ConVar;
using Network;
using Oxide.Core;
using UnityEngine;

public static class ConsoleNetwork
{
	internal static void Init()
	{
	}

	internal static void OnClientCommand(Message packet)
	{
		if (packet.read.Unread > ConVar.Server.maxpacketsize_command)
		{
			Debug.LogWarning("Dropping client command due to size");
			return;
		}
		string text = packet.read.StringRaw();
		if (packet.connection == null || !packet.connection.connected)
		{
			Debug.LogWarning("Client without connection tried to run command: " + text);
		}
		else if (Interface.CallHook("OnClientCommand", packet.connection, text) == null)
		{
			string text2 = ConsoleSystem.Run(ConsoleSystem.Option.Server.FromConnection(packet.connection).Quiet(), text);
			if (!string.IsNullOrEmpty(text2))
			{
				SendClientReply(packet.connection, text2);
			}
		}
	}

	internal static void SendClientReply(Connection cn, string strCommand)
	{
		if (Network.Net.sv.IsConnected())
		{
			NetWrite netWrite = Network.Net.sv.StartWrite();
			netWrite.PacketID(Message.Type.ConsoleMessage);
			netWrite.String(strCommand);
			netWrite.Send(new SendInfo(cn));
		}
	}

	public static void SendClientCommand(Connection cn, string strCommand, params object[] args)
	{
		if (Network.Net.sv.IsConnected() && Interface.CallHook("OnSendCommand", cn, strCommand, args) == null)
		{
			NetWrite netWrite = Network.Net.sv.StartWrite();
			netWrite.PacketID(Message.Type.ConsoleCommand);
			string val = ConsoleSystem.BuildCommand(strCommand, args);
			netWrite.String(val);
			netWrite.Send(new SendInfo(cn));
		}
	}

	public static void SendClientCommand(List<Connection> cn, string strCommand, params object[] args)
	{
		if (Network.Net.sv.IsConnected() && Interface.CallHook("OnSendCommand", cn, strCommand, args) == null)
		{
			NetWrite netWrite = Network.Net.sv.StartWrite();
			netWrite.PacketID(Message.Type.ConsoleCommand);
			netWrite.String(ConsoleSystem.BuildCommand(strCommand, args));
			netWrite.Send(new SendInfo(cn));
		}
	}

	public static void BroadcastToAllClients(string strCommand, params object[] args)
	{
		if (Network.Net.sv.IsConnected() && Interface.CallHook("OnBroadcastCommand", strCommand, args) == null)
		{
			NetWrite netWrite = Network.Net.sv.StartWrite();
			netWrite.PacketID(Message.Type.ConsoleCommand);
			netWrite.String(ConsoleSystem.BuildCommand(strCommand, args));
			netWrite.Send(new SendInfo(Network.Net.sv.connections));
		}
	}
}
