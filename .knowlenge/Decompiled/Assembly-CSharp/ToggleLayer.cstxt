using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleLayer : MonoBehaviour, IClientComponent
{
	public Toggle toggleControl;

	public TextMeshProUGUI textControl;

	public LayerSelect layer;

	protected void OnEnable()
	{
		if ((bool)MainCamera.mainCamera)
		{
			toggleControl.isOn = (MainCamera.mainCamera.cullingMask & layer.Mask) != 0;
		}
	}

	public void OnToggleChanged()
	{
		if ((bool)MainCamera.mainCamera)
		{
			if (toggleControl.isOn)
			{
				MainCamera.mainCamera.cullingMask |= layer.Mask;
			}
			else
			{
				MainCamera.mainCamera.cullingMask &= ~layer.Mask;
			}
		}
	}

	protected void OnValidate()
	{
		if ((bool)textControl)
		{
			textControl.text = layer.Name;
		}
	}
}
