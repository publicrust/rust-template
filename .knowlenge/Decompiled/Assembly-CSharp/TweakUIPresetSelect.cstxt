using System;

public class TweakUIPresetSelect : TweakUIDropdown
{
	[Serializable]
	public struct Presets
	{
		public string[] PresetValues;
	}

	public TweakUIBase[] TargetOptions;

	public Presets[] PresetsArray;

	public int CustomIndex;

	private bool blockChange;

	private void Start()
	{
		UpdateCurrentOption();
	}

	protected override void SetConvarValue()
	{
		if (blockChange)
		{
			return;
		}
		int num = int.Parse(nameValues[currentValue].value);
		ShowValue(nameValues[num].value);
		if (num == CustomIndex || num < 0 || num >= PresetsArray.Length)
		{
			return;
		}
		for (int i = 0; i < TargetOptions.Length; i++)
		{
			if (TargetOptions[i].gameObject.activeInHierarchy)
			{
				ConsoleSystem.Run(ConsoleSystem.Option.Client, TargetOptions[i].convarName, PresetsArray[num].PresetValues[i]);
			}
		}
	}

	public void UpdateCurrentOption()
	{
		for (int i = 0; i < PresetsArray.Length; i++)
		{
			if (MatchesOption(PresetsArray[i]))
			{
				blockChange = true;
				ChangeValue(i);
				ShowValue(nameValues[i].value);
				blockChange = false;
				return;
			}
		}
		ChangeValue(CustomIndex);
		ShowValue(nameValues[CustomIndex].value);
	}

	private bool MatchesOption(Presets preset)
	{
		for (int i = 0; i < TargetOptions.Length; i++)
		{
			if (TargetOptions[i].gameObject.activeInHierarchy && TargetOptions[i].GetCurrentValueAsInt() != int.Parse(preset.PresetValues[i]))
			{
				return false;
			}
		}
		return true;
	}
}
