using UnityEngine.UI;

public class TweakUIToggle : TweakUIBase
{
	public Toggle toggleControl;

	public bool inverse;

	public static string lastConVarChanged;

	public static TimeSince timeSinceLastConVarChange;

	protected override void Init()
	{
		base.Init();
		ResetToConvar();
	}

	protected void OnEnable()
	{
		ResetToConvar();
	}

	public void OnToggleChanged()
	{
		if (ApplyImmediatelyOnChange)
		{
			SetConvarValue();
		}
	}

	protected override void SetConvarValue()
	{
		base.SetConvarValue();
		if (conVar != null)
		{
			bool flag = toggleControl.isOn;
			if (inverse)
			{
				flag = !flag;
			}
			if (conVar.AsBool != flag)
			{
				lastConVarChanged = conVar.FullName;
				timeSinceLastConVarChange = 0f;
				conVar.Set(flag);
			}
		}
	}

	public override void ResetToConvar()
	{
		base.ResetToConvar();
		if (conVar != null)
		{
			bool flag = conVar.AsBool;
			if (inverse)
			{
				flag = !flag;
			}
			toggleControl.isOn = flag;
		}
	}
}
