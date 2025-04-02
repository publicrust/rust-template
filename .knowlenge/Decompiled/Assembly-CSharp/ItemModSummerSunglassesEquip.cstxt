using ConVar;

public class ItemModSummerSunglassesEquip : ItemMod
{
	public float SunsetTime;

	public float SunriseTime;

	public string AchivementName;

	public override void DoAction(Item item, BasePlayer player)
	{
		base.DoAction(item, player);
		if (player != null && !string.IsNullOrEmpty(AchivementName) && player.inventory.containerWear.FindItemByUID(item.uid) != null)
		{
			float time = Env.time;
			if (time < SunriseTime || time > SunsetTime)
			{
				player.GiveAchievement(AchivementName);
			}
		}
	}
}
