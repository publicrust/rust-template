public class NPCPlayerCorpse : PlayerCorpse
{
	private bool lootEnabled;

	public override float GetRemovalTime()
	{
		return 600f;
	}

	public override bool CanLoot()
	{
		return lootEnabled;
	}

	public void SetLootableIn(float when)
	{
		Invoke(EnableLooting, when);
	}

	public void EnableLooting()
	{
		lootEnabled = true;
	}
}
