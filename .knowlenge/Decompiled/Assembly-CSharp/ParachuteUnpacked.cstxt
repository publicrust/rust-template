using UnityEngine;

public class ParachuteUnpacked : DecayEntity
{
	public Rigidbody targetRigidbody;

	public Transform centreOfMassRoot;

	public override void ServerInit()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		base.ServerInit();
		targetRigidbody.centerOfMass = centreOfMassRoot.localPosition;
	}
}
