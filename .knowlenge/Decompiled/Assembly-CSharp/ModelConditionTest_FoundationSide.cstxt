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
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		Gizmos.matrix = ((Component)this).transform.localToWorldMatrix;
		Gizmos.color = Color.gray;
		Gizmos.DrawWireCube(new Vector3(1.5f, 1.5f, 0f), new Vector3(3f, 3f, 3f));
	}

	protected override void AttributeSetup(GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = worldRotation * Vector3.right;
		if (name.Contains("foundation.triangle"))
		{
			if (val.z < -0.9f)
			{
				socket = "foundation.triangle/sockets/foundation-top/1";
			}
			if (val.x < -0.1f)
			{
				socket = "foundation.triangle/sockets/foundation-top/2";
			}
			if (val.x > 0.1f)
			{
				socket = "foundation.triangle/sockets/foundation-top/3";
			}
			return;
		}
		if (val.z < -0.9f)
		{
			socket = "foundation/sockets/foundation-top/1";
		}
		if (val.z > 0.9f)
		{
			socket = "foundation/sockets/foundation-top/3";
		}
		if (val.x < -0.9f)
		{
			socket = "foundation/sockets/foundation-top/2";
		}
		if (val.x > 0.9f)
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
			if (!((Object)(object)buildingBlock == (Object)null) && !(buildingBlock.blockDefinition.info.name.token == "foundation_steps"))
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
