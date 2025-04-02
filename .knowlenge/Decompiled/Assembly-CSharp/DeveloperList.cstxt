using System.Linq;
using Facepunch;
using Facepunch.Models;

public static class DeveloperList
{
	public static bool Contains(string steamid)
	{
		if (Application.Manifest == null)
		{
			return false;
		}
		if (Application.Manifest.Administrators == null)
		{
			return false;
		}
		return Application.Manifest.Administrators.Any((Facepunch.Models.Manifest.Administrator x) => x.UserId == steamid);
	}

	public static bool Contains(ulong steamid)
	{
		return Contains(steamid.ToString());
	}

	public static bool IsDeveloper(BasePlayer ply)
	{
		if (ply != null)
		{
			return Contains(ply.UserIDString);
		}
		return false;
	}
}
