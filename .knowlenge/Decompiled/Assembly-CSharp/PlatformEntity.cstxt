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
		if (!base.isClient)
		{
			if (targetPosition == Vector3.zero || Vector3.Distance(base.transform.position, targetPosition) < 0.01f)
			{
				Vector2 vector = Random.insideUnitCircle * 10f;
				targetPosition = base.transform.position + new Vector3(vector.x, 0f, vector.y);
				targetPosition.y = WaterLevel.GetWaterOrTerrainSurface(targetPosition, waves: false, volumes: false) + 1f;
				targetRotation = Quaternion.LookRotation(targetPosition - base.transform.position);
			}
			base.transform.SetPositionAndRotation(Vector3.MoveTowards(base.transform.position, targetPosition, Time.fixedDeltaTime * 1f), Quaternion.RotateTowards(base.transform.rotation, targetRotation, Time.fixedDeltaTime * 10f));
		}
	}

	public override float GetNetworkTime()
	{
		return Time.fixedTime;
	}
}
