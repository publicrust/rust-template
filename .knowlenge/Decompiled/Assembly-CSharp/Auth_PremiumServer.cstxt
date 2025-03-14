using System.Collections;
using System.Threading.Tasks;
using ConVar;
using Network;
using UnityEngine;

public static class Auth_PremiumServer
{
	public static IEnumerator Run(Connection connection)
	{
		connection.authStatusPremiumServer = string.Empty;
		if (!connection.active || connection.rejected)
		{
			yield break;
		}
		if (!ConVar.Server.premium)
		{
			connection.authStatusPremiumServer = "ok";
			yield break;
		}
		Task<PremiumUtil.PremiumCheckResult> checkTask = PremiumUtil.CheckIfPlayerIsPremium(connection.userid);
		yield return new WaitUntil(() => checkTask.IsCompleted);
		if (checkTask.IsFaulted || checkTask.IsCanceled)
		{
			Reject(connection, "Failed to validate premium status: Faulted/Canceled");
			if (checkTask.Exception != null)
			{
				Debug.LogException(checkTask.Exception);
			}
			connection.authStatusNexus = "premium_error";
		}
		else if (!checkTask.Result.IsPremium)
		{
			Reject(connection, checkTask.Result.FailReason ?? "Failed to validate premium status: Unknown Fail Reason");
			connection.authStatusPremiumServer = "account_not_premium";
		}
		else
		{
			connection.authStatusPremiumServer = "ok";
			connection.lastPremiumCheckTime = UnityEngine.Time.realtimeSinceStartupAsDouble;
		}
	}

	private static void Reject(Connection connection, string reason)
	{
		ConnectionAuth.Reject(connection, reason);
		PlatformService.Instance.EndPlayerSession(connection.userid);
	}
}
