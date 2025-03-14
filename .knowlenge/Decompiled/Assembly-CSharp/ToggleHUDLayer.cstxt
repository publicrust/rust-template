using Facepunch.Extend;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleHUDLayer : MonoBehaviour, IClientComponent
{
	public Toggle toggleControl;

	public TextMeshProUGUI textControl;

	public string hudComponentName;

	protected void OnEnable()
	{
		UIHUD instance = SingletonComponent<UIHUD>.Instance;
		if (!(instance != null))
		{
			return;
		}
		Transform transform = instance.transform.FindChildRecursive(hudComponentName);
		if (transform != null)
		{
			Canvas component = transform.GetComponent<Canvas>();
			if (component != null)
			{
				toggleControl.isOn = component.enabled;
			}
			else
			{
				toggleControl.isOn = transform.gameObject.activeSelf;
			}
		}
		else
		{
			Debug.LogWarning(GetType().Name + ": Couldn't find child: " + hudComponentName);
		}
	}

	public void OnToggleChanged()
	{
		ConsoleSystem.Run(ConsoleSystem.Option.Client, "global.hudcomponent", hudComponentName, toggleControl.isOn);
	}
}
