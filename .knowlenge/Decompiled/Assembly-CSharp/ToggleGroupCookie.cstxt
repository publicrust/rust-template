using System.Linq;
using Rust;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroupCookie : MonoBehaviour
{
	public ToggleGroup group => GetComponent<ToggleGroup>();

	private void OnEnable()
	{
		string @string = PlayerPrefs.GetString("ToggleGroupCookie_" + base.name);
		if (!string.IsNullOrEmpty(@string))
		{
			Transform transform = FindChild(base.transform, @string);
			if ((bool)transform)
			{
				Toggle component = transform.GetComponent<Toggle>();
				if ((bool)component)
				{
					Toggle[] componentsInChildren = GetComponentsInChildren<Toggle>(includeInactive: true);
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						componentsInChildren[i].isOn = false;
					}
					component.isOn = false;
					component.isOn = true;
					SetupListeners();
					return;
				}
			}
		}
		Toggle toggle = group.ActiveToggles().FirstOrDefault((Toggle x) => x.isOn);
		if ((bool)toggle)
		{
			toggle.isOn = false;
			toggle.isOn = true;
		}
		SetupListeners();
	}

	private void OnDisable()
	{
		if (!Rust.Application.isQuitting)
		{
			Toggle[] componentsInChildren = GetComponentsInChildren<Toggle>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].onValueChanged.RemoveListener(OnToggleChanged);
			}
		}
	}

	private void SetupListeners()
	{
		Toggle[] componentsInChildren = GetComponentsInChildren<Toggle>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].onValueChanged.AddListener(OnToggleChanged);
		}
	}

	private void OnToggleChanged(bool b)
	{
		Toggle toggle = GetComponentsInChildren<Toggle>().FirstOrDefault((Toggle x) => x.isOn);
		if ((bool)toggle)
		{
			PlayerPrefs.SetString("ToggleGroupCookie_" + base.name, toggle.gameObject.name);
		}
	}

	private static Transform FindChild(Transform parent, string name)
	{
		foreach (Transform item in parent)
		{
			if (item.name == name)
			{
				return item;
			}
		}
		return null;
	}
}
