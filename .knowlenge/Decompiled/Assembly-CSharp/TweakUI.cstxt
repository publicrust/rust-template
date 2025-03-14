using UnityEngine;

public class TweakUI : SingletonComponent<TweakUI>
{
	public static bool isOpen;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F2) && CanToggle())
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
		if (b)
		{
			isOpen = true;
			return;
		}
		isOpen = false;
		ConsoleSystem.Run(ConsoleSystem.Option.Client, "writecfg");
	}
}
