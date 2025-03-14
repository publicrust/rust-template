using UnityEngine;

public class CursorManager : SingletonComponent<CursorManager>
{
	private static int iHoldOpen;

	private static int iPreviousOpen;

	private void Update()
	{
		if (!(SingletonComponent<CursorManager>.Instance != this))
		{
			if (iHoldOpen == 0 && iPreviousOpen == 0)
			{
				SwitchToGame();
			}
			else
			{
				SwitchToUI();
			}
			iPreviousOpen = iHoldOpen;
			iHoldOpen = 0;
		}
	}

	private void SwitchToGame()
	{
		if (Cursor.lockState != CursorLockMode.Locked)
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
		if (Cursor.visible)
		{
			Cursor.visible = false;
		}
	}

	private void SwitchToUI()
	{
		if (Cursor.lockState != 0)
		{
			Cursor.lockState = CursorLockMode.None;
		}
		if (!Cursor.visible)
		{
			Cursor.visible = true;
		}
	}

	public static void HoldOpen(bool cursorVisible = false)
	{
		iHoldOpen++;
	}
}
