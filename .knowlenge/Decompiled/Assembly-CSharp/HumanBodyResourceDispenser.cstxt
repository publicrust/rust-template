using UnityEngine;

public class HumanBodyResourceDispenser : ResourceDispenser
{
	public override bool OverrideOwnership(Item item, AttackEntity weapon)
	{
		if (item.info.shortname == "skull.human")
		{
			PlayerCorpse component = ((Component)this).GetComponent<PlayerCorpse>();
			if (Object.op_Implicit((Object)(object)component))
			{
				item.name = CreateSkullName(component.playerName);
				item.streamerName = CreateSkullName(component.streamerName);
				return true;
			}
		}
		return false;
	}

	public static string CreateSkullName(string playerName)
	{
		return "Skull of \"" + playerName + "\"";
	}
}
