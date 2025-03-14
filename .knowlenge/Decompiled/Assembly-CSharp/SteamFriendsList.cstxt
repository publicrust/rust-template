using System;
using UnityEngine;
using UnityEngine.Events;

public class SteamFriendsList : MonoBehaviour
{
	[Serializable]
	public class onFriendSelectedEvent : UnityEvent<ulong, string>
	{
	}

	public RectTransform targetPanel;

	public SteamUserButton userButton;

	public bool IncludeFriendsList = true;

	public bool IncludeRecentlySeen;

	public bool IncludeLastAttacker;

	public bool IncludeRecentlyPlayedWith;

	public bool ShowTeamFirst;

	public bool HideSteamIdsInStreamerMode;

	public bool RefreshOnEnable = true;

	public onFriendSelectedEvent onFriendSelected;

	public Func<ulong, bool> shouldShowPlayer;
}
