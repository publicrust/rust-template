using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class UIClans : SingletonComponent<UIClans>
{
	public static readonly Phrase LeaveConfirmation = new Phrase("clan.confirmation.leave", "Are you sure you want to leave your clan?");

	public static readonly Phrase GetInvitationsFailure = (Phrase)(object)new TokenisedPhrase("clan.get_invitations.fail", "Failed to load your clan invitations from the server.");

	public static readonly Phrase GetClanFailure = (Phrase)(object)new TokenisedPhrase("clan.get_clan.fail", "Failed to load your clan from the server.");

	public static readonly Phrase LeaveFailure = (Phrase)(object)new TokenisedPhrase("clan.leave.fail", "Failed to leave your clan.");

	public static readonly Phrase LeaveNoOtherLeader = (Phrase)(object)new TokenisedPhrase("clan.leave.no_other_leader", "As a clan leader, you cannot leave your clan unless it is empty or you promote another member to the leader role.");

	public CanvasGroup CanvasGroup;

	public UIEscapeCapture EscapeCapture;

	public NeedsCursor NeedsCursor;

	public NeedsKeyboard NeedsKeyboard;

	public GameObject ClanTableRequired;

	[Header("States")]
	public GameObject EmptyState;

	public GameObject CreateState;

	public GameObject InvitesState;

	public GameObject MainState;

	[Header("General")]
	public RustText ClanName;

	public Image ClanBanner;

	public RawImage ClanLogo;

	public RustText ClanMembers;

	public RustText ClanScore;

	public RustButton LeaveButton;

	public Texture2D DefaultLogo;

	public RustButton OverviewButton;

	public RustButton ScoreEventsButton;

	public RustButton LogsButton;

	public RustButton SettingsButton;

	public RustButton CreatePrompt;

	public CanvasGroup LoadingIndicator;

	public UIClanLeaderboard Leaderboard;

	public UIClanConfirmation Confirmation;

	public UIClanConfirmation Error;

	[Header("Tabs")]
	public UIClanInvitations Invitations;

	public UIClanOverview Overview;

	public UIClanMembers Members;

	public UIClanInvites Invites;

	public UIClanRanks Ranks;

	public UIClanScoreEvents ScoreEvents;

	public UIClanLog Logs;

	public UIClanSettings Settings;
}
