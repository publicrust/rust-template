using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Steam DLC Item")]
public class SteamDLCItem : ScriptableObject
{
	public int id;

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
}
