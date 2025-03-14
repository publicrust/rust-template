using UnityEngine;

public class ModelConditionTest_RampLow : ModelConditionTest
{
	private const string socket = "ramp/sockets/block-male/1";

	protected void OnDrawGizmosSelected()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = Color.gray;
		Gizmos.DrawWireCube(new Vector3(0f, 0.375f, 0f), new Vector3(3f, 0.75f, 3f));
	}

	public override bool DoTest(BaseEntity ent)
	{
		EntityLink entityLink = ent.FindLink("ramp/sockets/block-male/1");
		if (entityLink == null)
		{
			return false;
		}
		return !entityLink.IsEmpty();
	}
}
