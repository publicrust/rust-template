public class ModelConditionTest_Outside : ModelConditionTest
{
	public override bool DoTest(BaseEntity ent)
	{
		return CheckCondition(ent);
	}

	public static bool CheckCondition(BaseEntity ent)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		OBB val = ent.WorldSpaceBounds();
		return ent.IsOutside(((OBB)(ref val)).GetPoint(0f, 1f, 0f));
	}
}
