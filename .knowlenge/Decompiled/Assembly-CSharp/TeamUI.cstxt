using System;
using Rust.UI;
using UnityEngine;

public class TeamUI : MonoBehaviour
{
	public static Translate.Phrase invitePhrase = new Translate.Phrase("team.invited", "{0} has invited you to join a team");

	public RectTransform MemberPanel;

	public GameObject memberEntryPrefab;

	public TeamMemberElement[] elements;

	public GameObject NoTeamPanel;

	public GameObject TeamPanel;

	public GameObject LeaveTeamButton;

	public GameObject InviteAcceptPanel;

	public RustText inviteText;

	public static bool dirty = true;

	[NonSerialized]
	public static ulong pendingTeamID;

	[NonSerialized]
	public static string pendingTeamLeaderName;

	public GameObject teamMemberDetailsPanel;

	public RustText selectedTeamMemberNameText;
}
