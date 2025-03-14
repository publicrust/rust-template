using System;
using Facepunch;
using UnityEngine;

[Serializable]
public class TokenisedPhrase : Translate.Phrase
{
	public static readonly Translate.Phrase LeftMouse = new Translate.Phrase("button.mouse.left", "Left Mouse");

	public static readonly Translate.Phrase RightMouse = new Translate.Phrase("button.mouse.right", "Right Mouse");

	public static readonly Translate.Phrase MiddleMouse = new Translate.Phrase("button.mouse.middle", "Middle Mouse");

	public override string translated => ReplaceTokens(base.translated);

	public static string ReplaceTokens(string str)
	{
		if (!str.Contains("["))
		{
			return str;
		}
		str = str.Replace("[inventory.toggle]", string.Format("[{0}]", Facepunch.Input.GetButtonWithBind("inventory.toggle").ToUpper()));
		str = str.Replace("[inventory.togglecrafting]", string.Format("[{0}]", Facepunch.Input.GetButtonWithBind("inventory.togglecrafting").ToUpper()));
		str = str.Replace("[+map]", string.Format("[{0}]", Facepunch.Input.GetButtonWithBind("+map").ToUpper()));
		str = str.Replace("[inventory.examineheld]", string.Format("[{0}]", Facepunch.Input.GetButtonWithBind("inventory.examineheld").ToUpper()));
		str = str.Replace("[slot2]", string.Format("[{0}]", Facepunch.Input.GetButtonWithBind("+slot2").ToUpper()));
		str = str.Replace("[attack]", string.Format("[{0}]", TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+attack", strict: true)).ToUpper()));
		str = str.Replace("[attack2]", string.Format("[{0}]", TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+attack2")).ToUpper()));
		str = str.Replace("[attack3]", string.Format("[{0}]", TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+attack3")).ToUpper()));
		str = str.Replace("[+use]", string.Format("[{0}]", TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+use")).ToUpper()));
		str = str.Replace("[+altlook]", string.Format("[{0}]", TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+altlook")).ToUpper()));
		str = str.Replace("[+reload]", string.Format("[{0}]", TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+reload")).ToUpper()));
		str = str.Replace("[+voice]", string.Format("[{0}]", TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+voice")).ToUpper()));
		str = str.Replace("[+lockBreakHealthPercent]", $"{0.2f:0%}");
		str = str.Replace("[+gestures]", string.Format("[{0}]", TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+gestures")).ToUpper()));
		str = str.Replace("[+left]", string.Format("[{0}]", TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+left")).ToUpper()));
		str = str.Replace("[+right]", string.Format("[{0}]", TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+right")).ToUpper()));
		str = str.Replace("[+backward]", string.Format("[{0}]", TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+backward")).ToUpper()));
		str = str.Replace("[+forward]", string.Format("[{0}]", TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+forward")).ToUpper()));
		str = str.Replace("[+sprint]", string.Format("[{0}]", Facepunch.Input.GetButtonWithBind("+sprint")).ToUpper());
		str = str.Replace("[+duck]", string.Format("[{0}]", Facepunch.Input.GetButtonWithBind("+duck")).ToUpper());
		str = str.Replace("[+pets]", string.Format("[{0}]", Facepunch.Input.GetButtonWithBind("+pets")).ToUpper());
		str = str.Replace("[lighttoggle]", string.Format("[{0}]", Facepunch.Input.GetButtonWithBind("lighttoggle")).ToUpper());
		str = str.Replace("[+ping]", string.Format("[{0}]", Facepunch.Input.GetButtonWithBind("+ping")).ToUpper());
		str = str.Replace("[clan.toggleclan]", string.Format("[{0}]", Facepunch.Input.GetButtonWithBind("clan.toggleclan")).ToUpper());
		str = str.Replace("[+jump]", string.Format("[{0}]", Facepunch.Input.GetButtonWithBind("+jump")).ToUpper());
		str = str.Replace("[movement]", ("[" + TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+forward")) + TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+left")) + TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+backward")) + TranslateMouseButton(Facepunch.Input.GetButtonWithBind("+right")) + "]").ToUpper());
		str = str.Replace("[+help]", string.Format("[{0}]", Facepunch.Input.GetButtonWithBind("+opentutorialhelp")).ToUpper());
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
		if (!UnityEngine.Application.isPlaying)
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
		return Facepunch.Input.GetButtonWithBind(s);
	}
}
