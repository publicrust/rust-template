using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BaseCommandBuffer : MonoBehaviour
{
	private Dictionary<Camera, Dictionary<int, CommandBuffer>> cameras = new Dictionary<Camera, Dictionary<int, CommandBuffer>>();

	protected CommandBuffer GetCommandBuffer(string name, Camera camera, CameraEvent cameraEvent)
	{
		if (!cameras.TryGetValue(camera, out var value))
		{
			value = new Dictionary<int, CommandBuffer>();
			cameras.Add(camera, value);
		}
		if (value.TryGetValue((int)cameraEvent, out var value2))
		{
			value2.Clear();
		}
		else
		{
			value2 = new CommandBuffer();
			value2.name = name;
			value.Add((int)cameraEvent, value2);
			CleanupCamera(name, camera, cameraEvent);
			camera.AddCommandBuffer(cameraEvent, value2);
		}
		return value2;
	}

	protected void CleanupCamera(string name, Camera camera, CameraEvent cameraEvent)
	{
		CommandBuffer[] commandBuffers = camera.GetCommandBuffers(cameraEvent);
		foreach (CommandBuffer commandBuffer in commandBuffers)
		{
			if (commandBuffer.name == name)
			{
				camera.RemoveCommandBuffer(cameraEvent, commandBuffer);
			}
		}
	}

	protected void CleanupCommandBuffer(Camera camera, CameraEvent cameraEvent)
	{
		if (cameras.TryGetValue(camera, out var value) && value.TryGetValue((int)cameraEvent, out var value2))
		{
			camera.RemoveCommandBuffer(cameraEvent, value2);
		}
	}

	protected void Cleanup()
	{
		foreach (KeyValuePair<Camera, Dictionary<int, CommandBuffer>> camera in cameras)
		{
			Camera key = camera.Key;
			Dictionary<int, CommandBuffer> value = camera.Value;
			if (!key)
			{
				continue;
			}
			foreach (KeyValuePair<int, CommandBuffer> item in value)
			{
				int key2 = item.Key;
				CommandBuffer value2 = item.Value;
				key.RemoveCommandBuffer((CameraEvent)key2, value2);
			}
		}
	}
}
