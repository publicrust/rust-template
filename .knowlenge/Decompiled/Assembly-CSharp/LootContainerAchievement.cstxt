public class LootContainerAchievement : LootContainer
{
	public string AchievementName = string.Empty;

	public bool AllowDuringTutorial;

	public override bool OnStartBeingLooted(BasePlayer baseEntity)
	{
		if (!string.IsNullOrEmpty(AchievementName))
		{
			baseEntity.GiveAchievement(AchievementName, AllowDuringTutorial);
		}
		return base.OnStartBeingLooted(baseEntity);
	}
}
