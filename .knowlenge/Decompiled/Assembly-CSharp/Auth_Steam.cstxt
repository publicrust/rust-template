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
		connection.authStatusSteam = string.Empty;
		if (!connection.active || connection.rejected)
		{
			yield break;
		}
		if (!PlatformService.Instance.BeginPlayerSession(connection.userid, connection.token))
		{
			ConnectionAuth.Reject(connection, "Steam Auth Failed");
			yield break;
		}
		waitingList.Add(connection);
		Stopwatch timeout = Stopwatch.StartNew();
		while (timeout.Elapsed.TotalSeconds < 30.0 && connection.active && !(connection.authStatusSteam != string.Empty))
		{
			yield return null;
		}
		waitingList.Remove(connection);
		if (connection.active)
		{
			if (connection.authStatusSteam.Length == 0)
			{
				ConnectionAuth.Reject(connection, "Steam Auth Timeout: No auth response");
				PlatformService.Instance.EndPlayerSession(connection.userid);
			}
			else if (connection.authStatusSteam == "banned")
			{
				ConnectionAuth.Reject(connection, "Steam Auth: " + connection.authStatusSteam);
				PlatformService.Instance.EndPlayerSession(connection.userid);
			}
			else if (connection.authStatusSteam == "gamebanned")
			{
				ConnectionAuth.Reject(connection, "Steam Auth: " + connection.authStatusSteam);
				PlatformService.Instance.EndPlayerSession(connection.userid);
			}
			else if (connection.authStatusSteam == "vacbanned")
			{
				ConnectionAuth.Reject(connection, "Steam Auth: " + connection.authStatusSteam);
				PlatformService.Instance.EndPlayerSession(connection.userid);
			}
			else if (connection.authStatusSteam != "ok")
			{
				ConnectionAuth.Reject(connection, "Steam Auth Failed", "Steam Auth Error: " + connection.authStatusSteam);
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
			connection.authStatusSteam = "banned";
			return true;
		}
		switch (response)
		{
		case AuthResponse.OK:
			connection.authStatusSteam = "ok";
			return true;
		case AuthResponse.VACBanned:
			connection.authStatusSteam = "vacbanned";
			return true;
		case AuthResponse.PublisherBanned:
			connection.authStatusSteam = "gamebanned";
			return true;
		default:
			if (!ConVar.Server.strictauth_steam && response == AuthResponse.TimedOut)
			{
				UnityEngine.Debug.LogWarning("Steam Auth Timeout: AuthResponse.TimedOut for " + steamid + " / " + ownerSteamID + " - bypassing since strictauth_steam is false");
				connection.authStatusSteam = "ok";
				return true;
			}
			connection.authStatusSteam = response.ToString();
			return true;
		}
	}
}
