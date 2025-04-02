using Rust.UI;
using UnityEngine;

public class UIClanMemberDetails : UIClanMember
{
	public static readonly Translate.Phrase KickConfirmation = new Translate.Phrase("clan.confirmation.kick", "Are you sure you want to kick this player out of your clan?");

	public static readonly Translate.Phrase SaveNotesFailure = new TokenisedPhrase("clan.set_member_notes.fail", "Failed to save your updated player notes.");

	public static readonly Translate.Phrase ChangeRankCannotDemoteLeader = new TokenisedPhrase("clan.change_member_rank.cannot_demote_leader", "As a clan leader, you cannot demote yourself unless you promote another clan member to the leader role.");

	public static readonly Translate.Phrase ChangeRankFailure = new TokenisedPhrase("clan.change_member_rank.fail", "Failed to change the rank of the player.");

	public static readonly Translate.Phrase KickFailure = new TokenisedPhrase("clan.kick_member.fail", "Failed to kick the player out of the clan.");

	public UIClans UiClans;

	public RustInput NoteEditor;

	public RustButton SaveNoteButton;

	public GameObject ChangeRankSection;

	public Dropdown ChangeRankDropdown;

	public GameObject KickSection;

	public RustButton KickButton;
}
