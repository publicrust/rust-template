public class ModelConditionTest_Variant : ModelConditionTest
{
	public ulong VariantSeed;

	public ulong VariantIndex;

	public ulong VariantCount = 3uL;

	public override bool DoTest(BaseEntity ent)
	{
		ulong num = ent.net.ID.Value + VariantSeed;
		SeedRandom.Wanghash(ref num);
		SeedRandom.Wanghash(ref num);
		SeedRandom.Wanghash(ref num);
		return num % VariantCount == VariantIndex;
	}
}
