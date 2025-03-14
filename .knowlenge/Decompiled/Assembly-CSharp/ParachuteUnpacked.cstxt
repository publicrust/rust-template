using UnityEngine;

public class ParachuteUnpacked : DecayEntity
{
	public Rigidbody targetRigidbody;

	public Transform centreOfMassRoot;

	public override void ServerInit()
	{
		base.ServerInit();
		targetRigidbody.centerOfMass = centreOfMassRoot.localPosition;
	}
}
