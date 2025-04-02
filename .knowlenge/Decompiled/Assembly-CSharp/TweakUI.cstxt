using System;
using UnityEngine;

public class TweakUI : SingletonComponent<TweakUI>
{
	public static bool isOpen;

	private void Update()
	{
		if (Input.GetKeyDown((KeyCode)283) && CanToggle())
		{
			SetVisible(!isOpen);
		}
	}

	protected bool CanToggle()
	{
		if (!LevelManager.isLoaded)
		{
			return false;
		}
		return true;
	}

	public void SetVisible(bool b)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		if (b)
		{
			isOpen = true;
			return;
		}
		isOpen = false;
		ConsoleSystem.Run(Option.Client, "writecfg", Array.Empty<object>());
	}
}
