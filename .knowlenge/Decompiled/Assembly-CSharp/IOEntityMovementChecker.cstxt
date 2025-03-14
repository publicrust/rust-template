using UnityEngine;

[RequireComponent(typeof(IOEntity))]
public class IOEntityMovementChecker : FacepunchBehaviour
{
	private IOEntity ioEntity;

	private Vector3 prevPos;

	private const float MAX_MOVE = 0.05f;

	private const float MAX_MOVE_SQR = 0.0025000002f;

	protected void Awake()
	{
		ioEntity = GetComponent<IOEntity>();
	}

	protected void OnEnable()
	{
		InvokeRepeating(CheckPosition, Random.Range(0f, 0.25f), 0.25f);
	}

	protected void OnDisable()
	{
		CancelInvoke(CheckPosition);
	}

	private void CheckPosition()
	{
		if (!ioEntity.isClient && Vector3.SqrMagnitude(base.transform.position - prevPos) > 0.0025000002f)
		{
			prevPos = base.transform.position;
			if (ioEntity.HasConnections())
			{
				ioEntity.SendChangedToRoot(forceUpdate: true);
				ioEntity.ClearConnections();
			}
		}
	}
}
