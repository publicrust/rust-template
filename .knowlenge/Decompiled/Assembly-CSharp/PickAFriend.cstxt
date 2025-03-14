using System;
using Rust.UI;

public class PickAFriend : UIDialog
{
	public RustInput rustInput;

	public RustText headerText;

	public bool AutoSelectInputField;

	public bool AllowMultiple;

	public Action<ulong, string> onSelected;

	public Translate.Phrase sleepingBagHeaderPhrase = new Translate.Phrase("assign_to_friend", "Assign To a Friend");

	public Translate.Phrase turretHeaderPhrase = new Translate.Phrase("authorize_a_friend", "Authorize a Friend");

	public SteamFriendsList friendsList;

	public Func<ulong, bool> shouldShowPlayer
	{
		set
		{
			if (friendsList != null)
			{
				friendsList.shouldShowPlayer = value;
			}
		}
	}
}
