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
		if (Object.op_Implicit((Object)(object)MainCamera.mainCamera))
		{
			toggleControl.isOn = (MainCamera.mainCamera.cullingMask & layer.Mask) != 0;
		}
	}

	public void OnToggleChanged()
	{
		if (Object.op_Implicit((Object)(object)MainCamera.mainCamera))
		{
			if (toggleControl.isOn)
			{
				Camera mainCamera = MainCamera.mainCamera;
				mainCamera.cullingMask |= layer.Mask;
			}
			else
			{
				Camera mainCamera2 = MainCamera.mainCamera;
				mainCamera2.cullingMask &= ~layer.Mask;
			}
		}
	}

	protected void OnValidate()
	{
		if (Object.op_Implicit((Object)(object)textControl))
		{
			((TMP_Text)textControl).text = layer.Name;
		}
	}
}
