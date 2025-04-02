using UnityEngine;

public class PlatformEntity : BaseEntity
{
	private const float movementSpeed = 1f;

	private const float rotationSpeed = 10f;

	private const float radius = 10f;

	private Vector3 targetPosition = Vector3.zero;

	private Quaternion targetRotation = Quaternion.identity;

	protected void FixedUpdate()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		if (!base.isClient)
		{
			if (targetPosition == Vector3.zero || Vector3.Distance(((Component)this).transform.position, targetPosition) < 0.01f)
			{
				Vector2 val = Random.insideUnitCircle * 10f;
				targetPosition = ((Component)this).transform.position + new Vector3(val.x, 0f, val.y);
				targetPosition.y = WaterLevel.GetWaterOrTerrainSurface(targetPosition, waves: false, volumes: false) + 1f;
				targetRotation = Quaternion.LookRotation(targetPosition - ((Component)this).transform.position);
			}
			((Component)this).transform.SetPositionAndRotation(Vector3.MoveTowards(((Component)this).transform.position, targetPosition, Time.fixedDeltaTime * 1f), Quaternion.RotateTowards(((Component)this).transform.rotation, targetRotation, Time.fixedDeltaTime * 10f));
		}
	}

	public override float GetNetworkTime()
	{
		return Time.fixedTime;
	}
}
