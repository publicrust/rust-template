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
		foreach (Rigidbody rigidbody in array)
		{
			if (rigidbody != null)
			{
				rigidbody.isKinematic = true;
			}
		}
	}

	public void CreatePinJoint()
	{
		if (!(serverClientJoint != null))
		{
			serverClientJoint = base.gameObject.AddComponent<SpringJoint>();
			serverClientJoint.connectedBody = clientMiddleBody;
			serverClientJoint.autoConfigureConnectedAnchor = false;
			serverClientJoint.anchor = Vector3.zero;
			serverClientJoint.connectedAnchor = Vector3.zero;
			serverClientJoint.minDistance = 0f;
			serverClientJoint.maxDistance = 1f;
			serverClientJoint.damper = 1000f;
			serverClientJoint.spring = 5000f;
			serverClientJoint.enableCollision = false;
			serverClientJoint.enablePreprocessing = false;
		}
	}
}
