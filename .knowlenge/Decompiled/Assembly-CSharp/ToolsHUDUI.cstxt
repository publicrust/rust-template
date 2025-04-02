using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolsHUDUI : MonoBehaviour
{
	[SerializeField]
	private GameObject prefab;

	[SerializeField]
	private Transform parent;

	private bool initialised;

	protected void OnEnable()
	{
		Init();
	}

	private void Init()
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		if (initialised)
		{
			return;
		}
		UIHUD instance = SingletonComponent<UIHUD>.Instance;
		if ((Object)(object)instance == (Object)null)
		{
			return;
		}
		initialised = true;
		Transform[] componentsInChildren = ((Component)instance).GetComponentsInChildren<Transform>();
		foreach (Transform val in componentsInChildren)
		{
			string name = ((Object)val).name;
			if (!name.ToLower().StartsWith("gameui.hud."))
			{
				continue;
			}
			if (name.ToLower() == "gameui.hud.crosshair")
			{
				foreach (Transform item in val)
				{
					Transform val2 = item;
					AddToggleObj(((Object)val2).name, "<color=yellow>Crosshair sub:</color> " + ((Object)val2).name);
				}
			}
			AddToggleObj(name, name.Substring(11));
		}
	}

	private void AddToggleObj(string trName, string labelText)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		GameObject obj = Object.Instantiate<GameObject>(prefab, Vector3.zero, Quaternion.identity, parent);
		((Object)obj).name = trName;
		ToggleHUDLayer component = obj.GetComponent<ToggleHUDLayer>();
		component.hudComponentName = trName;
		((TMP_Text)component.textControl).text = labelText;
	}

	public void SelectAll()
	{
		Toggle[] componentsInChildren = ((Component)parent).GetComponentsInChildren<Toggle>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].isOn = true;
		}
	}

	public void SelectNone()
	{
		Toggle[] componentsInChildren = ((Component)parent).GetComponentsInChildren<Toggle>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].isOn = false;
		}
	}
}
