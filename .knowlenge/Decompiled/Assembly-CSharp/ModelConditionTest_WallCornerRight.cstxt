using UnityEngine;

public class ModelConditionTest_WallCornerRight : ModelConditionTest
{
	private const string socket = "sockets/stability/1";

	private static string[] sockets = new string[5] { "wall/sockets/stability/1", "wall.half/sockets/stability/1", "wall.low/sockets/stability/1", "wall.doorway/sockets/stability/1", "wall.window/sockets/stability/1" };

	public override bool DoTest(BaseEntity ent)
	{
		EntityLink entityLink = ent.FindLink(sockets);
		if (entityLink == null)
		{
			return false;
		}
		BuildingBlock buildingBlock = ent as BuildingBlock;
		if (buildingBlock == null)
		{
			return false;
		}
		bool result = false;
		for (int i = 0; i < entityLink.connections.Count; i++)
		{
			EntityLink entityLink2 = entityLink.connections[i];
			BuildingBlock buildingBlock2 = entityLink2.owner as BuildingBlock;
			if (buildingBlock2 == null)
			{
				continue;
			}
			float num = Vector3.SignedAngle(ent.transform.forward, buildingBlock2.transform.forward, Vector3.up);
			if (entityLink2.name.EndsWith("sockets/stability/1"))
			{
				if (num < 10f || num > 100f)
				{
					return false;
				}
				continue;
			}
			if (num < 10f && num > -10f)
			{
				return false;
			}
			if (num > 10f)
			{
				return false;
			}
			if (buildingBlock2.grade == buildingBlock.grade)
			{
				result = true;
			}
		}
		return result;
	}
}
