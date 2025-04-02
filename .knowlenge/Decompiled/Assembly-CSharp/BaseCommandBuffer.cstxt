using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BaseCommandBuffer : MonoBehaviour
{
	private Dictionary<Camera, Dictionary<int, CommandBuffer>> cameras = new Dictionary<Camera, Dictionary<int, CommandBuffer>>();

	protected CommandBuffer GetCommandBuffer(string name, Camera camera, CameraEvent cameraEvent)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected I4, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected I4, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		CommandBuffer[] commandBuffers = camera.GetCommandBuffers(cameraEvent);
		foreach (CommandBuffer val in commandBuffers)
		{
			if (val.name == name)
			{
				camera.RemoveCommandBuffer(cameraEvent, val);
			}
		}
	}

	protected void CleanupCommandBuffer(Camera camera, CameraEvent cameraEvent)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected I4, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
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
			if (!Object.op_Implicit((Object)(object)key))
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
