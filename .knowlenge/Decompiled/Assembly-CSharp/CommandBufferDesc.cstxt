using System;
using UnityEngine.Rendering;

public class CommandBufferDesc
{
	public delegate void FillCommandBuffer(CommandBuffer cb);

	public CameraEvent CameraEvent { get; private set; }

	public int OrderId { get; private set; }

	public Action<CommandBuffer> FillDelegate { get; private set; }

	public CommandBufferDesc(CameraEvent cameraEvent, int orderId, FillCommandBuffer fill)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		CameraEvent = cameraEvent;
		OrderId = orderId;
		FillDelegate = fill.Invoke;
	}
}
