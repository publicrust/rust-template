using UnityEngine;
using UnityEngine.UI;

public class UIPixelDownscale : MonoBehaviour
{
	public CanvasScaler CanvasScaler;

	private void Awake()
	{
		if ((Object)(object)CanvasScaler == (Object)null)
		{
			CanvasScaler = ((Component)this).GetComponent<CanvasScaler>();
			if ((Object)(object)CanvasScaler == (Object)null)
			{
				Debug.LogError((object)(((object)this).GetType().Name + " is attached to a gameobject that is missing a canvas scaler"));
				Object.Destroy((Object)(object)((Component)this).gameObject);
			}
		}
	}

	private void Update()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if ((float)Screen.width < CanvasScaler.referenceResolution.x || (float)Screen.height < CanvasScaler.referenceResolution.y)
		{
			CanvasScaler.uiScaleMode = (ScaleMode)0;
		}
		else
		{
			CanvasScaler.uiScaleMode = (ScaleMode)1;
		}
	}
}
