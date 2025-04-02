using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Underwear")]
public class Underwear : ScriptableObject
{
	public string shortname = "";

	public Phrase displayName;

	public Sprite icon;

	public Sprite iconFemale;

	public SkinReplacement[] replacementsMale;

	public SkinReplacement[] replacementsFemale;

	[Tooltip("User can craft this item on any server if they have this steam item")]
	public SteamInventoryItem steamItem;

	[Tooltip("User can craft this item if they have this DLC purchased")]
	public SteamDLCItem steamDLC;

	public bool adminOnly;

	public uint GetID()
	{
		return StringPool.Get(shortname);
	}

	public bool HasMaleParts()
	{
		return replacementsMale.Length != 0;
	}

	public bool HasFemaleParts()
	{
		return replacementsFemale.Length != 0;
	}

	public bool ValidForPlayer(BasePlayer player)
	{
		if (HasMaleParts() && HasFemaleParts())
		{
			return true;
		}
		bool flag = IsFemale(player);
		if (flag && HasFemaleParts())
		{
			return true;
		}
		if (!flag && HasMaleParts())
		{
			return true;
		}
		return false;
	}

	public static bool IsFemale(BasePlayer player)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		ulong num = player.userID.Get();
		long num2 = 4332L;
		State state = Random.state;
		Random.InitState((int)(num2 + (long)num));
		float num3 = Random.Range(0f, 1f);
		Random.state = state;
		if (!(num3 > 0.5f))
		{
			return false;
		}
		return true;
	}

	public static bool Validate(Underwear underwear, BasePlayer player)
	{
		if ((Object)(object)underwear == (Object)null)
		{
			return true;
		}
		if (!underwear.ValidForPlayer(player))
		{
			return false;
		}
		if (underwear.adminOnly && (!player.IsAdmin || !player.IsDeveloper))
		{
			return false;
		}
		bool num = (Object)(object)underwear.steamItem == (Object)null || player.blueprints.steamInventory.HasItem(underwear.steamItem.id);
		bool flag = false;
		if (player.isServer && ((Object)(object)underwear.steamDLC == (Object)null || underwear.steamDLC.HasLicense(player.userID)))
		{
			flag = true;
		}
		return num && flag;
	}
}
