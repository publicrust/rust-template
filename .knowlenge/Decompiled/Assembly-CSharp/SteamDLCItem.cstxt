using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Steam DLC Item")]
public class SteamDLCItem : ScriptableObject
{
	public Translate.Phrase dlcName;

	public int dlcAppID;

	public bool bypassLicenseCheck;

	public bool HasLicense(ulong steamid)
	{
		if (bypassLicenseCheck)
		{
			return true;
		}
		if (!PlatformService.Instance.IsValid)
		{
			return false;
		}
		return PlatformService.Instance.PlayerOwnsDownloadableContent(steamid, dlcAppID);
	}

	public bool CanUse(BasePlayer player)
	{
		if (player.isServer)
		{
			if (!HasLicense(player.userID))
			{
				return (ulong)player.userID < 10000000;
			}
			return true;
		}
		return false;
	}
}
