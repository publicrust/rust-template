using System.Collections;
using Network;

public static class Auth_EAC
{
	public static IEnumerator Run(Connection connection)
	{
		if (connection.active && !connection.rejected)
		{
			connection.authStatus = string.Empty;
			EACServer.OnJoinGame(connection);
			while (connection.active && !connection.rejected && connection.authStatus == string.Empty)
			{
				yield return null;
			}
		}
	}
}
