using UnityEngine;

public class ModelConditionTest_RampLow : ModelConditionTest
{
	private const string socket = "ramp/sockets/block-male/1";

	protected void OnDrawGizmosSelected()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		Gizmos.matrix = ((Component)this).transform.localToWorldMatrix;
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
