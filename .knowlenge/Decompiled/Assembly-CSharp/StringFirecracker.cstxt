using UnityEngine;

public class StringFirecracker : TimedExplosive
{
	public Rigidbody serverRigidBody;

	public Rigidbody clientMiddleBody;

	public Rigidbody[] clientParts;

	public SpringJoint serverClientJoint;

	public Transform clientFirecrackerTransform;

	public override void InitShared()
	{
		base.InitShared();
		if (!base.isServer)
		{
			return;
		}
		Rigidbody[] array = clientParts;
		foreach (Rigidbody val in array)
		{
			if ((Object)(object)val != (Object)null)
			{
				val.isKinematic = true;
			}
		}
	}

	public void CreatePinJoint()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)serverClientJoint != (Object)null))
		{
			serverClientJoint = ((Component)this).gameObject.AddComponent<SpringJoint>();
			((Joint)serverClientJoint).connectedBody = clientMiddleBody;
			((Joint)serverClientJoint).autoConfigureConnectedAnchor = false;
			((Joint)serverClientJoint).anchor = Vector3.zero;
			((Joint)serverClientJoint).connectedAnchor = Vector3.zero;
			serverClientJoint.minDistance = 0f;
			serverClientJoint.maxDistance = 1f;
			serverClientJoint.damper = 1000f;
			serverClientJoint.spring = 5000f;
			((Joint)serverClientJoint).enableCollision = false;
			((Joint)serverClientJoint).enablePreprocessing = false;
		}
	}
}
