using System;
using Facepunch;
using UnityEngine;

[Serializable]
public class TokenisedPhrase : Phrase
{
	public static readonly Phrase LeftMouse = new Phrase("button.mouse.left", "Left Mouse");

	public static readonly Phrase RightMouse = new Phrase("button.mouse.right", "Right Mouse");

	public static readonly Phrase MiddleMouse = new Phrase("button.mouse.middle", "Middle Mouse");

	public override string translated => ReplaceTokens(((Phrase)this).translated);

	public static string ReplaceTokens(string str)
	{
		if (!str.Contains("["))
		{
			return str;
		}
		str = str.Replace("[inventory.toggle]", string.Format("[{0}]", Input.GetButtonWithBind("inventory.toggle", false).ToUpper()));
		str = str.Replace("[inventory.togglecrafting]", string.Format("[{0}]", Input.GetButtonWithBind("inventory.togglecrafting", false).ToUpper()));
		str = str.Replace("[+map]", string.Format("[{0}]", Input.GetButtonWithBind("+map", false).ToUpper()));
		str = str.Replace("[inventory.examineheld]", string.Format("[{0}]", Input.GetButtonWithBind("inventory.examineheld", false).ToUpper()));
		str = str.Replace("[slot2]", string.Format("[{0}]", Input.GetButtonWithBind("+slot2", false).ToUpper()));
		str = str.Replace("[attack]", string.Format("[{0}]", TranslateMouseButton(Input.GetButtonWithBind("+attack", true)).ToUpper()));
		str = str.Replace("[attack2]", string.Format("[{0}]", TranslateMouseButton(Input.GetButtonWithBind("+attack2", false)).ToUpper()));
		str = str.Replace("[attack3]", string.Format("[{0}]", TranslateMouseButton(Input.GetButtonWithBind("+attack3", false)).ToUpper()));
		str = str.Replace("[+use]", string.Format("[{0}]", TranslateMouseButton(Input.GetButtonWithBind("+use", false)).ToUpper()));
		str = str.Replace("[+altlook]", string.Format("[{0}]", TranslateMouseButton(Input.GetButtonWithBind("+altlook", false)).ToUpper()));
		str = str.Replace("[+reload]", string.Format("[{0}]", TranslateMouseButton(Input.GetButtonWithBind("+reload", false)).ToUpper()));
		str = str.Replace("[+voice]", string.Format("[{0}]", TranslateMouseButton(Input.GetButtonWithBind("+voice", false)).ToUpper()));
		str = str.Replace("[+lockBreakHealthPercent]", $"{0.2f:0%}");
		str = str.Replace("[+gestures]", string.Format("[{0}]", TranslateMouseButton(Input.GetButtonWithBind("+gestures", false)).ToUpper()));
		str = str.Replace("[+left]", string.Format("[{0}]", TranslateMouseButton(Input.GetButtonWithBind("+left", false)).ToUpper()));
		str = str.Replace("[+right]", string.Format("[{0}]", TranslateMouseButton(Input.GetButtonWithBind("+right", false)).ToUpper()));
		str = str.Replace("[+backward]", string.Format("[{0}]", TranslateMouseButton(Input.GetButtonWithBind("+backward", false)).ToUpper()));
		str = str.Replace("[+forward]", string.Format("[{0}]", TranslateMouseButton(Input.GetButtonWithBind("+forward", false)).ToUpper()));
		str = str.Replace("[+sprint]", string.Format("[{0}]", Input.GetButtonWithBind("+sprint", false)).ToUpper());
		str = str.Replace("[+duck]", string.Format("[{0}]", Input.GetButtonWithBind("+duck", false)).ToUpper());
		str = str.Replace("[+pets]", string.Format("[{0}]", Input.GetButtonWithBind("+pets", false)).ToUpper());
		str = str.Replace("[lighttoggle]", string.Format("[{0}]", Input.GetButtonWithBind("lighttoggle", false)).ToUpper());
		str = str.Replace("[+ping]", string.Format("[{0}]", Input.GetButtonWithBind("+ping", false)).ToUpper());
		str = str.Replace("[clan.toggleclan]", string.Format("[{0}]", Input.GetButtonWithBind("clan.toggleclan", false)).ToUpper());
		str = str.Replace("[+jump]", string.Format("[{0}]", Input.GetButtonWithBind("+jump", false)).ToUpper());
		str = str.Replace("[movement]", ("[" + TranslateMouseButton(Input.GetButtonWithBind("+forward", false)) + TranslateMouseButton(Input.GetButtonWithBind("+left", false)) + TranslateMouseButton(Input.GetButtonWithBind("+backward", false)) + TranslateMouseButton(Input.GetButtonWithBind("+right", false)) + "]").ToUpper());
		str = str.Replace("[+help]", string.Format("[{0}]", Input.GetButtonWithBind("+opentutorialhelp", false)).ToUpper());
		return str;
	}

	public TokenisedPhrase(string t = "", string eng = "")
		: base(t, eng)
	{
	}

	public static string TranslateMouseButton(string mouseButton)
	{
		return mouseButton switch
		{
			"mouse0" => LeftMouse.translated, 
			"mouse1" => RightMouse.translated, 
			"mouse2" => MiddleMouse.translated, 
			_ => mouseButton, 
		};
	}

	private static string GetButtonWithBind(string s)
	{
		if (!Application.isPlaying)
		{
			switch (s)
			{
			case "inventory.toggle":
				return "tab";
			case "inventory.togglecrafting":
				return "q";
			case "+map":
				return "g";
			case "inventory.examineheld":
				return "n";
			case "+slot2":
				return "2";
			case "+attack":
				return "mouse0";
			case "+attack2":
				return "mouse1";
			case "+use":
				return "e";
			case "+altlook":
				return "leftalt";
			case "+reload":
				return "r";
			case "+voice":
				return "v";
			}
		}
		return Input.GetButtonWithBind(s, false);
	}
}
