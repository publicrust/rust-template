using Facepunch.Rust;

public class HalloweenHunt : EggHuntEvent
{
	public static Translate.Phrase topCreepPhrase = new Translate.Phrase("candyhunt.result.topcreeps", "{0} is the top creep with {1} candies collected.");

	public static Translate.Phrase placeCreepPhrase = new Translate.Phrase("candyhunt.result.place", "You placed {0} of {1} with {2} candies collected.");

	protected override Translate.Phrase GetTopBunnyPhrase()
	{
		return topCreepPhrase;
	}

	protected override Translate.Phrase GetPlacePhrase()
	{
		return placeCreepPhrase;
	}

	protected override void ReportPlayerParticipated(int topCount)
	{
		Analytics.Server.ReportPlayersParticipatedInHalloweenEvent(topCount);
	}

	protected override void ReportEggsCollected(int numEggs)
	{
		Analytics.Server.ReportCandiesCollectedByPlayer(numEggs);
	}
}
