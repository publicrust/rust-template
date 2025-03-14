public class ModelConditionTest_Wall : ModelConditionTest
{
	public override bool DoTest(BaseEntity ent)
	{
		if (!ModelConditionTest_WallTriangleLeft.CheckCondition(ent))
		{
			return !ModelConditionTest_WallTriangleRight.CheckCondition(ent);
		}
		return false;
	}
}
