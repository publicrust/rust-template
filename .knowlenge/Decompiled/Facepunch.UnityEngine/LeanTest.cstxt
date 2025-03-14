using UnityEngine;

public class LeanTest
{
	public static int expected;

	private static int tests;

	private static int passes;

	public static float timeout = 15f;

	public static bool timeoutStarted;

	public static bool testsFinished;

	public static void debug(string name, bool didPass, string failExplaination = null)
	{
		expect(didPass, name, failExplaination);
	}

	public static void expect(bool didPass, string definition, string failExplaination = null)
	{
		float num = printOutLength(definition);
		int totalWidth = 40 - (int)(num * 1.05f);
		string text = string.Empty.PadRight(totalWidth, "_"[0]);
		string text2 = formatB(definition) + " " + text + " [ " + ((!didPass) ? formatC("fail", "red") : formatC("pass", "green")) + " ]";
		if (!didPass && failExplaination != null)
		{
			text2 = text2 + " - " + failExplaination;
		}
		Debug.Log(text2);
		if (didPass)
		{
			passes++;
		}
		tests++;
		if (tests == expected && !testsFinished)
		{
			overview();
		}
		else if (tests > expected)
		{
			Debug.Log(formatB("Too many tests for a final report!") + " set LeanTest.expected = " + tests);
		}
		if (!timeoutStarted)
		{
			timeoutStarted = true;
			GameObject gameObject = new GameObject();
			gameObject.name = "~LeanTest";
			LeanTester leanTester = gameObject.AddComponent(typeof(LeanTester)) as LeanTester;
			leanTester.timeout = timeout;
			gameObject.hideFlags = HideFlags.HideAndDontSave;
		}
	}

	public static string padRight(int len)
	{
		string text = string.Empty;
		for (int i = 0; i < len; i++)
		{
			text += "_";
		}
		return text;
	}

	public static float printOutLength(string str)
	{
		float num = 0f;
		for (int i = 0; i < str.Length; i++)
		{
			num = ((str[i] != "I"[0]) ? ((str[i] != "J"[0]) ? (num + 1f) : (num + 0.85f)) : (num + 0.5f));
		}
		return num;
	}

	public static string formatBC(string str, string color)
	{
		return formatC(formatB(str), color);
	}

	public static string formatB(string str)
	{
		return "<b>" + str + "</b>";
	}

	public static string formatC(string str, string color)
	{
		return "<color=" + color + ">" + str + "</color>";
	}

	public static void overview()
	{
		testsFinished = true;
		int num = expected - passes;
		string text = ((num <= 0) ? (string.Empty + num) : formatBC(string.Empty + num, "red"));
		Debug.Log(formatB("Final Report:") + " _____________________ PASSED: " + formatBC(string.Empty + passes, "green") + " FAILED: " + text + " ");
	}
}
