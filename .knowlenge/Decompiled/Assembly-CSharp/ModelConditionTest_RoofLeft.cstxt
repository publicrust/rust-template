using UnityEngine;

public class ModelConditionTest_RoofLeft : ModelConditionTest
{
	public enum AngleType
	{
		None = -1,
		Straight = 0,
		Convex60 = 60,
		Convex90 = 90,
		Convex120 = 120,
		Concave30 = -30,
		Concave60 = -60,
		Concave90 = -90,
		Concave120 = -120
	}

	public enum ShapeType
	{
		Any = -1,
		Square,
		Triangle
	}

	public AngleType angle = AngleType.None;

	public ShapeType shape = ShapeType.Any;

	private const string roof_square = "roof/";

	private const string roof_triangle = "roof.triangle/";

	private const string socket_right = "sockets/neighbour/3";

	private const string socket_left = "sockets/neighbour/4";

	private static string[] sockets_left = new string[2] { "roof/sockets/neighbour/4", "roof.triangle/sockets/neighbour/4" };

	private bool IsConvex => angle > (AngleType)10;

	private bool IsConcave => angle < (AngleType)(-10);

	protected void OnDrawGizmosSelected()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = Color.gray;
		Gizmos.DrawWireCube(new Vector3(3f, 1.5f, 0f), new Vector3(3f, 3f, 3f));
	}

	public override bool DoTest(BaseEntity ent)
	{
		BuildingBlock buildingBlock = ent as BuildingBlock;
		if (buildingBlock == null)
		{
			return false;
		}
		EntityLink entityLink = ent.FindLink(sockets_left);
		if (entityLink == null)
		{
			return false;
		}
		if (angle == AngleType.None)
		{
			for (int i = 0; i < entityLink.connections.Count; i++)
			{
				if (entityLink.connections[i].name.EndsWith("sockets/neighbour/3"))
				{
					return false;
				}
			}
			return true;
		}
		if (entityLink.IsEmpty())
		{
			return false;
		}
		bool result = false;
		for (int j = 0; j < entityLink.connections.Count; j++)
		{
			EntityLink entityLink2 = entityLink.connections[j];
			if (!entityLink2.name.EndsWith("sockets/neighbour/3") || (shape == ShapeType.Square && !entityLink2.name.StartsWith("roof/")) || (shape == ShapeType.Triangle && !entityLink2.name.StartsWith("roof.triangle/")))
			{
				continue;
			}
			BuildingBlock buildingBlock2 = entityLink2.owner as BuildingBlock;
			if (buildingBlock2 == null || buildingBlock2.grade != buildingBlock.grade)
			{
				continue;
			}
			int num = (int)angle;
			float num2 = Vector3.SignedAngle(ent.transform.forward, buildingBlock2.transform.forward, Vector3.up);
			if (num2 < (float)(num - 10))
			{
				if (IsConvex)
				{
					return false;
				}
			}
			else if (num2 > (float)(num + 10))
			{
				if (IsConvex)
				{
					return false;
				}
			}
			else
			{
				result = true;
			}
		}
		return result;
	}
}
