public class ModelConditionTest_Outside : ModelConditionTest
{
	public override bool DoTest(BaseEntity ent)
	{
		return CheckCondition(ent);
	}

	public static bool CheckCondition(BaseEntity ent)
	{
		return ent.IsOutside(ent.WorldSpaceBounds().GetPoint(0f, 1f, 0f));
	}
}
