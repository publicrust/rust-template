public class ModelConditionTest_Variant : ModelConditionTest
{
	public ulong VariantSeed;

	public ulong VariantIndex;

	public ulong VariantCount = 3uL;

	public override bool DoTest(BaseEntity ent)
	{
		ulong x = ent.net.ID.Value + VariantSeed;
		SeedRandom.Wanghash(ref x);
		SeedRandom.Wanghash(ref x);
		SeedRandom.Wanghash(ref x);
		return x % VariantCount == VariantIndex;
	}
}
