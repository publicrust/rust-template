using System;
using UnityEngine;

public class DiveSiteBuoy : BaseEntity
{
	public float UpdateCullRange = 128f;

	public Vector3 RotationRate;

	public float InitialSpawnRange = 32f;

	private Action _updateAction;

	private Action updateAction => _updateAction ?? new Action(UpdateMovement);

	public override void ServerInit()
	{
		base.ServerInit();
		if (!BaseNetworkable.HasCloseConnections(base.transform.position, InitialSpawnRange))
		{
			UpdateMovement();
		}
		InvokeRandomized(CheckForNearbyPlayers, 0f, 10f, 5f);
	}

	private void CheckForNearbyPlayers()
	{
		bool flag = BaseNetworkable.HasCloseConnections(base.transform.position, UpdateCullRange);
		if (flag && !IsInvoking(updateAction))
		{
			InvokeRepeating(updateAction, 0f, 0f);
		}
		else if (!flag && IsInvoking(updateAction))
		{
			CancelInvoke(updateAction);
		}
	}

	private void UpdateMovement()
	{
		Vector3 position = base.transform.position;
		Quaternion rotation = base.transform.rotation;
		position.y = WaterLevel.GetWaterSurface(position, waves: true, volumes: false) + Mathf.Sin(Time.time * 3f) * 0.075f;
		rotation *= Quaternion.Euler(RotationRate * Time.deltaTime);
		base.transform.SetPositionAndRotation(position, rotation);
	}
}
