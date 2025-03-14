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
			return;
		}
		string text2 = ConsoleSystem.Run(ConsoleSystem.Option.Server.FromConnection(packet.connection).Quiet(), text);
		if (!string.IsNullOrEmpty(text2))
		{
			SendClientReply(packet.connection, text2);
		}
	}

	internal static void SendClientReply(Connection cn, string strCommand)
	{
		if (Network.Net.sv.IsConnected())
		{
			Network.Net.sv.write.Start();
			Network.Net.sv.write.PacketID(Message.Type.ConsoleMessage);
			Network.Net.sv.write.String(strCommand);
			Network.Net.sv.write.Send(new SendInfo(cn));
		}
	}

	public static void SendClientCommand(Connection cn, string strCommand, params object[] args)
	{
		if (Network.Net.sv.IsConnected())
		{
			Interface.CallHook("OnSendCommand", cn, strCommand, args);
			Network.Net.sv.write.Start();
			Network.Net.sv.write.PacketID(Message.Type.ConsoleCommand);
			Network.Net.sv.write.String(ConsoleSystem.BuildCommand(strCommand, args));
			Network.Net.sv.write.Send(new SendInfo(cn));
		}
	}

	public static void SendClientCommand(List<Connection> cn, string strCommand, params object[] args)
	{
		if (Network.Net.sv.IsConnected())
		{
			Interface.CallHook("OnSendCommand", cn, strCommand, args);
			Network.Net.sv.write.Start();
			Network.Net.sv.write.PacketID(Message.Type.ConsoleCommand);
			Network.Net.sv.write.String(ConsoleSystem.BuildCommand(strCommand, args));
			Network.Net.sv.write.Send(new SendInfo(cn));
		}
	}

	public static void BroadcastToAllClients(string strCommand, params object[] args)
	{
		if (Network.Net.sv.IsConnected())
		{
			Interface.CallHook("OnBroadcastCommand", strCommand, args);
			Network.Net.sv.write.Start();
			Network.Net.sv.write.PacketID(Message.Type.ConsoleCommand);
			Network.Net.sv.write.String(ConsoleSystem.BuildCommand(strCommand, args));
			Network.Net.sv.write.Send(new SendInfo(Network.Net.sv.connections));
		}
	}
}
