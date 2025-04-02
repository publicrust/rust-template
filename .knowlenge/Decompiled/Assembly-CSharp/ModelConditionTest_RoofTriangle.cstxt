public class ModelConditionTest_RoofTriangle : ModelConditionTest
{
	private const string socket = "roof/sockets/wall-female";

	public override bool DoTest(BaseEntity ent)
	{
		EntityLink entityLink = ent.FindLink("roof/sockets/wall-female");
		if (entityLink == null)
		{
			return true;
		}
		if (!entityLink.IsEmpty())
		{
			return false;
		}
		return true;
	}
}
