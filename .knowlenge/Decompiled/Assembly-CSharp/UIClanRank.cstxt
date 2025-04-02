using System;
using Rust.UI;
using UnityEngine.UI;

public class UIClanRank : BaseMonoBehaviour
{
	public static readonly Phrase MoveUpFailure = (Phrase)(object)new TokenisedPhrase("clan.move_rank_up.fail", "Failed to move the rank up.");

	public static readonly Phrase MoveDownFailure = (Phrase)(object)new TokenisedPhrase("clan.move_rank_down.fail", "Failed to move the rank down.");

	public static readonly Phrase DeleteRankFailure = (Phrase)(object)new TokenisedPhrase("clan.delete_rank.fail", "Failed to delete the rank.");

	public static readonly Phrase DeleteRankNotEmpty = new Phrase("clan.delete_rank.not_empty", "Some clan members are still be assigned this rank. You will need to assign them to a different rank before you can delete this one.");

	private static readonly Memoized<string, int> IndexToString = new Memoized<string, int>((Func<int, string>)((int i) => (i + 1).ToString("G")));

	public Image Highlight;

	public RustText IndexLabel;

	public RustText Name;

	public RustButton MoveUpButton;

	public RustButton MoveDownButton;

	public RustButton DeleteButton;
}
