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
		if (!((Object)(object)instance != (Object)null))
		{
			return;
		}
		Transform val = TransformEx.FindChildRecursive(((Component)instance).transform, hudComponentName);
		if ((Object)(object)val != (Object)null)
		{
			Canvas component = ((Component)val).GetComponent<Canvas>();
			if ((Object)(object)component != (Object)null)
			{
				toggleControl.isOn = ((Behaviour)component).enabled;
			}
			else
			{
				toggleControl.isOn = ((Component)val).gameObject.activeSelf;
			}
		}
		else
		{
			Debug.LogWarning((object)(((object)this).GetType().Name + ": Couldn't find child: " + hudComponentName));
		}
	}

	public void OnToggleChanged()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		ConsoleSystem.Run(Option.Client, "global.hudcomponent", new object[2] { hudComponentName, toggleControl.isOn });
	}
}
