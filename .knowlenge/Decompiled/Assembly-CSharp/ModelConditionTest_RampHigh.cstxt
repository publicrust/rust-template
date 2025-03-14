using UnityEngine;

public class ModelConditionTest_RampHigh : ModelConditionTest
{
	private const string socket = "ramp/sockets/block-male/1";

	protected void OnDrawGizmosSelected()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = Color.gray;
		Gizmos.DrawWireCube(new Vector3(0f, 0.75f, 0f), new Vector3(3f, 1.5f, 3f));
	}

	public override bool DoTest(BaseEntity ent)
	{
		return ent.FindLink("ramp/sockets/block-male/1")?.IsEmpty() ?? false;
	}
}
