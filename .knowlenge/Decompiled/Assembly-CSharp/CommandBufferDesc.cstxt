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
		CameraEvent = cameraEvent;
		OrderId = orderId;
		FillDelegate = fill.Invoke;
	}
}
