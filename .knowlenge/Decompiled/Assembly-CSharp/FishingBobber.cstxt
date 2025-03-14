using UnityEngine;

public class FishingBobber : BaseCombatEntity
{
	public Transform centerOfMass;

	public Rigidbody myRigidBody;

	public override void ServerInit()
	{
		myRigidBody.centerOfMass = centerOfMass.localPosition;
		base.ServerInit();
	}
}
