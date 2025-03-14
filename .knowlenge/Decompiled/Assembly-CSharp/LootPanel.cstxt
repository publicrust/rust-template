using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class LootPanel : MonoBehaviour
{
	public interface IHasLootPanel
	{
		Translate.Phrase LootPanelTitle { get; }
	}

	public Text Title;

	public RustText TitleText;

	public bool hideInvalidIcons;

	[Tooltip("Only needed if hideInvalidIcons is true")]
	public CanvasGroup canvasGroup;
}
