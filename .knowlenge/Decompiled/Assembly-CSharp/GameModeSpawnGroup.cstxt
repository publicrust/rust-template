public class GameModeSpawnGroup : SpawnGroup
{
	public string[] gameModeTags;

	public void ResetSpawnGroup()
	{
		Clear();
		SpawnInitial();
	}

	public bool ShouldSpawn()
	{
		BaseGameMode activeGameMode = BaseGameMode.GetActiveGameMode(serverside: true);
		if (activeGameMode == null)
		{
			return false;
		}
		if (gameModeTags.Length == 0)
		{
			return true;
		}
		if (activeGameMode.HasAnyGameModeTag(gameModeTags))
		{
			return true;
		}
		return false;
	}

	protected override void Spawn(int numToSpawn)
	{
		if (ShouldSpawn())
		{
			base.Spawn(numToSpawn);
		}
	}
}
