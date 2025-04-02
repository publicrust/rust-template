using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Time of Day/Camera Main Script")]
public class TOD_Camera : MonoBehaviour
{
	public TOD_Sky sky;

	public bool DomePosToCamera = true;

	public Vector3 DomePosOffset = Vector3.zero;

	public bool DomeScaleToFarClip = true;

	public float DomeScaleFactor = 0.95f;

	private Camera cameraComponent;

	private Transform cameraTransform;

	public bool HDR
	{
		get
		{
			if (!cameraComponent)
			{
				return false;
			}
			return cameraComponent.allowHDR;
		}
	}

	public float NearClipPlane
	{
		get
		{
			if (!cameraComponent)
			{
				return 0.1f;
			}
			return cameraComponent.nearClipPlane;
		}
	}

	public float FarClipPlane
	{
		get
		{
			if (!cameraComponent)
			{
				return 1000f;
			}
			return cameraComponent.farClipPlane;
		}
	}

	public Color BackgroundColor
	{
		get
		{
			if (!cameraComponent)
			{
				return Color.black;
			}
			return cameraComponent.backgroundColor;
		}
	}

	protected void OnValidate()
	{
		DomeScaleFactor = Mathf.Clamp(DomeScaleFactor, 0.01f, 1f);
	}

	protected void OnEnable()
	{
		cameraComponent = GetComponent<Camera>();
		cameraTransform = GetComponent<Transform>();
		if (!sky)
		{
			sky = FindSky(fallback: true);
		}
	}

	protected void Update()
	{
		if (!sky)
		{
			sky = FindSky();
		}
		if ((bool)sky && sky.Initialized)
		{
			sky.Components.Camera = this;
			if (cameraComponent.clearFlags != CameraClearFlags.Color)
			{
				cameraComponent.clearFlags = CameraClearFlags.Color;
			}
			if (cameraComponent.backgroundColor != Color.clear)
			{
				cameraComponent.backgroundColor = Color.clear;
			}
			if (RenderSettings.skybox != sky.Resources.Skybox)
			{
				RenderSettings.skybox = sky.Resources.Skybox;
				DynamicGI.UpdateEnvironment();
			}
		}
	}

	protected void OnPreCull()
	{
		if (!sky)
		{
			sky = FindSky();
		}
		if ((bool)sky && sky.Initialized)
		{
			if (DomeScaleToFarClip)
			{
				DoDomeScaleToFarClip();
			}
			if (DomePosToCamera)
			{
				DoDomePosToCamera();
			}
		}
	}

	private TOD_Sky FindSky(bool fallback = false)
	{
		if ((bool)TOD_Sky.Instance)
		{
			return TOD_Sky.Instance;
		}
		if (fallback)
		{
			return Object.FindObjectOfType(typeof(TOD_Sky)) as TOD_Sky;
		}
		return null;
	}

	public void DoDomeScaleToFarClip()
	{
		float num = DomeScaleFactor * cameraComponent.farClipPlane;
		Vector3 localScale = new Vector3(num, num, num);
		sky.Components.DomeTransform.localScale = localScale;
	}

	public void DoDomePosToCamera()
	{
		Vector3 position = cameraTransform.position + cameraTransform.rotation * DomePosOffset;
		sky.Components.DomeTransform.position = position;
	}
}
