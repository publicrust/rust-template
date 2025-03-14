using UnityEngine;

public static class KeyCodeEx
{
	public static string ToShortname(this KeyCode code, bool lowercase = true)
	{
		string text = code.ToString();
		if (text.StartsWith("Alpha"))
		{
			text = text.Replace("Alpha", "");
		}
		if (!lowercase)
		{
			return text;
		}
		return text.ToLower();
	}
}
