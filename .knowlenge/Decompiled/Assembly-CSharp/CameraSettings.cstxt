using ConVar;
using UnityEngine;

public class CameraSettings : MonoBehaviour, IClientComponent
{
	private Camera cam;

	private void OnEnable()
	{
		cam = GetComponent<Camera>();
	}

	private void Update()
	{
		cam.farClipPlane = Mathf.Clamp(ConVar.Graphics.drawdistance, 500f, 2500f);
	}
}
