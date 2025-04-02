using System.Collections;
using Network;

public static class Auth_EAC
{
	public static IEnumerator Run(Connection connection)
	{
		connection.authStatusEAC = string.Empty;
		if (connection.active && !connection.rejected)
		{
			EACServer.OnJoinGame(connection);
			while (connection.active && !connection.rejected && connection.authStatusEAC == string.Empty)
			{
				yield return null;
			}
		}
	}
}
