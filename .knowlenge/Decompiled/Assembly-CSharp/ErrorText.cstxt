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
		if (!Rust.Application.isQuitting)
		{
			Output.OnMessage -= CaptureLog;
		}
	}

	internal void CaptureLog(string error, string stacktrace, LogType type)
	{
		if ((type == LogType.Error || type == LogType.Exception || type == LogType.Assert) && !(text == null))
		{
			TextMeshProUGUI textMeshProUGUI = text;
			textMeshProUGUI.text = textMeshProUGUI.text + error + "\n" + stacktrace + "\n\n";
			if (text.text.Length > maxLength)
			{
				text.text = text.text.Substring(text.text.Length - maxLength, maxLength);
			}
			stopwatch = Stopwatch.StartNew();
		}
	}

	protected void Update()
	{
		if (stopwatch != null && stopwatch.Elapsed.TotalSeconds > 30.0)
		{
			text.text = string.Empty;
			stopwatch = null;
		}
	}
}
