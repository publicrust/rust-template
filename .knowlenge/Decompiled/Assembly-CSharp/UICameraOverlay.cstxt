using Rust.UI;
using UnityEngine;

public class UICameraOverlay : SingletonComponent<UICameraOverlay>
{
	public static readonly Translate.Phrase FocusOffText = new Translate.Phrase("camera.infinite_focus", "Infinite Focus");

	public static readonly Translate.Phrase FocusAutoText = new Translate.Phrase("camera.auto_focus", "Auto Focus");

	public static readonly Translate.Phrase FocusManualText = new Translate.Phrase("camera.manual_focus", "Manual Focus");

	public CanvasGroup CanvasGroup;

	public RustText FocusModeLabel;

	public void Show()
	{
		CanvasGroup.alpha = 1f;
	}

	public void Hide()
	{
		CanvasGroup.alpha = 0f;
	}

	public void SetFocusMode(CameraFocusMode mode)
	{
		switch (mode)
		{
		case CameraFocusMode.Auto:
			FocusModeLabel.SetPhrase(FocusAutoText);
			break;
		case CameraFocusMode.Manual:
			FocusModeLabel.SetPhrase(FocusManualText);
			break;
		default:
			FocusModeLabel.SetPhrase(FocusOffText);
			break;
		}
	}
}
