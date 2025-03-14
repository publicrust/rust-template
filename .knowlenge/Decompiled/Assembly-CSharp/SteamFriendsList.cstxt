using System;
using UnityEngine;
using UnityEngine.Events;

public class SteamFriendsList : MonoBehaviour
{
	[Serializable]
	public class onFriendSelectedEvent : UnityEvent<ulong>
	{
	}

	public RectTransform targetPanel;

	public SteamUserButton userButton;

	public bool IncludeFriendsList = true;

	public bool IncludeRecentlySeen;

	public bool IncludeLastAttacker;

	public bool IncludeRecentlyPlayedWith;

	public onFriendSelectedEvent onFriendSelected;
}
