using Rust.UI;
using UnityEngine;

public class UIClanSettings : BaseMonoBehaviour
{
	public static readonly Phrase SetLogoFailure = (Phrase)(object)new TokenisedPhrase("clan.set_logo.fail", "Failed to update the clan logo.");

	public static readonly Phrase SetColorFailure = (Phrase)(object)new TokenisedPhrase("clan.set_color.fail", "Failed to update the clan banner color.");

	public UIClans UiClans;

	[Header("Logo Editing")]
	public RustButton EditLogoButton;

	public GameObjectRef ChangeSignDialog;

	public MeshPaintableSource[] PaintableSources;

	[Header("Banner Colors")]
	public RectTransform ColorsContainer;
}
