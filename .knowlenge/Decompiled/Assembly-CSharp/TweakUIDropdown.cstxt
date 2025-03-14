using System;
using System.Collections.Generic;
using Facepunch;
using Rust.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TweakUIDropdown : TweakUIBase
{
	[Serializable]
	public class NameValue
	{
		public string value;

		public Color imageColor;

		public Translate.Phrase label;
	}

	public RustText Current;

	public Image BackgroundImage;

	public RustButton Opener;

	public RectTransform Dropdown;

	public RectTransform DropdownContainer;

	public GameObject DropdownItemPrefab;

	public NameValue[] nameValues;

	public bool assignImageColor;

	public UnityEvent onValueChanged = new UnityEvent();

	public int currentValue;

	protected override void Init()
	{
		base.Init();
		DropdownItemPrefab.SetActive(value: false);
		UpdateDropdownOptions();
		Opener.SetToggleFalse();
		ResetToConvar();
	}

	protected void OnEnable()
	{
		ResetToConvar();
	}

	public void UpdateDropdownOptions()
	{
		List<RustButton> obj = Pool.GetList<RustButton>();
		DropdownContainer.GetComponentsInChildren(includeInactive: false, obj);
		foreach (RustButton item in obj)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		Pool.FreeList(ref obj);
		for (int i = 0; i < nameValues.Length; i++)
		{
			GameObject obj2 = UnityEngine.Object.Instantiate(DropdownItemPrefab, DropdownContainer);
			int itemIndex = i;
			RustButton component = obj2.GetComponent<RustButton>();
			component.Text.SetPhrase(nameValues[i].label);
			component.OnPressed.AddListener(delegate
			{
				ChangeValue(itemIndex);
			});
			obj2.SetActive(value: true);
		}
	}

	public void OnValueChanged()
	{
		if (ApplyImmediatelyOnChange)
		{
			SetConvarValue();
		}
	}

	public void OnDropdownOpen()
	{
		RectTransform rectTransform = (RectTransform)base.transform;
		if (rectTransform.position.y <= (float)Screen.height / 2f)
		{
			Dropdown.pivot = new Vector2(0.5f, 0f);
			Dropdown.anchoredPosition = Dropdown.anchoredPosition.WithY(0f);
		}
		else
		{
			Dropdown.pivot = new Vector2(0.5f, 1f);
			Dropdown.anchoredPosition = Dropdown.anchoredPosition.WithY(0f - rectTransform.rect.height);
		}
	}

	public void ChangeValue(int index)
	{
		Opener.SetToggleFalse();
		int num = Mathf.Clamp(index, 0, nameValues.Length - 1);
		bool num2 = num != currentValue;
		currentValue = num;
		if (ApplyImmediatelyOnChange)
		{
			SetConvarValue();
		}
		else
		{
			ShowValue(nameValues[currentValue].value);
		}
		if (num2)
		{
			onValueChanged?.Invoke();
		}
	}

	protected override void SetConvarValue()
	{
		base.SetConvarValue();
		NameValue nameValue = nameValues[currentValue];
		if (conVar != null && !(conVar.String == nameValue.value))
		{
			conVar.Set(nameValue.value);
		}
	}

	public override void ResetToConvar()
	{
		base.ResetToConvar();
		if (conVar != null)
		{
			string @string = conVar.String;
			ShowValue(@string);
		}
	}

	private void ShowValue(string value)
	{
		for (int i = 0; i < nameValues.Length; i++)
		{
			if (!(nameValues[i].value != value))
			{
				Current.SetPhrase(nameValues[i].label);
				currentValue = i;
				if (assignImageColor)
				{
					BackgroundImage.color = nameValues[i].imageColor;
				}
				break;
			}
		}
	}
}
