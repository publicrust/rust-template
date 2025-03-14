public class HumanBodyResourceDispenser : ResourceDispenser
{
	public override bool OverrideOwnership(Item item, AttackEntity weapon)
	{
		if (item.info.shortname == "skull.human")
		{
			PlayerCorpse component = GetComponent<PlayerCorpse>();
			if ((bool)component)
			{
				item.name = "Skull of \"" + component.playerName + "\"";
				return true;
			}
		}
		return false;
	}
}
