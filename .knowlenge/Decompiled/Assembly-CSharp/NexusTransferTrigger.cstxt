using System.Collections.Generic;
using UnityEngine;

public class NexusTransferTrigger : BaseMonoBehaviour, IServerComponent
{
	[Tooltip("Must implement INexusTransferTriggerController!")]
	public MonoBehaviour Controller;

	private static readonly HashSet<BaseEntity> PendingEntities = new HashSet<BaseEntity>();

	private INexusTransferTriggerController _controller;

	protected void Start()
	{
		_controller = Controller as INexusTransferTriggerController;
		if (_controller == null)
		{
			Debug.LogError("NexusTransferTrigger doesn't have a valid controller assigned!", this);
		}
	}

	protected void OnTriggerEnter(Collider other)
	{
		if (_controller == null)
		{
			return;
		}
		var (zoneKey, method) = _controller.GetTransferDestination();
		if (string.IsNullOrEmpty(zoneKey))
		{
			return;
		}
		BaseEntity entity = GameObjectEx.ToBaseEntity(other.gameObject);
		if (!(entity == null))
		{
			BaseEntity baseEntity = NexusServer.FindRootEntity(entity, includeFerry: true);
			if (_controller.CanTransfer(baseEntity) && PendingEntities.Add(baseEntity))
			{
				TransferAndWait();
			}
		}
		async void TransferAndWait()
		{
			try
			{
				await NexusServer.TransferEntity(entity, zoneKey, method);
			}
			finally
			{
				PendingEntities.Remove(entity);
			}
		}
	}
}
