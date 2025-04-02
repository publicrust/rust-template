using Rust.UI;
using UnityEngine;

public class ChangelogButton : MonoBehaviour
{
	public RustButton Button;

	public CanvasGroup CanvasGroup;

	private void Update()
	{
		BaseGameMode activeGameMode = BaseGameMode.GetActiveGameMode(serverside: false);
		if (activeGameMode != null)
		{
			if (CanvasGroup.alpha != 1f)
			{
				CanvasGroup.alpha = 1f;
				CanvasGroup.blocksRaycasts = true;
				Button.Text.SetPhrase(new Translate.Phrase(activeGameMode.shortname, activeGameMode.shortname));
			}
		}
		else if (CanvasGroup.alpha != 0f)
		{
			CanvasGroup.alpha = 0f;
			CanvasGroup.blocksRaycasts = false;
		}
	}
}
