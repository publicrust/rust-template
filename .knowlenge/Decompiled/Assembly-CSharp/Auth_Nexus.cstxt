using System;
using System.Collections;
using System.Threading.Tasks;
using Facepunch.Nexus;
using Facepunch.Nexus.Models;
using Network;
using UnityEngine;

public static class Auth_Nexus
{
	public static IEnumerator Run(Connection connection)
	{
		connection.authStatusNexus = string.Empty;
		if (!connection.active || connection.rejected)
		{
			yield break;
		}
		if (!NexusServer.Started)
		{
			connection.authStatusNexus = "ok";
			yield break;
		}
		Task<NexusLoginResult> loginTask = NexusServer.Login(connection.userid);
		yield return new WaitUntil(() => loginTask.IsCompleted);
		if (loginTask.IsFaulted || loginTask.IsCanceled)
		{
			Reject("Nexus login failure");
			if (loginTask.Exception != null)
			{
				Debug.LogException(loginTask.Exception);
			}
			connection.authStatusNexus = "nexus_login_fail";
			yield break;
		}
		NexusLoginResult result = loginTask.Result;
		if (result.IsRedirect)
		{
			object obj;
			if (result.AssignedZoneKey == null)
			{
				obj = null;
			}
			else
			{
				NexusZoneDetails nexusZoneDetails = NexusServer.FindZone(result.AssignedZoneKey);
				obj = ((nexusZoneDetails != null) ? NexusUtil.ConnectionProtocol(nexusZoneDetails) : null);
			}
			string text = (string)obj;
			ConsoleNetwork.SendClientCommandImmediate(connection, "nexus.redirect", result.RedirectIpAddress, result.RedirectGamePort, text ?? "");
			Reject("Redirecting to another zone...");
			connection.authStatusNexus = "nexus_login_redirect";
			yield break;
		}
		if (result.AssignedZoneKey == null)
		{
			string spawnZoneKey;
			NexusZoneDetails spawnZone;
			try
			{
				spawnZoneKey = ZoneController.Instance.ChooseSpawnZone(connection.userid, isAlreadyAssignedToThisZone: false);
				if (string.IsNullOrWhiteSpace(spawnZoneKey))
				{
					throw new Exception("ZoneController did not choose a spawn zone (returned '" + (spawnZoneKey ?? "<null>") + "')");
				}
				spawnZone = NexusServer.FindZone(spawnZoneKey);
				if (spawnZone == null)
				{
					throw new Exception("ZoneController picked a spawn zone which we don't know about (" + spawnZoneKey + ")");
				}
			}
			catch (Exception exception)
			{
				Reject("Nexus spawn - exception while choosing spawn zone");
				Debug.LogException(exception);
				connection.authStatusNexus = "nexus_zone_pick_fail";
				yield break;
			}
			Task assignTask = NexusServer.AssignInitialZone(connection.userid, spawnZoneKey);
			yield return new WaitUntil(() => assignTask.IsCompleted);
			if (assignTask.IsFaulted || assignTask.IsCanceled)
			{
				Reject("Nexus spawn - exception while registering transfer to spawn zone");
				if (assignTask.Exception != null)
				{
					Debug.LogException(assignTask.Exception);
				}
				connection.authStatusNexus = "nexus_zone_transfer_fail";
				yield break;
			}
			if (spawnZoneKey != NexusServer.ZoneKey)
			{
				ConsoleNetwork.SendClientCommandImmediate(connection, "nexus.redirect", spawnZone.IpAddress, spawnZone.GamePort, NexusUtil.ConnectionProtocol(spawnZone));
				Reject("Redirecting to another zone...");
				connection.authStatusNexus = "nexus_zone_redirect";
				yield break;
			}
		}
		if (NexusServer.TryGetPlayer(connection.userid, out var player))
		{
			if (!player.TryGetVariable("appKey", out var variable) || variable.Type != VariableType.String || string.IsNullOrWhiteSpace(variable.GetAsString()))
			{
				player.SetVariable("appKey", Guid.NewGuid().ToString("N"), isTransient: false, isSecret: false);
			}
		}
		else
		{
			Debug.LogWarning($"Couldn't find NexusPlayer for {connection.userid}, skipping setting up their app key");
		}
		connection.authStatusNexus = "ok";
		void Reject(string reason)
		{
			ConnectionAuth.Reject(connection, reason);
			PlatformService.Instance.EndPlayerSession(connection.userid);
		}
	}
}
