using ConVar;
using UnityEngine;

public class CameraSettings : MonoBehaviour, IClientComponent
{
	private Camera cam;

	private void OnEnable()
	{
		cam = ((Component)this).GetComponent<Camera>();
	}

	private void Update()
	{
		cam.farClipPlane = Mathf.Clamp(Graphics.drawdistance, 500f, 2500f);
	}
}
