using System;
using System.IO;
using System.Linq;
using UnityEngine;

public class ChildrenScreenshot : MonoBehaviour
{
	public Vector3 offsetAngle = new Vector3(0f, 0f, 1f);

	public int width = 512;

	public int height = 512;

	public float fieldOfView = 70f;

	[Tooltip("0 = full recursive name, 1 = object name")]
	public string folder = "screenshots/{0}.png";

	[ContextMenu("Create Screenshots")]
	public void CreateScreenshots()
	{
		RenderTexture renderTexture = new RenderTexture(width, height, 0);
		GameObject gameObject = new GameObject();
		Camera camera = gameObject.AddComponent<Camera>();
		camera.targetTexture = renderTexture;
		camera.orthographic = false;
		camera.fieldOfView = fieldOfView;
		camera.nearClipPlane = 0.1f;
		camera.farClipPlane = 2000f;
		camera.cullingMask = LayerMask.GetMask("TransparentFX");
		camera.clearFlags = CameraClearFlags.Color;
		camera.backgroundColor = new Color(0f, 0f, 0f, 0f);
		camera.renderingPath = RenderingPath.DeferredShading;
		Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, mipChain: false);
		foreach (Transform item in base.transform.Cast<Transform>())
		{
			PositionCamera(camera, item.gameObject);
			int layer = item.gameObject.layer;
			TransformEx.SetLayerRecursive(item.gameObject, 1);
			camera.Render();
			TransformEx.SetLayerRecursive(item.gameObject, layer);
			string recursiveName = TransformEx.GetRecursiveName(item);
			recursiveName = recursiveName.Replace('/', '.');
			RenderTexture.active = renderTexture;
			texture2D.ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), 0, 0, recalculateMipMaps: false);
			RenderTexture.active = null;
			byte[] bytes = texture2D.EncodeToPNG();
			string path = string.Format(folder, recursiveName, item.name);
			string directoryName = Path.GetDirectoryName(path);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			File.WriteAllBytes(path, bytes);
		}
		UnityEngine.Object.DestroyImmediate(texture2D, allowDestroyingAssets: true);
		UnityEngine.Object.DestroyImmediate(renderTexture, allowDestroyingAssets: true);
		UnityEngine.Object.DestroyImmediate(gameObject, allowDestroyingAssets: true);
	}

	public void PositionCamera(Camera cam, GameObject obj)
	{
		Bounds bounds = new Bounds(obj.transform.position, Vector3.zero * 0.1f);
		bool flag = true;
		Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in componentsInChildren)
		{
			if (flag)
			{
				bounds = renderer.bounds;
				flag = false;
			}
			else
			{
				bounds.Encapsulate(renderer.bounds);
			}
		}
		float num = bounds.size.magnitude * 0.5f / Mathf.Tan(cam.fieldOfView * 0.5f * (MathF.PI / 180f));
		cam.transform.position = bounds.center + obj.transform.TransformVector(offsetAngle.normalized) * num;
		cam.transform.LookAt(bounds.center);
	}
}
