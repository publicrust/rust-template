using UnityEngine;

public class ModelConditionTest_FoundationSide : ModelConditionTest
{
	private const string square_south = "foundation/sockets/foundation-top/1";

	private const string square_north = "foundation/sockets/foundation-top/3";

	private const string square_west = "foundation/sockets/foundation-top/2";

	private const string square_east = "foundation/sockets/foundation-top/4";

	private const string triangle_south = "foundation.triangle/sockets/foundation-top/1";

	private const string triangle_northwest = "foundation.triangle/sockets/foundation-top/2";

	private const string triangle_northeast = "foundation.triangle/sockets/foundation-top/3";

	private string socket = string.Empty;

	protected void OnDrawGizmosSelected()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = Color.gray;
		Gizmos.DrawWireCube(new Vector3(1.5f, 1.5f, 0f), new Vector3(3f, 3f, 3f));
	}

	protected override void AttributeSetup(GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		Vector3 vector = worldRotation * Vector3.right;
		if (name.Contains("foundation.triangle"))
		{
			if (vector.z < -0.9f)
			{
				socket = "foundation.triangle/sockets/foundation-top/1";
			}
			if (vector.x < -0.1f)
			{
				socket = "foundation.triangle/sockets/foundation-top/2";
			}
			if (vector.x > 0.1f)
			{
				socket = "foundation.triangle/sockets/foundation-top/3";
			}
			return;
		}
		if (vector.z < -0.9f)
		{
			socket = "foundation/sockets/foundation-top/1";
		}
		if (vector.z > 0.9f)
		{
			socket = "foundation/sockets/foundation-top/3";
		}
		if (vector.x < -0.9f)
		{
			socket = "foundation/sockets/foundation-top/2";
		}
		if (vector.x > 0.9f)
		{
			socket = "foundation/sockets/foundation-top/4";
		}
	}

	public override bool DoTest(BaseEntity ent)
	{
		EntityLink entityLink = ent.FindLink(socket);
		if (entityLink == null)
		{
			return false;
		}
		for (int i = 0; i < entityLink.connections.Count; i++)
		{
			BuildingBlock buildingBlock = entityLink.connections[i].owner as BuildingBlock;
			if (!(buildingBlock == null) && !(buildingBlock.blockDefinition.info.name.token == "foundation_steps"))
			{
				if (buildingBlock.grade == BuildingGrade.Enum.TopTier)
				{
					return false;
				}
				if (buildingBlock.grade == BuildingGrade.Enum.Metal)
				{
					return false;
				}
				if (buildingBlock.grade == BuildingGrade.Enum.Stone)
				{
					return false;
				}
			}
		}
		return true;
	}
}
