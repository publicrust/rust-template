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
		yield return (object)new WaitUntil((Func<bool>)(() => loginTask.IsCompleted));
		if (loginTask.IsFaulted || loginTask.IsCanceled)
		{
			Reject("Nexus login failure");
			if (loginTask.Exception != null)
			{
				Debug.LogException((Exception)loginTask.Exception);
			}
			connection.authStatusNexus = "nexus_login_fail";
			yield break;
		}
		NexusLoginResult result = loginTask.Result;
		if (((NexusLoginResult)(ref result)).IsRedirect)
		{
			string text = ((((NexusLoginResult)(ref result)).AssignedZoneKey == null) ? null : NexusServer.FindZone(((NexusLoginResult)(ref result)).AssignedZoneKey)?.ConnectionProtocol());
			ConsoleNetwork.SendClientCommandImmediate(connection, "nexus.redirect", ((NexusLoginResult)(ref result)).RedirectIpAddress, ((NexusLoginResult)(ref result)).RedirectGamePort, text ?? "");
			Reject("Redirecting to another zone...");
			connection.authStatusNexus = "nexus_login_redirect";
			yield break;
		}
		if (((NexusLoginResult)(ref result)).AssignedZoneKey == null)
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
			catch (Exception ex)
			{
				Reject("Nexus spawn - exception while choosing spawn zone");
				Debug.LogException(ex);
				connection.authStatusNexus = "nexus_zone_pick_fail";
				yield break;
			}
			Task assignTask = NexusServer.AssignInitialZone(connection.userid, spawnZoneKey);
			yield return (object)new WaitUntil((Func<bool>)(() => assignTask.IsCompleted));
			if (assignTask.IsFaulted || assignTask.IsCanceled)
			{
				Reject("Nexus spawn - exception while registering transfer to spawn zone");
				if (assignTask.Exception != null)
				{
					Debug.LogException((Exception)assignTask.Exception);
				}
				connection.authStatusNexus = "nexus_zone_transfer_fail";
				yield break;
			}
			if (spawnZoneKey != NexusServer.ZoneKey)
			{
				ConsoleNetwork.SendClientCommandImmediate(connection, "nexus.redirect", spawnZone.IpAddress, spawnZone.GamePort, spawnZone.ConnectionProtocol());
				Reject("Redirecting to another zone...");
				connection.authStatusNexus = "nexus_zone_redirect";
				yield break;
			}
		}
		if (NexusServer.TryGetPlayer(connection.userid, out var player))
		{
			Variable val = default(Variable);
			if (!player.TryGetVariable("appKey", ref val) || (int)val.Type != 1 || string.IsNullOrWhiteSpace(val.GetAsString()))
			{
				player.SetVariable("appKey", Guid.NewGuid().ToString("N"), false, false);
			}
		}
		else
		{
			Debug.LogWarning((object)$"Couldn't find NexusPlayer for {connection.userid}, skipping setting up their app key");
		}
		connection.authStatusNexus = "ok";
		void Reject(string reason)
		{
			ConnectionAuth.Reject(connection, reason);
			PlatformService.Instance.EndPlayerSession(connection.userid);
		}
	}
}
