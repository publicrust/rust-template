public static class ServerBrowserEx
{
	public static string GetPingString(this ServerInfo server)
	{
		if (((ServerInfo)(ref server)).Ping != int.MaxValue)
		{
			return ((ServerInfo)(ref server)).Ping.ToString();
		}
		return "?";
	}
}
