using Rust.UI;
using UnityEngine.UI;

public class UIClanRank : BaseMonoBehaviour
{
	public static readonly Translate.Phrase MoveUpFailure = new TokenisedPhrase("clan.move_rank_up.fail", "Failed to move the rank up.");

	public static readonly Translate.Phrase MoveDownFailure = new TokenisedPhrase("clan.move_rank_down.fail", "Failed to move the rank down.");

	public static readonly Translate.Phrase DeleteRankFailure = new TokenisedPhrase("clan.delete_rank.fail", "Failed to delete the rank.");

	public static readonly Translate.Phrase DeleteRankNotEmpty = new Translate.Phrase("clan.delete_rank.not_empty", "Some clan members are still be assigned this rank. You will need to assign them to a different rank before you can delete this one.");

	private static readonly Memoized<string, int> IndexToString = new Memoized<string, int>((int i) => (i + 1).ToString("G"));

	public Image Highlight;

	public RustText IndexLabel;

	public RustText Name;

	public RustButton MoveUpButton;

	public RustButton MoveDownButton;

	public RustButton DeleteButton;
}
