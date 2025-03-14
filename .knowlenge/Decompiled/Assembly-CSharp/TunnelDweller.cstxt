using Rust;

public class TunnelDweller : HumanNPC
{
	public static readonly Translate.Phrase TunnelDwellerName = new Translate.Phrase("npc_tunneldweller", "Tunnel Dweller");

	private const string DWELLER_KILL_STAT = "dweller_kills_while_moving";

	public override string displayName => TunnelDwellerName.translated;

	protected override void OnKilledByPlayer(BasePlayer p)
	{
		base.OnKilledByPlayer(p);
		if (Rust.GameInfo.HasAchievements && p.GetParentEntity() != null && p.GetParentEntity() is TrainEngine { CurThrottleSetting: not TrainEngine.EngineSpeeds.Zero, IsMovingOrOn: not false })
		{
			p.stats.Add("dweller_kills_while_moving", 1, Stats.All);
			p.stats.Save(forceSteamSave: true);
		}
	}
}
