using System;
using TMPro;
using UnityEngine;
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

	public Button Left;

	public Button Right;

	public TextMeshProUGUI Current;

	public Image BackgroundImage;

	public NameValue[] nameValues;

	public bool assignImageColor;

	public int currentValue;

	protected override void Init()
	{
		base.Init();
		ResetToConvar();
	}

	protected void OnEnable()
	{
		ResetToConvar();
	}

	public void OnValueChanged()
	{
		if (ApplyImmediatelyOnChange)
		{
			SetConvarValue();
		}
	}

	public void ChangeValue(int change)
	{
		currentValue += change;
		if (currentValue < 0)
		{
			currentValue = 0;
		}
		if (currentValue > nameValues.Length - 1)
		{
			currentValue = nameValues.Length - 1;
		}
		Left.interactable = currentValue > 0;
		Right.interactable = currentValue < nameValues.Length - 1;
		if (ApplyImmediatelyOnChange)
		{
			SetConvarValue();
		}
		else
		{
			ShowValue(nameValues[currentValue].value);
		}
	}

	protected override void SetConvarValue()
	{
		base.SetConvarValue();
		NameValue nameValue = nameValues[currentValue];
		if (conVar != null && !(conVar.String == nameValue.value))
		{
			conVar.Set(nameValue.value);
			ResetToConvar();
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
				Current.text = nameValues[i].label.translated;
				currentValue = i;
				if (assignImageColor)
				{
					BackgroundImage.color = nameValues[i].imageColor;
				}
			}
		}
	}
}
