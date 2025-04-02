using System.Diagnostics;
using Facepunch;
using Rust;
using TMPro;
using UnityEngine;

public class ErrorText : MonoBehaviour
{
	public TextMeshProUGUI text;

	public int maxLength = 1024;

	private Stopwatch stopwatch;

	public void OnEnable()
	{
		Output.OnMessage += CaptureLog;
	}

	public void OnDisable()
	{
		if (!Application.isQuitting)
		{
			Output.OnMessage -= CaptureLog;
		}
	}

	internal void CaptureLog(string error, string stacktrace, LogType type)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Invalid comparison between Unknown and I4
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if (((int)type == 0 || (int)type == 4 || (int)type == 1) && !((Object)(object)text == (Object)null))
		{
			TextMeshProUGUI val = text;
			((TMP_Text)val).text = ((TMP_Text)val).text + error + "\n" + stacktrace + "\n\n";
			if (((TMP_Text)text).text.Length > maxLength)
			{
				((TMP_Text)text).text = ((TMP_Text)text).text.Substring(((TMP_Text)text).text.Length - maxLength, maxLength);
			}
			stopwatch = Stopwatch.StartNew();
		}
	}

	protected void Update()
	{
		if (stopwatch != null && stopwatch.Elapsed.TotalSeconds > 30.0)
		{
			((TMP_Text)text).text = string.Empty;
			stopwatch = null;
		}
	}
}
