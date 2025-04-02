using Facepunch;

public static class NameHelper
{
	public static string Get(ulong userId, string name, bool isClient = true, bool forceFriendly = false)
	{
		return name;
	}

	public static string Get(IPlayerInfo playerInfo, bool isClient = true)
	{
		return Get(playerInfo.UserId, playerInfo.UserName, isClient);
	}

	public static string GetPlayerNameStreamSafe(BasePlayer from, BasePlayer target)
	{
		if (from == null || target == null)
		{
			return string.Empty;
		}
		if (!from.net.connection.info.GetBool("global.streamermode"))
		{
			return target.displayName;
		}
		return RandomUsernames.Get(target.userID);
	}
}
