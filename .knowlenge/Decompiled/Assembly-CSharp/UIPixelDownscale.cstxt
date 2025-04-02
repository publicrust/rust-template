using UnityEngine;
using UnityEngine.UI;

public class UIPixelDownscale : MonoBehaviour
{
	public CanvasScaler CanvasScaler;

	private void Awake()
	{
		if (CanvasScaler == null)
		{
			CanvasScaler = GetComponent<CanvasScaler>();
			if (CanvasScaler == null)
			{
				Debug.LogError(GetType().Name + " is attached to a gameobject that is missing a canvas scaler");
				Object.Destroy(base.gameObject);
			}
		}
	}

	private void Update()
	{
		if ((float)Screen.width < CanvasScaler.referenceResolution.x || (float)Screen.height < CanvasScaler.referenceResolution.y)
		{
			CanvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
		}
		else
		{
			CanvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		}
	}
}
