using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ConVar;
using Facepunch;
using Network;
using UnityEngine;

public static class Auth_Steam
{
	internal static List<Connection> waitingList = new List<Connection>();

	public static IEnumerator Run(Connection connection)
	{
		connection.authStatus = "";
		if (!PlatformService.Instance.BeginPlayerSession(connection.userid, connection.token))
		{
			ConnectionAuth.Reject(connection, "Steam Auth Failed");
			yield break;
		}
		waitingList.Add(connection);
		Stopwatch timeout = Stopwatch.StartNew();
		while (timeout.Elapsed.TotalSeconds < 30.0 && connection.active && !(connection.authStatus != ""))
		{
			yield return null;
		}
		waitingList.Remove(connection);
		if (connection.active)
		{
			if (connection.authStatus.Length == 0)
			{
				ConnectionAuth.Reject(connection, "Steam Auth Timeout");
				PlatformService.Instance.EndPlayerSession(connection.userid);
			}
			else if (connection.authStatus == "banned")
			{
				ConnectionAuth.Reject(connection, "Auth: " + connection.authStatus);
				PlatformService.Instance.EndPlayerSession(connection.userid);
			}
			else if (connection.authStatus == "gamebanned")
			{
				ConnectionAuth.Reject(connection, "Steam Auth: " + connection.authStatus);
				PlatformService.Instance.EndPlayerSession(connection.userid);
			}
			else if (connection.authStatus == "vacbanned")
			{
				ConnectionAuth.Reject(connection, "Steam Auth: " + connection.authStatus);
				PlatformService.Instance.EndPlayerSession(connection.userid);
			}
			else if (connection.authStatus != "ok")
			{
				ConnectionAuth.Reject(connection, "Steam Auth Failed", "Steam Auth Error: " + connection.authStatus);
				PlatformService.Instance.EndPlayerSession(connection.userid);
			}
			else
			{
				string userName = (ConVar.Server.censorplayerlist ? RandomUsernames.Get(connection.userid + (ulong)Random.Range(0, 100000)) : connection.username);
				PlatformService.Instance.UpdatePlayerSession(connection.userid, userName);
			}
		}
	}

	public static bool ValidateConnecting(ulong steamid, ulong ownerSteamID, AuthResponse response)
	{
		Connection connection = waitingList.Find((Connection x) => x.userid == steamid);
		if (connection == null)
		{
			return false;
		}
		connection.ownerid = ownerSteamID;
		if (ServerUsers.Is(ownerSteamID, ServerUsers.UserGroup.Banned) || ServerUsers.Is(steamid, ServerUsers.UserGroup.Banned))
		{
			connection.authStatus = "banned";
			return true;
		}
		switch (response)
		{
		case AuthResponse.OK:
			connection.authStatus = "ok";
			return true;
		case AuthResponse.VACBanned:
			connection.authStatus = "vacbanned";
			return true;
		case AuthResponse.PublisherBanned:
			connection.authStatus = "gamebanned";
			return true;
		case AuthResponse.TimedOut:
			connection.authStatus = "ok";
			return true;
		default:
			connection.authStatus = response.ToString();
			return true;
		}
	}
}
