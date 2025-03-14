public static class FishStateExtensions
{
	public static bool Contains(this BaseFishingRod.FishState state, BaseFishingRod.FishState check)
	{
		return (state & check) == check;
	}

	public static BaseFishingRod.FishState FlipHorizontal(this BaseFishingRod.FishState state)
	{
		if (state.Contains(BaseFishingRod.FishState.PullingLeft))
		{
			state |= BaseFishingRod.FishState.PullingRight;
			state &= ~BaseFishingRod.FishState.PullingLeft;
		}
		else if (state.Contains(BaseFishingRod.FishState.PullingRight))
		{
			state |= BaseFishingRod.FishState.PullingLeft;
			state &= ~BaseFishingRod.FishState.PullingRight;
		}
		return state;
	}
}
